
<script>
import ReviewSection from '@/components/ReviewSection.vue'
import ContactSection from '@/components/ContactSection.vue'

export default {
  components: {
    ReviewSection,
    ContactSection
  }
}
</script>

<template>
  <div id="about">
   
    <!-- <img src="images/logo4.png" id="logo" width="100"> -->
    <h1 class="titulo">Sobre Nosotros</h1>
    <main>
      
      <section class="about-section">
  
                        <div class="text">Somos DraMask, una empresa especializada en ofrecer espectaculos de teatro al
                            publico para que se apasionen
                            y disfruten con toda la variedad de obras que ofrecemos, nuestro objetivo es seguir
                            creciendo y sefuir llevando el teatro a la gente.
                            <br><br>El teatro DraMask se situa en el bello pueblo de Zaragoza, Belchite, donde
                            transmitimos nuestro amor por el tetro
                            a el pueblo y a todos los demas pueblos de alrededor que viajan hasta nuestro teatro para
                            vivir una experiencia unica
                        </div>
        <ReviewSection></ReviewSection>
      <ContactSection></ContactSection>
      </section>
      
    </main>
   
  </div>
</template>

<style scoped>

.titulo {
  color: #000000;
  letter-spacing: .05em;
  text-shadow: 4px 4px 0px #d5d5d5, 7px 7px 0px rgba(0, 0, 0, 0.2);
  text-align: center;
  font-family: "Avant Garde", Avantgarde, "Century Gothic", CenturyGothic, "AppleGothic", sans-serif;
  font-size: 52px;
  text-align: center;
  text-transform: uppercase;
  text-rendering: optimizeLegibility;
  margin-top: 2%;
}

.about-section .text {
  margin-bottom: 40px;
  font-size: 16px;
  line-height: 26px;
  color: #848484;
  font-weight: 400;
  padding-right: 35px;
}

.about-section {
  position: relative;
  padding: 120px 0 70px;
}
</style>


