<template>
    <div id="slider">
      <figure>
        <img v-for="(img, index) in images" :key="index" :src="img" width="700" height="400" :alt="`Slider image ${index + 1}`">
      </figure>
    </div>
  </template>
  
  
  <script setup lang="ts">
  import { defineComponent } from 'vue';
  
  // Importa imágenes estáticamente
  import sliderImage1 from '@/assets/slider.5.jpg';
  import sliderImage2 from '@/assets/slider3.jpg';
  import sliderImage3 from '@/assets/slider2.webp';
  import sliderImage4 from '@/assets/s4.jpg';
  import sliderImage5 from '@/assets/s5.jpg';
  
  defineComponent({
    name: 'AboutSlider',
    // Otras opciones de componente
  });
  
  // Exponer las imágenes para usarlas en el template
  const images = [sliderImage1, sliderImage2, sliderImage3, sliderImage4, sliderImage5];
  </script>
  
  
  <style scoped>
  @keyframes slidy {
    0% { left: 0%; }
    20% { left: 0%; }
    25% { left: -100%; }
    45% { left: -100%; }
    50% { left: -200%; }
    70% { left: -200%; }
    75% { left: -300%; }
    95% { left: -300%; }
    100% { left: -400%; }
  }
  
  #slider {
    overflow: hidden;
  }
  
  #slider figure {
    position: relative;
    width: 500%;
    margin: 0;
    left: 0;
    text-align: left;
    font-size: 0;
    animation: 33s slidy infinite;
  }
  
  #slider figure img {
    width: 20%;
    float: left;
  }
  </style>
  