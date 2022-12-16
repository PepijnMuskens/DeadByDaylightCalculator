    <template>
      <div v-if="loadout != Object">
        <MedkitInfo :loadout="loadout"></MedkitInfo>
        <flashlightInfo :loadout="loadout"></flashlightInfo>
      </div>
      
    </template> 
    <script>
    import FlashlightInfo from './FlashlightInfo.vue';
    import MedkitInfoVue from './MedkitInfo.vue';
    export default {
      name: 'InfoSection',
      props: {
        loadout: Object
      }, 
      components:{
        MedkitInfo : MedkitInfoVue,
        flashlightInfo : FlashlightInfo
      }
    }
    </script>
    
    <style scoped>

    </style>