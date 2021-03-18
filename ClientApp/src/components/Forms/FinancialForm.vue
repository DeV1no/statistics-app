<template>
  <div>
    <div class="row mr-2">
      <div class="col-md-5">
        <form-input
          label="بیشترین حقوق"
          :required="true"
          id="name"
          type="number"
          v-model="finnanceRell.maxSalary"
        />
      </div>
      <div class="col-md-5">
        <form-input
          label="کم ترین حقوق"
          :required="true"
          id="name"
          type="number"
          v-model="finnanceRell.minSalary"
        />
      </div>
    </div>
    <div class="row my-2">
      <div class="col-md-5">
        <div class="form-check mt-1 mr-4">
          <label class="form-check-label" for="exampleCheck1"
            >معاف از مالیات</label
          >
          <input
            v-model="finnanceRell.isExemptTax"
            type="checkbox"
            class="form-check-input mr-5"
            id="exampleCheck1"
          />
        </div>
      </div>
      <div class="col-md-5">
        <button
          class="btn btn-block  btn-success mr-1"
          @click="postFinanceRell"
        >
          ثبت رابطه مالی
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import FormInput from "./FormInput";
import axios from "axios";
export default {
  data() {
    return {
      id: this.$route.params.id,
      finnanceRell: {
        maxSalary: "",
        minSalary: "",
        isExemptTax: false,
        utmId: []
      }
    };
  },
  components: {
    FormInput
  },
  methods: {
    postFinanceRell() {
      this.finnanceRell.utmId.push(this.id);
      axios
        .post("/api/IndustryFinancial", this.finnanceRell)
        .then(res => console.log(res.data));
    }
  }
};
</script>

<style></style>
