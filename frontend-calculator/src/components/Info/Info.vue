    <template>
      <div v-if="loadout != Object">
        <MedkitInfo :loadout="loadout"></MedkitInfo>
        <ToolboxInfo :loadout="loadout"></ToolboxInfo>
        <flashlightInfo :loadout="loadout"></flashlightInfo>
        <MapInfo :loadout="loadout"></MapInfo>
        <KeyInfo :loadout="loadout"></KeyInfo>
      </div>
      
    </template> 
    <script>
    import FlashlightInfo from './FlashlightInfo.vue';
    import MedkitInfoVue from './MedkitInfo.vue';
    import ToolboxInfo from './ToolboxInfo.vue';
    import MapInfo from './MapInfo.vue';
    import KeyInfo from './KeyInfo.vue';
    export default {
      name: 'InfoSection',
      props: {
        loadout: Object
      }, 
      components:{
    MedkitInfo: MedkitInfoVue,
    flashlightInfo: FlashlightInfo,
    ToolboxInfo : ToolboxInfo,
    MapInfo: MapInfo,
    KeyInfo: KeyInfo
}
    }
    </script>
    
    <style scoped>

    </style>