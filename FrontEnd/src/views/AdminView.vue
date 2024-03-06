<script setup lang="ts">
import Admin from "../components/Admin.vue"
import { ref } from 'vue';

const nombreUsuario = ref('');
const contra = ref('');
const esAdmin = ref(false);
const mensajeError = ref('');

const verificarAcceso = () => {
  if (nombreUsuario.value === 'admin') {
    esAdmin.value = true;
    mensajeError.value = '';
  } else {
    mensajeError.value = 'No tienes acceso';
    esAdmin.value = false;
  }
};
</script>

<template>
    <section class="menu" id="menu">
        <br>
        <h1 class="heading"> Admin <span>View</span> </h1>
    </section>
    
    <div>
    <form @submit.prevent="verificarAcceso">
      <input type="text" v-model="nombreUsuario" placeholder="Nombre de usuario">
      <!-- <input type="text" v-model="contra" placeholder="Contraseña"> -->
      <button type="submit">Iniciar sesión</button>
    </form>

    <p v-if="mensajeError">{{ mensajeError }}</p>

    <!-- Componente Admin, mostrado solo si el usuario es admin -->
    <Admin v-if="esAdmin" />
  </div>
</template>


<style scoped>
.heading {
    text-align: center;
    color: #000000;
    text-transform: uppercase;
    padding-bottom: 3.5rem;
    font-size: 4rem;
}

.heading span {
    color: #F0D303;
    text-transform: uppercase;
}
</style>