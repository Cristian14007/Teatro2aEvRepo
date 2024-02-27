<script setup lang="ts">

import obras from "../App.vue"
import Card from '../components/Card.vue'
</script>

<template>
    DisplayObras

    <Card
    v-for="obra in obras"
    :id="obra.id"
    :titulo="obra.titulo"
    :descripcion="obra.descripcion"
    />
    
</template>