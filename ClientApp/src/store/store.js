import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import Movie from './Modules/Movie'
import post from './Modules/post'



const store = createStore({
    modules: {
        post,
        Movie
    },

    plugins: [createPersistedState()],

});

export default store;