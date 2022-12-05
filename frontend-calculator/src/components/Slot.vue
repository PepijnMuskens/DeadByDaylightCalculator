<template>
    <div class="card">
            <img :src="('data:image/jpeg;base64,'+item.icon)">
    </div>
    </template>
    
    <script>
    export default {
      name: 'ItemCard',
      props: {
        item: Object
      }
    }
    </script>
    
    <style scoped>
      .card{
          background: "('data:image/jpeg;base64,'+item.icon)";
          background-repeat: inherit;
          display: flex;
          justify-content: flex-start;
          flex-direction: column ;;
          width: 50px;
          height: 50px;
      }
      a {
          color: white;
          text-decoration: none;
          text-transform: uppercase;
      }
      h3{
        color: gray;
      }
    </style>