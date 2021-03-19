<script>
import { Bar } from "vue-chartjs";

export default {
  props: {
    industryData: {
      type: Object
    }
  },
  extends: Bar,
  mounted() {
    console.log(this.industryData);
    this.renderChart(
      {
        labels: ["بیشترین حقوق", "کم ترین حقوق", "میانگین حقوق ", "مالیات"],
        datasets: [
          {
            label: "",
            backgroundColor: "#f87979",
            data: [
              this.industryData.maxSalary,
              this.industryData.minSalary,
              this.industryData.averageSalary,
              this.industryData.exempt
            ]
          }
        ]
      },
      { responsive: true, maintainAspectRatio: false }
    );
  }
};
</script>
