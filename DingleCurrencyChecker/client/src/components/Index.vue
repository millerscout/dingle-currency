<template lang="html">

  <section class="components-index">
    <h1>Dingle Conversion</h1>
    <form v-on:submit.prevent="convert()">
      <table>
        <tr>
          <td>
            <label>From</label>
            <select v-model="from" style="width:200px">
              <option value="0">
                Select a Currency
              </option>
              <option v-for="option in currencyList" v-bind:value="option">
                {{ option }}
              </option>
            </select>
          </td>
          <td>
            <label>To</label>
            <select v-model="to" style="width:200px">
              <option value="0">
                Select a Currency
              </option>
              <option v-for="option in currencyList" v-bind:value="option">
                {{ option}}
              </option>
            </select>
          </td>
        </tr>
        <tr>
          <td>
            <label>Amount</label><br>
            <input type="number" v-model="amount" />
          </td> 
          <td>
            <input type="button" v-on:click="convert()" value="Load" />
          </td>
        </tr>
      </table>  
    </form>

    <h2 v-if="result!=''">
        Result: {{result}}
    </h2>
    <h2 v-if="loading">
        Carregando
    </h2>
  </section>

</template>

<script lang="js">
  import service from "@/services/common-services.js";
  export default  {
    name: 'components-index',
    props: [],
    mounted() {
      this.getCurrencyList();
    },
    data() {
      return {
        from: 0,
        to: 0,
        amount:0,
        currencyList: [],
        result: '',
        loading: false
      }
    },
    methods: {
      getCurrencyList(){
        var q =service.getCurrencyList().then(r=>{
          this.currencyList = Object.keys(r.data)
        })
      },
      convert(){
        this.loading = true;
        if(this.from ==""){
          alert('Select a Currency [From]');
          return;
        }
        if(this.to==''){
          alert('Select a Currency [To]');
          return;
        }
        if(this.amount==''||this.amount < 0){
          alert('Amount must be greater than 0');
          return;
        }
        var q =service.convert(this.from, this.to, this.amount).then(r=>{
          this.result = r.data.toFixed(2)
          this.loading = false;
        })
      }
    },
    computed: {

    }
}
</script>

