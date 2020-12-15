(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["pdf-component"],{

/***/ "./node_modules/babel-loader/lib/index.js?!./node_modules/vue-loader/lib/index.js?!./src/components/PDF.vue?vue&type=script&lang=js&":
/*!*****************************************************************************************************************************************************!*\
  !*** ./node_modules/babel-loader/lib??ref--4-0!./node_modules/vue-loader/lib??vue-loader-options!./src/components/PDF.vue?vue&type=script&lang=js& ***!
  \*****************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var jspdf__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! jspdf */ "./node_modules/jspdf/dist/jspdf.min.js");
/* harmony import */ var jspdf__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(jspdf__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var html2canvas__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! html2canvas */ "./node_modules/html2canvas/dist/html2canvas.js");
/* harmony import */ var html2canvas__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(html2canvas__WEBPACK_IMPORTED_MODULE_1__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


/* harmony default export */ __webpack_exports__["default"] = ({
  data: function data() {
    return {
      infoFactura: [],
      itemsFactura: [],
      submitted: false,
      idFactura: 0
    };
  },
  mounted: function mounted() {
    this.idFactura = this.$route.query.id;
    this.obtenerFactura(this.idFactura);
  },
  methods: {
    obtenerFactura: function obtenerFactura(id) {
      var self = this;
      axios.get(this.$baseUrl + 'ObtienerFactura', {
        params: {
          IdFactura: id
        }
      }).then(function (res) {
        self.infoFactura = res.data;
      })["catch"](function (err) {
        console.log(err);
      });
    },
    exportPDF: function exportPDF() {
      var self = this;
      this.$store.commit('loader', true);
      html2canvas__WEBPACK_IMPORTED_MODULE_1___default()(document.getElementById("content")).then(function (canvas) {
        var width = canvas.width;
        var height = canvas.height;
        var millimeters = {};
        millimeters.width = Math.floor(width - 250);
        millimeters.height = Math.floor(height);
        var imgData = canvas.toDataURL('image/png');
        var doc = new jspdf__WEBPACK_IMPORTED_MODULE_0__("p", "mm", "a4");
        doc.deletePage(1);
        doc.addPage(millimeters.width, millimeters.height);
        doc.addImage(imgData, 'PNG', 5, 5);
        doc.save('Factura.pdf');
        self.$store.commit('loader', false);
      });
    }
  }
});

/***/ }),

/***/ "./node_modules/vue-loader/lib/loaders/templateLoader.js?!./node_modules/vue-loader/lib/index.js?!./src/components/PDF.vue?vue&type=template&id=c949ec1c&":
/*!*********************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!./node_modules/vue-loader/lib??vue-loader-options!./src/components/PDF.vue?vue&type=template&id=c949ec1c& ***!
  \*********************************************************************************************************************************************************************************************/
/*! exports provided: render, staticRenderFns */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "render", function() { return render; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "staticRenderFns", function() { return staticRenderFns; });
var render = function() {
  var _vm = this
  var _h = _vm.$createElement
  var _c = _vm._self._c || _h
  return _c("div", { staticClass: "container" }, [
    _c(
      "button",
      {
        staticClass: "btn btn-success mt-3 mb-3",
        on: {
          click: function($event) {
            return _vm.exportPDF()
          }
        }
      },
      [_vm._v("Guardar")]
    ),
    _vm._v(" "),
    _c("div", { attrs: { id: "content" } }, [
      _c("div", { staticClass: "container" }, [
        _c("div", { staticClass: "card" }, [
          _c("div", { staticClass: "card-header" }, [
            _vm._v(
              "\n                    Factura # " +
                _vm._s(_vm.infoFactura.IdFactura) +
                "\n                    "
            ),
            _c("strong", [_vm._v(_vm._s(_vm.infoFactura.Fecha))]),
            _vm._v(" "),
            _vm._m(0)
          ]),
          _vm._v(" "),
          _c("div", { staticClass: "card-body" }, [
            _c("div", { staticClass: "row mb-4" }, [
              _vm._m(1),
              _vm._v(" "),
              _c("div", { staticClass: "col-sm-6" }, [
                _c("h6", { staticClass: "mb-3" }, [_vm._v("Cliente:")]),
                _vm._v(" "),
                _c("div", [
                  _c("strong", [
                    _vm._v(
                      _vm._s(_vm.infoFactura.Nombre) +
                        " " +
                        _vm._s(_vm.infoFactura.Apellido)
                    )
                  ])
                ])
              ])
            ]),
            _vm._v(" "),
            _vm._m(2),
            _vm._v(" "),
            _c("div", { staticClass: "row" }, [
              _c("div", { staticClass: "col-lg-4 col-sm-5" }),
              _vm._v(" "),
              _c("div", { staticClass: "col-lg-4 col-sm-5 ml-auto" }, [
                _c("table", { staticClass: "table table-clear" }, [
                  _c("tbody", [
                    _c("tr", [
                      _vm._m(3),
                      _vm._v(" "),
                      _c("td", { staticClass: "right" }, [
                        _c("strong", [_vm._v(_vm._s(_vm.infoFactura.Total))])
                      ])
                    ])
                  ])
                ])
              ])
            ])
          ])
        ])
      ])
    ])
  ])
}
var staticRenderFns = [
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("span", { staticClass: "float-right" }, [
      _c("strong", [_vm._v("Estado:")]),
      _vm._v(" Pendiente")
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "col-sm-6" }, [
      _c("div", [_c("strong", [_vm._v("Tienda en Liena")])]),
      _vm._v(" "),
      _c("div", [_vm._v("Cartago")]),
      _vm._v(" "),
      _c("div", [_vm._v("2471-1018")]),
      _vm._v(" "),
      _c("div", [_vm._v("Email: info@tiendaenlinea.com")])
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "table-responsive-sm" }, [
      _c("table", { staticClass: "table table-striped" }, [
        _c("thead", [
          _c("tr", [
            _c("th", [_vm._v("Descripcion")]),
            _vm._v(" "),
            _c("th", { staticClass: "center" }, [_vm._v("Cantidad")]),
            _vm._v(" "),
            _c("th", { staticClass: "right" }, [_vm._v("Total")])
          ])
        ]),
        _vm._v(" "),
        _c("tbody", [
          _c("tr", [
            _c("td", { staticClass: "left" }, [_vm._v("Extended License")]),
            _vm._v(" "),
            _c("td", { staticClass: "center" }, [_vm._v("1")]),
            _vm._v(" "),
            _c("td", { staticClass: "right" }, [_vm._v("$999,00")])
          ])
        ])
      ])
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("td", { staticClass: "left" }, [_c("strong", [_vm._v("Total")])])
  }
]
render._withStripped = true



/***/ }),

/***/ "./src/components/PDF.vue":
/*!********************************!*\
  !*** ./src/components/PDF.vue ***!
  \********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./PDF.vue?vue&type=template&id=c949ec1c& */ "./src/components/PDF.vue?vue&type=template&id=c949ec1c&");
/* harmony import */ var _PDF_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./PDF.vue?vue&type=script&lang=js& */ "./src/components/PDF.vue?vue&type=script&lang=js&");
/* empty/unused harmony star reexport *//* harmony import */ var _node_modules_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../node_modules/vue-loader/lib/runtime/componentNormalizer.js */ "./node_modules/vue-loader/lib/runtime/componentNormalizer.js");





/* normalize component */

var component = Object(_node_modules_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_2__["default"])(
  _PDF_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__["default"],
  _PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__["render"],
  _PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"],
  false,
  null,
  null,
  null
  
)

/* hot reload */
if (false) { var api; }
component.options.__file = "src/components/PDF.vue"
/* harmony default export */ __webpack_exports__["default"] = (component.exports);

/***/ }),

/***/ "./src/components/PDF.vue?vue&type=script&lang=js&":
/*!*********************************************************!*\
  !*** ./src/components/PDF.vue?vue&type=script&lang=js& ***!
  \*********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_babel_loader_lib_index_js_ref_4_0_node_modules_vue_loader_lib_index_js_vue_loader_options_PDF_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../node_modules/babel-loader/lib??ref--4-0!../../node_modules/vue-loader/lib??vue-loader-options!./PDF.vue?vue&type=script&lang=js& */ "./node_modules/babel-loader/lib/index.js?!./node_modules/vue-loader/lib/index.js?!./src/components/PDF.vue?vue&type=script&lang=js&");
/* empty/unused harmony star reexport */ /* harmony default export */ __webpack_exports__["default"] = (_node_modules_babel_loader_lib_index_js_ref_4_0_node_modules_vue_loader_lib_index_js_vue_loader_options_PDF_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__["default"]); 

/***/ }),

/***/ "./src/components/PDF.vue?vue&type=template&id=c949ec1c&":
/*!***************************************************************!*\
  !*** ./src/components/PDF.vue?vue&type=template&id=c949ec1c& ***!
  \***************************************************************/
/*! exports provided: render, staticRenderFns */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../node_modules/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!../../node_modules/vue-loader/lib??vue-loader-options!./PDF.vue?vue&type=template&id=c949ec1c& */ "./node_modules/vue-loader/lib/loaders/templateLoader.js?!./node_modules/vue-loader/lib/index.js?!./src/components/PDF.vue?vue&type=template&id=c949ec1c&");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "render", function() { return _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__["render"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "staticRenderFns", function() { return _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_PDF_vue_vue_type_template_id_c949ec1c___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"]; });



/***/ })

}]);