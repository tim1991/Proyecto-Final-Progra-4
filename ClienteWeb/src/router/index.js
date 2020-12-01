import Vue    from 'vue'
import Router from 'vue-router'

const Login     = () => import( /* webpackChunkName: "login-component" */ '../components/Login')
const Home    = () => import( /* webpackChunkName: "home-component" */ '../components/Home')
Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            component: Home
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