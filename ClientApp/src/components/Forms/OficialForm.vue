<template>
  <div>
    <div class="row mr-2">
      <div class="col-md-5">
        <form-input
          label="نام دفتر مرکزی"
          :required="true"
          id="name"
          v-model="oficialCenter.name"
        />
      </div>
      <div class="col-md-5">
        <form-input
          label="شهر"
          :required="true"
          id="name"
          v-model="oficialCenter.city"
        />
      </div>
    </div>
    <div class="row mr-2">
      <div class="col-md-8">
        <form-input
          label="کدپستی"
          :required="true"
          id="name"
          v-model="oficialCenter.postalCode"
          type="number"
        />
      </div>
    </div>
    <div class="row mr-2">
      <div class="col-md-5">
        <form-input
          label="طول جغرافیایی"
          :required="true"
          id="name"
          v-model="oficialCenter.lngitude"
        />
      </div>
      <div class="col-md-5">
        <form-input
          label="عرض جغرافیایی"
          :required="true"
          id="name"
          v-model="oficialCenter.latitude"
        />
      </div>
    </div>
    <div class="row">
      <div class="col-md-11 mr-4">
        <div class="map">
          <LMap
            @click="add"
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
    </div>
    <div class="row my-2">
      <div class="col-md-5 mr-auto ml-5 mb-2">
        <button class="btn btn-block  btn-success mr-1" @click="postOficeRell">
          ثبت دفتر مرکزی
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";

import FormInput from "./FormInput";
import axios from "axios";
export default {
  data() {
    return {
      id: this.$route.params.id,
      zoom: 5.2,
      center: [31.887178, 54.3579483],
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      latlong: [],
      oficialCenter: {
        name: "",
        city: "",
        lngitude: 0,
        latitude: 0,
        postalCode: 0,
        utmId: []
      }
    };
  },
  components: {
    FormInput,
    LMap,
    LTileLayer,
    LMarker
  },
  methods: {
    onReady(mapObject) {
      mapObject.locate();
    },
    onLocationFound(location) {
      console.log(location);
    },
    add(event) {
      this.latlong.push(event.latlng.lat);
      this.latlong.push(event.latlng.lng);

      this.oficialCenter.lngitude = this.latlong[1];
      this.oficialCenter.latitude = this.latlong[0];
    },
    remove() {
      this.latlong.splice(-1, 1);
    },
    postOficeRell() {
      this.oficialCenter.utmId.push(this.id);
      axios
        .post("/api/CentralOficeController", this.oficialCenter)
        .then(res => console.log(res.data));
    }
  }
};
</script>

<style scoped>
.map {
  height: 65vh;
  border: 1px solid #888;
  margin-bottom: 1rem;
}
li {
  list-style: none;
}
.text-border {
  background-color: rgb(247, 244, 244) !important;
  -webkit-box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  padding: 0.45rem;
}
</style>
