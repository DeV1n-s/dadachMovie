// import Vue from 'vue'
import axios from 'axios'
const state = {
    MovieData: [{
            id: 99999,
            rate: '9.8',
            Release: '11/29/2020',
            Director: 'دانیال',
            Cast: 'آریا-سجاد-رضا',
            title: 'فیلم زیبا . دیدنی',
            shortPara: 'این فیلمیست توسط بچه های تی اس بکس ساخته شده ',
            longPara: '',
            Genre: 'اکشن',
            img: 'http://localhost:8080/images/uploads/mv2.jpg'
        },

        {
            id: 999999,
            rate: '9.7',
            Release: '11/29/2020',
            Director: 'آریا',
            Cast: 'فرشاد- داداچ- پروت',
            title: 'فیلم خفن داداچ',
            shortPara: 'ا طراحی های گرافیکی سروکار دارید به متن های برخورده اید که با نام لورم ایپسوم شناخته می‌شوند. لورم ایپسوم یا طرح‌نما (به انگلیسی: Lorem ipsum) م ',
            longPara: 'اگر شما یک طراح هستین و یا با طراحی های گرافیکی سروکار دارید به متن های برخورده اید که با نام لورم ایپسوم شناخته می‌شوند. لورم ایپسوم یا طرح‌نما (به انگلیسی: Lorem ipsum) متنی ساختگی و بدون معنی است که برای امتحان فونت و یا پر کردن فضا در یک طراحی گرافیکی و یا صنعت چاپ استفاده میشود. ',
            Genre: 'اکشن',
            img: 'http://localhost:8080/images/uploads/mv3.jpg'
        }


    ],
    id: 1
};


const getters = {
    GetMovies(state) {
        return state.MovieData;
    },
    Movie: state => id => {
        return state.MovieData.find(Movie => Movie.id === id)
    },
    // groupSort: state => badge => {
    //     return state.MovieData.find(groupSort => groupSort.badge === badge)
    // }
};

const mutations = {
    // SetPost(state, post) {
    //     state.post = post;
    // }
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
    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}