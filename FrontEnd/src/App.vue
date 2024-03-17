<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';
import SoyHeader from './components/SoyHeader.vue'
import SoyFooter from './components/SoyFooter.vue'
import Card from './components/Card.vue'




const superadmin = false;

function reciboClick(a:string) {
  console.log('click', a)
}
</script>

<template>
    <SoyHeader></SoyHeader>
    <main>
      <br><br><br><br>
      <router-view></router-view>
      <SoyFooter></SoyFooter>
    </main>
  </template>



