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
            label="نام صنعت"
            :required="true"
            id="name"
            v-model="industry.name"
          />
        </div>
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
      </div>
      <h5 class="text-info mt-5 mb-0">مختصات</h5>

      <div class="row ">
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
            label="طول جغرافیایی"
            :required="true"
            id="name"
            v-model="industry.latitude"
          />
        </div>
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
      </div>
      <div class="row"></div>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import FormInput from "../components/Forms/FormInput";
export default {
  data() {
    return {
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
    postIndustry() {
      try {
        axios.post("/api/Utm", this.industry).then(res => {
          if (res.status == 201) {
            this.$router.push("/");
          }
        });
      } catch (error) {
        console.log(error);
      }
    }
  },
  components: {
    FormInput
  }
};
</script>

<style scoped>
.map {
  height: 80vh;
  border: 1px solid #888;
}
</style>
