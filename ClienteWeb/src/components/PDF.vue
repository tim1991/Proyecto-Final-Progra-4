<template>
    <div class="container">
        <button @click="exportPDF()" class="btn btn-success mt-3 mb-3">Guardar</button>
        <div id="content">
            <div class="container">
                <div class="card">
                    <div class="card-header">
                        Factura # {{infoFactura.IdFactura}}
                        <strong>{{infoFactura.Fecha}}</strong>
                        <span class="float-right"> <strong>Estado:</strong> Pendiente</span>

                    </div>
                    <div class="card-body">
                        <div class="row mb-4">
                            <div class="col-sm-6">
                                <div>
                                    <strong>Tienda en Liena</strong>
                                </div>
                                <div>Cartago</div>
                                <div>2471-1018</div>
                                <div>Email: info@tiendaenlinea.com</div>
                            </div>

                            <div class="col-sm-6">
                                <h6 class="mb-3">Cliente:</h6>
                                <div>
                                    <strong>{{infoFactura.Nombre}} {{infoFactura.Apellido}}</strong>
                                </div>
                              
                            </div>



                        </div>

                        <div class="table-responsive-sm">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Descripcion</th>
                                        <th class="center">Cantidad</th>
                                        <th class="right">Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="(item, index) in itemsFactura" :key="index">
                                        <td class="left">{{item.NombreProducto}}</td>
                                        <td class="center">{{item.Cantidad}}</td>
                                        <td class="right">{{item.SubTotal}}</td>
                                    </tr>
                                  
                                  
                                </tbody>
                            </table>
                        </div>
                        <div class="row">
                            <div class="col-lg-4 col-sm-5">

                            </div>

                            <div class="col-lg-4 col-sm-5 ml-auto">
                                <table class="table table-clear">
                                    <tbody>
                                        
                                        <tr>
                                            <td class="left">
                                                <strong>Total</strong>
                                            </td>
                                            <td class="right">
                                                <strong>{{infoFactura.Total}}</strong>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import * as jsPDF from 'jspdf';
    import html2canvas from 'html2canvas';

    export default {
        data: function () {
            return {
                infoFactura: [],
                itemsFactura: [],
                submitted: false,
                idFactura: 0
            }
        },
        mounted() {
            this.idFactura = this.$route.query.id;

            this.obtenerFactura(this.idFactura);
            this.ObtenerItemsFactura(this.idFactura);
        },
        methods: {



            obtenerFactura: function (id) {

                let self = this
                axios.get(this.$baseUrl + 'ObtienerFactura', {
                        params: {
                            IdFactura: id
                        }

                    })
                    .then(function (res) {

                        self.infoFactura = res.data

                    }).catch(function (err) {
                        console.log(err)

                    });

            },
            ObtenerItemsFactura: function (id) {

                let self = this
                axios.get(this.$baseUrl + 'ObtenerItemsFactura', {
                        params: {
                            IdFactura: id
                        }

                    })
                    .then(function (res) {

                        self.itemsFactura = res.data

                    }).catch(function (err) {
                        console.log(err)

                    });

            },

            exportPDF: function () {
                let self = this
                this.$store.commit('loader', true)
                html2canvas(document.getElementById("content")).then(function (canvas) {
                    var width = canvas.width;
                    var height = canvas.height;
                    var millimeters = {};
                    millimeters.width = Math.floor(width - 250);
                    millimeters.height = Math.floor(height);

                    var imgData = canvas.toDataURL(
                        'image/png');
                    var doc = new jsPDF("p", "mm", "a4");
                    doc.deletePage(1);
                    doc.addPage(millimeters.width, millimeters.height);
                    doc.addImage(imgData, 'PNG', 5, 5);
                    doc.save('Factura.pdf');
                    self.$store.commit('loader', false)
                });

            },
        }
    }
</script>