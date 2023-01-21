<template>
  <input @mouseover="hover = true" @mouseleave="hover = false" class="slot" type="image" :src="('data:image/jpeg;base64,'+item.icon)" @click="click">
  <div v-if="hover" class="info">
    <h3 class="text">{{item.name}}</h3>
    <p class="text">{{item.charges}} charges</p>
    <p v-if="item.selfHealSpeed != null" class="text">{{item.selfHealSpeed * 100}}% healspeed</p>
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
  border-style: solid;
  border-color: black;
  align-items: left;
  width: 15%;
  height: 20%;
  background-color: #434343d1;
  margin-left: 7%;
  padding-left: 1%;
}
.text{
  display: flex;
  align-self: left;
  color: black;
}
</style>