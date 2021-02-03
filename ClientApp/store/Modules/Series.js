// import Vue from 'vue'
import axios from 'axios'
const state = {
    SeriesData: [],
    SeriesTotal: ''
};

const getters = {
    GetSeries(state) {
        return state.SeriesData;
    },
    GetSeriesTotal(state) {
        return state.SeriesTotal
    }

};

const mutations = {
    SET_SERIES(state, Series) {
        state.SeriesData = Series.items,
            state.SeriesTotal = Series.totalItems
    },
};


const actions = {
    getSeries({ commit }) {
        axios.get('/api/series')
            .then(response => {
                commit('SET_SERIES', response.data)
            })
    },

}

export default {
    state,
    getters,
    mutations,
    actions,
}