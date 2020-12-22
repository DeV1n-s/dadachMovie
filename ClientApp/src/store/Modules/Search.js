// import Vue from 'vue'
import axios from 'axios'
const state = {
    movieTitle: '',
    searchMovieTitle: [],
};

const getters = {
    GetSearchTitleMovie(state) {
        return state.searchMovieTitle;
    },
    getMovieTitle(state) {
        return state.movieTitle;
    }
};

const mutations = {
    SEARCH_MOVIE_TITLE(state, movie) {
        state.searchMovieTitle = movie
    },


};


const actions = {
    MovieSearchTitle({ commit }, searchTitle) {
        axios.get('/api/Movies/filter?Title=' + searchTitle)
            .then(response => {
                commit('SEARCH_MOVIE_TITLE', response.data);
                console.log(searchTitle);

            })
    },

}

export default {
    state,
    getters,
    mutations,
    actions,
}