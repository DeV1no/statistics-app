<template>
  <div>
    <div v-if="industryFinancial != null">
      <div class="row mr-3 my-3">
        <div class="col-md-6">
          <p class="d-block text-border">
            بیشترین حقوق : {{ industryFinancial[0].maxSalary }}
          </p>
        </div>
        <div class="col-md-6">
          <p class="d-block text-border">
            کم ترین حقوق : {{ industryFinancial[0].minSalary }}
          </p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-10 mr-5 text-border">
          میانگین حقوق = (کمترین حقوق + بیشترین حقوق) / 2 =

          <span class="badge badge-success py-1">
            {{ industryFinancial[0].averageSalary }}
          </span>
        </div>
      </div>

      <div class="row">
        <div class="col-md-10 mr-5 text-border">
          مالیات = میانگین حقوقی X نرخ مالیات =

          <span class="badge badge-danger py-1">
            {{ industryFinancial[0].exempt }}
          </span>
        </div>
      </div>
      <h5 class="text-info mt-4 mr-3">
        نمودار ها :
      </h5>
      <bar-chart :industryData="industryFinancial[0]" />
    </div>
    <!-- add fiinance -->
    <div v-else>
      <h6 class="text-info mt-3 mr-3">
        افزودن رابطه مالی
      </h6>

      <financial-form />
    </div>
  </div>
</template>

<script>
import BarChart from "../BarChart";
import FinancialForm from "../Forms/FinancialForm.vue";

export default {
  props: {
    industryFinancial: Array
  },
  components: {
    BarChart,
    FinancialForm
  }
};
</script>

<style scoped>
.text-border {
  background-color: rgb(247, 244, 244) !important;
  -webkit-box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  box-shadow: 4px 4px 10px -8px rgba(0, 0, 0, 0.2);
  padding: 0.45rem;
}
</style>
