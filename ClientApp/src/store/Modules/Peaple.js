// import Vue from 'vue'
import axios from 'axios'
const state = {
    PeopleData: [],
};


const getters = {
    GetPeaple(state) {
        return state.PeopleData;
    },
    // Movie: state => id => {
    //     return state.MovieData.find(Movie => Movie.id === id)
    // },
};

const mutations = {
    SET_PEOPLE(state, people) {
        state.PeopleData = people
    },

};


const actions = {
    GetPeoples({ commit }) {
        axios.get('http://localhost:5000/api/People')
            .then(response => {
                commit('SET_PEOPLE', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}