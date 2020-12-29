import Vue from 'vue';
import Vuex from 'vuex';
import Movie from './Modules/Movie'
import post from './Modules/post'
import Peaple from './Modules/Peaple'
import Search from './Modules/Search.js'
import Country from './Modules/Country.js'
Vue.use(Vuex)
export const store = new Vuex.Store({
    modules: {
        post,
        Movie,
        Peaple,
        Search,
        Country
    },


});