import axios from 'axios'
const state = {

    token: null,
    tokenExpiration: null,
    isAuth: ''
};


const getters = {
    token(state) {
        return state.token
    },
    isAuthGet(state) {
        return !!state.token
    }
};

const mutations = {
    setUser(state, payload) {
        state.token = payload.token;
        // state.userId = payload.userId;
        state.tokenExpiration = payload.tokenExpiration;
        state.isAuth = true
    },

};


const actions = {
    async login(context, payload) {
        const lg = {
            emailAddress: payload.emailAddress,
            password: payload.password
        }
        const response = await axios.post('/api/accounts/Login', lg)
        console.log(response);
        console.log(response.statusText);
        // const responseData = await response.json()
        if (response.statusText != 'OK') {
            console.log(response);
            const error = new Error(response.message || 'Failed to Authenticate');
            throw error
        }
        localStorage.setItem('token', response.data.token)
        localStorage.setItem('tokenExpiration', response.data.expiration)
        context.commit('setUser', {
            token: response.data.token,
            // userId: response.localId,
            tokenExpiration: response.data.expiration,

        })

    },
    // async signup(context, payload) {
    //     const response = await fetch(
    //         'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyBdFe6J_9HARP8yPmNEIaW5VY5qH86lhR8', {
    //             method: 'POST',
    //             body: JSON.stringify({
    //                 email: payload.email,
    //                 password: payload.password,
    //                 returnSecureToken: true
    //             })
    //         });
    //     const responseData = await response.json()
    //     if (!response.ok) {
    //         console.log(responseData);
    //         const error = new Error(responseData.message || 'Failed to Authenticate');
    //         throw error
    //     }
    //     console.log(responseData);
    //     context.commit('setUser', {
    //         token: responseData.idToken,
    //         userId: responseData.localId,
    //         tokenExpiration: responseData.expiresIn
    //     })
    // },

    autoLog(context) {
        const Token = localStorage.getItem('token');
        const TokenExpiration = localStorage.getItem('tokenExpiration')
        console.log(Token);
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
}

export default {
    state,
    getters,
    mutations,
    actions,
}