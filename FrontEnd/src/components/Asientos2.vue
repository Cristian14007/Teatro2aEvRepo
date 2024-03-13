<!-- eslint-disable vue/multi-word-component-names -->
<script setup lang="ts">
import IconAsiento from '@/components/icons/IconButaca.vue';
import { ref, onMounted, computed } from 'vue';
//import axios from 'axios';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';
const router = useRouter(); // Obtiene el objeto router


async function proceedToPurchase() {
    await updateSeatStatus();
    // Navegar a la vista de compra después de actualizar los asientos
    router.push({ name: 'CompraView', params: { obraId },  });
}

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
    asientos: Array<Asiento>;
}

interface Asiento {
    obraId: number;
    asientoId: number;
    reservado: boolean;
    num_Asiento: number;

}
// Simula una función para cargar los datos de la obra basada en obraId
onMounted(async () => {
    try {
        const obraResponse = await fetch(`http://localhost:5008/Obra/${obraId}`);
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


// // Función para cargar los asientos por obraId
// async function fetchSeatsPerId(id: any) {
//     try {
//         const seatsResponse = await fetch(`http://localhost:5008/Asiento/${id}`);
//         if (!seatsResponse.ok) {
//             throw new Error('Failed to fetch seats');
//         }
//         const data = await seatsResponse.json();
//         if (Array.isArray(data)) {
//             seats.value = data;
//         } else {
//             // Convertir objeto en array o manejar de otra manera
//             seats.value = [data]; // Si 'data' es un objeto y quieres convertirlo en un array
//         }
//     } catch (error) {
//         console.error('Error al hacer la petición:', error);
//     }
// }



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

async function updateSeatStatus() {
    try {
        // Crear un array de promesas para cada solicitud de actualización
        const updatePromises = choosenSeats.value.map(asientoId => 
            fetch(`http://localhost:5008/Asiento/${asientoId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    reservado: true,
                }),
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
            <div class="title">
                <h2>SELECCION Asientos</h2>
                <h3>Total de Asientos: {{ calcularCantidad }}</h3>
            </div>
            <div class="gridasientos">
                <div class="asientos">
                    <div v-if="obra && obra.asientos">
                        <div v-for="filaIndex in 10" :key="filaIndex" class="fila">
                            <IconAsiento v-for="asiento in obra.asientos.slice((filaIndex - 1) * 10, filaIndex * 10)"
                                :key="asiento.asientoId" :isFree="!asiento.reservado" :asientoid="asiento.asientoId" :numAsiento="asiento.num_Asiento"
                                @selectSeat="onChooseSeat" @unselectSeat="onUnchooseSeat" />
                        </div>
                    </div>

                </div>
            </div>
            <div class="escenario">
                <div>escenario</div>
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