
import Vue from 'vue'
import router from './router'
import App from './components/App'
import { store } from './store/store'
import Notifications from 'vue-notification'
import Vuelidate from 'vuelidate'
import 'popper.js/dist/umd/popper';
import 'bootstrap';
import VueMq from 'vue-mq'
import Select2 from 'v-select2-component';
import NoSideBar from './layouts/NoSideBar.vue'
import PrettyInput from 'pretty-checkbox-vue/input';
import PrettyCheck from 'pretty-checkbox-vue/check';
import PrettyRadio from 'pretty-checkbox-vue/radio';
import {
  misMixins
} from "./mixins"

Vue.use(require('vue-moment'));
Vue.component('Select2', Select2);
const axios = require('axios');
Vue.config.productionTip = false
window.axios = require('axios');
Vue.use(Vuelidate)
Vue.component('p-input', PrettyInput);
Vue.component('p-check', PrettyCheck);
Vue.component('p-radio', PrettyRadio);
Vue.use(VueMq, {
    breakpoints: {
      mobile: 768,
      tablet: 900,
      laptop: 1250,
      desktop: Infinity,
    }
  })

require('jquery-confirm');
Vue.component('no-sidebar-layout',NoSideBar)
Vue.prototype.$baseUrl = window.baseUrl 
Vue.prototype.$uploadsUrl = window.uploadsUrl 
Vue.prototype.$Url = window.url 
Vue.use(Notifications)
new Vue({
    router,
    mixins: [misMixins],
    store,
    render: h => h(App)
}).$mount('#app');
