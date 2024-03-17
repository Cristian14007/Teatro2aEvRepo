<script setup lang="ts">

import { ref, onMounted, computed } from 'vue';
import Card from '../components/Card.vue'
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
const categoriaSeleccionada = ref('');
const terminoBusqueda = ref('');
const opcionOrdenacion = ref('');

onMounted(async () => {
  try {
    const response = await fetch('http://dramaskBack.retocsv.es:80/Obra');
    const data = await response.json();
    console.log(data); // Esto te mostrará los datos exactos que estás recibiendo
    obras.value = data;
  } catch (error) {
    console.error('Error:', error);
  }
});

const obrasFiltradasYOrdenadas = computed(() => {
  let obrasFiltradas = obras.value
    .filter(obra => {
      return categoriaSeleccionada.value ? obra.genero === categoriaSeleccionada.value : true;
    })
    .filter(obra => {
      return obra.titulo.toLowerCase().includes(terminoBusqueda.value.toLowerCase());
    });

  switch (opcionOrdenacion.value) {
    case 'valoracionDesc':
      return obrasFiltradas.sort((a, b) => b.valoracion - a.valoracion);
    case 'precioDesc':
      return obrasFiltradas.sort((a, b) => b.precio - a.precio);
    case 'valoracionAsc':
      return obrasFiltradas.sort((a, b) => a.valoracion - b.valoracion);
    case 'precioAsc':
      return obrasFiltradas.sort((a, b) => a.precio - b.precio);
    default:
      return obrasFiltradas;
  }
});


function removeFilter() {
  categoriaSeleccionada.value = '';
  terminoBusqueda.value = '';
  opcionOrdenacion.value = '';
}
</script>

<template>
  <section class="filter" id="filter">
    <div class="filters">
      <label>Filtro: &nbsp;</label>
      <select class="select" v-model="opcionOrdenacion" name="selectOrdenacion">
        <option value="">Sin Ordenar</option>
        <option value="valoracionDesc">Mayor Valoración</option>
        <option value="precioDesc">Mayor Precio</option>
        <option value="valoracionAsc">Menor Valoración</option>
        <option value="precioAsc">Menor Precio</option>
      </select>
      <label>Categoría: &nbsp;</label>
      <select class="select" v-model="categoriaSeleccionada" name="select2">
        <option value="">No Filtro</option>
        <option value="Drama">Drama</option>
        <option value="Musical">Musical</option>
        <option value="Tragedia">Tragedia</option>
        <option value="Comedia">Comedia</option>
      </select>
      <label>Busqueda: &nbsp;</label>
      <input type="text" v-model="terminoBusqueda" placeholder="Buscar obra" class="filtro-input">
      <span @click="removeFilter" id="removeFilter" class="fas fa-times"></span>
    </div>
  </section>

  <div class="container">
    <Card v-for="obra in obrasFiltradasYOrdenadas" :key="obra.obraId" :obra="obra" />

  </div>
</template>

<style scoped>
.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  gap: 20px;
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

.filters select,
.filtro-input {
  width: 100%; /* Ajustado para dispositivos móviles */
  height: 35px;
  margin-bottom: 10px; /* Espaciado adicional para dispositivos móviles */
  padding: 0 10px;
}

.filters p {
  width: 100%; /* Ajustar el ancho para dispositivos móviles */
  text-align: center; /* Centrar texto para una mejor visualización en dispositivos móviles */
  color: black;
  margin: 10px 0; /* Añadir margen superior e inferior */
}

.filters #removeFilter {
  cursor: pointer;
}

.filters #removeFilter:hover {
  transition: 0.7s;
  transform: scale(1.1);
  color: rgb(233, 32, 32);
}

/* Media queries para pantallas más pequeñas */
@media (max-width: 768px) {
  .filters select,
  .filtro-input {
    width: 100%; /* Ocupa todo el ancho en dispositivos pequeños */
    margin-right: 0; /* Eliminar margen derecho */
  }

  .filters p {
    float: none; /* Eliminar flotado para evitar problemas de diseño */
  }
}
</style>
