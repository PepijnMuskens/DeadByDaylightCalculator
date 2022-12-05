<template>
  <h1>All Items</h1>
  <div class="page">

    <div class="half">
      <div>
        <h2>loadout</h2>
      </div>
      <div>
        <h2>inventory</h2>
      </div>
    </div>

    <div class="half">
      <div>
        <h2>INFO</h2>
      </div>
      <div>
        <h2>SELECT</h2>
      </div>
    </div>

  </div>
  
  <div class="test">
        <div v-for="item in items" :key="item.id">
            <Itemcard :item="item"/>
        </div>
    </div>
</template>

<script>
import Item from "./components/Item"
import ItemAddonRow from "./components/ItemAddonRow"
import axios from "axios"
export default {
  name: 'App',
  components: {
    Itemcard: Item,
    ItemAddonRow : ItemAddonRow
  },
  data(){
    return{
      items:[]
    }
  },
  created(){
    this.getItems();
  },
  methods : {
    async getItems(){
    let result = await axios.get("https://localhost:7134/Item/GetAll");
    this.items = result.data;
    console.log(result.data);
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: darkgray;;
}
.page{
  display: flex;
  justify-content: center;
  flex-direction: row;
  border-style: solid;
}
.half{
  display: flex;
  flex-direction: column;
  margin-left: 100pt;
  margin-right: 100pt;
  border-style: solid;
}
.test{
        display: flex;
        flex-wrap: wrap;
        margin-left: 10%;
        margin-right: 10%;
        justify-content: space-between;
        border-style: solid;
    }
body {
  background-image: url('https://deadbydaylight.com/static/f666c1750beb64be359b67b8c3a49139/66180/fog-background.jpg');
  background-size: auto;
}
</style>
