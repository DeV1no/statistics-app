<template>
  <!-- v-if="isOficialCenterMode -->
  <div>
    <div v-if="centralOfice[0] != null">
      <div class="row mr-3 my-3">
        <div class="col-md-6">
          <p class="d-block text-border">
            نام دفتر :
            {{ centralOfice[0].name }}
          </p>
        </div>
        <div class="col-md-6">
          <p class="d-block text-border">
            نام دفتر :
            {{ centralOfice[0].city }}
          </p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-10 mr-5 text-border">
          کد پستی :

          {{ centralOfice[0].postalCode }}
        </div>
      </div>
      <div class="row mr-3 mt-3">
        <div class="col-md-6">
          <p class="d-block text-border">
            طول جغرافیایی :
            {{ centralOfice[0].lngitude }}
          </p>
        </div>
        <div class="col-md-6">
          <p class="d-block text-border">
            عرض جغرافیایی :
            {{ centralOfice[0].latitude }}
          </p>
        </div>
      </div>

      <h5 class="text-info mt-4 mr-3">
        نمودار ها :
      </h5>
    </div>
    <!-- add fiinance -->
    <div v-else>
      <h6 class="text-info mt-3 mr-3">
        دفتر مرکزی
      </h6>

      <oficial-form />
    </div>
  </div>
</template>

<script>
import OficialForm from "../Forms/OficialForm.vue";
export default {
  props: {
    centralOfice: Array
  },
  components: {
    OficialForm
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
