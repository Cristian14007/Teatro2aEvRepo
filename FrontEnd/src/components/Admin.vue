<template>
    <div class="container">
        <div v-for="obra in obras" :key="obra.obraId" class="obra">
            <h2>{{ obra.titulo }}</h2>
            <p>{{ obra.descripcion }}</p>
            <p>Género: {{ obra.genero }}</p>
            <p>duracion: {{ obra.duracion }}</p>
            <p>director: {{ obra.director }}</p>
            <p>interpretes: {{ obra.interpretes }}</p>
            <p>fecha: {{ obra.fecha }}</p>
            <p>sala: {{ obra.sala }}</p>
            <p>precio: {{ obra.precio }}</p>
            <p>valoracion: {{ obra.valoracion }}</p>
            <button @click="eliminarObra(obra.obraId)">Eliminar</button>
            <!-- <button @click="mostrarModalEditar(obra)">Editar</button> -->
            <button @click="mostrarModalEditar(obra.obraId)">Editar</button>

        </div>
        <!-- Modal para editar obra -->
  <div v-if="obraIdEditada" class="modal">
    <h2>Editar Obra</h2>
    <form @submit.prevent="enviarEdicion">
      <input type="text" v-model="obraEditada.titulo" placeholder="Título" required>
      <input type="text" v-model="obraEditada.descripcion" placeholder="Descripción" required>
      <!-- Agrega campos adicionales para las demás propiedades de la obra -->
      <button type="submit">Guardar Cambios</button>
      <!-- <button type="button" @click="cerrarModal">Cancelar</button> -->
    </form>
  </div>
    </div>
    <!-- Añade esto para depurar -->
    <!-- <pre>{{ obraSeleccionada }}</pre>
    <pre>{{ obraEditada }}</pre> -->
</template>
  
<script setup lang="ts">
import { ref, onMounted } from 'vue';

interface Obra {
    obraId: number;
    titulo: string;
    imagen: string;
    descripcion: string;
    genero: string;
    duracion: string;
    director: string;
    interpretes: string;
    fecha: Date;
    sala: number;
    precio: number;
    valoracion: number;
}

const obras = ref<Obra[]>([]);
const obraIdEditada = ref(0);
// const obraSeleccionada = ref<Obra | null>(null);
const obraEditada = ref<Obra>({
    obraId: 0,
    titulo: '',
    imagen: '',
    descripcion: '',
    genero: '',
    duracion: '',
    director: '',
    interpretes: '',
    fecha: new Date(), // Asigna una fecha por defecto o deja en blanco según lo que necesites
    sala: 0,
    precio: 0,
    valoracion: 0,
    // Inicializa cualquier otra propiedad que necesites
});


const mostrarModalEditar = (id: number) => {
  const obraAEditar = obras.value.find(obra => obra.obraId === id);
  if (obraAEditar) {
    obraEditada.value = { ...obraAEditar };
    obraIdEditada.value = id;
  }
};



onMounted(async () => {
    try {
        const response = await fetch('http://localhost:5008/Obra');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        obras.value = await response.json();
    } catch (error) {
        console.error('Error:', error);
    }
});
// Función para eliminar una obra
const eliminarObra = async (obraId: number) => {
    try {
        const response = await fetch(`http://localhost:5008/Obra/${obraId}`, {
            method: 'DELETE',
        });
        if (!response.ok) {
            throw new Error('Error al eliminar la obra');
        }
        // Actualizar la lista de obras eliminando la obra borrada
        obras.value = obras.value.filter(obra => obra.obraId !== obraId);
    } catch (error) {
        console.error('Error:', error);
    }
};

const enviarEdicion = async () => {
  try {
    const response = await fetch(`http://localhost:5008/Obra/${obraIdEditada.value}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(obraEditada.value),
    });
    if (!response.ok) {
      throw new Error('Error al editar la obra');
    }
    // Actualiza la obra en la lista
    const index = obras.value.findIndex(o => o.obraId === obraIdEditada.value);
    obras.value[index] = { ...obraEditada.value };
    obraIdEditada.value = 0; // Resetea el ID de la obra seleccionada
  } catch (error) {
    console.error('Error:', error);
  }
};

</script>
  
<style scoped>
.modal {
    display: block;
    /* Asegúrate de que el modal sea bloque por defecto */
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: white;
    padding: 20px;
    z-index: 1000;
    /* Otros estilos que necesites para hacer visible el modal */
}
</style>

  