    <template>
        <div v-if="loadout.item.type == 0" class="info">
          <div class="row">
            <h3>number of heals {{loadout.heals.toFixed(2)}}</h3>
            <progress max="5" v-bind:value="loadout.heals"></progress>
          </div>
          <div class="row">
            <h3>time to heal others: {{loadout.timeToHeal.toFixed(2)}} seconds</h3>
            <progress max="8" v-bind:value="16-loadout.timeToHeal"></progress>
          </div>
          <div class="row">
            <h3>time saved with healing others: {{loadout.timeSave.toFixed(2)}} seconds</h3>
            <progress max="22" v-bind:value="loadout.timeSave"></progress>
          </div>
          <div class="row">
            <h3>time to selfheal: {{loadout.timeToSelfHeal.toFixed(2)}} seconds </h3>
            <progress max="8" v-bind:value="17-loadout.timeToSelfHeal"></progress>
          </div>
          <div class="row">
            <h3>time saved with selfhealing: {{loadout.timeSaveSelfHeal.toFixed(2)}} seconds </h3>
            <progress max="60" v-bind:value="loadout.timeSaveSelfHeal"></progress>
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