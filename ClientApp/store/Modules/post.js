// import Vue from 'vue'
const state = {
    PostData: [

    ],
    id: 1
};


const getters = {
    GetPosts(state) {
        return state.PostData;
    },

    post: state => id => {
        return state.PostData.find(post => post.id === id)
    },
    // groupSort: state => badge => {
    //     return state.PostData.find(groupSort => groupSort.badge === badge)
    // }
};

const mutations = {
    // SetPost(state, post) {
    //     state.post = post;
    // }
    AddPost(state, newPost) {
        state.PostData.push(newPost)
            // state.refreshToken = userData.refreshToken
    }
};


const actions = {
    AddPostAsync({
        commit
    }, newPost) {
        commit('AddPost',
            newPost
        )
    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}