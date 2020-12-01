import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
        loader: false,
        logotipo: '',
        user:[]
    },
    mutations: {
        loader(state, loader) {
            state.loader = loader
        },
        logotipo(state, logotipo) {
            state.logotipo = logotipo
        },
        user(state, user) {
            state.user = user
        }
    },
    getters:{
        loader: state=> state.loader,
        logotipo: state=> state.logotipo,
        user: state=> state.user,
    }

})