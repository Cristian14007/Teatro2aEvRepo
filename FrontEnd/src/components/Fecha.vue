<template>
    <section class="menu" id="menu">

<h1 class="heading"> Fecha <span>Hora</span> </h1>


<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
      {{ obra ? obra.fecha : 'Cargando...' }}
    </div>

    <!-- <RouterLink to="/reserva" class="btn" id="reserva-btn">Comprar entradas</RouterLink> -->
    <RouterLink :to="{ name: 'ReservaView', params: { obraId: obra?.obraId ?? 'defaultId' }}" class="btn" id="reserva-btn">Comprar entradas</RouterLink>
</div>
<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha1" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
      {{ obra ? obra.fecha_Estreno_1 : 'Cargando...' }}
    </div>

    <a href="" type="submit" value="contact now" class="btn">Proximamente en venta</a>
</div>
<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha2" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
      {{ obra ? obra.fecha_Estreno_2 : 'Cargando...' }}
    </div>

    <a href="" type="submit" value="contact now" class="btn">Proximamente en venta</a>
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
  fecha: Date;
  fecha_Estreno_1: Date;
  fecha_Estreno_2: Date;
  sala: number;
  valoracion: number;
  precio: number;
}

// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
  try {
    const response = await fetch(`http://localhost:5008/Obra/${obraId}`);
    if (!response.ok) {
      throw new Error('Failed to fetch');
    }
    const data = await response.json();
    data.fecha = data.fecha ? formatDate(data.fecha) : null;
    data.fecha_Estreno_1 = data.fecha_Estreno_1 ? formatDate(data.fecha_Estreno_1) : null;
    data.fecha_Estreno_2 = data.fecha_Estreno_2 ? formatDate(data.fecha_Estreno_2) : null;
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
.btn {
  margin-top: 1rem;
  display: inline-block;
  padding: 0.9rem 3rem;
  font-size: 1.7rem;
  color: var(--black);
  background: #D8BE02;
  cursor: pointer;
  border: 3px solid #000000;
}

.btn:hover {
  box-shadow: 0 12px 16px 0 rgba(0, 0, 0, 0.24), 0 17px 50px 0 rgba(0, 0, 0, 0.19);
}

/* Media queries para pantallas más pequeñas */
@media (max-width: 768px) {
  .btn {
    padding: 0.7rem 2rem; /* Padding más pequeño para dispositivos móviles */
    font-size: 1.4rem; /* Tamaño de fuente más pequeño */
    margin-top: 0.5rem; /* Margen superior ajustado */
  }
}


</style>
  