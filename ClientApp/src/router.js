import { createRouter, createWebHistory } from 'vue-router';
import Home from './pages/Home/Home.vue'
import MovieList from './pages/MovieList/MovieList.vue'
import ActorList from './pages/Actors/ActorList.vue'
import News from './pages/News/NewsList.vue'
import MovieSingle from './pages/MovieSingle/MovieSingle.vue'
import MoviePanel from './pages/Admin/Movie/MoviePanel.vue'
import MovieAdd from './pages/Admin/Movie/MovieAdd.vue'
import NewsSingle from './pages/News/NewsSingle'
import NewsPanel from './pages/Admin/News/NewsPanel.vue'
import NewsAdd from './pages/Admin/News/NewsAdd.vue'
import ActorSingle from './pages/Actors/ActorSingle.vue'
const router = createRouter({
    history: createWebHistory(),
    routes: [

        { path: '/', component: Home },
        { path: '/MovieList', component: MovieList },
        { path: '/ActorList', component: ActorList },
        { path: '/News', component: News },
        { path: '/MovieSingle/:id', name: 'MovieSingle', component: MovieSingle },
        { path: '/MoviePanel', component: MoviePanel },
        { path: '/MovieAdd', component: MovieAdd },
        { path: '/NewsSingle/:id', name: 'NewsSingle', component: NewsSingle },
        { path: '/NewsPanel', component: NewsPanel },
        { path: '/NewsAdd', component: NewsAdd },
        { path: '/ActorSingle/:id', name: 'ActorSingle', component: ActorSingle },


        // { path: '/PostData', component: PostData, meta: { requiresAuth: true } },
    ],

});
// router.beforeEach(function(to, _, next) {
//     if (to.meta.requiresAuth && !store.state.auth.isAuth) {
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

export default router;