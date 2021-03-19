<template>
  <div class="container" dir="rtl">
    <div class="row">
      <div class=" my-4"></div>
    </div>
    <div class="row">
      <div class="col-md-3  text-align-right">
        <div class="card">
          <div class="card-header">
            <h4 class="text-info">
              {{ industryData.name }}
            </h4>
          </div>
          <ul class="list-group list-group-flush">
            <li
              class="list-group-item grab"
              @click="
                isInfoMode = true;
                isFinanceMode = false;
              "
            >
              مشخصات عمومی
            </li>
            <li
              class="list-group-item grab"
              @click="
                isInfoMode = false;
                isFinanceMode = true;
              "
            >
              بخش مالی
            </li>
          </ul>
        </div>
      </div>
      <div class="col-md-8 ">
        <div class="card bg-light">
          <!-- info -->
          <div v-if="isInfoMode">
            <div class="row mr-3 my-3">
              <div class="col-md-6">
                <p class="d-block text-border">
                  نام مرکز : {{ industryData.name }}
                </p>
              </div>
              <div class="col-md-6">
                <p class="d-block text-border">
                  استان : {{ industryData.city }}
                </p>
              </div>
            </div>
            <div class="row">
              <div class="col-md-6 mr-5 text-border">
                کد پستی : {{ industryData.postalCode }}
              </div>
            </div>
            <h5 class="text-info mt-4 mr-3">
              زون بندی :
            </h5>

            <div class="row my-3 mr-1">
              <div class="col-md-6">
                <p class="d-block text-border">
                  طول جغرافیایی : {{ industryData.lngitude }}
                </p>
              </div>
              <div class="col-md-6">
                <p class="d-block text-border">
                  عرض جغرافیایی : {{ industryData.latitude }}
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
          <!-- finance -->
          <div v-if="isFinanceMode">
            <div v-if="industryFinancial != null">
              <div class="row mr-3 my-3">
                <div class="col-md-6">
                  <p class="d-block text-border">
                    بیشترین حقوق : {{ industryFinancial.maxSalary }}
                  </p>
                </div>
                <div class="col-md-6">
                  <p class="d-block text-border">
                    کم ترین حقوق : {{ industryFinancial.minSalary }}
                  </p>
                </div>
              </div>
              <div class="row">
                <div class="col-md-10 mr-5 text-border">
                  میانگین حقوق = (کمترین حقوق + بیشترین حقوق) / 2 =

                  <span class="badge badge-success py-1">
                    {{ industryFinancial.averageSalary }}
                  </span>
                </div>
              </div>

              <div class="row">
                <div class="col-md-10 mr-5 text-border">
                  مالیات = میانگین حقوقی X نرخ مالیات =

                  <span class="badge badge-danger py-1">
                    {{ industryFinancial.exempt }}
                  </span>
                </div>
              </div>
              <h5 class="text-info mt-4 mr-3">
                نمودار ها :
              </h5>
              <bar-chart :industryData="industryFinancial" />
            </div>
            <!-- add fiinance -->
            <div v-else>
              <h6 class="text-info mt-3 mr-3">
                افزودن رابطه مالی
              </h6>

              <financial-form />
            </div>
          </div>
          <div class="w-100 alert alert-info mb-0">
            تاریخ آخرین بروز رسانی :

            <span dir="ltr">
              {{ industryData.updatedAt }}
            </span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import axios from "axios";
import FinancialForm from "../components/Forms/FinancialForm.vue";
import BarChart from "../components/BarChart.vue";
export default {
  components: {
    LMap,
    LTileLayer,
    LMarker,

    FinancialForm,
    BarChart
  },

  data() {
    return {
      id: this.$route.params.id,
      isInfoMode: true,
      isFinanceMode: false,
      industryData: "",
      industryFinancial: "",
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 5.3,
      center: [31.887178, 54.3579483],
      bounds: null,
      results: null,
      country: [],
      latlong: [],
      confirmed: [],
      lngitude: "",
      latitude: ""
    };
  },
  methods: {
    getIndustryById() {
      axios.get(`/api/Utm/id?id=${this.id}`).then(res => {
        this.industryData = res.data;
        this.industryFinancial = res.data.industryFinancial[0];
        this.getUtm(res.data.latitude, res.data.lngitude);
      });
    },
    onLocationFound(location) {
      console.log(location);
    },
    onReady(mapObject) {
      mapObject.locate();
    },
    getUtm(latitude, lngitude) {
      var a = [];

      a.push(latitude);
      a.push(lngitude);

      this.latlong.push(a);
    }
  },
  async mounted() {
    await this.getIndustryById();
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
</style>
