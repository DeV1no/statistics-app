<template>
  <nav class="sidebar-navigation">
    <ul class="w-100">
      <router-link to="/" active-class="active" exact>
        <li class="a">
          <i class="fa fa-map"></i>

          <span class="tooltip">لیست مناطق</span>
        </li>
      </router-link>
      <li>
        <router-link to="/IndustryAdd" active-class="active">
          <i class="fa fa-plus"></i>

          <span class="tooltip">افزودن صنعت</span>
        </router-link>
      </li>
      <li class="ml-5">
        <router-link to="/charts" active-class="active">
          <i class="fas fa-chart-bar"></i>
          <span class="tooltip">آمار و ارقام</span>
        </router-link>
      </li>
      <li>
        <i class="fa fa-newspaper-o"></i>
        <span class="tooltip">Contacts</span>
      </li>
      <li>
        <i class="fa fa-print"></i>
        <span class="tooltip">Fax</span>
      </li>
      <li>
        <i class="fa fa-sliders"></i>
        <span class="tooltip">Settings</span>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {};
</script>

<style scoped>
.fa {
  margin-left: 1rem;
}
ul li {
  list-style: none;
}

.sidebar-navigation {
  display: inline-block;
  min-height: 140vh;
  width: 80px;
  background-color: #313443;
  float: left;
}
.sidebar-navigation ul {
  text-align: center;
  color: white;
}
.sidebar-navigation ul li {
  padding: 28px 0;
  cursor: pointer;
  transition: all ease-out 120ms;
}
.sidebar-navigation ul li i {
  display: block;
  font-size: 24px;
  transition: all ease 450ms;
}
.tooltip {
  color: azure !important;
}
.sidebar-navigation ul li .tooltip {
  display: inline-block;
  position: absolute;
  background-color: #313443;
  padding: 8px 15px;
  border-radius: 3px;
  margin-top: -26px;
  left: 90px;
  opacity: 0;
  visibility: hidden;
  font-size: 13px;
  letter-spacing: 0.5px;
}
.sidebar-navigation ul li .tooltip:before {
  content: "";
  display: block;
  position: absolute;
  left: -4px;
  top: 10px;
  transform: rotate(45deg);
  width: 10px;
  height: 10px;
  background-color: inherit;
}
.sidebar-navigation ul li:hover {
  color: brown;
}
.sidebar-navigation ul li:hover .tooltip {
  visibility: visible;
  opacity: 1;
}

.sidebar-navigation ul li.active {
  color: brown !important;
}
.sidebar-navigation ul li.active i {
  color: brown !important;
}
</style>
