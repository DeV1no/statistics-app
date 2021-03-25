<template>
  <div>
    <div class="container" dir="rtl">
      <div class="row">
        <div class="col-12 mt-4">
          <h4 class="text-info">نمودار حقوق بر اساس صنعت</h4>
        </div>
      </div>
    </div>
    <div class="container mb-4">
      <radar-chart />
    </div>
  </div>
</template>

<script>
import RadarChart from "../components/Charts/RadarChart.vue";
export default {
  components: { RadarChart }
};
</script>

<style></style>
