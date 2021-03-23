<template>
  <div class="container" dir="rtl">
    <div class="row">
      <div class="col-12 my-4">
        <h2 class="text-info">افزودن صنعت</h2>
      </div>
    </div>
    <form action="">
      <div class="row">
        <div class="col-md-4">
          <form-input
            label="کد پستی"
            :required="true"
            id="name"
            v-model="industry.postalCode"
          />
        </div>
        <div class="col-md-4">
          <form-input
            label="شهر"
            :required="true"
            id="name"
            v-model="industry.city"
          />
        </div>
        <div class="col-md-4">
          <form-input
            label="نام صنعت"
            :required="true"
            id="name"
            v-model="industry.name"
          />
        </div>
      </div>
      <h5 class="text-info mt-5 mb-0">مختصات</h5>

      <div class="row ">
        <div class="col-md-4 ">
          <button class="btn btn-danger mt-5 mx-1">
            <router-link class="text-white" to="/">
              بازگشت
            </router-link>
          </button>
          <button class="btn btn-success mt-5" @click.prevent="postIndustry">
            افزودن صنعت
          </button>
        </div>
        <div class="col-md-4">
          <form-input
            label="طول جغرافیایی"
            :required="true"
            id="name"
            v-model="industry.lngitude"
          />
        </div>
        <div class="col-md-4">
          <form-input
            label="عرض جغرافیایی"
            :required="true"
            id="name"
            v-model="industry.latitude"
          />
        </div>
      </div>
      <div class="row">
        <div class="col-md-6"></div>

        <div class="col-md-6">
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
    </form>
  </div>
</template>

<script>
import axios from "axios";
import FormInput from "../components/Forms/FormInput";
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";

export default {
  data() {
    return {
      newIndustryId: "",
      zoom: 5,
      center: [31.887178, 54.3579483],
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      latlong: [],

      industry: {
        name: "",
        city: "",
        postalCode: "",
        lngitude: "",
        latitude: ""
      }
    };
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

      this.industry.lngitude = this.latlong[1];
      this.industry.latitude = this.latlong[0];
    },
    remove() {
      this.latlong.splice(-1, 1);
    },
    postIndustry() {
      try {
        axios.post("/api/Utm", this.industry).then(res => {
          this.newIndustryId = res.data.id;
          if (res.status == 201) {
            this.$router.push(`/industry/${this.newIndustryId}`);
          }
        });
      } catch (error) {
        console.log(error);
      }
    }
  },
  components: {
    FormInput,
    LMap,
    LTileLayer,
    LMarker
  }
};
</script>

<style scoped>
.map {
  height: 50vh;
  border: 1px solid #888;
  margin-bottom: 1rem;
}
li {
  list-style: none;
}
</style>
