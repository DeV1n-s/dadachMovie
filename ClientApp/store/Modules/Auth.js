import axios from 'axios'

const state = {

    token: null,
    tokenExpiration: null,
    isAuth: ''
};
const mutations = {

    setUser(state, payload) {
        state.token = payload.token;
        // state.userId = payload.userId;
        state.tokenExpiration = payload.tokenExpiration;
        state.isAuth = true
    },
}
const actions = {

    async login(context, payload) {
        const lg = {
            emailAddress: payload.emailAddress,
            password: payload.password
        }
        await axios.post('/api/accounts/Login', lg).then(res => {
            console.log(res.statusText);
            if (res.statusText != 'OK') {

                alert('ورود انجام نشد')
            }
            localStorage.setItem('token', res.data.token)
            localStorage.setItem('tokenExpiration', res.data.expiration)
            context.commit('setUser', {
                token: res.data.token,
                userId: res.localId,
                tokenExpiration: res.data.expiration,

            })
        })





    },
    autoLog(context) {
        const Token = localStorage.getItem('token');
        const TokenExpiration = localStorage.getItem('tokenExpiration')
        if (Token) {
            context.commit('setUser', {
                token: Token,
                tokenExpiration: TokenExpiration

            })
        }
    },

    logOut(context) {
        localStorage.removeItem('token')
        localStorage.removeItem('tokenExpiration')

        context.commit('setUser', {
            token: null,
            userId: null,
            tokenExpiration: null,
            isAuth: false
        })

    }
};
const getters = {
    token(state) {
        return state.token
    },
    isAuthGet(state) {
        return !!state.token
    }
}


export default {
    state,
    actions,
    getters,
    mutations
};