<script setup lang="ts">
defineProps(['obra']);
</script>

<template>
  <div class="card">
    <img :src="obra.imagen" :alt="obra.titulo" />
    <h3>{{ obra.titulo }}</h3>
    <RouterLink to="/horario" class="btn" id="cartebtn">Comprar entradas</RouterLink>
  </div>
</template>

<style scoped>
.card {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  width: 25%;
  border-radius: 5px;
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

img {
  border-radius: 5px 5px 0 0;
}
.card img {
  width: 100%;
  height: auto;
  border-radius: 8px 8px 0 0;
}
.container {
  padding: 2px 16px;
}


.card h3 {
  margin-top: 10px;
}


.btn {
  background-color: #F0D303;
  color: var(--black);
  border: none;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  border: 3px solid #000000;
}
.btn:hover {
  box-shadow: 0 12px 16px 0 rgba(0, 0, 0, 0.24), 0 17px 50px 0 rgba(0, 0, 0, 0.19);
}

</style>