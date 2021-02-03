import Vuex from 'vuex';
import Auth from './Modules/Auth'
import Country from './Modules/Country'
import Genres from './Modules/Genres'
import Movie from './Modules/Movie'
import Peaple from './Modules/Peaple'
import Post from './Modules/post'
import Search from './Modules/Search'
import Users from './Modules/Users'
import Series from './Modules/Series'


const createStore = () => {
    return new Vuex.Store({
        namespaced: true,
        modules: {
            Auth,
            Country,
            Genres,
            Movie,
            Peaple,
            Post,
            Search,
            Users,
            Series
        }
    });
};

export default createStore