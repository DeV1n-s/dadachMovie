// import Vue from 'vue'
import axios from 'axios'
import { store } from '../store.js'

const state = {
    UsersData: [],
    TotalUsers: ''
};


const getters = {
    GetUsers(state) {
        return state.UsersData;
    },
    GetTotalUsers(state) {
        return state.TotalUsers;
    }
    // Movie: state => id => {
    //     return state.MovieData.find(Movie => Movie.id === id)
    // },

};

const mutations = {
    SET_USERS(state, Users) {
        state.UsersData = Users.items;
        state.TotalUsers = Users.totalItems
    },

};

let token = localStorage.getItem('token');
let token2 = store



const actions = {
    GetUsers({ commit }) {
        console.log(token2);
        axios.get('/api/accounts/Users', {
                headers: {
                    'Authorization': ` Bearer ${token}`
                }
            })
            .then(response => {
                commit('SET_USERS', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}