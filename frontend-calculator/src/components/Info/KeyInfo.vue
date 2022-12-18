    <template>
        <div v-if="loadout.item.type == 3" class="info">
          <div class="row">
            <h3>Duration: {{loadout.duration.toFixed(2)}} seconds</h3>
            <progress max="33" v-bind:value="loadout.duration"></progress>
          </div>
          <div class="row">
            <h3>Aura range: {{loadout.auraRange.toFixed(2)}} meter</h3>
            <progress max="20" v-bind:value="16-loadout.auraRange"></progress>
          </div>
          <h3>{{loadout.info}}</h3>
        </div>
    </template> 
    
    <script>
    export default {
      name: 'KeyInfo',
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