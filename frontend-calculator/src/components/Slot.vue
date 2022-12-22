    <template>
        <input class="slot" type="image" :src="('data:image/jpeg;base64,'+item.icon)" @click="click">
    </template> 
    
    <script>
    export default {
      name: 'ItemSlot',
      props: {
        item: Object,
        index: Number
      },
      methods:{
        click(){
        this.$emit('slot',this.index)
        }
      }
    }
    </script>
    
    <style scoped>
    .slot{
      width: 100%;
      height: 100%;
    }
    </style>