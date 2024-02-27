<template>
    <div class="contact-section">
        <h1 class="heading"> <span>contacta</span> Con Nosotros </h1>

<div class="row">

    <iframe class="map"
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2997.0748300411788!2d-0.7522944999999999!3d41.3072357!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd592d62ba27cf45%3A0x4fb6400e7ffb138e!2sC.%20Constituci%C3%B3n%20Espa%C3%B1ola%2C%2050130%20Belchite%2C%20Zaragoza!5e0!3m2!1ses!2ses!4v1700930592834!5m2!1ses!2ses"
        width="700" height="500" style="border:0;" allowfullscreen="" loading="lazy"
        referrerpolicy="no-referrer-when-downgrade"></iframe>

    <form action="">
        <h3>Contactanos</h3>
        <div class="inputBox">
            <span class="fas fa-user"></span>
            <input type="text" name="name" value="DraMask" readonly>
        </div>
        <div class="inputBox">
            <span class="fas fa-envelope"></span>
            <input type="text" name="email2" value="DraMask@gmail.com" readonly>
        </div>
        <div class="inputBox">
            <span class="fas fa-phone"></span>
            <input type="text" name="phone" value="632-543-432" readonly>
        </div>
        <a href="mailto:DraMask@gmail.com" type="submit" value="contact now"
            class="btn">Contacta Ahora</a>
    </form>

</div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'ContactSection'
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
  .contact-section {
    margin-bottom: 80px;
  }
  
  .contact-section .row {
    display: flex;
    background: #D8BE02;
    flex-wrap: wrap;
    gap: 1rem;
  }
  
  .contact-section .row .map {
    flex: 1 1 45rem;
    object-fit: cover;
  }
  
  .contact-section .row form {
    flex: 1 1 45rem;
    padding: 5rem 2rem;
    text-align: center;
  }
  
  .contact-section .row form h3 {
    text-transform: uppercase;
    font-size: 3.5rem;
    color: var(--black);
  }
  
  .contact-section .row form .inputBox {
    display: flex;
    align-items: center;
    margin-top: 2rem;
    margin-bottom: 2rem;
    background: var(--white);
    border: var(--border);
  }
  
  .contact-section .row form .inputBox span {
    color: var(--black);
    font-size: 2rem;
    padding-left: 2rem;
  }
  
  .contact-section .row form .inputBox input {
    width: 100%;
    padding: 2rem;
    font-size: 1.7rem;
    color: var(--black);
    background: none;
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
  
  