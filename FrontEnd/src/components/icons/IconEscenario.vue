<script setup lang="ts">
import { ref } from 'vue'


</script>
<template>
    <!-- ... el resto de tu plantilla ... -->
    <div class="selection">
        <!-- ... contenido existente ... -->
        <div class="escenario">
            <svg class="escenario-svg" viewBox="0 0 100 20" xmlns="http://www.w3.org/2000/svg">
                <!-- Base del escenario -->
                <rect x="0" y="15" width="100" height="5" fill="#654321"/>
                <!-- Telón -->
                <rect x="20" y="0" width="60" height="15" fill="#ff0000"/>
                <!-- Laterales del escenario -->
                <rect x="0" y="0" width="20" height="15" fill="#7c7c7c"/>
                <rect x="80" y="0" width="20" height="15" fill="#7c7c7c"/>
            </svg>
        </div>
        <!-- ... resto de contenido ... -->
    </div>
</template>

<style scoped lang="scss">
    /* ... tus estilos existentes ... */

    .escenario {
        display: flex;
        justify-content: center;
        align-items: center;
        width: 100%;
        height: 50px;
        font-family: "Montserrat";
    }

    .escenario-svg {
        width: 100%;
        max-width: 800px; /* Ajusta este valor según el diseño */
        height: auto;
    }
</style>
