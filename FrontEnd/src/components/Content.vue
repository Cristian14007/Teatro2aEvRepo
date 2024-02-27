<template>
    <section class="about" id="about">
        <div class="row">

            <div class="image">
                <img src="@/assets/hamlet.jpg" alt="Hamlet" width="150" height="150">
            </div>

            <div class="content">
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Género</h2>
                    </div>
                    <div class="col-6" id="obra-genero"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
                        <!-- El género de la obra se mostrará aquí -->
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Descripción</h2>
                    </div>
                    <div class="col-6" id="obra-descripcion"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:120%;">
                        <!-- El descrip de la obra se mostrará aquí -->
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Duración</h2>
                    </div>
                    <div class="col-6" id="obra-duracion"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
                        <!-- El duracion de la obra se mostrará aquí -->
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Director</h2>
                    </div>
                    <div class="col-6" id="obra-director"
                        style="border: 3px solid black; padding: 20px; text-align: center; font-size:200%;">
                        <!-- El director de la obra se mostrará aquí -->
                    </div>
                </div>
                <!-- Primera fila con dos columnas -->
                <div class="row">
                    <div class="col-6" style="border: 3px solid black; padding: 20px; text-align: center;">
                        <h2>Interpretes</h2>
                    </div>
                    <div class="col-6" id="obra-interpretes"
                        style="border: 3px solid black; padding: 20px; text-align: center;font-size:150%;">
                        <!-- El interpretes de la obra se mostrará aquí -->
                    </div>
                </div>
            </div>

        </div>
    </section>
</template>
  
  
<script setup lang="ts">

</script>
  
  
<style scoped>
.about .row {
  display: flex;
  align-items: center;
  background: #D8BE02;
  flex-wrap: wrap;
}

.about .row .image {
    background: #D8BE02;
    display: grid;
    font-family: "Lato", sans-serif;
    text-transform: uppercase;
    flex: 1 1 45rem;
    background-size: cover;
}

.about .row .image .container {
    position: relative;
    margin: auto;
    margin-top: 5%;
    margin-bottom: 5%;
    overflow: hidden;
    width: 300px;
    height: 500px;
}

.about .row .image .bar {
    position: absolute;
    height: 85%;
    width: 3px;
    left: 7%;
    top: 7.5%;
    background: #F4E8DA;
}

.about .row .image img {
    width: 40%;
    height: 100%;
    margin-left: 30%;
}

.about .row h1 {
    color: #F4E8DA;
    font-size: 2.5em;
    letter-spacing: 3px;
}

.about .row .content {
    flex: 1 1 35rem;
    padding: 5rem;
}

.about .row .content h3 {
    font-size: 3rem;
    color: var(--white);
}

.about .row .content p {
    font-size: 1.6rem;
    color: #ccc;
    padding: 1rem 0;
    line-height: 1.8;
}</style>
  