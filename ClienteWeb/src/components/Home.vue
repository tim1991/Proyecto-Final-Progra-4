<template>
    <div>
        <header class="hero" style="background:linear-gradient(#33691ebd, rgb(2 67 61 / 58%)), url(images/bg2.jpg)">
            <div class="container">

                <nav class="nav">
                    <div class="logo">Tienda en linea</div>
                    <ul>
                        <li><a href="#">Inicio</a></li>
                        <li><a href="#">Productos</a></li>
                        <li>
                            <div class="dropdown show">
  <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    <i class="fas fa-shopping-cart"></i> Carrito ({{itemsCarrito}})
  </a>

  <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
    <a style="color: black;" v-for="(item,key) in carrito" :key="key" class="dropdown-item" href="#"><img class="card-img-top" style="width: 40px;" :src="item.ImagenProducto" alt="Card image cap"> {{item.NombreProducto}} x {{item.Cantidad}}</a>
  </div>
</div>
                        </li>
                    </ul>
                </nav>
                <div class="row">
                    <div class="col-12 col-md-6">
                        <div class="caption">
                            <h1>Bienvenido</h1>
                            <p>Sistemas de compras en linea.</p>
                        </div>

                    </div>
                    <div class="col-12 col-md-6">
                        <form class="login-form" @submit.prevent="login">
                            <h2 style="text-align:left; text-transform:uppercase;">Ingresar</h2>
                            <p>Ingrese los datos de su cuenta para ingresar al sistema.</p>
                            <div class="form-group">
                                <label style="font-weight: bold;font-size: 16px;">Email</label>
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text custom-addon" id="basic-addon1"><i
                                                class="far fa-user"></i></span>
                                    </div>

                                    <input type="email" v-model="user.email" class="form-control"
                                        placeholder="Ingrese su email" name="" id="email"
                                        :class="{ 'is-invalid': submitted && $v.user.email.$error }">
                                </div>
                            </div>
                            <div class="form-group">
                                <label style="font-weight: bold;font-size: 16px;">Contraseña</label>
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text custom-addon" id="basic-addon1"><i
                                                class="fas fa-lock"></i></span>
                                    </div>
                                    <input type="password" v-model="user.password" class="form-control"
                                        placeholder="Ingrese su contraseña" name="" id="password"
                                        :class="{ 'is-invalid': submitted && $v.user.password.$error }">
                                </div>
                            </div>
                            <div class="login_actions" style="display:block;">
                                <button class="btn btn-gradient" type="submit">Ingresar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </header>

        <section class="container mt-3">
            <div class="row">
                <div class="col-12">
                    <h4>Productos Destacados</h4>
                </div>


                <div v-for="(producto,key) in productList" :key="key" class="col-12 col-md-6 mt-3">
                    <div class="card" style="width: 18rem;">
                        <img class="card-img-top" :src="producto.ImagenProducto" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title">{{producto.NombreProducto}} </h5>
                            <p class="card-text">{{producto.DescripcionProducto}}</p>
                            <p class="card-text">{{producto.PrecioProducto}}</p>
                            <button class="btn btn-success btn-block" @click="addCart(producto.IdProducto)">Agregar al carrito</button>
                        </div>

                    </div>
                </div>
            </div>
        </section>
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
                carrito: [],
                itemsCarrito:0,
                productList: undefined,
                user: {
                    email: '',
                    password: ''
                },
                submitted: false
            }
        },
        mixins: [misMixins],
        mounted() {

            this.getProducts()
            this.obtenerCarrito()
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
                localStorage.userId = 1;
                /*
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

                                    */

            },

            getProducts: function () {

                let self = this
                axios.post('http://localhost:55466/SerivicioCompras.asmx/ObtieneProductos')
                    .then(function (res) {

                        self.productList = res.data
                    }).catch(function (err) {
                        console.log(err)

                    });

            },
            addCart: function (id) {

                let self = this
                axios.get('http://localhost:55466/SerivicioCompras.asmx/InsertarCarritoPorCliente', {
                        params: {
                            IdCliente: localStorage.userId,
                            IdProducto: id,
                            Cantidad: 1
                        }

                    })
                    .then(function (res) {

                       if(res.data){
                           $.alert("Item agregado al carrito");
                           self.obtenerCarrito()
                       }
                    }).catch(function (err) {
                        console.log(err)

                    });

            },
            obtenerCarrito: function (id) {

                let self = this
                axios.get('http://localhost:55466/SerivicioCompras.asmx/ObtenerCarritoPorCliente', {
                        params: {
                            IdCliente: localStorage.userId
                        }

                    })
                    .then(function (res) {

                       self.carrito = res.data

                       self.itemsCarrito = self.carrito.length 

                    }).catch(function (err) {
                        console.log(err)

                    });

            },

            verifyProvider: function () {
                if (localStorage.provider) {



                }

            }
        }

    }
</script>