
<script setup lang="ts">

import SoyHeader from '../components/SoyHeader.vue'
import SoyFooter from '../components/SoyFooter.vue'
/* import Card from './components/Card.vue' */




function reciboClick(a:string) {
  console.log('click', a)
}
</script>

<template>


  
  <main>
    <br><br><br><br>
    <section class="menu" id="menu">

<h1 class="heading"> CARTELERA </h1>

</section>
 

  </main>


</template>

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


</style>

