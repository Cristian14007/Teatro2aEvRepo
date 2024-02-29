<script setup lang="ts">

import { ref, onMounted ,computed } from 'vue';
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
const categoriaSeleccionada = ref('');

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

const obrasFiltradasPorCategoria = computed(() => {
  if (!categoriaSeleccionada.value) {
    return obras.value;
  }
  return obras.value.filter(obra => obra.genero === categoriaSeleccionada.value);
});

function removeFilter() {
  categoriaSeleccionada.value = '';
}
</script>

<template>
  <section class="filter" id="filter">
    <div class="filters">
      <label>Filtro: &nbsp;</label>
      <select class="select"  name="select">
        <!-- Opciones de filtro (puedes implementar esta lógica más adelante) -->
      </select>

      <label>Categoría: &nbsp;</label>
      <select class="select" v-model="categoriaSeleccionada" name="select2">
        <option value="">No Filtro</option>
        <option value="Drama">Drama</option>
        <option value="Musical">Musical</option>
        <option value="Tragedia">Tragedia</option>
        <option value="Comedia">Comedia</option>
      </select>
      <span @click="removeFilter" id="removeFilter" class="fas fa-times"></span>
    </div>
  </section>

  <div class="container">
    <Card v-for="obra in obrasFiltradasPorCategoria" :key="obra.obraId" :obra="obra" />
  </div>
</template>

  <style scoped>
  .container {
    display: flex;
    flex-wrap: wrap; /* Esto permite que las tarjetas pasen a la siguiente línea si no hay espacio */
    justify-content: space-around; /* Ajusta el espacio entre las tarjetas */
    gap: 20px; /* Espacio entre las tarjetas */
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
  </style>