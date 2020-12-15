<template>
    <div>
        <header class="hero" style="background: linear-gradient(#180c049c,#351c0b99), url(images/hero.jpeg)">
            <div class="container">
                <nav class="nav">
                    <div class="logo">Tienda en linea</div>
                    <ul>
                        <li><a href="#">Inicio</a></li>
                        <li><a href="#">Productos</a></li>
                        <li v-if="useriD!=0">

                            <div class="dropdown show">
                                <a class="btn btn-secondary dropdown-toggle" href="#" role="button"
                                    id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">
                                    Hola, {{userName}}
                                </a>

                                <div class="dropdown-menu" style="min-width: 200px;" aria-labelledby="dropdownMenuLink">
                                    <a @click="obtenerFacturasCliente()" data-toggle="modal"
                                        data-target="#facturasModal" style="color:black;" class="dropdown-item">Ver mis
                                        pedidos</a>
                                </div>
                            </div>

                        </li>

                        <li v-if="useriD==0"><a data-toggle="modal" data-target="#loginModal">Ingresar</a></li>
                        <li>
                            <div class="dropdown show">
                                <a class="btn btn-secondary dropdown-toggle" href="#" role="button"
                                    id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">
                                    <i class="fas fa-shopping-cart"></i> Carrito ({{itemsCarrito}})
                                </a>

                                <div class="dropdown-menu" style="min-width: 200px;" aria-labelledby="dropdownMenuLink">
                                    <div style="color: black;" v-for="(item,key) in carrito" :key="key"
                                        class="dropdown-item">
                                        <a style="color:red" @click="deleteCart(item.IdCarrito)"> <i
                                                class="fas fa-trash"></i></a>
                                        <img class="card-img-top" style="width: 40px;" :src="item.ImagenProducto"
                                            alt="Card image cap"> {{item.NombreProducto}} x
                                        {{item.Cantidad}}</div>
                                    <button @click="crearFactura()" class="btn btn-success">Procesar carrito</button>
                                </div>
                            </div>
                        </li>
                    </ul>
                </nav>
                <div class="caption">
                    <h1>Bienvenido</h1>
                    <p>Sistemas de compras en linea.</p>

                    <div class="form-group">
                        <input type="text" @keyup="getProductsNombre()" v-model="buscar" class="form-control" placeholder="Buscar">
                    </div>
                </div>

            </div>
        </header>

        <section class="container mt-3 mb-5">
            <div class="row">
                <div class="col-12 mt-5">
                    <h4>Productos</h4>
                </div>


                <div v-for="(producto,key) in productList " :key="key" class="col-12 col-md-4 mt-3">
                    <div class="card" style="width: 18rem;">
                        <img class="card-img-top" :src="producto.ImagenProducto" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title">{{producto.NombreProducto}} </h5>
                            <p class="card-text">{{producto.DescripcionProducto}}</p>
                            <b class="card-text">$ {{producto.PrecioProducto}}</b>
                            <button class="btn btn-success btn-block mt-3" @click="addCart(producto.IdProducto)">Agregar
                                al
                                carrito</button>
                        </div>

                    </div>
                </div>
            </div>
        </section>

        <footer class="container-fluid">
            <div class="container">
                <p class="text-right">Tienda en Linea 2020, Derechos Reservados</p>
            </div>
        </footer>

        <!-- Modal -->
        <div class="modal fade" id="facturasModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Pedidos relizados</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Fecha</th>
                                    <th>Factura</th>
                                    <th>Total</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(factura, index) in facturas" :key="index">
                                    <td>{{factura.IdFactura}}</td>
                                    <td>{{factura.Fecha}}</td>
                                    <td>{{factura.Total}}</td>
                                    <td><button  data-dismiss="modal"  @click="obtenerPDF(factura.IdFactura)" class="btn btn-info">Ver PDF</button></td>
                                </tr>
                            </tbody>
                        </table>

                    </div>

                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ingresar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form v-if="useriD==0" class="login-form" @submit.prevent="login">
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
        </div>
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
                facturas: [],
                buscar:'',
                useriD: 0,
                userName: '',
                itemsCarrito: 0,
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
            console.log(localStorage.userId);
            if (localStorage.userId) {
                this.useriD = localStorage.userId;
                this.userName = localStorage.usuario;
                this.obtenerCarrito()
            }
        },
        validations: {
            user: {
                email: {
                    required,
                    email
                },
                password: {
                    required,
                    minLength: minLength(1)
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


                axios.get(this.$baseUrl + 'LoginCliente', {
                        params: {
                            Email: this.user.email,
                            Contrasena: this.user.password
                        }

                    })
                    .then(function (res) {
                        console.log(res.data);
                        if (res.data.IdCliente != 0) {
                            localStorage.userId = res.data.IdCliente;
                            localStorage.usuario = res.data.Nombre + " " + res.data.Apellido;

                            self.useriD = localStorage.userId
                            self.userName = localStorage.usuario
                        }

                        localStorage.provider = btoa('3747309182101sdhbfu')

                        self.obtenerCarrito()
                        self.$store.commit('loader', false)



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

           obtenerPDF: function (id)  {
                this.$router.push('/Factura?id=' + id)
            },

            obtenerFacturasCliente: function () {

                let self = this;
                axios.get(this.$baseUrl + 'ObtenerFacturasCliente', {
                        params: {
                            IdCliente: localStorage.userId,
                        }

                    })
                    .then(function (res) {

                        if (res.data) {
                            self.facturas = res.data
                        }
                    }).catch(function (err) {
                        console.log(err)

                    });
            },
            getProducts: function () {

                let self = this
                axios.post(this.$baseUrl + 'ObtieneProductos')
                    .then(function (res) {

                        self.productList = res.data
                    }).catch(function (err) {
                        console.log(err)

                    });

            },
            getProductsNombre: function () {

                let self = this
                axios.get(this.$baseUrl + 'ObtieneProductosXNombre', {
                        params: {
                            NombreProducto: this.buscar,
                        }

                    })
                    .then(function (res) {

                        self.productList = res.data
                    }).catch(function (err) {
                        console.log(err)

                    });

            },

            ObtenerCarritoPorCliente: function () {
                axios.get(this.$baseUrl + 'ObtenerCarritoPorCliente', {
                        params: {
                            IdCliente: localStorage.userId,
                        }

                    })
                    .then(function (res) {

                        if (res.data) {
                            $.alert("Item agregado al carrito");
                            self.obtenerCarrito()
                        }
                    }).catch(function (err) {
                        console.log(err)

                    });
            },
            crearFactura: function () {

                let self = this;
                axios.get(this.$baseUrl + 'crearFactura', {
                        params: {
                            IdCliente: localStorage.userId,
                        }

                    })
                    .then(function (res) {

                        if (res.data) {
                            $.alert("Factura procesada correctamente");
                            self.obtenerCarrito()
                        }
                    }).catch(function (err) {
                        console.log(err)

                    });
            },
            deleteCart: function (id) {
                debugger;
                let self = this
                if (this.useriD != 0) {
                    axios.get(this.$baseUrl + 'EliminarCarritoPorCliente', {
                            params: {
                                IdCarrito: id
                            }

                        })
                        .then(function (res) {

                            if (res.data) {
                                $.alert("Item eliminado del carrito");
                                self.obtenerCarrito()
                            }
                        }).catch(function (err) {
                            console.log(err)

                        });
                } else {
                    $.alert("Debes de ingresar con tu cuenta para agregar al carrito");
                }


            },
            addCart: function (id) {

                let self = this
                if (this.useriD != 0) {
                    axios.get(this.$baseUrl + 'InsertarCarritoPorCliente', {
                            params: {
                                IdCliente: localStorage.userId,
                                IdProducto: id,
                                Cantidad: 1,
                                IdCarrito: 1
                            }

                        })
                        .then(function (res) {

                            if (res.data) {
                                $.alert("Item agregado al carrito");
                                self.obtenerCarrito()
                            }
                        }).catch(function (err) {
                            console.log(err)

                        });
                } else {
                    $.alert("Debes de ingresar con tu cuenta para agregar al carrito");
                }



            },
            obtenerCarrito: function (id) {

                let self = this
                axios.get(this.$baseUrl + 'ObtenerCarritoPorCliente', {
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
        },
        

    }
</script>