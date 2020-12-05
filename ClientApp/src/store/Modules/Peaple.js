// import Vue from 'vue'
import axios from 'axios'
const state = {
    PeopleData: [],
};


const getters = {
    GetPeaple(state) {
        return state.PeopleData;
    },
    Movie: state => id => {
        return state.MovieData.find(Movie => Movie.id === id)
    },
};

const mutations = {
    SET_People(state, people) {
        state.PeopleData = people
    },

};


const actions = {
    getPeople({ commit }) {
        axios.get('https://localhost:5001/api/people')
            .then(response => {
                commit('SET_People', response.data)
            })
    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}