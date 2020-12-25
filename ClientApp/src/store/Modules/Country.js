// import Vue from 'vue'
import axios from 'axios'
const state = {
    CountryData: [],
};


const getters = {
    GetCountry(state) {
        return state.CountryData;
    },
    // Movie: state => id => {
    //     return state.MovieData.find(Movie => Movie.id === id)
    // },

};

const mutations = {
    SET_COUNTRY(state, Country) {
        state.CountryData = Country
    },

};


const actions = {
    GetCountry({ commit }) {
        axios.get('/api/Countries')
            .then(response => {
                commit('SET_COUNTRY', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}