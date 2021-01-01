import Vue from 'vue'
import App from './App.vue'
// import VueResource from 'vue-resource';
import VueRouter from 'vue-router';
import VueGoodTablePlugin from 'vue-good-table';
Vue.use(VueGoodTablePlugin);
import 'vue-good-table/dist/vue-good-table.css'
import 'vue-multiselect/dist/vue-multiselect.min.css'
import 'vue-search-select/dist/VueSearchSelect.css'
import { ModelSelect } from 'vue-search-select'

import Multiselect from 'vue-multiselect'
Vue.component('multiselect', Multiselect)
Vue.component('ModelSelect', ModelSelect)




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