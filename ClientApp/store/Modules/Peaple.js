// import Vue from 'vue'
import axios from 'axios'
const state = {
    PeopleData: [],
    PeopleCount: ''
};


const getters = {
    GetPeaple(state) {
        return state.PeopleData;
    },
    GetPeopleCount(state) {
        return state.PeopleCount
    }
    // Movie: state => id => {
    //     return state.MovieData.find(Movie => Movie.id === id)
    // },
    // Peoples: state => id => {
    //     return state.PeopleData.find(People => People.id === id)
    // },
};

const mutations = {
    SET_PEOPLE(state, people) {
        state.PeopleData = people.items
    },
    SET_PEOPLE_COUNT(state, people) {
        state.PeopleCount = people.totalItems
    }
};


const actions = {
    GetPeoples({ commit }) {
        axios.get('http://localhost:8080/api/People')
            .then(response => {
                commit('SET_PEOPLE', response.data)
                commit('SET_PEOPLE_COUNT', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}