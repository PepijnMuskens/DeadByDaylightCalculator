<template>
  <div class="row">
    <div class="itemdiv">
    <Slot v-if="hasitem" :item="item" :index="0" @slot="getData($event)"></Slot>
    <EmptySlot v-else></EmptySlot>
    </div>
    <div class="addondiv">
      <Slot v-if="hasaddon1" :item="addon1" :index="1" @slot="getData($event)"></Slot>
    <EmptySlot v-else></EmptySlot>
    </div>
    <div class="addondiv">
      <Slot v-if="hasaddon2" :item="addon2" :index="2" @slot="getData($event)"></Slot>
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
          width: 100pt;
          height: 100pt;
          padding-right: 10pt;
      }
      .addondiv{
          width: 80pt;
          height: 80pt;
          padding: 10pt;
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