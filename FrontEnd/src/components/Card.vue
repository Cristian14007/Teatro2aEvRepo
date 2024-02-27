<script setup lang="ts">
 defineProps<{
    titulo?: string
    descripcion?: string
    imagen?: string

 }>()
</script>

<template>
    <div class="card">

  <div class="container">
    <h4><b>{{ titulo }}</b></h4> 
    <p>{{ descripcion }}</p>
    
  </div>
  <button><RouterLink to="/horario">Comprar</RouterLink></button>
</div>
</template>

<style scoped>
.card {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  width: 40%;
  border-radius: 5px;
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

img {
  border-radius: 5px 5px 0 0;
}

.container {
  padding: 2px 16px;
}

button {
  background-color: #F0D303;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}


</style>