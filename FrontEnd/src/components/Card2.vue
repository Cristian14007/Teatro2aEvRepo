<script setup lang="ts">
defineProps(['estreno']);
import { RouterLink } from 'vue-router';
</script>

<template>
  <div class="card">
    <div class="coolcard__img"><img :src="'src/assets/' + estreno.imagen" :alt="estreno.titulo" width="150" height="150"></div>
    <div class="coolcard__body">
            <h1 class="coolcard__title">{{estreno.titulo}}</h1>
            <div class="coolcard__text">
            <a  class="btn">Proximamente</a>
            </div>
        </div>
    </div>
    
       
</template>

<style scoped>

.card {
  border-radius: 10px; /* Bordes redondeados */
  overflow: hidden; /* Asegura que todo dentro de la tarjeta también tenga bordes redondeados */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Sombra sutil */
  transition: transform 0.3s ease, box-shadow 0.3s ease; /* Transición suave para hover */
  background-color: white; /* Fondo blanco */
}

.card:hover {
  transform: translateY(-5px); /* Eleva ligeramente la tarjeta al pasar el ratón */
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.3); /* Sombra más pronunciada en hover */
}

.coolcard__img {
  width: 100%; /* Ancho completo de la tarjeta */
  height: 200px; /* Altura fija para la imagen */
  overflow: hidden; /* Oculta cualquier parte de la imagen que sobrepase los bordes */
}

.coolcard__img img {
  width: 100%; /* Ancho completo del contenedor de la imagen */
  height: 100%; /* Altura completa del contenedor de la imagen */
  object-fit: cover; /* Ajusta la imagen para cubrir todo el contenedor */
}

.coolcard__body {
  padding: 15px; /* Espacio interior para el texto */
}

.coolcard__title {
  margin: 10px 0; /* Espacio antes y después del título */
  font-size: 1.5em; /* Tamaño del texto del título */
}

.coolcard__text {
  font-size: 1em; /* Tamaño del texto normal */
  color: #333; /* Color del texto */
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