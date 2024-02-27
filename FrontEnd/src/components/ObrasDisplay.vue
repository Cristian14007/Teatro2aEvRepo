<script setup lang="ts">

import { ref, onMounted } from 'vue';
import Card from '../components/Card.vue'
interface Obra {
  obraId: number;
  titulo: string;
  imagen: string;
  descripcion: string;
  genero: string;
  sesiones: any; // Cambia 'any' por un tipo más específico si es necesario
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
      <Card v-for="obra in obras" :key="obra.obraId" :obra="obra" />
    </div>
  </template>
  <style scoped>
  .container {
    display: flex;
    flex-wrap: wrap; /* Esto permite que las tarjetas pasen a la siguiente línea si no hay espacio */
    justify-content: space-around; /* Ajusta el espacio entre las tarjetas */
    gap: 20px; /* Espacio entre las tarjetas */
  }
  </style>