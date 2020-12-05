import { createStore } from 'vuex'
import Movie from './Modules/Movie'
import post from './Modules/post'



const store = createStore({
    modules: {
        post,
        Movie
    }
});

export default store;