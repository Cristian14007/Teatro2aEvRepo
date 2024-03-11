<!-- eslint-disable vue/multi-word-component-names -->
<script setup lang="ts">
import IconButaca from '@/components/icons/IconButaca.vue';
import { ref, onMounted, computed } from 'vue';
import axios from 'axios';
import { useRoute } from 'vue-router';


// cojo la url y el id de la obra
const route = useRoute();
const obraId = route.params.obraId;
const obra = ref<Obra | null>(null);
const seats = ref<Array<Butaca>>([]);
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
}

interface Butaca {
    obraId: number;
    butacaId: number;
    libre: boolean;

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
async function fetchSeatsPerId(id: any) {
        try {
            const response = await axios.get(`http://localhost:5008/Asiento/${id}`);
            console.log("Fetch para sacar butacas por obra id");
            seats.value = response.data;
            console.log(seats.value);

        } catch (error) {
            console.error('Error al hacer la petición:', error);
        }
    }




const choosenSeats = ref<number[]>([]);

function onChooseSeat(butacaId: number) {
  console.log(`Se selecciona la butaca ${butacaId}`);
  // Agregar el asiento seleccionado al array
  choosenSeats.value.push(butacaId);
  console.log(choosenSeats.value);
  // Guardar en el sessionStorage
  sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

function onUnchooseSeat(butacaId: number) {
  console.log(`Se deselecciona la butaca ${butacaId}`);
  // Filtrar el array para eliminar la butaca deseleccionada
  choosenSeats.value = choosenSeats.value.filter(seatId => seatId !== butacaId);
  console.log(choosenSeats.value);
  // Actualizar el sessionStorage
  sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

// Filtro para formatear la fecha
const formatoFecha = (fechaHora: string) => {
    const fecha = new Date(fechaHora);
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    return fecha.toLocaleDateString('es-ES', options);
};

// Filtro para formatear la hora
const formatoHora = (fechaHora: string) => {
    const hora = new Date(fechaHora);
    const options = { hour: 'numeric', minute: 'numeric' };
    return hora.toLocaleTimeString('es-ES', options);
};
</script>


<template>
    <div>
        Butacas view
    </div>

    <div class="content">
        <div class="info">
            <div class="info__text">
                <div class="title">
                    <h2>TITULO DE LA FUNCIÓN:</h2>
                    <h3>{{ FunctionStore.functions.titulo }}</h3>
                </div>
                <div class="hour">
                    <h2>HORA DE LA FUNCIÓN:</h2>
                    <h3>{{ formatoFecha(FunctionStore.functions.diaObra) }}</h3>
                </div>
            </div>
            <div class="info__img">
                <img :src="'../src/assets/IMAGENES/' + FunctionStore.functions.imagen" alt="">
            </div>
        </div>
        <div class="selection">
            <div class="title">
                <h2>SELECCION BUTACAS</h2>
            </div>
            <div class="gridButacas">
                <div class="butacas">

                    <div v-for="filaIndex in 10" :key="filaIndex">
                        <div class="fila">
                            <IconButaca
                                v-for="(butaca, index) in SeatStore.seats.slice((filaIndex - 1) * 10, filaIndex * 10)"
                                :key="butaca.butacaId" :isFree="butaca.libre" :butacaId="butaca.butacaId" @selectSeat="onChooseSeat" @unselectSeat="onUnchooseSeat"/>
                        </div>

                    </div>
                </div>


            </div>
            <div class="escenario">
                <div>escenario</div>
            </div>
        </div>
        <div class="button" id="botonPago">
            <RouterLink :to="'/Compra'">IR A PAGAR</RouterLink>
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