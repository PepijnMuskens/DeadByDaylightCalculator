<template>
  <div class="row">
    <div class="itemdiv">
    <Slot v-if="item != Object" :item="item" :index="0" @slot="getData($event)"></Slot>
    <EmptySlot v-else></EmptySlot>
    </div>
      <div class="addondiv">
      <Slot v-if="addon1 != Object" :item="addon1" :index="1" @slot="getData($event)"></Slot>
    <EmptySlot v-else></EmptySlot>
    </div>
      <div class="addondiv">
        <Slot v-if="addon2 != Object" :item="addon2" :index="2" @slot="getData($event)"></Slot>
        <EmptySlot v-else></EmptySlot>
      </div>
   
  </div>
</template>
    
    <script>
    import Slot from "./Slot"
    import EmptySlot from "./EmptySlot";
    export default {
      name: 'ItemAddonRow',
      props: {
        item: Object,
        addon1: Object,
        addon2: Object
      },
      methods:{
        getData(data){
          this.$emit('slot',data)
        }
      },
      data(){
        return{
          hasitem : false,
          hasaddon1 : false,
          hasaddon2 : false
        }
      },
      created(){
        if(this.item != null){
          this.hasitem = true;
        }
        if(this.addon1 != null){
          this.hasaddon1 = true;
        }
        if(this.addon2 != null){
          this.hasaddon2 = true
        }
      },
      components: {
        EmptySlot: EmptySlot,
        Slot: Slot
     }
    }
    </script>
    
    <style scoped>
    .row{
      display: flex;
      flex-direction: row;
    }
      .itemdiv{
        display: flex;
        flex-direction: column;
        align-items: center;
        align-content: center;
        margin:10pt;
          width: 100pt;
          height: 100pt;
      }
      .addondiv{
        display: flex;
        flex-direction: column;
        align-items: center;
        margin: 10pt;
        margin-top: 20pt;
          width: 80pt;
          height: 80pt;
          
      }
      a {
          color: white;
          text-decoration: none;
          text-transform: uppercase;
      }
      h3{
        color: gray;
      }
    </style>