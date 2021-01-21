import Vue from 'vue';
import Vuex from 'vuex';
import Movie from './Modules/Movie'
import post from './Modules/post'
import Peaple from './Modules/Peaple'
import Search from './Modules/Search.js'
import Country from './Modules/Country.js'
import Genres from './Modules/Genres.js'
import Auth from './Modules/Auth.js'
import Users from './Modules/Users.js'
import axios from 'axios'
Vue.use(Vuex)
export const store = new Vuex.Store({
    modules: {
        post,
        Movie,
        Peaple,
        Search,
        Country,
        Genres,
        Auth,
        Users
    },


});


const createStore = () => {

    return new Vuex.Store({
        state: {
            //AUTH
            token: null,
            tokenExpiration: null,
            isAuth: ''
        },
        mutations: {
            //AUTH
            setUser(state, payload) {
                state.token = payload.token;
                // state.userId = payload.userId;
                state.tokenExpiration = payload.tokenExpiration;
                state.isAuth = true
            },
        },
        actions: {
            //AUTH
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
        },
        getters: {
            ///AUTH
            token(state) {
                return state.token
            },
            isAuthGet(state) {
                return !!state.token
            }
        }
    });
};

export default createStore;