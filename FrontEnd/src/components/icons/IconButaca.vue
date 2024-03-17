<script setup lang="ts">
import { ref } from 'vue'

const emits = defineEmits(['selectSeat', 'unselectSeat'])

defineProps<{
    isFree: boolean;
    asientoid: number;
    num_Asiento: number;
}>()

const seatRef = ref<SVGGElement>();

// Funcion para seleccionar butacas
function chooseSeat(asientoid: number, isFree: boolean) {
    if (seatRef.value) {
        const esLibre = seatRef.value.classList.contains('free');
        // Si la butaca está libre en la base de datos
        if (isFree) { 
            console.log("butaca LIBRE en la BBDD");
            // Si se selecciona
            if (esLibre) { 
                seatRef.value.classList.remove('free');
                seatRef.value.classList.add('choosen');
                emits('selectSeat', asientoid);
            // Si se deselecciona
            } else {
                seatRef.value.classList.remove('choosen');
                seatRef.value.classList.add('free');
                emits('unselectSeat', asientoid);
            }

        // Si la butaca está ocupada en la base de datos
        } else {
            console.log("butaca OCUPADA en la BBDD: " + asientoid);
        }
    }
}
</script>

<template>
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 86 70" width="86" height="70">
  <g ref="seatRef" :class="[isFree ? 'free' : 'taken']" @click="chooseSeat(asientoid, isFree)">
    <!-- respaldo -->
    <rect x="12" y="2" width="60" height="40" rx="10" />

    <!-- asiento -->
    <rect x="12" y="42" width="60" height="20" rx="10" />

    <!-- reposabrazos izquierdo -->
    <rect x="2" y="26" width="20" height="40" rx="10" />

    <!-- reposabrazos derecho -->
    <rect x="62" y="26" width="20" height="40" rx="10" />

    <text x="40" y="35" fill="black" text-anchor="middle" alignment-baseline="middle">{{ num_Asiento }}</text>
  </g>
</svg>

</template>

<style>
.choosen {
    fill: #b7ba13;
    stroke-width: 1;
    stroke: rgb(0, 0, 0);
}

.free {
    fill: rgb(2, 238, 255);
    stroke-width: 1;
    stroke: rgb(0, 0, 0);
}

.taken {
    fill:#800000;
    stroke-width: 1;
    stroke: rgb(0, 0, 0);
}
</style>
