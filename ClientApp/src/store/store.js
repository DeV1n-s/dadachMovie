import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import Movie from './modules/Movie'
import post from './modules/post'



const store = createStore({
    modules: {
        post,
        Movie
    },

    plugins: [createPersistedState()],

});

export default store;