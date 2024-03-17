<script setup lang="ts">

</script>

<template>
    <footer>
    <div class="footer-container">
      <div class="logo">
        <img src="../assets/logo3.png" alt="Logo" width="60">
      </div>
      <div class="small-images">
        <img class="small-image" src="../assets/instagram.png" alt="Imagen 1">
        <img class="small-image" src="../assets/facebook.png" alt="Imagen 2">
        <img class="small-image" src="../assets/twitter.png" alt="Imagen 3">
      </div>
      <nav class="navbar-footer">
    <RouterLink to="/">Inicio</RouterLink>
    <RouterLink to="/cartelera">Cartelera</RouterLink>
    <RouterLink to="/about">Sobre Nosotros</RouterLink>
    </nav>
      <div class="contact-info">
        <h1>Información de contacto:</h1>
        <br>
        <h2>976 14 67 10</h2>
        <h2>C/ Constitucion 50130 - Belchite</h2>
      </div>
    </div>
  </footer>
</template>

<style scoped>

footer {
  background-color: #F0D303;
  color: #000;
  font-family: Arial, sans-serif; 
  text-align: center;
  width: 100%;
}

.footer-container {
  display: flex;
  align-items: center;
  padding: 1%;
  justify-content: space-around;
  flex-wrap: wrap;
}

.logo {
  display: flex;
  align-items: left;
  margin-bottom: 10px;
}

.small-images {
  display: flex;
  align-items: left;
  margin-bottom: 10px;
}

.contact-info {
  display: flex;
  align-items: left;
  margin-bottom: 10px;
  flex-direction: column;
  font-size: 10px;
  text-align: left;
}
.navbar-footer{
    align-items: end;
}
.navbar-footer a {
  display: inline-block; 
  margin-right: 15px; 
  color: black; 
  font-family: Arial, sans-serif; 
  text-decoration: none; 
  
}

.navbar-footer a:hover {
  text-decoration: underline; 
}

.small-image {
  width: 40px;
  margin-right: 5px;
}


</style>