<template>
    <section class="about" id="about">



<div class="row">

    <div class="image">
                <img src="@/assets/hamlet.jpg" alt="Hamlet" width="150" height="150">
            
        <div class="row">
            <div class="col-6" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">Importe</div>
            <div class="col-6" id="obra-importe" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> </div>
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-6" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">Fecha 
            </div>
            <div class="col-6"  id="obra-fecha" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> </div>
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-6" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">Hora
            </div>
            <div class="col-6"  id="obra-hora" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> </div>
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-6" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">Lugar de
                Teatro</div>
            <div class="col-6"  id="obra-sala" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> </div>
        </div>
        <!-- Primera fila con dos columnas -->
        <div class="row">
            <div class="col-6" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;">Asientos Seleccionados
            </div>
            <div class="col-6"  id="obra-asientos" style="border: 3px solid black; padding: 10px; text-align: center;font-size:200%;"> </div>
        </div>

    </div>

    <div class="content">


        <form action="tu-servidor-de-procesamiento" method="post">


            <div class="form-group">
                <label for="cardNumber"><h2>Número de Tarjeta</h2></label>
                <input type="text" id="cardNumber" name="cardNumber" placeholder="1234 5678 9012 3456"
                    maxlength="19" pattern="\d{4} \d{4} \d{4} \d{4}" required>
            </div>

            <div class="form-group">
                <label for="cardExpiry"><h2>Fecha de Caducidad</h2></label>
                <input type="text" id="cardExpiry" name="cardExpiry" placeholder="MM/YY" pattern="\d{2}/\d{2}"
                    required>
            </div>

            <div class="form-group">
                <label for="cardCVV"><h2>CVV</h2></label>
                <input type="text" id="cardCVV" name="cardCVV" placeholder="123" maxlength="3" pattern="\d{3}"
                    required>
            </div>
            <div class="proceedBtnEl">
                <RouterLink to="/entrada" class="btn" id="entradabtn">Comprar entradas</RouterLink>
            </div>
        </form>
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
}
/* Estilos Generales */


form {
  background-color: #D8BE02;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  width: 300px;
  justify-content: flex-end; /* Alinea el contenido a la derecha */
  align-items: center;
  border: 3px solid #000000;
}

h2 {
  text-align: center;
  color: #333;
  margin-bottom: 20px;
}

.form-group {
  margin-bottom: 15px;

}

.form-group label {
  display: block;
  margin-bottom: 5px;
  color: #000000;
}

.form-group input {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
  box-sizing: border-box; /* Asegura que padding no afecte el ancho total */
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
  