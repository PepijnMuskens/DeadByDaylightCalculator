    <template>
      <div v-if="loadout != Object">
        <MedkitInfo :loadout="loadout"></MedkitInfo>
        <ToolboxInfo :loadout="loadout"></ToolboxInfo>
        <flashlightInfo :loadout="loadout"></flashlightInfo>
      </div>
      
    </template> 
    <script>
    import FlashlightInfo from './FlashlightInfo.vue';
    import MedkitInfoVue from './MedkitInfo.vue';
    import ToolboxInfo from './ToolboxInfo.vue';
    export default {
      name: 'InfoSection',
      props: {
        loadout: Object
      }, 
      components:{
    MedkitInfo: MedkitInfoVue,
    flashlightInfo: FlashlightInfo,
    ToolboxInfo : ToolboxInfo
}
    }
    </script>
    
    <style scoped>

    </style>