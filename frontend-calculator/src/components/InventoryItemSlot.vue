<template>
  <input type="image" :src="('data:image/jpeg;base64,'+item.icon)" @click="click">
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
  }
}
</script>

<style scoped>
.button{
  width: 100%;
  height: 100%;
  padding: 0px;
}
</style>