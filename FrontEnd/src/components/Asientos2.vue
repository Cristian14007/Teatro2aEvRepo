<!-- eslint-disable vue/multi-word-component-names -->
<script setup lang="ts">
import IconAsiento from '@/components/icons/IconButaca.vue';
import IconEscenario from '@/components/icons/IconEscenario.vue';
import { ref, onMounted, computed } from 'vue';
//import axios from 'axios';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';
const router = useRouter(); // Obtiene el objeto router

import { toRaw } from 'vue';

async function proceedToPurchase() {
    const selectedSeatNumbers = choosenSeats.value.map(seat => seat.num_Asiento);

    // Verificar si hay asientos seleccionados
    if (selectedSeatNumbers.length === 0) {
        alert('No tienes asientos seleccionados');
        return; // Detener la función aquí si no hay asientos seleccionados
    }

    console.log("Asientos seleccionados:", selectedSeatNumbers);

    // Continuar con la navegación si hay asientos seleccionados
    router.push({ 
        name: 'CompraView', 
        params: { 
            selectedSeats: selectedSeatNumbers.join(',') 
        } 
    });

    
    await updateSeatStatus();
}




// cojo la url y el id de la obra
const route = useRoute();
const obraId = route.params.obraId;
const obra = ref<Obra | null>(null);
const seats = ref<Array<Asiento>>([]);
    const calcularCantidad = computed(() => {
  // Filtrar solo los asientos que no están reservados y contarlos
  return seats.value.filter(seat => !seat.reservado).length;
});
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
    asientos: Array<Asiento>;
}

interface Asiento {
    obraId: number;
    asientoId: number;
    reservado: boolean;
    num_Asiento: number;

}
interface Seat {
    asientoId: number;
    num_Asiento: number;
}
// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
    try {
        const obraResponse = await fetch(`http://dramaskBack.retocsv.es:80/Obra/${obraId}`);
        if (!obraResponse.ok) {
            throw new Error('Failed to fetch obra details');
        }
        const obraData = await obraResponse.json();
        obra.value = obraData;
        seats.value = obraData.asientos; // Asume que los asientos están incluidos en la respuesta de la obra
    } catch (error) {
        console.error('Error:', error);
    }
});

onMounted(() => {
    console.log("Parámetros de la ruta en Compra:", route.params);
});




const choosenSeats = ref<Seat[]>([]);


function onChooseSeat(asientoId: number, num_Asiento: number) {
    console.log(`Asiento seleccionado: ${asientoId}, Número: ${num_Asiento}`);
    const seat = { asientoId, num_Asiento };
    choosenSeats.value.push(seat);
    console.log("Asientos seleccionados después de agregar:", choosenSeats.value);
    // Guardar en el sessionStorage
    sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

function onUnchooseSeat(asientoId: number) {
    console.log(`Asiento deseleccionado: ${asientoId}`);
    choosenSeats.value = choosenSeats.value.filter(seat => seat.asientoId !== asientoId);
    console.log("Asientos seleccionados después de quitar:", choosenSeats.value);
    // Actualizar el sessionStorage
    sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
}

async function updateSeatStatus() {
    try {
        // Crear un array de promesas para cada solicitud de actualización
        const updatePromises = choosenSeats.value.map(seat => 
            fetch(`http://dramaskBack.retocsv.es:80/Asiento/${seat.asientoId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ reservado: true }),
            })
        );

        // Esperar a que todas las solicitudes se completen
        const responses = await Promise.all(updatePromises);

        // Comprobar si alguna solicitud no fue exitosa
        const allSuccessful = responses.every(response => response.ok);
        if (!allSuccessful) {
            throw new Error('Error al actualizar uno o más asientos');
        }

        // Limpieza después de la actualización exitosa
        sessionStorage.removeItem('choosenSeats');
        choosenSeats.value = [];

        // Aquí puedes redirigir o mostrar un mensaje de éxito
    } catch (error) {
        console.error('Error al actualizar los asientos:', error);
    }
}



</script>


<template>
    <div class="content">
        <div class="selection">
            <h1 class="heading"> Selección <span>Asientos</span> </h1>

                <h3>Total de Asientos: {{ calcularCantidad }}</h3>

            <div class="gridasientos">
                <div class="asientos">
                    <div v-if="obra && obra.asientos">
                        <div v-for="filaIndex in 5" :key="filaIndex" class="fila">
                            <IconAsiento v-for="asiento in obra.asientos.slice((filaIndex - 1) * 5, filaIndex * 5)"
            :key="asiento.asientoId"
            :isFree="!asiento.reservado"
            :asientoid="asiento.asientoId"
            :num_Asiento="asiento.num_Asiento"
            @selectSeat="onChooseSeat(asiento.asientoId, asiento.num_Asiento)"
            @unselectSeat="onUnchooseSeat(asiento.asientoId)" />
                        </div>
                    </div>

                </div>
            </div>
            <div class="escenario">
                <div><IconEscenario></IconEscenario></div>
            </div>
        </div>
        <div class="buttonCont">
              <div class="cancelBtn">
                <button id="cancelBtn">Cancelar</button>
              </div>
              <div class="proceedBtnEl">
                <!--<button href="Compra.html?id=placeholder" id="proceedBtn">Continuar</button>-->
                 <!-- <RouterLink :to="{ name: 'CompraView', params: { obraId: obra?.obraId ?? 'defaultId' }}" class="btn" id="proceedBtn">Continuar</RouterLink> -->
                 <button @click="proceedToPurchase" class="btn" id="proceedBtn">Continuar</button>


              </div>
            </div>
    </div>
</template>


<style scoped lang="scss">
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


 .buttonCont .cancelBtn button {
    margin-top: 1rem;
  display: inline-block;
  padding: 0.9rem 3rem;
  font-size: 1.7rem;
  color: var(--black);
  background: #D8BE02;
  cursor: pointer;
  border: 3px solid #000000;
}
 .buttonCont .cancelBtn button:hover {
  background-color: rgb(204, 0, 41);
  transition: 0.3s ease background-color;
  box-shadow: 0 12px 16px 0 rgba(0, 0, 0, 0.24), 0 17px 50px 0 rgba(0, 0, 0, 0.19);
}
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
    color: #b7ba13;
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
    background-color: #b7ba13;
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

.selection .gridButacas .asientos {
    width: 100%;
    height: 380px;
    display: grid;
    grid-template-rows: repeat(10, 30px);
    grid-gap: 5px;
    justify-content: center;
    align-items: center;
}

.selection .gridButacas .asientos .fila {
    padding: 0;
    display: flex;
    align-items: center;
    justify-content: center;
}

.selection .gridButacas .asientos .asiento {
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
    background-color: #afba13;
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
}
</style>