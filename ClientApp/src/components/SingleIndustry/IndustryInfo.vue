<template>
  <div>
    <div class="row mr-3 my-3">
      <div class="col-md-6">
        <p class="d-block text-border">
          نام مرکز : {{ industryDataAr[0].name }}
        </p>
      </div>
      <div class="col-md-6">
        <p class="d-block text-border">استان : {{ industryDataAr[0].city }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6 mr-5 text-border">
        کد پستی : {{ industryDataAr[0].postalCode }}
      </div>
    </div>
    <h5 class="text-info mt-4 mr-3">
      زون بندی :
    </h5>

    <div class="row my-3 mr-1">
      <div class="col-md-6">
        <p class="d-block text-border">
          طول جغرافیایی : {{ industryDataAr[0].lngitude }}
        </p>
      </div>
      <div class="col-md-6">
        <p class="d-block text-border">
          عرض جغرافیایی : {{ industryDataAr[0].latitude }}
        </p>
      </div>
    </div>
    <div class="map row">
      <LMap
        @ready="onReady"
        @locationfound="onLocationFound"
        :zoom="zoom"
        :center="center"
      >
        <LTileLayer :url="url"></LTileLayer>

        <ul>
          <li v-for="(l, i) in latlong" :key="i">
            <LMarker :lat-lng="l"></LMarker>
          </li>
        </ul>
      </LMap>
    </div>
  </div>
</template>

<script>
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
export default {
  props: {
    latlong: Array,
    industryDataAr: Array
  },
  components: {
    LMap,
    LTileLayer,
    LMarker
  },
  data() {
    return {
      id: this.$route.params.id,
      industryData: "",
      centralOfice: "",
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 5.3,
      center: [31.887178, 54.3579483],
      bounds: null,
      results: null,
      country: [],
      //   latlong: [],
      confirmed: [],
      lngitude: "",
      latitude: ""
    };
  },
  methods: {
    onLocationFound(location) {
      console.log(location);
    },
    onReady(mapObject) {
      mapObject.locate();
    }
  }
};
</script>

<style scoped>
.container {
  direction: rtl !important;
}
.map {
  height: 80vh;
  border: 1px solid #888;
}
.text-align-right {
  text-align: right;
}

.text-border {
  background-color: rgb(247, 244, 244) !important;
  -webkit-box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  padding: 0.45rem;
}
.map {
  width: 95%;
  margin-right: 10px;
  height: 550px;
  margin-bottom: 10px;
}
ul li {
  list-style: none;
}
</style>
