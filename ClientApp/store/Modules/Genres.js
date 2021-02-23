// import Vue from 'vue'
import axios from 'axios'
const state = {
    GenreData: [],
};


const getters = {
    GetGenres(state) {
        return state.GenreData;
    },
    // Movie: state => id => {
    //     return state.MovieData.find(Movie => Movie.id === id)
    // },

};

const mutations = {
    SET_GENRES(state, Genres) {
        state.GenreData = Genres.items
    },

};


const actions = {
    GetGenres({ commit }) {
        axios.get('/api/genres?PageSize=990')
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