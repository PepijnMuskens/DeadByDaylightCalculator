  <template>
      <input type="image" class="empty" src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/1f/Blank_square.svg/1200px-Blank_square.svg.png">
  </template> 
    
    <script>
    export default {
      name: 'EmptySlot',
    }
    </script>
    
    <style scoped>
    .empty{
      width: 100%;
      height: 100%;
      background-image: url(..//assets/emptySlot.png);
      background-repeat: no-repeat;
      background-size: contain;
    }
    </style>