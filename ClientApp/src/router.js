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
import CastPanel from './pages/Admin/Cast/CastPanel.vue'
import CastAdd from './pages/Admin/Cast/CastAdd.vue'
import UserProfile from './pages/UserProfile/UserProfile'
import Top250Movies from './pages/Top250IMDB/Top250IMDB.vue'
import Top250Single from './pages/Top250IMDB/MovieSingle.vue'
import MovieListGenre from './pages/MovieListGenre/MovieListGenre.vue'
import NotFound from './pages/404/404.vue'
import MovieListTitleSearch from './pages/MovieListTitleSearch/MovieListTitleSearch.vue'
// import MovieSortGenre from './pages/MovieList/MovieSortGenre.vue '

const router = createRouter({
    history: createWebHistory(),
    routes: [

        { path: '/', component: Home },
        { path: '/UserProfile', component: UserProfile },
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
        { path: '/CastPanel', component: CastPanel },
        { path: '/CastAdd', component: CastAdd },
        { path: '/Top250Movies', component: Top250Movies },
        { path: '/Top250Single/:id', name: 'Top250Single', component: Top250Single },
        { path: '/MovieListGenre/:id', name: 'MovieListGenre', component: MovieListGenre },
        { path: '/MovieListTitleSearch/:id', name: 'MovieListTitleSearch', component: MovieListTitleSearch },

        { path: '/404', component: NotFound },  
        {
            // path: "*",
            path: "/:catchAll(.*)",
            name: "NotFound",
            component: NotFound,
            meta: {
              requiresAuth: false
            }
          }
        // { path: '/MovieSortGenre/:id', name: 'MovieSortGenre', component: MovieSortGenre }
        

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