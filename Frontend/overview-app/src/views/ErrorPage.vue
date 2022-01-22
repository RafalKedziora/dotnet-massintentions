<template>
  <div class="error-page">
    <div class="error-wrapper">
      <h1>Nie odnaleziono podanej podstrony</h1>
      <h2>
        Podstrona o podanym adresie nie istnieje. Jeśli uważasz, że jest to wynik błędu,
        niezwłocznie zgłoś ten fakt administratorowi.
      </h2>
      <div class="buttons">
        <image-button
          caption="Wróć do strony głównej"
          image-src="backspace-icon.svg"
          :task="goToMainMenu"
        >
        </image-button>
        <image-button
          caption="Wróć na ostatnio odwiedzoną stronę"
          image-src="go-back-icon.svg"
          :task="goToLastPage"
        >
        </image-button>
      </div>
    </div>
  </div>
</template>

<script>
import ImageButton from "@/components/ImageButton"

export default {
  name: "ErrorPage",
  components: {
    ImageButton
  },
  methods: {
    goToMainMenu: function () {
      this.$router.push('/');
    },

    goToLastPage: function () {
      this.$router.go(-1);
    }
  }
}
</script>

<style scoped>
h1{
  font-size: 2rem;
  color: rgba(57, 29, 6, 1);
  margin-bottom: 30px;
}

h2{
  font-size: 1.4rem;
  color: rgba(57, 29, 6, 0.8);
  margin-bottom: 50px;
}

h1, h2{
  text-align: center;
}

.error-page{
  width: 100vw;
  min-height: 100vh;

  display: flex;
  justify-content: center;
  align-items: center;
}

.error-wrapper{
  display: flex;
  flex-direction: column;
  align-items: center;

  width: 100vw;
  max-width: 600px;
}

.buttons{
  display: flex;
}
</style>