import Vue    from 'vue'
import Router from 'vue-router'

const Login     = () => import( /* webpackChunkName: "login-component" */ '../components/Login')
const Home    = () => import( /* webpackChunkName: "home-component" */ '../components/Home')
const PDF    = () => import( /* webpackChunkName: "pdf-component" */ '../components/PDF')
Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            component: Home
        },
        {
            path: '/Factura',
            component: PDF
        },
        /*{
            path: '/Dashboard',
            component: Home,
            meta:{
                title: 'Dashboard - Kalkulus',
                layout:'no-sidebar'
            }
        },*/
    ],
    linkActiveClass: "active",
})