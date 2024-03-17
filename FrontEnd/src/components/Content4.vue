<template>
    <section class="about" id="about">

<h1 class="heading"> Gracias por la compra <span>Aqui tiene su entrada</span> </h1>

<div class="row">

    <div class="image">
        <img :src="'https://imgdramask.s3.amazonaws.com/' + obra?.imagen" :alt="obra?.titulo" width="150" height="150">
            </div>

    <div class="content">
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-12" id="obra-titulo" style="border: 3px solid black; padding: 10px; text-align: center;"> 
                {{ obra ? obra.titulo : 'Cargando...' }} 
            </div>

        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-12" id="obra-fecha" style="border: 3px solid black; padding: 10px; text-align: center;">{{ obra ? obra.fecha : 'Cargando...' }} </div>
            
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-12" id="obra-sala" style="border: 3px solid black; padding: 10px; text-align: center;">{{ obra ? obra.sala +' sala': 'Cargando...' }} </div>
            
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-12" id="obra-importe" style="border: 3px solid black; padding: 10px; text-align: center;">{{ obra ? obra.precio + ' €' : 'Cargando...' }} </div>
            
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-12" id="obra-asientos" style="border: 3px solid black; padding: 10px; text-align: center;">  {{ selectedSeatNumbers.join(', ') }}</div>
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
    const selectedSeats = route.params.selectedSeats;
  const selectedSeatNumbers = Array.isArray(selectedSeats) ? selectedSeats : [selectedSeats];

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
  valoracion: number;
  precio: number;
}

// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
  try {
    const response = await fetch(`http://dramaskBack.retocsv.es:80/Obra/${obraId}`);
    if (!response.ok) {
      throw new Error('Failed to fetch');
    }
    const data = await response.json();
    data.fecha = data.fecha ? formatDate(data.fecha) : null;
    obra.value = data;
  } catch (error) {
    console.error('Error:', error);
  }
});

function formatDate(dateString: string): string {
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, '0');
  const day = date.getDate().toString().padStart(2, '0');
  const hours = date.getHours().toString().padStart(2, '0');
  const minutes = date.getMinutes().toString().padStart(2, '0');
  return `${day}-${month}-${year} / ${hours}:${minutes}`;
}

</script>
  
  
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
  