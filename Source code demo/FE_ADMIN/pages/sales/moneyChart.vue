<script>
import { Line, mixins } from 'vue-chartjs'
import axios from 'axios'
import { scaleService } from 'chart.js'

export default {
  mixins: [mixins.reactiveData],
  data() {
    return {
      chartData: ''
    }
  },
  extends: Line,
  mounted() {
    this.renderChart(this.chartData,this.options)
  },
  created() {
    axios.get(`https://localhost:44389/api/MoneyCharts`)
      .then(response => {
        // JSON responses are automatically parsed.
        const responseData = response.data
        this.chartData = {
          labels: responseData.map(item => item.moneyChartMonth),
          datasets: [
            {
             label: 'Tổng doanh thu qua các tháng (đơn vị: VND)',
             data: responseData.map(item => item.chartSumOfMoney*23000),
             backgroundColor: "transparent",
             borderColor: "green",
             pointBackgroundColor: "rgba(171, 71, 188, 1)"
            }
          ]
        }
        this.options ={
          responsive: scaleService,
          maintainAspectRatio: false,
          title: {
            display: true,
            text: "SNEAKER SHOP"
          }
        }
      })
      .catch(e => {
        this.errors.push(e)
      })
  }
}
</script>

