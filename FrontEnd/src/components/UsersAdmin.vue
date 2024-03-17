<template>
    <div class="container">
      <table>
  <thead>
    <tr>
      <th>Nombre</th>
      <th>Email</th>
      <th>Acciones</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="user in users" :key="user.userId">
      <td>{{ user.name }}</td>
      <td>{{ user.email }}</td>
      <td>
        <div class="action-buttons">
          <button class="delete-button" @click="eliminarObra(user.userId)">Eliminar</button>
          <!-- <button @click="mostrarModalEditar(obra)">Editar</button> -->
          <button class="edit-button" @click="mostrarModalEditar(user.userId)">Editar</button>
        </div>
      </td>
    </tr>
  </tbody>
</table>
        <!-- Modal para editar obra -->
  <div v-if="obraIdEditada" class="modal">
    <h2>Editar Obra</h2>
    <form @submit.prevent="enviarEdicion">
      <input type="text" v-model="obraEditada.name" placeholder="Título" required>
      <input type="text" v-model="obraEditada.email" placeholder="Descripción" required>
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

interface User {
    userId: number;
    name: string;
    email: string;

}

const users = ref<User[]>([]);
const obraIdEditada = ref(0);
// const obraSeleccionada = ref<Obra | null>(null);
const obraEditada = ref<User>({
    userId: 0,
    name: '',
    email: ''
});


const mostrarModalEditar = (id: number) => {
  const obraAEditar = users.value.find(user => user.userId === id);
  if (obraAEditar) {
    obraEditada.value = { ...obraAEditar };
    obraIdEditada.value = id;
  }
};



onMounted(async () => {
    try {
        const response = await fetch('http://dramaskBack.retocsv.es:80/User');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        users.value = await response.json();
    } catch (error) {
        console.error('Error:', error);
    }
});
// Función para eliminar una obra
const eliminarObra = async (userId: number) => {
    try {
        const response = await fetch(`http://dramaskBack.retocsv.es:80/User/${userId}`, {
            method: 'DELETE',
        });
        if (!response.ok) {
            throw new Error('Error al eliminar la obra');
        }
        // Actualizar la lista de obras eliminando la obra borrada
        users.value = users.value.filter(user => user.userId !== userId);
    } catch (error) {
        console.error('Error:', error);
    }
};

const enviarEdicion = async () => {
  try {
    const response = await fetch(`http://dramaskBack.retocsv.es:80/User/${obraIdEditada.value}`, {
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
    const index = users.value.findIndex(u => u.userId === obraIdEditada.value);
    users.value[index] = { ...obraEditada.value };
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


table {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 20px;
  }

  th, td {
    padding: 8px;
    text-align: left;
    border-bottom: 1px solid #ddd;
  }

  th {
    background-color: #f2f2f2;
  }

  tr:hover {
    background-color: #f5f5f5;
  }

  .action-buttons {
    display: flex;
    justify-content: space-between;
  }

  .action-buttons button {
    padding: 5px 10px;
    border: none;
    cursor: pointer;
  }

  .delete-button {
    background-color: #FF5733; /* Rojo */
    color: white;
  }

  .edit-button {
    background-color: #4CAF50; /* Verde */
    color: white;
  }

  .edit-button:hover {
    background-color: #45a049;
  }
</style>
