// import Vue from 'vue'
import axios from 'axios'
const state = {
    MovieData: [],
    InTheater: "",
    Genres: "",
    TopImbd: [],
    movieTtotal: ''
};

const getters = {
    GetMovies(state) {
        return state.MovieData;
    },
    getTop(state) {
        return state.InTheater;
    },

    GetTopImbd(state) {
        return state.TopImbd;
    },
    GetMovieTotal(state) {
        return state.movieTtotal
    },
    // People: state => {
    //     return state.PeopleData
    // },

    // groupSort: state => badge => {
    //     return state.MovieData.find(groupSort => groupSort.badge === badge)
    // }
};

const mutations = {
    SET_MOVIE(state, movie) {
        state.MovieData = movie.items,
            state.movieTtotal = movie.totalItems
    },
    SET_TOP_MOVIE(state, topMovie) {
        state.InTheater = topMovie
    },

    SET_TOP_IMBD(state, TopImbd) {
        // for (let i = 0; i < 5; i++)
        state.TopImbd.push(TopImbd.items)
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
        axios.get('/api/Movies/top')
            .then(response => {
                commit('SET_TOP_MOVIE', response.data)
            })
    },

    // 
    Top250Movies({ commit }) {
        axios.get('https://imdb-api.com/en/API/Top250Movies/k_l3dksm3b')
            .then(response => {
                commit('SET_TOP_IMBD', response.data)
            })
    },


}

export default {
    state,
    getters,
    mutations,
    actions,
}