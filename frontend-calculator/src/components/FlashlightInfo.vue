    <template>
        <div v-if="loadout.item.type == 2" class="info">
          <div class="row">
            <h3>Beam range: {{loadout.beamRange.toFixed(2)}} meter</h3>
            <progress max="15" v-bind:value="loadout.beamRange"></progress>
          </div>
          <div class="row">
            <h3>Beam width: {{loadout.beamWidth.toFixed(2)}} degrees</h3>
            <progress max="30" v-bind:value="loadout.beamWidth"></progress>
          </div>
          <div class="row">
            <h3>Blind duration: {{loadout.blindDuration.toFixed(2)}} seconds </h3>
            <progress max="2" v-bind:value="loadout.blindDuration -1.5"></progress>
          </div>
          <div class="row">
            <h3>Killer blinds: {{loadout.nrOfBlinds.toFixed(2)}} </h3>
            <progress max="26" v-bind:value="loadout.nrOfBlinds"></progress>
          </div>
        </div>
    </template> 
    
    <script>
    export default {
      name: 'FlashlightInfo',
      props: {
        loadout: Object
      }
    }
    </script>
    
<style scoped>
.info{
 display: flex;
 text-align: left;
 flex-direction: column;
}
.row{
  display:flex;
  flex-direction: row;
  justify-content: space-between;
}
h3{
  margin-block-end: 0.5;
  margin-block-start: 0;
}
</style>