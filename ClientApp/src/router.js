import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter)
import Brew from './components/Brew.vue'
import IndustryAdd from "./Pages/IndustryAdd"
import IndustrySingle from "./Pages/IndustrySingle"
export const Routes = [
    // history: createWebHistory(),
    {
        path: '/',
        component: Brew
    },
    {
        path: '/IndustryAdd',
        component: IndustryAdd
    },
    {
        path: '/Industry/:id',
        name: 'Industry',
        component: IndustrySingle
    }
]