import Vue from 'vue'
import Router from 'vue-router'
import { normalizeURL, decode } from '@nuxt/ufo'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _7d409032 = () => interopDefault(import('../pages/Admin/index.vue' /* webpackChunkName: "pages/Admin/index" */))
const _477f315d = () => interopDefault(import('../pages/Home/index.vue' /* webpackChunkName: "pages/Home/index" */))
const _dccc8bfe = () => interopDefault(import('../pages/Movies/index.vue' /* webpackChunkName: "pages/Movies/index" */))
const _4e2586be = () => interopDefault(import('../pages/Register/index.vue' /* webpackChunkName: "pages/Register/index" */))
const _f3dedae8 = () => interopDefault(import('../pages/Home/home-news.vue' /* webpackChunkName: "pages/Home/home-news" */))
const _a58eb54c = () => interopDefault(import('../pages/Home/home-slider.vue' /* webpackChunkName: "pages/Home/home-slider" */))
const _7f3dcb24 = () => interopDefault(import('../pages/Home/in-theater.vue' /* webpackChunkName: "pages/Home/in-theater" */))
const _736df4a3 = () => interopDefault(import('../pages/Home/soon-movie.vue' /* webpackChunkName: "pages/Home/soon-movie" */))
const _5e9e7bb6 = () => interopDefault(import('../pages/Movies/MovieGrid.vue' /* webpackChunkName: "pages/Movies/MovieGrid" */))
const _13f42492 = () => interopDefault(import('../pages/People/Cast/index.vue' /* webpackChunkName: "pages/People/Cast/index" */))
const _7ef98b28 = () => interopDefault(import('../pages/Register/RegisterForm.vue' /* webpackChunkName: "pages/Register/RegisterForm" */))
const _947a6900 = () => interopDefault(import('../pages/People/Cast/PeopleGrid.vue' /* webpackChunkName: "pages/People/Cast/PeopleGrid" */))
const _8c88cef2 = () => interopDefault(import('../pages/index.vue' /* webpackChunkName: "pages/index" */))

// TODO: remove in Nuxt 3
const emptyFn = () => {}
const originalPush = Router.prototype.push
Router.prototype.push = function push (location, onComplete = emptyFn, onAbort) {
  return originalPush.call(this, location, onComplete, onAbort)
}

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: '/',
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/Admin",
    component: _7d409032,
    name: "Admin"
  }, {
    path: "/Home",
    component: _477f315d,
    name: "Home"
  }, {
    path: "/Movies",
    component: _dccc8bfe,
    name: "Movies"
  }, {
    path: "/Register",
    component: _4e2586be,
    name: "Register"
  }, {
    path: "/Home/home-news",
    component: _f3dedae8,
    name: "Home-home-news"
  }, {
    path: "/Home/home-slider",
    component: _a58eb54c,
    name: "Home-home-slider"
  }, {
    path: "/Home/in-theater",
    component: _7f3dcb24,
    name: "Home-in-theater"
  }, {
    path: "/Home/soon-movie",
    component: _736df4a3,
    name: "Home-soon-movie"
  }, {
    path: "/Movies/MovieGrid",
    component: _5e9e7bb6,
    name: "Movies-MovieGrid"
  }, {
    path: "/People/Cast",
    component: _13f42492,
    name: "People-Cast"
  }, {
    path: "/Register/RegisterForm",
    component: _7ef98b28,
    name: "Register-RegisterForm"
  }, {
    path: "/People/Cast/PeopleGrid",
    component: _947a6900,
    name: "People-Cast-PeopleGrid"
  }, {
    path: "/",
    component: _8c88cef2,
    name: "index"
  }],

  fallback: false
}

function decodeObj(obj) {
  for (const key in obj) {
    if (typeof obj[key] === 'string') {
      obj[key] = decode(obj[key])
    }
  }
}

export function createRouter () {
  const router = new Router(routerOptions)

  const resolve = router.resolve.bind(router)
  router.resolve = (to, current, append) => {
    if (typeof to === 'string') {
      to = normalizeURL(to)
    }
    const r = resolve(to, current, append)
    if (r && r.resolved && r.resolved.query) {
      decodeObj(r.resolved.query)
    }
    return r
  }

  return router
}
