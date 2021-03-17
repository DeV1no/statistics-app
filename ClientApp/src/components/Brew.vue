<template>
  <div class="container" dir="rtl">
    <div class="row">
      <div class="col-12 my-4">
        <h2 class=" text-info">لیست مناطق</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-6 brew-list float-left">
        <div class="card" style="width:18rem">
          <ul class="list-group list-group-flush">
            <li class="li list-group-item" v-for="u in utm" :key="u.id">
              {{ u.name }} , {{ u.city }}
            </li>
          </ul>
        </div>
      </div>
      <div class="col-6">
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
                <LMarker :lat-lng="l"
                  ><l-tooltip>{{ l[2] }}</l-tooltip></LMarker
                >
              </li>
            </ul>
          </LMap>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { LMap, LTileLayer, LMarker, LTooltip } from "vue2-leaflet";

import axios from "axios";
export default {
  name: "Map",
  components: {
    LMap,
    LTileLayer,
    LMarker,
    LTooltip
  },
  data() {
    return {
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 5.3,
      center: [31.887178, 54.3579483],
      bounds: null,
      utm: [],

      results: null,
      country: [],
      latlong: [],
      confirmed: []
    };
  },
  methods: {
    onLocationFound(location) {
      console.log(location);
    },
    onReady(mapObject) {
      mapObject.locate();
    },
    getUtm() {
      axios
        .get("/api/Utm")

        .then(res => {
          res.data.forEach(q => {
            var a = [];
            a.push(q.latitude);
            a.push(q.lngitude);
            a.push(q.name);
            this.latlong.push(a);
            console.log(this.latlong);
          });
          this.utm = res.data;
        });
    }
  },
  mounted() {
    this.getUtm();
  }
};
</script>
<style scoped>
.map {
  height: 80vh;
  border: 1px solid #888;
}
ul li {
  list-style: none;
}
</style>
