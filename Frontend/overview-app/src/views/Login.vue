<template>
  <section class="login-panel">
    <form class="login-wrapper" @submit.prevent="sendCredentials">
      <div class="login-inputs">
        <input-with-label
          label="Login / email"
          name="email"
          input-type="email"
          v-model="email"
          class="email-input"
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
        <p v-if="isPasswordError">
          Błędny login lub hasło
        </p>
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
          :task="() => ''"
          class="login-button"
        />
      </div>
    </form>
    <div class="info-wrapper">
      <h2>INFORMACJE</h2>
      <p>{{ information }}</p>
    </div>
  </section>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel"
import ImageButton from "@/components/ImageButton"
import {ApiService} from "@/services/api-service"

const APIService = new ApiService()

export default {
  name: "Login",
  components: {
    InputWithLabel,
    ImageButton
  },

  data(){
    return{
      email: '',
      password: '',
      information: '' +
        'Prosimy wszystkich duchownych w parafii o rejestrację kont w nowym systemie do obsługi' +
        'intencji mszalnych. Odpowiednie uprawienia administracyjne zostały przekazane proboszczowi. ' +
        'Szkolenie z korzystania z systemu odbędzie się w piątek o 19:00',
      isPasswordError: false
    }
  },

  computed: {
    apiModel: function () {
      return {
        email: this.email,
        password: this.password
      }
    }
  },

  methods: {
    sendCredentials: async function () {
      this.isPasswordError = false
      const [loginError, token] = await APIService.login(this.apiModel)

      if(loginError){
        this.isPasswordError = true
        console.error(loginError)
        return
      }

      this.$emit('login', {token, email: this.email})
      await this.$router.push('/list')
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

.login-inputs p{
  margin-left: 10px;
  color: rgba(255, 255, 255, 1);
  font-weight: 700;
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