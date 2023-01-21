<template>
  <vueTitle :title="'Dbd Calculator'"></vueTitle>
  <div class="page">

    <div class="half">
      <div class="loadout">
        <div class="loadoutrow"> 
          <h2>loadout</h2>
          <button class="button" @click="Clear">Clear</button>
        </div>
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
          <div v-if="(selecteditem == Object || selecteditem.type == 0)" class="selectrow">
            <h3>medkit</h3>
            <div class="calcbtns"> 
              <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="0" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
              </div>
            </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 1)" class="selectrow">
          <h3>toolbox</h3>
            <div class="calcbtns"> 
              <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="1" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
              <calculateBtn :text="'Calculate Most Time Saved'" :path="'GetToolboxTimesave'" :type="1" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
            </div>
          </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 2)" class="selectrow">
          <h3>flashlight</h3>
          <div class="calcbtns"> 
          <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="2" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
        </div>
        </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 3)" class="selectrow">
          <h3>key</h3>
            <div class="calcbtns"> 
              <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="3" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
            </div>
          </div>

        <div v-if="(selecteditem == Object || selecteditem.type == 4)" class="selectrow">
          <h3>map</h3>
            <div class="calcbtns"> 
              <calculateBtn :text="'Calculate Longest Duration'" :path="'GetLongestDuration'" :type="4" :item="selecteditem" :baseaddress="this.baseaddress" @loadout="UpdateLoadout($event)"></calculateBtn>
            </div>
          </div>
        </div>
        

      </div>
    </div>
  </div>
</template>

<script>
import titleComponent from './components/Title.vue';
import InventoryItemSlot from "./components/InventoryItemSlot"
import ItemAddonRow from "./components/ItemAddonRow"
import CalculateBtn from "./components/CalculateBtn"
import Info from "./components/Info/Info.vue"
import axios from "axios"

import jsonitems from "../src/assets/items"
import jsonaddons from "../src/assets/addons"
export default {
  name: 'App',
  title: 'Dbd Calculator',
  components: {
    vueTitle: titleComponent,
    InventoryItemSlot: InventoryItemSlot,
    ItemAddonRow : ItemAddonRow,
    CalculateBtn: CalculateBtn,
    Info: Info
  },
  data(){
    return{
      baseaddress: 'https://deadbydaylightitemapi20221218193729.azurewebsites.net',
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
    this.allItems = jsonitems
    console.log(jsonitems);
    },
    async getAddons(){
    this.allAddons = jsonaddons
    console.log(jsonaddons);
    },
    async getAddonsByType(type){
    let result = await axios.get(this.baseaddress + "/Addon/GetAll/"+ type);
    this.addons = result.data;
    console.log(result.data);
    },
    async Update(){
    let addon1id = 0
    let addon2id = 0
    if(this.selectedaddon1.id != undefined) addon1id = this.selectedaddon1.id
    if(this.selectedaddon2.id != undefined) addon2id = this.selectedaddon2.id
    let result = await axios.get(this.baseaddress + "/Calculate/Update?itemid="+this.selecteditem.id+"&addon1id="+addon1id+"&addon2id="+ addon2id);
    this.loadout = result.data;
    console.log(result.data);
    },
    getSlot(data){
      this.selectedindex = data;
    },
    Clear(){
      this.selecteditem = Object
      this.selectedaddon1 = Object
      this.selectedaddon2 = Object
      this.selectedindex = 0
      this.Update()
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
  padding-top: 1.5%;
}
.half{
  display: flex;
  flex-direction: column;
  padding-left: 2%;
  padding-right: 2%;
  width: 45%;
}
.loadoutrow{
  display: flex;
}
.button{
  width: 50pt;
  height: 20pt;
  align-self: center;
  margin-left: 100pt;
}
.inventory{
  display: flex;
  padding-left: 5%;
  flex-direction: row;
  flex-wrap: wrap;
}
.select{
  display: flex;
  padding: 10px;
  flex-direction: column;
  justify-content: left;
  align-self: left;
  flex-wrap: wrap;
}
.selectrow{
  display: flex;
  margin-bottom: 20pt;
  flex-direction: row;
  justify-content: left;
  align-self: left;
  flex-wrap: wrap;
}
.calcbtns{
  position:absolute;
  display: flex;
  flex-direction: row;
  margin-left: 60pt;
}
.calcbtn{
  margin-left: 20pt;
  width:80pt;
  height: 60pt;
  
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
          width: 15%;
          height: 15%;
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
