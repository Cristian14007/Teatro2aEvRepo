<template>
    <svg 
      xmlns="http://www.w3.org/2000/svg" 
      width="100%" 
      height="100px" 
      viewBox="0 0 600 100" 
      class="theater-stage"
    >
      <!-- Base del escenario -->
      <rect x="50" y="30" width="500" height="20" fill="#8B4513"/>
      <!-- Cortinas laterales -->
      <path d="M50 30 Q25 60, 50 90" fill="#B22222"/>
      <path d="M550 30 Q575 60, 550 90" fill="#B22222"/>
      <!-- Cortina central -->
      <path d="M50 30 Q300 10, 550 30 Q300 50, 50 30" fill="#800000"/>
      <!-- Texto (opcional) -->
     
    </svg>
  </template>
  
  <style scoped>
  .theater-stage {
    display: block;
    margin: auto;
  }
  </style>
  