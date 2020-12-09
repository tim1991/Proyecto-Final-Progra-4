(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["home-component"],{

/***/ "./node_modules/babel-loader/lib/index.js?!./node_modules/vue-loader/lib/index.js?!./src/components/Home.vue?vue&type=script&lang=js&":
/*!******************************************************************************************************************************************************!*\
  !*** ./node_modules/babel-loader/lib??ref--4-0!./node_modules/vue-loader/lib??vue-loader-options!./src/components/Home.vue?vue&type=script&lang=js& ***!
  \******************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* WEBPACK VAR INJECTION */(function($) {/* harmony import */ var vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vuelidate/lib/validators */ "./node_modules/vuelidate/lib/validators/index.js");
/* harmony import */ var vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _mixins__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../mixins */ "./src/mixins.js");
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
      carrito: [],
      itemsCarrito: 0,
      productList: undefined,
      user: {
        email: '',
        password: ''
      },
      submitted: false
    };
  },
  mixins: [_mixins__WEBPACK_IMPORTED_MODULE_1__["misMixins"]],
  mounted: function mounted() {
    this.getProducts();
    this.obtenerCarrito();
  },
  validations: {
    user: {
      email: {
        required: vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__["required"],
        email: vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__["email"]
      },
      password: {
        required: vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__["required"],
        minLength: Object(vuelidate_lib_validators__WEBPACK_IMPORTED_MODULE_0__["minLength"])(6)
      }
    }
  },
  methods: {
    login: function login(e) {
      this.submitted = true; // stop here if form is invalid

      this.$v.$touch();

      if (this.$v.$invalid) {
        return;
      }

      var self = this;
      this.$store.commit('loader', true);
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
    getProducts: function getProducts() {
      var self = this;
      axios.post('http://localhost:55466/SerivicioCompras.asmx/ObtieneProductos').then(function (res) {
        self.productList = res.data;
      })["catch"](function (err) {
        console.log(err);
      });
    },
    addCart: function addCart(id) {
      var self = this;
      axios.get('http://localhost:55466/SerivicioCompras.asmx/InsertarCarritoPorCliente', {
        params: {
          IdCliente: localStorage.userId,
          IdProducto: id,
          Cantidad: 1
        }
      }).then(function (res) {
        if (res.data) {
          $.alert("Item agregado al carrito");
          self.obtenerCarrito();
        }
      })["catch"](function (err) {
        console.log(err);
      });
    },
    obtenerCarrito: function obtenerCarrito(id) {
      var self = this;
      axios.get('http://localhost:55466/SerivicioCompras.asmx/ObtenerCarritoPorCliente', {
        params: {
          IdCliente: localStorage.userId
        }
      }).then(function (res) {
        self.carrito = res.data;
        self.itemsCarrito = self.carrito.length;
      })["catch"](function (err) {
        console.log(err);
      });
    },
    verifyProvider: function verifyProvider() {
      if (localStorage.provider) {}
    }
  }
});
/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! jquery */ "./node_modules/jquery/dist/jquery.js")))

/***/ }),

/***/ "./node_modules/vue-loader/lib/loaders/templateLoader.js?!./node_modules/vue-loader/lib/index.js?!./src/components/Home.vue?vue&type=template&id=8dc7cce2&":
/*!**********************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!./node_modules/vue-loader/lib??vue-loader-options!./src/components/Home.vue?vue&type=template&id=8dc7cce2& ***!
  \**********************************************************************************************************************************************************************************************/
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
  return _c("div", [
    _c(
      "header",
      {
        staticClass: "hero",
        staticStyle: {
          background:
            "linear-gradient(#33691ebd, rgb(2 67 61 / 58%)), url(images/bg2.jpg)"
        }
      },
      [
        _c("div", { staticClass: "container" }, [
          _c("nav", { staticClass: "nav" }, [
            _c("div", { staticClass: "logo" }, [_vm._v("Tienda en linea")]),
            _vm._v(" "),
            _c("ul", [
              _vm._m(0),
              _vm._v(" "),
              _vm._m(1),
              _vm._v(" "),
              _c("li", [
                _c("div", { staticClass: "dropdown show" }, [
                  _c(
                    "a",
                    {
                      staticClass: "btn btn-secondary dropdown-toggle",
                      attrs: {
                        href: "#",
                        role: "button",
                        id: "dropdownMenuLink",
                        "data-toggle": "dropdown",
                        "aria-haspopup": "true",
                        "aria-expanded": "false"
                      }
                    },
                    [
                      _c("i", { staticClass: "fas fa-shopping-cart" }),
                      _vm._v(
                        " Carrito (" +
                          _vm._s(_vm.itemsCarrito) +
                          ")\n                            "
                      )
                    ]
                  ),
                  _vm._v(" "),
                  _c(
                    "div",
                    {
                      staticClass: "dropdown-menu",
                      attrs: { "aria-labelledby": "dropdownMenuLink" }
                    },
                    _vm._l(_vm.carrito, function(item, key) {
                      return _c(
                        "a",
                        {
                          key: key,
                          staticClass: "dropdown-item",
                          staticStyle: { color: "black" },
                          attrs: { href: "#" }
                        },
                        [
                          _c("img", {
                            staticClass: "card-img-top",
                            staticStyle: { width: "40px" },
                            attrs: {
                              src: item.ImagenProducto,
                              alt: "Card image cap"
                            }
                          }),
                          _vm._v(
                            " " +
                              _vm._s(item.NombreProducto) +
                              " x\n                                    " +
                              _vm._s(item.Cantidad)
                          )
                        ]
                      )
                    }),
                    0
                  )
                ])
              ])
            ])
          ]),
          _vm._v(" "),
          _c("div", { staticClass: "row" }, [
            _vm._m(2),
            _vm._v(" "),
            _c("div", { staticClass: "col-12 col-md-6" }, [
              _c(
                "form",
                {
                  staticClass: "login-form",
                  on: {
                    submit: function($event) {
                      $event.preventDefault()
                      return _vm.login($event)
                    }
                  }
                },
                [
                  _c(
                    "h2",
                    {
                      staticStyle: {
                        "text-align": "left",
                        "text-transform": "uppercase"
                      }
                    },
                    [_vm._v("Ingresar")]
                  ),
                  _vm._v(" "),
                  _c("p", [
                    _vm._v(
                      "Ingrese los datos de su cuenta para ingresar al sistema."
                    )
                  ]),
                  _vm._v(" "),
                  _c("div", { staticClass: "form-group" }, [
                    _c(
                      "label",
                      {
                        staticStyle: {
                          "font-weight": "bold",
                          "font-size": "16px"
                        }
                      },
                      [_vm._v("Email")]
                    ),
                    _vm._v(" "),
                    _c("div", { staticClass: "input-group mb-3" }, [
                      _vm._m(3),
                      _vm._v(" "),
                      _c("input", {
                        directives: [
                          {
                            name: "model",
                            rawName: "v-model",
                            value: _vm.user.email,
                            expression: "user.email"
                          }
                        ],
                        staticClass: "form-control",
                        class: {
                          "is-invalid":
                            _vm.submitted && _vm.$v.user.email.$error
                        },
                        attrs: {
                          type: "email",
                          placeholder: "Ingrese su email",
                          name: "",
                          id: "email"
                        },
                        domProps: { value: _vm.user.email },
                        on: {
                          input: function($event) {
                            if ($event.target.composing) {
                              return
                            }
                            _vm.$set(_vm.user, "email", $event.target.value)
                          }
                        }
                      })
                    ])
                  ]),
                  _vm._v(" "),
                  _c("div", { staticClass: "form-group" }, [
                    _c(
                      "label",
                      {
                        staticStyle: {
                          "font-weight": "bold",
                          "font-size": "16px"
                        }
                      },
                      [_vm._v("Contraseña")]
                    ),
                    _vm._v(" "),
                    _c("div", { staticClass: "input-group mb-3" }, [
                      _vm._m(4),
                      _vm._v(" "),
                      _c("input", {
                        directives: [
                          {
                            name: "model",
                            rawName: "v-model",
                            value: _vm.user.password,
                            expression: "user.password"
                          }
                        ],
                        staticClass: "form-control",
                        class: {
                          "is-invalid":
                            _vm.submitted && _vm.$v.user.password.$error
                        },
                        attrs: {
                          type: "password",
                          placeholder: "Ingrese su contraseña",
                          name: "",
                          id: "password"
                        },
                        domProps: { value: _vm.user.password },
                        on: {
                          input: function($event) {
                            if ($event.target.composing) {
                              return
                            }
                            _vm.$set(_vm.user, "password", $event.target.value)
                          }
                        }
                      })
                    ])
                  ]),
                  _vm._v(" "),
                  _vm._m(5)
                ]
              )
            ])
          ])
        ])
      ]
    ),
    _vm._v(" "),
    _c("section", { staticClass: "container mt-3" }, [
      _c(
        "div",
        { staticClass: "row" },
        [
          _vm._m(6),
          _vm._v(" "),
          _vm._l(_vm.productList, function(producto, key) {
            return _c(
              "div",
              { key: key, staticClass: "col-12 col-md-6 mt-3" },
              [
                _c(
                  "div",
                  { staticClass: "card", staticStyle: { width: "18rem" } },
                  [
                    _c("img", {
                      staticClass: "card-img-top",
                      attrs: {
                        src: producto.ImagenProducto,
                        alt: "Card image cap"
                      }
                    }),
                    _vm._v(" "),
                    _c("div", { staticClass: "card-body" }, [
                      _c("h5", { staticClass: "card-title" }, [
                        _vm._v(_vm._s(producto.NombreProducto) + " ")
                      ]),
                      _vm._v(" "),
                      _c("p", { staticClass: "card-text" }, [
                        _vm._v(_vm._s(producto.DescripcionProducto))
                      ]),
                      _vm._v(" "),
                      _c("p", { staticClass: "card-text" }, [
                        _vm._v(_vm._s(producto.PrecioProducto))
                      ]),
                      _vm._v(" "),
                      _c(
                        "button",
                        {
                          staticClass: "btn btn-success btn-block",
                          on: {
                            click: function($event) {
                              return _vm.addCart(producto.IdProducto)
                            }
                          }
                        },
                        [
                          _vm._v(
                            "Agregar al\n                            carrito"
                          )
                        ]
                      )
                    ])
                  ]
                )
              ]
            )
          })
        ],
        2
      )
    ])
  ])
}
var staticRenderFns = [
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("li", [_c("a", { attrs: { href: "#" } }, [_vm._v("Inicio")])])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("li", [_c("a", { attrs: { href: "#" } }, [_vm._v("Productos")])])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "col-12 col-md-6" }, [
      _c("div", { staticClass: "caption" }, [
        _c("h1", [_vm._v("Bienvenido")]),
        _vm._v(" "),
        _c("p", [_vm._v("Sistemas de compras en linea.")])
      ])
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "input-group-prepend" }, [
      _c(
        "span",
        {
          staticClass: "input-group-text custom-addon",
          attrs: { id: "basic-addon1" }
        },
        [_c("i", { staticClass: "far fa-user" })]
      )
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "input-group-prepend" }, [
      _c(
        "span",
        {
          staticClass: "input-group-text custom-addon",
          attrs: { id: "basic-addon1" }
        },
        [_c("i", { staticClass: "fas fa-lock" })]
      )
    ])
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c(
      "div",
      { staticClass: "login_actions", staticStyle: { display: "block" } },
      [
        _c(
          "button",
          { staticClass: "btn btn-gradient", attrs: { type: "submit" } },
          [_vm._v("Ingresar")]
        )
      ]
    )
  },
  function() {
    var _vm = this
    var _h = _vm.$createElement
    var _c = _vm._self._c || _h
    return _c("div", { staticClass: "col-12" }, [
      _c("h4", [_vm._v("Productos Destacados")])
    ])
  }
]
render._withStripped = true



/***/ }),

/***/ "./src/components/Home.vue":
/*!*********************************!*\
  !*** ./src/components/Home.vue ***!
  \*********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Home.vue?vue&type=template&id=8dc7cce2& */ "./src/components/Home.vue?vue&type=template&id=8dc7cce2&");
/* harmony import */ var _Home_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Home.vue?vue&type=script&lang=js& */ "./src/components/Home.vue?vue&type=script&lang=js&");
/* empty/unused harmony star reexport *//* harmony import */ var _node_modules_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../node_modules/vue-loader/lib/runtime/componentNormalizer.js */ "./node_modules/vue-loader/lib/runtime/componentNormalizer.js");





/* normalize component */

var component = Object(_node_modules_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_2__["default"])(
  _Home_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__["default"],
  _Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__["render"],
  _Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"],
  false,
  null,
  null,
  null
  
)

/* hot reload */
if (false) { var api; }
component.options.__file = "src/components/Home.vue"
/* harmony default export */ __webpack_exports__["default"] = (component.exports);

/***/ }),

/***/ "./src/components/Home.vue?vue&type=script&lang=js&":
/*!**********************************************************!*\
  !*** ./src/components/Home.vue?vue&type=script&lang=js& ***!
  \**********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_babel_loader_lib_index_js_ref_4_0_node_modules_vue_loader_lib_index_js_vue_loader_options_Home_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../node_modules/babel-loader/lib??ref--4-0!../../node_modules/vue-loader/lib??vue-loader-options!./Home.vue?vue&type=script&lang=js& */ "./node_modules/babel-loader/lib/index.js?!./node_modules/vue-loader/lib/index.js?!./src/components/Home.vue?vue&type=script&lang=js&");
/* empty/unused harmony star reexport */ /* harmony default export */ __webpack_exports__["default"] = (_node_modules_babel_loader_lib_index_js_ref_4_0_node_modules_vue_loader_lib_index_js_vue_loader_options_Home_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__["default"]); 

/***/ }),

/***/ "./src/components/Home.vue?vue&type=template&id=8dc7cce2&":
/*!****************************************************************!*\
  !*** ./src/components/Home.vue?vue&type=template&id=8dc7cce2& ***!
  \****************************************************************/
/*! exports provided: render, staticRenderFns */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../node_modules/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!../../node_modules/vue-loader/lib??vue-loader-options!./Home.vue?vue&type=template&id=8dc7cce2& */ "./node_modules/vue-loader/lib/loaders/templateLoader.js?!./node_modules/vue-loader/lib/index.js?!./src/components/Home.vue?vue&type=template&id=8dc7cce2&");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "render", function() { return _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__["render"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "staticRenderFns", function() { return _node_modules_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_node_modules_vue_loader_lib_index_js_vue_loader_options_Home_vue_vue_type_template_id_8dc7cce2___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"]; });



/***/ })

}]);