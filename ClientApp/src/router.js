import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter)
import Brew from './components/Brew.vue'
import IndustryAdd from "./Pages/IndustryAdd"
export const Routes = [
    // history: createWebHistory(),
    {
        path: '/',
        component: Brew
    },
    {
        path: '/IndustryAdd',
        component: IndustryAdd
    }
]