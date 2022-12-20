<template>
  <button class="calcbtn" @click="click">{{ text }}</button>
</template> 
  
  <script>
  import axios from "axios"
  export default {
    name: 'CalculateBtn',
    props: {
      type: Number,
      path: Text,
      text: String ,
      item: Object,
      baseaddress: String
    },
    methods:{
      async click(){
        let result;
        if(this.item == Object){
             result = await axios.get(this.baseaddress + "/Calculate/"+ this.path +"/?type=" + this.type);
        }else{
            result = await axios.get(this.baseaddress + "/Calculate/"+ this.path +"/" + this.item.id);
            
        }
        console.log(result.data);
        this.$emit('loadout',result.data)
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