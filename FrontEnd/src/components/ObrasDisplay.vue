<script setup lang="ts">
import { computed, onMounted } from 'vue';
import Card from '../components/Card.vue'
import { useFunctionStore } from '../stores/FunctionStore';

const store = useFunctionStore();

onMounted(() => {
  store.cargarObras();
});

const obrasFiltradasYOrdenadas = computed(() => {
  let obrasFiltradas = store.obras
    .filter(obra => {
      return store.categoriaSeleccionada ? obra.genero === store.categoriaSeleccionada : true;
    })
    .filter(obra => {
      return obra.titulo.toLowerCase().includes(store.terminoBusqueda.toLowerCase());
    });

  switch (store.opcionOrdenacion) {
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
</script>

<template>
  <section class="filter" id="filter">
    <div class="filters">
      <!-- A continuación, los v-model se actualizan para enlazarlos directamente con el store -->
      <select class="select" v-model="store.opcionOrdenacion" name="selectOrdenacion">
        <option value="">Sin Ordenar</option>
        <option value="valoracionDesc">Mayor Valoración</option>
        <option value="precioDesc">Mayor Precio</option>
        <option value="valoracionAsc">Menor Valoración</option>
        <option value="precioAsc">Menor Precio</option>
      </select>
      <select class="select" v-model="store.categoriaSeleccionada" name="select2">
        <option value="">No Filtro</option>
        <option value="Drama">Drama</option>
        <option value="Musical">Musical</option>
        <option value="Tragedia">Tragedia</option>
        <option value="Comedia">Comedia</option>
      </select>
      <input type="text" v-model="store.terminoBusqueda" placeholder="Buscar obra" class="filtro-input">
      <span @click="store.removeFilter" id="removeFilter" class="fas fa-times"></span>
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
