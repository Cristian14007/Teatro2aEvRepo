<template>
    <section class="review-section">
      <h1 class="heading">Reseñas <span>Clientes</span></h1>
      <div class="box-container">
        <div class="box">
                                    <p>El teatro es magnifico tiene unas instalaciones increibles y la ubicacion es
                                        espectacular de paso puedes visitar los alrededores del pueblo</p>
                                    <!-- <img src="images/pic-1.png" class="user" alt=""> -->
                                    <h3>Alberto Akkari</h3>
                                    <div class="stars">
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star-half-alt"></i>
                                    </div>
                                </div>

                                <div class="box">
                                    <p>La pagina web funciona de lujo, es sencilla y facil de utilizar a la vez que
                                        util, hace que la compra de entradas sea apta para todos los publicos</p>
                                    <!-- <img src="images/pic-2.png" class="user" alt=""> -->
                                    <h3>Erika Linan</h3>
                                    <div class="stars">
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                    </div>
                                </div>

                                <div class="box">
                                    <p>Los trabajadores de DraMask son personas encantadoras y muy atentas que te
                                        facilitan la visita al teatro, ademas tiene un gran catalogo de obras para todos
                                        los gustos</p>
                                    <!-- <img src="images/pic-3.png" class="user" alt=""> -->
                                    <h3>Diego Genzor</h3>
                                    <div class="stars">
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star-half-alt"></i>
                                    </div>
                                </div>
      </div>
    </section>
  </template>
  
  <script>
  export default {
    name: 'ReviewSection',
    // Aquí puedes agregar data, computed properties, methods, etc., si es necesario
  }
  </script>
  
  <style scoped>
.heading {
  text-align: center;
  color: var(--black);
  text-transform: uppercase;
  padding-bottom: 3.5rem;
  font-size: 4rem;
}
.heading span {
  color: #D8BE02;
  text-transform: uppercase;
}

.review-section .box-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(30rem, 1fr));
  gap: 1.5rem;
}

.review-section .box-container .box {
  border: var(--border);
  text-align: center;
  padding: 3rem 2rem;
  background-color: #D8BE02;
  box-shadow: 0 0px 30px #000000;
}

.review-section .box-container .box p {
  font-size: 1.5rem;
  line-height: 1.8;
  color: #000000;
  padding: 2rem 0;
}

.review-section .box-container .box .user {
  height: 7rem;
  width: 7rem;
  border-radius: 50%;
  object-fit: cover;
}

.review-section .box-container .box h3 {
  padding: 1rem 0;
  font-size: 2rem;
  color: var(--black);
}

.review-section .box-container .box .stars i {
  font-size: 1.5rem;
  color: #000;
}
</style>
