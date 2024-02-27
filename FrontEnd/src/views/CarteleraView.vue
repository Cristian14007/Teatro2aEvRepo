<script setup lang="ts">
import ObrasDisplay from "../components/ObrasDisplay.vue"

</script>

<template>
 <section class="menu" id="menu">
<br>
<h1 class="heading"> Cartelera <span>obras</span> </h1>


</section>
    <ObrasDisplay></ObrasDisplay>
 

   
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