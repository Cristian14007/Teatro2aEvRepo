<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';

</script>

<template>

  <!-- <nav>
    <RouterLink to="/">Home</RouterLink>
    <RouterLink to="/about">About</RouterLink>
  </nav> -->

<header class="header">
    <a href="">
      <img src="../assets/logo3.png" alt="" width="50">
    </a>

    <nav class="navbar-header">
    <RouterLink to="/">Inicio</RouterLink>
    <RouterLink to="/cartelera">Cartelera</RouterLink>
    <RouterLink to="/">Próximos Estrenos</RouterLink>
    <RouterLink to="/about">Sobre Nosotros</RouterLink>
    </nav>

</header>

<!-- <RouterView /> -->
</template>

<style scoped>
.header {
  background-color: #F0D303;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1.5rem 7%;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
}

.navbar-header{
    align-items: end;
}
.navbar-header a {
  display: inline-block; 
  margin-right: 15px; 
  color: black; 
  font-family: Arial, sans-serif; 
  text-decoration: none; 
}

.navbar-header a:hover {
  text-decoration: underline; 
}


</style>