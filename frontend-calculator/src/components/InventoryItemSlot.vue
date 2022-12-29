<template>
  <input @mouseover="hover = true" @mouseleave="hover = false" class="slot" type="image" :src="('data:image/jpeg;base64,'+item.icon)" @click="click">
  <div v-if="hover" class="info">
    <h3>{{item.name}}</h3>
    <p>{{item.charges}} charges</p>
    <p>{{item.selfHealSpeed * 100}}% healspeed</p>
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
  width: 10%;
  height: 20%;
  background-color: gray;
  margin-left: 6%;
}
</style>