<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';
import logo from '../components/logo.vue'
import { ref } from 'vue';

const isNavOpen = ref(false);
const isSearchOpen = ref(false);

const toggleSearch = () => {
  isSearchOpen.value = !isSearchOpen.value;
};
const toggleNav = () => {
  isNavOpen.value = !isNavOpen.value;
};
</script>

<template>

  <!-- <nav>
    <RouterLink to="/">Home</RouterLink>
    <RouterLink to="/about">About</RouterLink>
  </nav> -->

<header class="header">
    <a href="">
      <!-- <img src="../assets/logo3.png" alt="" width="50"> -->
      <router-link to="/"><logo></logo></router-link>
    </a>

    <nav class="navbar-header" :class="{ 'active': isNavOpen }">
    <RouterLink to="/">Inicio</RouterLink>
    <RouterLink to="/cartelera">Cartelera</RouterLink>
    <RouterLink to="/">Próximos Estrenos</RouterLink>
    <RouterLink to="/about">Sobre Nosotros</RouterLink>
    <RouterLink :to="{ name: 'AdminView'}" class="btn" id="adminbtn">Admin</RouterLink>
    </nav>

    <div class="icons" id="icons">
      <div class="fas fa-search" id="search-btn" @click="toggleSearch"></div>
      <div class="fas fa-bars" id="menu-btn" @click="toggleNav"></div>
    </div>

    <div class="search-form" :class="{ 'active': isSearchOpen }">
      <input type="search" id="search-box" placeholder="search here...">
      <label for="search-box" class="fas fa-search"></label>
    </div>

</header>

<!-- <RouterView /> -->
</template>

<style scoped>
.header {
  background-color: #F0D303;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1.5rem 7%;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
}

.navbar-header{
    align-items: end;
}
.navbar-header a {
  display: inline-block; 
  margin-right: 15px; 
  color: black; 
  font-family: Arial, sans-serif; 
  text-decoration: none; 
}

.navbar-header a:hover {
  text-decoration: underline; 
}
 .icons div {
  color: var(--black);
  cursor: pointer;
  font-size: 2.6rem;
  margin-left: 2rem;
}
 .icons div:hover {
  color: var(--main-color);
  transition: 1.5s;
  transform: rotate(-360deg) scale(1.3);
}
 .icons a {
  text-decoration: none;
  color: white;
}
 .icons .loginUser:hover {
  transform: none;
}
 .search-form {
  position: absolute;
  top: 115%;
  right: 7%;
  background: var(--white);
  width: 50rem;
  height: 5rem;
  display: flex;
  align-items: center;
  transform: scaleY(0);
  transform-origin: top;
}
.search-form input {
  height: 100%;
  width: 100%;
  font-size: 1.6rem;
  color: var(--black);
  padding: 1rem;
  text-transform: none;
}
.search-form label {
  cursor: pointer;
  font-size: 2.2rem;
  margin-right: 1.5rem;
  color: var(--black);
}
.search-form label:hover {
  color: #F0D303;
}
.search-form.active {
  transform: scaleY(1);
}
#menu-btn {
  display: none;
}
.menu .box-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(30rem, 1fr));
  gap: 1.5rem;
}
.menu .box-container .coolcard {
  position: relative;
  overflow: hidden;
  display: flex;
  flex-direction: column;
  border-radius: 15px;
  margin-left: 22.5%;
  color: rgb(255, 255, 255);
  height: 400px;
  width: 300px;
  flex: 1 1 45rem;
  transition: box-shadow 0.8s ease-in-out;
  font-family: "Palatino Linotype", "Book Antiqua", Palatino, serif;
  font-size: 20px;
  letter-spacing: 2px;
  word-spacing: 2px;
  box-shadow: 0 0 30px black;
  font-weight: 700;
  text-decoration: none solid rgb(192, 19, 19);
  font-style: italic;
  font-variant: normal;
  text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
  text-transform: none;
  background-size: cover;
}
.menu .box-container .coolcard:hover {
  box-shadow: rgba(22, 45, 91, 0.1) 0px 1px 2px, rgba(22, 45, 91, 0.1) 0px 2px 4px, rgba(22, 45, 91, 0.1) 0px 4px 8px, rgba(22, 45, 91, 0.1) 0px 8px 16px, rgba(22, 45, 91, 0.1) 0px 16px 32px, rgba(22, 45, 91, 0.1) 0px 32px 64px;
}
.menu .box-container .coolcard:hover::before {
  transform: rotate(360deg);
}
.menu .box-container .coolcard::before {
  position: absolute;
  content: "";
  border-radius: inherit;
  background: linear-gradient(235deg, #e100ff 0%, #162d5b 73 50%, #00bcd4 90%);
  top: -44px;
  bottom: -44px;
  left: -94px;
  right: -94px;
  transition: transform 1.5s ease-in-out;
  background-size: cover;
}
.menu .coolcard__img {
  object-fit: cover;
  object-position: left;
  position: relative;
  height: 100%;
  opacity: 0;
  transition: opacity 1.5s ease-in;
  background-size: cover;
}
.menu .coolcard:hover .coolcard__img {
  opacity: 0.9;
}
.menu .coolcard:hover .coolcard__body {
  transform: translateY(0px);
}
.menu .coolcard:hover .coolcard__title::before {
  width: 102%;
}
.menu .coolcard__body {
  padding: 0 1rem 1rem;
  background: linear-gradient(#000 0 0%, #000 e3 100%);
  transform: translateY(92px);
  transition: transform 1s ease;
}
.menu .coolcard__title {
  z-index: 1;
  position: relative;
  margin-block: 0.5rem;
  width: fit-content;
  font-weight: 700;
  font-size: 1.8em;
  -webkit-text-fill-color: transparent;
  -webkit-text-stroke: 1px white;
}
.menu .coolcard__title::before {
  content: "";
  position: absolute;
  bottom: 6px;
  background: #826251;
  height: 2px;
  width: 0%;
  transition: width 1s ease 0.5s;
}
.menu .coolcard-text {
  position: relative;
  color: #ddd de;
  text-align: start;
}
.menu .coolcard--2.coolcard::before {
  transition: none;
}
.menu .coolcard--2 .coolcard__img {
  position: absolute;
  left: 0;
  height: 100%;
  opacity: 0.4;
}
.menu .coolcard--2 .coolcard__body {
  position: absolute;
  bottom: 0;
  background: linear-gradient(#000 0 0%, #000 e3 100%);
}
@media (max-width: 991px) {
  html {
    font-size: 55%;
  }
  .header {
    padding: 1.5rem 2rem;
  }
  section {
    padding: 2rem;
  }
  .menu .box-container .coolcard {
    margin-left: 17%;
    height: 300px;
    width: 220px;
  }
}

@media (max-width: 768px) {
  #menu-btn {
    display: inline-block;
  }
  .navbar-header {
    display: none; /* Ocultar la navegación por defecto en móviles */
    position: absolute;
    top: 100%;
    background: #F0D303;
    width: 100%;
    height: calc(100vh - 9.5rem);
  }
  .navbar-header a {
    color: var(--black);
    display: block;
    margin: 1.5rem;
    padding: 0.5rem;
    font-size: 2rem;
  }
  .navbar-header.active {
    display: block; /* Mostrar la navegación cuando esté activa */
  }
  .header .navbar {
    position: absolute;
    top: 100%;
    right: -100%;
    background: #fff;
    width: 30rem;
    height: calc(100vh - 9.5rem);
  }
  .header .navbar a {
    color: var(--green);
    display: block;
    margin: 1.5rem;
    padding: 0.5rem;
    font-size: 2rem;
  }
  .header .navbar.active {
    right: 0;
  }
  .header .search-form {
    width: 90%;
    right: 2rem;
  }
  .home {
    background-position: left;
    justify-content: center;
    text-align: center;
  }
  .home .content img {
    margin-left: none;
    margin: 15px;
    width: 300px;
    height: 300px;
  }
  .key {
    margin-bottom: -20%;
  }
  .menu .box-container .coolcard {
    margin-left: 22%;
    height: 350px;
    width: 250px;
  }
}
@media (max-width: 541px) {
  html {
    font-size: 50%;
  }
  .about .row .image img {
    width: 100%;
    height: auto;
    max-width: 100px;
    display: block;
  }
  .about .row .image .container {
    margin-left: 15%;
  }
  .key {
    margin-bottom: -150%;
    left: -500px;
    z-index: -500;
  }
  .menu .box-container .coolcard {
    height: 350px;
    width: 250px;
  }
}
@media (max-width: 450px) {
  html {
    font-size: 50%;
  }
}
</style>