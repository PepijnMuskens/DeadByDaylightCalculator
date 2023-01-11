<template>
  <input @mouseover="hover = true" @mouseleave="hover = false" class="slot" type="image" :src="('data:image/jpeg;base64,'+item.icon)" @click="click">
  <div v-if="hover" class="info">
    <h3>{{item.name}}</h3>
    <p>{{item.charges}} charges</p>
    <p v-if="item.selfHealSpeed != null">{{item.selfHealSpeed * 100}}% self healspeed</p>
    <p v-if="item.selfHealSpeed != null">{{item.selfHealSpeed * 100}}% self healspeed</p>

    <p v-if="item.repairSpeed != null">{{(item.repairSpeed * 100).toFixed(0)}}% repair speed</p>
    <p v-if="item.saboSpeed != null">{{item.saboSpeed}} c/s sabotage speed</p>

    <p v-if="item.consumptionRate != 1">consumptionsrate {{item.consumptionRate}}</p>
    <p v-if="item.beamRange != null">range: {{item.beamRange}} meter</p>
    <p v-if="item.beamAngle != null">{{item.beamAngle}}° beam width</p>
    <p v-if="item.blindDuration != null">{{item.blindDuration}} seconds blind duration</p>

    <p v-if="item.aurarange > 0">aura range: {{item.aurarange}} meters</p>

    
  </div>
</template> 

<script>

export default {
  name: 'ItemSlot',
  props: {
    item: Object
  },
  methods:{
    click(){
      this.$emit('item',this.item)
    }
  },
  data() {
    return {
      hover: false
    }
  }
}
</script>

<style scoped>
.slot{
  width: 100%;
  height: 100%;
  
}
.info{
  position: absolute;
  width: 15%;
  padding-bottom: 1%;
  background-image: linear-gradient(rgba(0, 0, 0, 0.85),rgba(0, 0, 0, 0.6));
  margin-left: 6%;
}
</style>