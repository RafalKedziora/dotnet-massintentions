<template>
  <section class="login-panel">
    <div class="login-wrapper">
      <div class="login-inputs">
        <input-with-label
          label="Login / email"
          name="login"
          input-type="text"
          v-model="login"
          class="login-input"
          :big="true"
        />
        <input-with-label
          label="Hasło"
          name="password"
          input-type="password"
          v-model="password"
          class="login-input"
          :big="true"
        />
      </div>
      <div class="login-buttons">
        <image-button
          caption="ZAREJESTRUJ SIĘ"
          image-src="register-icon.svg"
          :task="goToRegisterPage"
          class="login-button"
        />
        <image-button
          caption="ZALOGUJ SIĘ"
          image-src="login-icon.svg"
          :task="sendCredentials"
          class="login-button"
        />
      </div>
    </div>
    <div class="info-wrapper">
      <h2>INFORMACJE</h2>
      <p>{{ information }}</p>
    </div>
  </section>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel"
import ImageButton from "@/components/ImageButton"

export default {
  name: "Login",
  components: {
    InputWithLabel,
    ImageButton
  },
  data(){
    return{
      login: '',
      password: '',
      information: '' +
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ' +
        'ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco' +
        ' laboris nisi ut aliquip ex ea commodo consequat.'
    }
  },
  methods: {
    sendCredentials: function () {
      this.$router.push('/list')
    },

    goToRegisterPage: function () {
      this.$router.push('/register')
    }
  }
}
</script>

<style scoped>
.login-panel{
  width: 100vw;

  display: flex;
  justify-content: space-evenly;
  align-items: center;
}

.login-wrapper, .info-wrapper{
  height: 500px;
  width: 500px;
  padding: 50px 50px;

  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.login-wrapper{
  background-color: rgba(80, 44, 15, 0.3);
}

.info-wrapper{
  color: rgba(255, 255, 255, 1);
  background-color: rgba(80, 44, 15, 0.6);
  justify-content: space-evenly;
  align-items: center;
  text-align: center;
}

.info-wrapper h2{
  font-size: 2rem;
}

.info-wrapper p{
  font-size: 1.6rem;
}

.login-buttons{
  display: flex;
  flex-direction: column;
}

.login-input label{
  background-color: black;
}

.login-input label{
  font-size: 2rem;
  font-weight: 700;
}

.login-input input{
  height: 50px;
  font-size: 1.3rem;
}

.login-button{
  margin-top: 20px;
}

.login-button:nth-child(1){
  background-color: rgba(94, 66, 44, 0.9);
}
</style>