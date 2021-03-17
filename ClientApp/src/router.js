import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter)
import Brew from './components/Brew.vue'
export const Routes = [
  // history: createWebHistory(),
  {
    path: '/',
    component: Brew
  }
  ]
