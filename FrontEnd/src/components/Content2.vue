<template>
    <section class="about" id="about">
        <div class="row">

            <div class="image">
                <img src="@/assets/hamlet.jpg" alt="Hamlet" width="150" height="150">
            </div>

            <div class="content">
        <!-- Primera fila con dos columnas -->
        <div class="row">
          <div class="col-12" id="obra-titulo" style="border: 3px solid black; padding: 10px; text-align: center; font-size:200%;"> 
            {{ obra ? obra.titulo : 'Cargando...' }}
          </div>

        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
          <div class="col-12" id="obra-fecha" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">
            <!-- {{ obra ? obra.fecha : 'Cargando...' }}  -->
          </div>

        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
          <div class="col-12" id="obra-sala" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> 
            <!-- {{ obra ? obra.sala : 'Cargando...' }} -->
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
    const response = await fetch(`http://localhost:5008/Obra/${obraId}`);
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
    color: #F4E8DA;
    font-size: 2.5em;
    letter-spacing: 3px;
}

.about .row .content {
    flex: 1 1 35rem;
    padding: 5rem;
}

.about .row .content h3 {
    font-size: 3rem;
    color: var(--white);
}

.about .row .content p {
    font-size: 1.6rem;
    color: #ccc;
    padding: 1rem 0;
    line-height: 1.8;
}</style>
  