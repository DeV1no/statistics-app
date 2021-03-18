<template>
  <div dir="rtl">
    <side-bar></side-bar>
    <router-view id="app" />
  </div>
</template>

<script>
import SideBar from "./components/SideBar.vue";
export default {
  components: {
    SideBar
  },
  name: "App"
};
</script>

<style>
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  font-family: "Sahel" !important;
  direction: ltr;
  text-align: right !important;
}

@font-face {
  font-family: Sahel;
  src: url(../public/Sahel.woff);
}

a {
  text-decoration: none;
}

a:hover {
  text-decoration: none !important;
  border: none !important;
}

.active {
  color: brown;
}
.grab {
  cursor: -webkit-grab;
  cursor: grab;
}
</style>
