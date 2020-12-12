// import Vue from 'vue'
import axios from 'axios'
const state = {
    MovieData: [],
    InTheater: "",
    Genres: ""
};

const getters = {
    GetMovies(state) {
        return state.MovieData;
    },
    getTop(state) {
        return state.InTheater;
    },
    GetGenres(state) {
        return state.Genres;
    },
    Movie: state => id => {
        return state.MovieData.find(Movie => Movie.id === id)
    },
    People: state => {
        return state.PeopleData
    },

    // groupSort: state => badge => {
    //     return state.MovieData.find(groupSort => groupSort.badge === badge)
    // }
};

const mutations = {
    SET_MOVIE(state, movie) {
        state.MovieData = movie
    },
    SET_TOP_MOVIE(state, topMovie) {
        state.InTheater = topMovie
    },
    SET_GENRES(state, Genres) {
        state.Genres = Genres
    }
};


const actions = {
    getMovie({ commit }) {
        axios.get('http://localhost:8080/api/Movies')
            .then(response => {
                commit('SET_MOVIE', response.data)
            })
    },

    getTopMovie({ commit }) {
        axios.get('http://localhost:8080/api/Movies/top')
            .then(response => {
                commit('SET_TOP_MOVIE', response.data)
            })
    },
    GetGenres({ commit }) {
        axios.get('http://localhost:8080/api/Genres')
            .then(response => {
                commit('SET_GENRES', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}