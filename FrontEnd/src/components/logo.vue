<template>
     <canvas ref="miCanvas"
          width="50"
          height="50"
          @mouseenter="girarCanvas"
          @mouseleave="detenerGiroCanvas"></canvas>
</template>
   
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import img1Src from '@/assets/Capa_1.png';
import img2Src from '@/assets/Capa_2.png';
import img3Src from '@/assets/Capa_3.png';

const miCanvas = ref<HTMLCanvasElement | null>(null);

onMounted(() => {
    if (!miCanvas.value) return;

    const canvas = miCanvas.value as HTMLCanvasElement;
    const ctx = canvas.getContext('2d');

    if (!ctx) {
        console.error('No se pudo obtener el contexto del canvas');
        return;
    }

    var img1 = new Image();
    var img2 = new Image();
    var img3 = new Image();

    var posX = -200; // Posición inicial de img2 fuera del canvas
    var img3Visible = false; // Controla la visibilidad de img3

    function draw() {
        if (!ctx) return;
        ctx.clearRect(0, 0, canvas.width, canvas.height); // Usa canvas aquí
        ctx.drawImage(img1, 5, 2); // Dibujar img1 en posición fija

        if (posX < 23) { // Mover img2 hasta una posición específica
            posX += 2;
        }

        ctx.drawImage(img2, posX, 2); // Dibujar img2 en su posición actual

        if (img3Visible) {
            ctx.drawImage(img3, 0, img1.height + 2); // Dibujar img3 debajo de img1
        }

        requestAnimationFrame(draw); // Repetir la animación
    }
    setTimeout(function () {
        img3Visible = true; // Hacer img3 visible después de 5 segundos
    }, 5000); // 5000 milisegundos = 5 segundos

    img1.onload = () => {
    console.log("Imagen 1 cargada");
    draw();
};
img2.onload = () => {
    console.log("Imagen 2 cargada");
    draw();
};
img3.onload = () => {
    console.log("Imagen 3 cargada");
    draw();
};

img1.src = img1Src;
img2.src = img2Src;
img3.src = img3Src;
});

const girarCanvas = () => {
  if (miCanvas.value) {
    miCanvas.value.classList.add('canvas-rotar');
  }
};

const detenerGiroCanvas = () => {
  if (miCanvas.value) {
    miCanvas.value.classList.remove('canvas-rotar');
  }
};
</script>
   
<style scoped>
/* canvas {
    border: 1px solid black;
} */

@keyframes rotar360 {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}

.canvas-rotar {
  animation: rotar360 2s ease-in-out;
}
</style>
   