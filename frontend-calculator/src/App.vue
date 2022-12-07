<template>
  <h1>Item Calculator</h1>
  <div class="page">

    <div class="half">
      <div>
        <h2>loadout</h2>
        <ItemAddonRow :item="selecteditem" :addon1="selectedaddon1" :addon2="selectedaddon2" @slot="getSlot($event)"/>
      </div>
      <div>
        <h2>inventory</h2>
        <div v-if="(selectedindex === 0)" class="inventory">
            <div class="card" v-for="item in items" :key="item.id">
            <InventoryItemSlot :item="item" @item="getData($event)"/>
          </div>
        </div>
        <div v-if="(selectedindex === 1)" class="inventory">
          <div class="card" v-for="addon in addons" :key="addon.id">
            <InventoryItemSlot :item="addon" @item="getData($event)"/>
          </div>
        </div>
        <div v-if="(selectedindex === 2)" class="inventory">
          <div class="card" v-for="addon in addons" :key="addon.id">
            <InventoryItemSlot :item="addon" @item="getData($event)"/>
          </div>
        </div>
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
</template>

<script>
import InventoryItemSlot from "./components/InventoryItemSlot"
import ItemAddonRow from "./components/ItemAddonRow"
import axios from "axios"
export default {
  name: 'App',
  components: {
    InventoryItemSlot: InventoryItemSlot,
    ItemAddonRow : ItemAddonRow
  },
  data(){
    return{
      items:[],
      addons:[],
      selectedindex:0,
      selecteditem:Object,
      selectedaddon1:Object,
      selectedaddon2:Object
    }
  },
  created(){
    this.getItems();
    this.getAddons();
  },
  methods : {
    async getItems(){
    let result = await axios.get("https://localhost:7134/Item/GetAll");
    this.items = result.data;
    console.log(result.data);
    },
    async getAddons(){
    let result = await axios.get("https://localhost:7134/Addon/GetAll");
    this.addons = result.data;
    console.log(result.data);
    },
    async getAddonsByType(type){
    let result = await axios.get("https://localhost:7134/Addon/GetAll/"+ type);
    this.addons = result.data;
    console.log(result.data);
    },
    getSlot(data){
      this.selectedindex = data;
    },
     getData(data){
      if(this.selectedindex == 0){
        this.selecteditem = data;
        this.selectedindex = 1;
        this.addons = this.getAddonsByType(data.type)
      }
      else if(this.selectedindex == 1){
        this.selectedaddon1 = data;
        this.selectedindex = 2;
        this.addons = this.addons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id);
      }
      else if(this.selectedindex == 2){
        this.selectedaddon2 = data;
        this.addons = this.addons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id);
      }
      
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
  padding-left: 5%;
  padding-right: 5%;
  width: 40%;
  border-style: solid;
}
.inventory{
  display: flex;
  padding: 25px;
  flex-direction: row;
  flex-wrap: wrap;
  border-style: solid;
}
.card{
          background: "('data:image/jpeg;base64,'+item.icon)";
          background-repeat: inherit;
          display: flex;
          justify-content: flex-start;
          flex-direction: column ;;
          width: 100pt;
          height: 100pt;
}
body {
  background-image: url('https://deadbydaylight.com/static/f666c1750beb64be359b67b8c3a49139/66180/fog-background.jpg');
  background-size: auto;
}

h2{
  text-align: left;
  padding-left: 25pt;
}
</style>
