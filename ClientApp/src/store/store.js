import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import Movie from './Modules/Movie'
import post from './Modules/post'

import Peaple from './Modules/Peaple'


const store = createStore({
    modules: {
        post,
        Movie,
        Peaple
    },

    plugins: [createPersistedState()],

});

export default store;