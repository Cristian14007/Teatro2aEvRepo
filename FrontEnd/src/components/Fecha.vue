<template>
    <section class="menu" id="menu">

<h1 class="heading"> Fecha <span>Hora</span> </h1>


<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El fecha de la obra se mostrará aquí -->
    </div>
    <div class="col-4" id="obra-hora" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El hora de la obra se mostrará aquí -->
    </div>
    <RouterLink to="/reserva" class="btn" id="reserva-btn">Comprar entradas</RouterLink>

</div>
<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha1" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El fecha de la obra se mostrará aquí -->
    </div>
    <div class="col-4" id="obra-hora1" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El hora de la obra se mostrará aquí -->
    </div>
    <a href="" type="submit" value="contact now" class="btn">Proximamente en venta</a>
</div>
<!-- Tercera fila con tres columnas -->
<div class="row">
    <div class="col-4" id="obra-fecha2" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El fecha de la obra se mostrará aquí -->
    </div>
    <div class="col-4" id="obra-hora2" style="border: 1px solid black; padding: 20px; text-align: center; font-size:200%;">   
        <!-- El hora de la obra se mostrará aquí -->
    </div>
    <a href="" type="submit" value="contact now" class="btn">Proximamente en venta</a>
</div>


</section>
</template>
  
  
<script setup lang="ts">

</script>
  
  
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
</style>
  