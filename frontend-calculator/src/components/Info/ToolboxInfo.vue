    <template>
        <div v-if="loadout.item.type == 1" class="info">
          <div class="row">
            <h3>Repair duration: {{loadout.repairDuration.toFixed(2)}} seconds</h3>
            <progress max="35" v-bind:value="loadout.repairDuration"></progress>
          </div>
          <div class="row">
            <h3>Repair speed: {{loadout.repairSpeed.toFixed(2)}} c/s</h3>
            <progress max="2.5" v-bind:value="loadout.repairSpeed"></progress>
          </div>
          <div class="row">
            <h3>Time saved repairing: {{loadout.timeSaveRepair.toFixed(2)}} seconds</h3>
            <progress max="22" v-bind:value="loadout.timeSaveRepair"></progress>
          </div>
          <div class="row">
            <h3>Sabotage {{loadout.nrOfSabo.toFixed(2)}} hooks </h3>
            <progress max="9" v-bind:value="loadout.nrOfSabo"></progress>
          </div>
          <div class="row">
            <h3>Time to sabotage: {{loadout.timetoSabo.toFixed(2)}} seconds </h3>
            <progress max="1.7" v-bind:value="3.4-loadout.timetoSabo"></progress>
          </div>
        </div>
    </template> 
    
    <script>
    export default {
      name: 'MedkitInfo',
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