<script setup lang="ts">

import { ref, onMounted, computed } from 'vue';
import Card2 from '../components/Card2.vue'
interface Obra {
  obraId: number;
  titulo: string;
  imagen: string;
  descripcion: string;
  genero: string;
  valoracion: number;
  precio: number;
}

const obras = ref<Obra[]>([]);


onMounted(async () => {
  try {
    const response = await fetch('http://localhost:5008/Obra');
    const data = await response.json();
    console.log(data); // Esto te mostrará los datos exactos que estás recibiendo
    obras.value = data;
  } catch (error) {
    console.error('Error:', error);
  }
});





</script>

<template>

  <div class="container">
    <Card2 v-for="obra in obras" :key="obra.obraId" :obra="obra" />


  </div>
</template>

<style scoped>
.container {
  display: flex;
  flex-wrap: wrap;
  /* Esto permite que las tarjetas pasen a la siguiente línea si no hay espacio */
  justify-content: space-around;
  /* Ajusta el espacio entre las tarjetas */
  gap: 20px;
  /* Espacio entre las tarjetas */
}

.filters {
  position: relative;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  width: 100%;
  font-family: "Poppins", sans-serif;
  margin: 3%;
  font-size: 100%;
}

.filters select {
  width: 25%;
  height: 35px;
  margin-right: 1%;
}

.filters p {
  float: left;
  color: black;
  margin-right: 1%;
}

.filters #removeFilter {
  cursor: pointer;
}

.filters #removeFilter:hover {
  transition: 0.7s;
  transform: scale(1.1);
  color: rgb(233, 32, 32);
}

.filtro-input {
  width: 25%;
  height: 35px;
  margin-right: 1%;
  padding: 0 10px;
}
</style>