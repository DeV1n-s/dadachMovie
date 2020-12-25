import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import Movie from './Modules/Movie'
import post from './Modules/post'
import Peaple from './Modules/Peaple'
import Search from './Modules/Search.js'
import Country from './Modules/Country.js'
const store = createStore({
    modules: {
        post,
        Movie,
        Peaple,
        Search,
        Country
    },

    plugins: [createPersistedState()],

});

export default store;