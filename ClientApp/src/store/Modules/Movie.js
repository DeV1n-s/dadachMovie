// import Vue from 'vue'
import axios from 'axios'
const state = {
    MovieData: [],
    PeopleData: [],
    id: 1
};


const getters = {
    GetMovies(state) {
        return state.MovieData;
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
    // SetPost(state, post) {
    //     state.post = post;
    // }
    SET_People(state, people) {
        state.PeopleData = people
    },
    SET_MOVIE(state, movie) {
        state.MovieData = movie
            // state.refreshToken = userData.refreshToken
    }
};


const actions = {
    getMovie({ commit }) {
        axios.get('https://dadach-movie.firebaseio.com/News.json')
            .then(response => {
                commit('SET_MOVIE', response.data)
            })
    },
    getPeople({ commit }) {
        axios.get('http://localhost:8080/api/people')
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