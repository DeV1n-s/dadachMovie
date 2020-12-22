// import Vue from 'vue'
import axios from 'axios'
const state = {
    movieTitle: '',
    searchMovieTitle: [],
    peopleTitle: '',
    searchCastTitle: [],

};

const getters = {
    GetSearchTitleMovie(state) {
        return state.searchMovieTitle;
    },
    getMovieTitle(state) {
        return state.movieTitle;
    },
    GetSearchTitlePeople(state) {
        return state.searchCastTitle;
    }
};

const mutations = {
    SEARCH_MOVIE_TITLE(state, movie) {
        state.searchMovieTitle = movie
    },
    SEARCH_PEOPLE_TITLE(state, people) {
        state.searchCastTitle = people;
    }

};


const actions = {
    MovieSearchTitle({ commit }, searchTitle) {
        axios.get('/api/Movies/filter?Title=' + searchTitle)
            .then(response => {
                commit('SEARCH_MOVIE_TITLE', response.data);
                console.log(searchTitle);

            })
    },

    PeopleSearchTitle({ commit }, searchTitle) {
        axios
            .get('http://localhost:8080/api/People/filter?Name=' + searchTitle)
            .then(response => {
                commit('SEARCH_PEOPLE_TITLE', response.data);
            })

    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}