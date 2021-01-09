import Vue from 'vue'
import VueRouter from 'vue-router'
import {
    store
} from './store/store.js';
import HomeContainer from './HomeContainer.vue'
import Home from './pages/Home/Home.vue'
import MovieList from './pages/MovieList/MovieList.vue'
import ActorList from './pages/Actors/ActorList.vue'
import News from './pages/News/NewsList.vue'
import MovieSingle from './pages/MovieSingle/MovieSingle.vue'
import MoviePanel from './pages/Admin/Movie/MoviePanel.vue'
import MovieAdd from './pages/Admin/Movie/MovieAdd.vue'
import NewsSingle from './pages/News/NewsSingle'
// import NewsPanel from './pages/Admin/News/NewsPanel.vue'
import NewsAdd from './pages/Admin/News/NewsAdd.vue'
import ActorSingle from './pages/Actors/ActorSingle.vue'
import CastPanel from './pages/Admin/Cast/CastPanel.vue'
import CastAdd from './pages/Admin/Cast/CastAdd.vue'
import UserProfile from './pages/UserProfile/UserProfile'
import Top250Movies from './pages/Top250IMDB/Top250IMDB.vue'
import Top250Single from './pages/Top250IMDB/MovieSingle.vue'
import MovieListGenre from './pages/MovieListGenre/MovieListGenre.vue'
import NotFound from './pages/404/404.vue'
import MovieListTitleSearch from './pages/MovieListTitleSearch/MovieListTitleSearch.vue'
import ActorListsSearch from './pages/ActorsSearch/ActorListsSearch.vue'
import AdminContainer from './AdminContaner.vue'
import Dashbord from './pages/Admin/Dashbord.vue'
// import MovieEdit from './pages/Admin/Movie/MovieEdit.vue'
// import MovieSortGenre from './pages/MovieList/MovieSortGenre.vue '
Vue.use(VueRouter)

export const Routes = [
    // history: createWebHistory(),


    {

        path: '/',
        component: HomeContainer,
        children: [
            { path: '/', component: Home },
            { path: '/UserProfile', component: UserProfile, meta: { requiresAuth: true } },
            { path: '/MovieList', component: MovieList },
            { path: '/ActorList', component: ActorList },
            { path: '/News', component: News },
            { path: '/MovieSingle/:id', name: 'MovieSingle', component: MovieSingle },
            // { path: '/MoviePanel', component: MoviePanel, meta: { requiresAuth: true } },
            { path: '/NewsSingle/:id', name: 'NewsSingle', component: NewsSingle },
            // { path: '/NewsPanel', component: NewsPanel, meta: { requiresAuth: true } },
            { path: '/NewsAdd', component: NewsAdd },
            { path: '/ActorSingle/:id', name: 'ActorSingle', component: ActorSingle },
            // { path: '/CastPanel', component: CastPanel, meta: { requiresAuth: true } },
            // { path: '/CastAdd', component: CastAdd, meta: { requiresAuth: true } },
            { path: '/Top250Movies', component: Top250Movies },
            { path: '/Top250Single/:id', name: 'Top250Single', component: Top250Single },
            { path: '/MovieListGenre/:id', name: 'MovieListGenre', component: MovieListGenre },
            { path: '/MovieListTitleSearch/:id', name: 'MovieListTitleSearch', component: MovieListTitleSearch },
            { path: '/ActorListsSearch/:id', name: 'ActorListsSearch', component: ActorListsSearch },

        ]
    },
    {
        beforeEnter(to, _, next) {
            console.log(localStorage.getItem('token'));
            console.log(store.getters.isAuthGet);
            if (to.meta.requiresAuth && !store.getters.isAuthGet) {
                next();
            } else {
                next();
            }
        },
        path: '/admin',
        component: AdminContainer,
        meta: { requiresAuth: true },
        children: [
            { path: '/dashbord', component: Dashbord },
            { path: '/MoviePanels', component: MoviePanel, meta: { requiresAuth: true } },
            { path: '/CastPanels', component: CastPanel, meta: { requiresAuth: true } },
            { path: '/CastAdd', component: CastAdd, meta: { requiresAuth: true } },
            { path: '/CastEdit/:id', name: 'CastEdit', component: CastAdd, meta: { requiresAuth: true } },
            { path: '/MovieAdd', component: MovieAdd, meta: { requiresAuth: true } },
            { path: '/MovieEdit/:id', name: 'MovieEdit', component: MovieAdd, meta: { requiresAuth: true } },

        ]

    },

    { path: '/#', redirect: '/' },
    { path: '/404', component: NotFound },
    {
        // path: "*",
        path: "/:catchAll(.*)",
        name: "NotFound",
        component: NotFound,
        meta: {
            requiresAuth: false
        }
    },

    // { path: '/MovieSortGenre/:id', name: 'MovieSortGenre', component: MovieSortGenre }


    // { path: '/PostData', component: PostData, meta: { requiresAuth: true } },


];
// Routes.beforeEach((to, _, next) => {
//     if (to.meta.requiresAuth && !store.getters.isAuthGet) {
//         next('/');
//     } else if (to.meta.requiresUnauth && store.state.auth.isAuth) {
//         next('/');
//     } else {
//         next();
//     }
//     // if (to.meta.requiresAuth && store.state.auth.isAuth) {
//     //     next()
//     // }
// })