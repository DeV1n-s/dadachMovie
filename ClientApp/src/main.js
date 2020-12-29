import Vue from 'vue'
import App from './App.vue'
// import VueResource from 'vue-resource';
import VueRouter from 'vue-router';

import {
    Routes
} from './router'


import {
    store
} from './store/store.js';


// import store from './store/store.js'
Vue.config.productionTip = false
Vue.use(VueRouter);
// Vue.use(VueResource);

export const router = new VueRouter({
    routes: Routes,
    mode: 'history',
    scrollBehavior() {
        return {
            x: 0,
            y: 0
        };
    }
});

new Vue({
    el: '#app',
    store,
    router,
    render: h => h(App)
});