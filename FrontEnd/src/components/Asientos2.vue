<!-- eslint-disable vue/multi-word-component-names -->
<script setup lang="ts">
import { onMounted, computed } from 'vue';
import IconAsiento from '@/components/icons/IconButaca.vue';
import IconEscenario from '@/components/icons/IconEscenario.vue';
import { useRoute, useRouter } from 'vue-router';
import { useAsientoStore } from '@/stores/AsientoStore';

const route = useRoute();
const router = useRouter();
const obraId = route.params.obraId;
const asientoStore = useAsientoStore();


onMounted(() => {
  // Asegurarse de que obraId es un número antes de pasarlo a cargarAsientos
  const obraIdParam = route.params.obraId;
  let obraIdNumber = 0;

  if (Array.isArray(obraIdParam)) {
    // Si es un array, toma el primer elemento y conviértelo a número
    obraIdNumber = parseInt(obraIdParam[0], 10);
  } else {
    // Si no es un array, conviértelo directamente a número
    obraIdNumber = parseInt(obraIdParam, 10);
  }

  // Verificar si obraIdNumber es un número válido antes de llamar a cargarAsientos
  if (!isNaN(obraIdNumber)) {
    asientoStore.cargarAsientos(obraIdNumber);
  } else {
    console.error('ID de obra inválido:', obraIdParam);
  }
});

const calcularCantidad = computed(() => {
  return asientoStore.seats.filter(seat => !seat.reservado).length;
});

async function proceedToPurchase() {
    const selectedSeatNumbers = asientoStore.choosenSeats.map(seat => seat.num_Asiento);

    if (selectedSeatNumbers.length === 0) {
        alert('No tienes asientos seleccionados');
        return;
    }

    console.log("Asientos seleccionados:", selectedSeatNumbers);

    router.push({ 
        name: 'CompraView', 
        params: { 
            selectedSeats: selectedSeatNumbers.join(',') 
        } 
    });

    await asientoStore.updateSeatStatus();
}
</script>

<template>
    <div class="content">
        <div class="selection">
            <h1 class="heading"> Selección <span>Asientos</span> </h1>
                <h3>Total de Asientos: {{ calcularCantidad }}</h3>
            <div class="gridasientos">
                <div class="asientos">
                    <div v-if="asientoStore.seats.length">
                        <div v-for="filaIndex in 5" :key="filaIndex" class="fila">
                            <IconAsiento 
                                v-for="asiento in asientoStore.seats.slice((filaIndex - 1) * 5, filaIndex * 5)"
                                :key="asiento.asientoId"
                                :isFree="!asiento.reservado"
                                :asientoid="asiento.asientoId"
                                :num_Asiento="asiento.num_Asiento"
                                @selectSeat="asientoStore.onChooseSeat(asiento.asientoId, asiento.num_Asiento)"
                                @unselectSeat="asientoStore.onUnchooseSeat(asiento.asientoId)" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="escenario">
                <IconEscenario></IconEscenario>
            </div>
        </div>
        <div class="buttonCont">
            <div class="cancelBtn">
                <button id="cancelBtn">Cancelar</button>
            </div>
            <div class="proceedBtnEl">
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