<template>
    <div class="card">
            <h3>{{item.name}}</h3>
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
          width: 200px;
          height: 100px;
          margin-bottom: 20%;
          padding-top: 10px;
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