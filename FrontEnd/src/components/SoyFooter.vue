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
      <div class="contact-info">
        <a href="index.html"><h1>Inicio</h1></a>
        <a href="product.html"><h1>Cartelera</h1></a>
        <a href="aboutus.html"><h1>Sobre Nosotros</h1></a>

        
      </div>
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
.contact-info a {
  text-decoration: none;
  color: #000;
  cursor: pointer;
}

.small-image {
  width: 40px;
  margin-right: 5px;
}

</style>