<script setup lang="ts">
defineProps(['obra']);
import { RouterLink } from 'vue-router';
</script>

<template>
  <div class="card">
    <!-- <img :src="obra.imagen" :alt="obra.titulo" /> -->
    <img :src="'https://imgdramask.s3.amazonaws.com/' + obra.imagen" :alt="obra.titulo" width="150" height="150">
    <h3>{{ obra.titulo }}</h3>
    <RouterLink :to="{ name: 'HorarioView', params: { obraId: obra.obraId }}" class="btn" id="cartebtn">Comprar entradas</RouterLink>
    </div>
</template>

<style scoped>
.card {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  width: 100%; /* Cambiado a 100% para ajustarse a pantallas más pequeñas */
  max-width: 300px; /* Añadido para mantener un tamaño máximo */
  border-radius: 5px;
  border: 1px solid transparent;
  margin: 10px; /* Añadido para asegurar espacio alrededor de la tarjeta */
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
  border-color: #F0D303;
  border-width: 5px;
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

/* Media queries para pantallas más pequeñas */
@media (max-width: 600px) {
  .card {
    width: 90%; /* Ocupa más ancho en pantallas pequeñas */
    margin: 10px auto; /* Centrado y con margen */
  }

  .container {
    padding: 10px; /* Más padding en dispositivos pequeños */
  }

  .btn {
    padding: 10px 20px; /* Padding reducido para botones */
    font-size: 14px; /* Tamaño de fuente más pequeño para ajustarse a pantallas más pequeñas */
  }
}
</style>
