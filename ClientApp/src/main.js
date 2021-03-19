import App from './App.vue'
import Vue from 'vue'
import VueRouter from 'vue-router'
import 'leaflet/dist/leaflet.css';
import { Icon } from "leaflet";
import LiquorTree from 'liquor-tree'

delete Icon.Default.prototype._getIconUrl;

Icon.Default.mergeOptions({
    iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
    iconUrl: require("leaflet/dist/images/marker-icon.png"),
    shadowUrl: require("leaflet/dist/images/marker-shadow.png")
});
Vue.use(VueRouter)
Vue.use(LiquorTree)

Vue.config.productionTip = false
import {
    Routes
} from './router'
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
    router,
    render: h => h(App),
}).$mount('#app')