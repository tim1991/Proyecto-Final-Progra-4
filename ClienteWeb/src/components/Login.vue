<template>

    <div class="container">
        <form class="login-form" @submit.prevent="login">
            <h2 style="text-align:left; text-transform:uppercase;">Bienvenido</h2>
            <p>Ingrese los datos de su cuenta para ingresar al sistema.</p>
            <div class="form-group">
                <label style="font-weight: bold;font-size: 16px;">Email</label>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text custom-addon" id="basic-addon1"><i class="far fa-user"></i></span>
                    </div>

                    <input type="email" v-model="user.email" class="form-control" placeholder="Ingrese su email" name=""
                        id="email" :class="{ 'is-invalid': submitted && $v.user.email.$error }">
                </div>
            </div>
            <div class="form-group">
                <label style="font-weight: bold;font-size: 16px;">Contraseña</label>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text custom-addon" id="basic-addon1"><i class="fas fa-lock"></i></span>
                    </div>
                    <input type="password" v-model="user.password" class="form-control"
                        placeholder="Ingrese su contraseña" name="" id="password"
                        :class="{ 'is-invalid': submitted && $v.user.password.$error }">
                </div>
            </div>
            <div style="float: left;width: 100%;margin: 8px 0;text-align: right;margin-bottom: 16px;">
                <router-link style="color: grey;" to="/ResetPass" exact> ¿Olvidó su contraseña?</router-link>
            </div>
            <div class="login_actions" style="display:block;">
                <button class="btn btn-gradient" type="submit">Ingresar</button>
            </div>
            <div class="login_head" style="text-align: left;">
                <span class="signup-label">No tienes una cuenta?</span>&nbsp;&nbsp;
                <router-link to="/Registro" exact> Registrarse! </router-link>
            </div>
        </form>
    </div>

</template>
<script>
    import {
        required,
        email,
        minLength,
        sameAs
    } from "vuelidate/lib/validators";
    import {
        misMixins
    } from "../mixins"

    export default {
        data: function () {
            return {
                user: {
                    email: '',
                    password: ''
                },
                submitted: false
            }
        },
        mixins: [misMixins],
        mounted() {

            this.verifyProvider()
        },
        validations: {
            user: {
                email: {
                    required,
                    email
                },
                password: {
                    required,
                    minLength: minLength(6)
                }
            }
        },
        methods: {
            login(e) {
                this.submitted = true;
                // stop here if form is invalid
                this.$v.$touch();
                if (this.$v.$invalid) {
                    return;
                }
                let self = this
                this.$store.commit('loader', true)

                axios.post(this.$baseUrl + 'auth_api/login/', {
                        email: this.encriptar(this.user.email, false),
                        pass: this.encriptar(this.user.password, false)
                    })
                    .then(function (res) {

                        var desencriptar = self.desencriptar(res.data.ciphertext)

                        localStorage.provider = btoa('3747309182101sdhbfu')
                        localStorage.realm = self.encriptar(desencriptar.empresa, false)



                        localStorage.AT = res.data.ciphertext;
                        self.$store.commit('loader', false)

                        if (res.data.empresa != 0 || res.data.activo != 0) {
                            self.$router.push('Dashboard')
                        } else {
                            self.$router.push('Activar')
                        }


                        self.$store.commit('logotipo', res.data.folder + '/' + res.data.logotipo)


                    }).catch(function (err) {
                        console.log(err)
                        self.$notify({
                            group: 'foo',
                            type: 'error',
                            title: 'Error!',
                            text: 'El usuario ingresado no existe, verifique sus datos'
                        });
                        self.$store.commit('loader', false)
                    });

            },

            verifyProvider: function () {
                if (localStorage.provider) {

                    //this.$router.push('Dashboard')

                }

            }
        }

    }
</script>