<template>
    <section class="about" id="about">
        <div class="row">

            <div class="image">
                <img :src="'https://imgdramask.s3.amazonaws.com/' + obra?.imagen" :alt="obra?.titulo" width="150" height="150">
            </div>

            <div class="content">
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Género</h2>
                    </div>
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
        <!-- Se muestra el género de la obra aquí, asegurándose primero de que obra no es null  {{ obra.value?.genero }}-->
        {{ obra ? obra.genero : 'Cargando...' }}
      </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Descripción</h2>
                    </div>
                    <div class="col-6" id="obra-descripcion"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:120%;">
                        {{ obra ? obra.descripcion : 'Cargando...' }}
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Duración</h2>
                    </div>
                    <div class="col-6" id="obra-duracion"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
                        {{ obra ? obra.duracion : 'Cargando...' }}
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Director</h2>
                    </div>
                    <div class="col-6" id="obra-director"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
                        {{ obra ? obra.director : 'Cargando...' }}
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Interpretes</h2>
                    </div>
                    <div class="col-6" id="obra-interpretes"
                        style="border: 3px solid black; padding: 20px; text-align: center;font-size:150%;">
                        {{ obra ? obra.interpretes : 'Cargando...' }}
                    </div>
                </div>
            </div>

        </div>
    </section>
</template>
  
  
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const obraId = route.params.obraId;
const obra = ref<Obra | null>(null);

interface Obra {
  obraId: number;
  titulo: string;
  imagen: string;
  descripcion: string;
  genero: string;
  duracion: string;
  director: string;
  interpretes: string;
}

// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
  try {
    const response = await fetch(`http://dramaskBack.retocsv.es:80/Obra/${obraId}`);
    if (!response.ok) {
      throw new Error('Failed to fetch');
    }
    obra.value = await response.json();
  } catch (error) {
    console.error('Error:', error);
  }
});
</script>
  
  
<style scoped>
.about .row {
  display: flex;
  align-items: center;
  background: #D8BE02;
  flex-wrap: wrap;
}

.about .row .image {
    background: #D8BE02;
    display: grid;
    font-family: "Lato", sans-serif;
    text-transform: uppercase;
    flex: 1 1 45rem;
    background-size: cover;
}

.about .row .image .container {
    position: relative;
    margin: auto;
    margin-top: 5%;
    margin-bottom: 5%;
    overflow: hidden;
    width: 300px;
    height: 500px;
}

.about .row .image .bar {
    position: absolute;
    height: 85%;
    width: 3px;
    left: 7%;
    top: 7.5%;
    background: #F4E8DA;
}

.about .row .image img {
    width: 40%;
    height: 100%;
    margin-left: 30%;
}

.about .row h1 {
    font-size: 2.5em; /* Tamaño de fuente original */
}

.about .row .content {
    flex: 1 1 35rem; /* Originalmente 35rem */
    padding: 5rem;
}

.about .row .content h3 {
    font-size: 3rem; /* Tamaño de fuente original */
}

.about .row .content p {
    font-size: 1.6rem; /* Tamaño de fuente original */
}

</style>

  