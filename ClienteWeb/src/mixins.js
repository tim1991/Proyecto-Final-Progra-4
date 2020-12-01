var CryptoJS = require("crypto-js");

export const misMixins = {
    methods: {
        desencriptar: function (cyper, json = true) {
            var txtpassword = cyper
            var key = CryptoJS.enc.Utf8.parse('7061737323313233');
            var iv = CryptoJS.enc.Utf8.parse('7061737323313233');

            var decrypted = CryptoJS.AES.decrypt(txtpassword, key, {
                iv: iv,
                mode: CryptoJS.mode.CBC,
            });

            if (json) {
                return JSON.parse((decrypted.toString(CryptoJS.enc.Utf8)))
            } else {
                return (decrypted.toString(CryptoJS.enc.Utf8))
            }

        },
        desencriptarHex: function (cyper) {
            try {
                var txtpassword = cyper
                var key = CryptoJS.enc.Utf8.parse('7061737323313233');
                var iv = CryptoJS.enc.Utf8.parse('7061737323313233');
                var bytes = CryptoJS.AES.decrypt({
                    ciphertext: CryptoJS.enc.Hex.parse(txtpassword)
                }, key, {
                    format: CryptoJS.format.Hex,
                    iv: iv,
                    mode: CryptoJS.mode.CBC
                });
                var plaintext = bytes.toString(CryptoJS.enc.Utf8);

                return plaintext
            } catch (error) {

            }

        },
        encriptar: function (cyper, json = true) {
            var txtpassword = cyper
            var key = CryptoJS.enc.Utf8.parse('7061737323313233');
            var iv = CryptoJS.enc.Utf8.parse('7061737323313233');
            var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtpassword), key, {
                iv: iv,
                mode: CryptoJS.mode.CBC,
            });

            if (json) {
                return JSON.parse(encrypted.toString())
            } else {
                return encrypted.toString()
            }


        },
        encriptarHex: function (cyper, json = true) {
            var txtpassword = cyper
            var key = CryptoJS.enc.Utf8.parse('7061737323313233');
            var iv = CryptoJS.enc.Utf8.parse('7061737323313233');
            var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtpassword), key, {
                iv: iv,
                mode: CryptoJS.mode.CBC,
            });

            if (json) {
                return JSON.parse(encrypted.toString(CryptoJS.format.Hex))
            } else {
                return encrypted.toString(CryptoJS.format.Hex)
            }


        },
        verificarPermisosUser: function (modulo) {

            let self = this;

            var userData = localStorage.AT;
            userData = this.desencriptar(userData);

            var modulos = userData.permisos;

            var permisos = modulos.split(",");

            if (permisos.indexOf(modulo) != -1) {
                return true;
            } else {
                self.$router.push('Error');
                return;
            }



        },
        formatPrice(value) {
            let val = (value / 1).toFixed(2).replace(',', '.')
            return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        }
    },
}