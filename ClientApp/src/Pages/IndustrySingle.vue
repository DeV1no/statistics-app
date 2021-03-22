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
                isOficialCenterMode = false;
              "
            >
              مشخصات عمومی
            </li>
            <li
              class="list-group-item grab"
              @click="
                isInfoMode = false;
                isFinanceMode = true;
                isOficialCenterMode = false;
              "
            >
              بخش مالی
            </li>
            <li
              class="list-group-item grab"
              @click="
                isInfoMode = false;
                isFinanceMode = false;
                isOficialCenterMode = true;
              "
            >
              دفتر مرکزی
            </li>
          </ul>
        </div>
      </div>
      <div class="col-md-8 ">
        <div class="card bg-light">
          <!-- info -->
          <industry-info
            v-if="isInfoMode"
            :industryDataAr="industryDataAr"
            :latlong="latlong"
          />
          <!-- finance -->
          <industry-finance
            v-if="isFinanceMode"
            :industryFinancial="industryFinancial"
          />
          <!-- oficial Center -->
          <oficial-center
            v-if="isOficialCenterMode"
            :centralOfice="centralOfice"
          />

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
import axios from "axios";
import IndustryInfo from "../components/SingleIndustry/IndustryInfo.vue";
import IndustryFinance from "../components/SingleIndustry/IndustryFinance.vue";
import OficialCenter from "../components/SingleIndustry/OficialCenter.vue";
export default {
  components: {
    IndustryInfo,
    IndustryFinance,
    OficialCenter
  },

  data() {
    return {
      id: this.$route.params.id,
      isInfoMode: true,
      isFinanceMode: false,
      isOficialCenterMode: false,
      industryData: "",
      industryDataAr: [],
      industryFinancial: "",
      centralOfice: "",
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
        this.industryFinancial = res.data.industryFinancial;
        this.centralOfice = res.data.centralOfice;
        this.getUtm(res.data.latitude, res.data.lngitude, res.data.name);
        console.log(res.data.centralOfice.length !== 0);
        if (res.data.centralOfice.length !== 0) {
          this.getOficialUtm(
            res.data.centralOfice[0].latitude,
            res.data.centralOfice[0].lngitude,
            res.data.centralOfice[0].name
          );
        }
        this.industryDataAr.push(res.data);
      });
    },
    onLocationFound(location) {
      console.log(location);
    },
    onReady(mapObject) {
      mapObject.locate();
    },
    getUtm(latitude, lngitude, name) {
      var a = [];

      a.push(latitude);
      a.push(lngitude);
      a.push(name);

      this.latlong.push(a);
    },
    getOficialUtm(olatitude, olngitude, oname) {
      var b = [];
      b.push(olatitude);
      b.push(olngitude);
      b.push(oname);
      this.latlong.push(b);
    }
  },
  created() {
    this.getIndustryById();
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
