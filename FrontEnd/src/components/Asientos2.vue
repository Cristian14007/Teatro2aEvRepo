<!-- eslint-disable vue/multi-word-component-names -->
<script setup lang="ts">
import IconAsiento from '@/components/icons/IconButaca.vue';
import { ref, onMounted, computed } from 'vue';
//import axios from 'axios';
import { useRoute } from 'vue-router';


// cojo la url y el id de la obra
const route = useRoute();
const obraId = route.params.obraId;
const obra = ref<Obra | null>(null);
const seats = ref<Array<Asiento>>([]);
const calcularCantidad = computed(() => seats.value.length);
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
  asiento: Array<Asiento>;
}

interface Asiento {
    obraId: number;
    asientoId: number;
    reservado: boolean;

}
// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
  try {
    const obraResponse = await fetch(`http://localhost:5008/Obra/${obraId}`);
    if (!obraResponse.ok) {
      throw new Error('Failed to fetch obra details');
    }
    obra.value = await obraResponse.json();
    await fetchSeatsPerId(obraId); // Llama a fetchSeatsPerId después de cargar los detalles de la obra
  } catch (error) {
    console.error('Error:', error);
  }
});

// Función para cargar los asientos por obraId
async function fetchSeatsPerId(id:any) {
    try {
        const seatsResponse = await fetch(`http://localhost:5008/Asiento/${id}`);
        if (!seatsResponse.ok) {
            throw new Error('Failed to fetch seats');
        }
        const data = await seatsResponse.json();
        if (Array.isArray(data)) {
            seats.value = data;
        } else {
            // Convertir objeto en array o manejar de otra manera
            seats.value = [data]; // Si 'data' es un objeto y quieres convertirlo en un array
        }
    } catch (error) {
        console.error('Error al hacer la petición:', error);
    }
}



const choosenSeats = ref<number[]>([]);

function onChooseSeat(asientoId: number) {
  console.log(`Se selecciona la asiento ${asientoId}`);
  // Agregar el asiento seleccionado al array
  choosenSeats.value.push(asientoId);
  console.log(choosenSeats.value);
  // Guardar en el sessionStorage
  sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

function onUnchooseSeat(asientoId: number) {
  console.log(`Se deselecciona la asiento ${asientoId}`);
  // Filtrar el array para eliminar la asiento deseleccionada
  choosenSeats.value = choosenSeats.value.filter(seatId => seatId !== asientoId);
  console.log(choosenSeats.value);
  // Actualizar el sessionStorage
  sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

</script>


<template>

    <div class="content">
        <div class="selection">
            <div class="title">
                <h2>SELECCION Asientos</h2>
                <h3>Total de Asientos: {{ calcularCantidad }}</h3>
            </div>
            <div class="gridasientos">
                <div class="asientos">
  < <div v-for="filaIndex in 10" :key="filaIndex" class="fila">
    <IconAsiento
      v-for="asiento in obra.value.asientos.slice((filaIndex - 1) * 10, filaIndex * 10)"
      :key="asiento.asientoId"
      :isFree="!asiento.reservado"
      :asientoid="asiento.asientoId"
      @selectSeat="onChooseSeat"
      @unselectSeat="onUnchooseSeat" />
  </div>
</div>



            </div>
            <div class="escenario">
                <div>escenario</div>
            </div>
        </div>
        <div class="button" id="botonPago">
            <RouterLink :to="'/compra'">IR A PAGAR</RouterLink>
        </div>
    </div>
</template>


<style scoped lang="scss">
.content {
    width: 100%;
    display: flex;
    flex-direction: column;
}

.info {
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.info__text {
    width: 50%;
    height: auto;
    background-color: #fff;
    margin-top: 5px;
}

.info__text div {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.info__text div h2 {
    margin-top: 5%;
    margin-bottom: 0;
    margin-left: 6%;
    margin-right: 6%;
    font-family: "Bebas Neue";
    color: #ffffff;
    color: #ba1313;
}

.info__text div h3 {
    margin-top: 0;
    margin-bottom: 5%;
    font-family: "Montserrat";
}

.info__img {
    width: 50%;
    height: 100%;
    background-color: #fff;
    margin-top: 5px;
}

.info__img img {
    width: 55%;
    height: auto;
    border-radius: 15px;
    margin-top: 5%;
}

.selection {
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.selection .title {
    width: 100%;
    height: 15%;
    background-color: #ba1313;
    margin-top: 5%;
    margin-bottom: 0;
    margin-left: 6%;
    margin-right: 6%;
    font-family: "Bebas Neue";
    color: #ffffff;
}

.selection .gridButacas {
    width: 100%;
    height: 70%;
}

.selection .gridButacas .butacas {
    width: 100%;
    height: 380px;
    display: grid;
    grid-template-rows: repeat(10, 30px);
    grid-gap: 5px;
    justify-content: center;
    align-items: center;
}

.selection .gridButacas .butacas .fila {
    padding: 0;
    display: flex;
    align-items: center;
    justify-content: center;
}

.selection .gridButacas .butacas .butaca {
    width: 22px;
    height: 22px;
    background-size: cover;
    cursor: pointer;
    margin: 3px;
}

.selection .gridButacas .escenario {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 50px;
    font-family: "Montserrat";
}

.selection .gridButacas .escenario div {
    background-color: #D9D9D9;
    height: 100%;
    width: 60%;
}

.selection .button {
    width: 100%;
    height: 15%;
    margin: 20px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.selection .button a {
    color: #ffffff;
    text-decoration: none;
    background-color: #ba1313;
    padding: 10px;
    font-family: "Montserrat";
    font-size: 18px;
    border-radius: 50px;
}

/* PARA ORDENADORES */
@media screen and (min-width: 767px) {
    .info__img {
        width: 30%;
    }

    .selection .gridButacas .butacas {
        height: 415px;
        grid-gap: 8px;
    }

    .selection .gridButacas .butacas .butaca {
        width: 37px;
        height: 35px;
        margin: 5px;
    }

    .selection .gridButacas .escenario div {
        margin-top: 35px;
    }

    .selection .button {
        margin: 45px;
    }
}</style>