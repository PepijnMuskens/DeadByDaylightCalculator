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
            <div class="card" v-for="item in allItems" :key="item.id">
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
        <info :loadout="loadout"></info>
      </div>
      <div>
        <h2>SELECT</h2>
        <div class="select">
          <div v-if="(selecteditem == Object || selecteditem.type == 0)">
          <h3>medkit</h3>
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="0" :item="selecteditem" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 1)">
          <h3>toolbox</h3>
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="1" :item="selecteditem" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 2)">
          <h3>flashlight</h3>
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="2" :item="selecteditem" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 3)">
          <h3>key</h3>
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="3" :item="selecteditem" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 4)">
          <h3>map</h3>
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="4" :item="selecteditem" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>
        </div>
        

      </div>
    </div>
  </div>
</template>

<script>
import InventoryItemSlot from "./components/InventoryItemSlot"
import ItemAddonRow from "./components/ItemAddonRow"
import CalculateBtn from "./components/CalculateBtn"
import Info from "./components/Info"
import axios from "axios"
export default {
  name: 'App',
  components: {
    InventoryItemSlot: InventoryItemSlot,
    ItemAddonRow : ItemAddonRow,
    CalculateBtn: CalculateBtn,
    Info : Info
  },
  data(){
    return{
      items:[],
      allItems:[],
      addons:[],
      allAddons:[],
      selectedindex:0,
      selecteditem:Object,
      selectedaddon1:Object,
      selectedaddon2:Object,
      loadout: Object
    }
  },
  created(){
    this.getItems();
    this.getAddons();
  },
  methods : {
    async getItems(){
    let result = await axios.get("https://localhost:7134/Item/GetAll");
    this.allItems = result.data;
    console.log(result.data);
    },
    async getAddons(){
    let result = await axios.get("https://localhost:7134/Addon/GetAll");
    this.allAddons = result.data;
    console.log(result.data);
    },
    async getAddonsByType(type){
    let result = await axios.get("https://localhost:7134/Addon/GetAll/"+ type);
    this.addons = result.data;
    console.log(result.data);
    },
    async Update(){
    let addon1id = 0
    let addon2id = 0
    if(this.selectedaddon1.id != undefined) addon1id = this.selectedaddon1.id
    if(this.selectedaddon2.id != undefined) addon2id = this.selectedaddon2.id
    let result = await axios.get("https://localhost:7134/Calculate/Update?itemid="+this.selecteditem.id+"&addon1id="+addon1id+"&addon2id="+ addon2id);
    this.loadout = result.data;
    console.log(result.data);
    },
    getSlot(data){
      this.selectedindex = data;
    },
    UpdateLoadout(loadout){
      this.selecteditem = loadout.item
      this.selectedaddon1 = loadout.addons[0]
      this.selectedaddon2 = loadout.addons[1]
      this.addons = this.allAddons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id && addon.type == this.selecteditem.type);
      this.loadout = loadout
    },
    getData(data){
      if(this.selectedindex == 0){
       if(this.selecteditem.type != data.type){
          this.selectedaddon1 = Object;
          this.selectedaddon2 = Object;
        }
        if(this.selecteditem.id == data.id){
          this.selecteditem = Object;
          this.selectedaddon1 = Object;
          this.selectedaddon2 = Object;
        }else{
          this.selecteditem = data;
          this.selectedindex = 1;
          this.addons = this.allAddons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id && addon.type == this.selecteditem.type);
        }
      }
      else if(this.selectedindex == 1){
        this.selectedaddon1 = data;
        this.selectedindex = 2;
        this.addons = this.allAddons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id && addon.type == this.selecteditem.type);
      }
      else if(this.selectedindex == 2){
        this.selectedaddon2 = data;
        this.addons = this.allAddons.filter(addon => addon.id != this.selectedaddon1.id && addon.id != this.selectedaddon2.id && addon.type == this.selecteditem.type);
      }
      this.Update()
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
.select{
  display: flex;
  padding: 25px;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: wrap;
  border-style: solid;
}
.selectbtn{
  width:80pt;
  height: fit-content;
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
