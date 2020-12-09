// import Vue from 'vue'
import axios from 'axios'
const state = {
    MovieData: [],
    InTheater: ""
};

const getters = {
    GetMovies(state) {
        return state.MovieData;
    },
    getTop(state) {
        return state.InTheater;
    },
    Movie: state => id => {
        return state.MovieData.find(Movie => Movie.id === id)
    },
    People: state => {
            return state.PeopleData
        }
        // groupSort: state => badge => {
        //     return state.MovieData.find(groupSort => groupSort.badge === badge)
        // }
};

const mutations = {
    SET_MOVIE(state, movie) {
        state.MovieData = movie
            // state.refreshToken = userData.refreshToken
    },
    SET_TOP_MOVIE(state, topMovie) {
        state.InTheater = topMovie
            // state.refreshToken = userData.refreshToken
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
}

export default {
    state,
    getters,
    mutations,
    actions,
}