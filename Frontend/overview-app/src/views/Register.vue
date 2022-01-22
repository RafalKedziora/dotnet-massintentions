<template>
  <form class="register-form" @submit.prevent="saveChanges">
    <div class="title-section">
      <aside class="title">
        <h1>
          Rejestracja nowego użytkownika
        </h1>
        <go-back-button />
      </aside>
      <div class="buttons">
        <image-button
          caption="Zarejestruj"
          image-src="register-icon.svg"
          :task="() => ''"
        />
      </div>
    </div>
    <div class="inputs">
      <div class="inline-container">
        <div class="left">
          <input-with-label
            label="Email"
            name="email"
            input-type="email"
            v-model="user.email"
            :big="true"
          />
          <input-with-label
            label="Hasło"
            name="password"
            input-type="password"
            v-model="user.password"
            :big="true"
          />
          <input-with-label
            label="Potwierdź hasło"
            name="confirm-password"
            input-type="password"
            v-model="user.confirmPassword"
            :big="true"
          />
        </div>
        <div class="right">
          <input-with-label
            label="Imię"
            name="first-name"
            input-type="text"
            v-model="user.firstName"
            :big="true"
          />
          <input-with-label
            label="Nazwisko"
            name="last-name"
            input-type="text"
            v-model="user.lastName"
            :big="true"
          />
        </div>
      </div>
    </div>
  </form>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel"
import ImageButton from "@/components/ImageButton"
import {ApiService} from "@/services/api-service"
import GoBackButton from "@/components/GoBackButton"
const APIService = new ApiService()

export default {
  name: "Register",
  components: {
    InputWithLabel,
    ImageButton,
    GoBackButton
  },

  data(){
    return {
      user: {
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        confirmPassword: '',
      },
      roles: undefined,
    }
  },

  computed: {
    apiModel: function () {
      return {
        email: this.user.email,
        password: this.user.password,
        confirmPassword: this.user.confirmPassword
      }
    }
  },

  methods: {
    saveChanges: async function () {
      const [error] = await APIService.register(
        this.apiModel
      );

      if(error){
        console.error(error)
        return
      }

      await this.$router.push('/list')
    },
  },
}
</script>

<style scoped>
.title-section{
  display: flex;
  justify-content: space-between;
  height: 60px;
}

h1{
  font-size: 2rem;
  color: rgba(57, 29, 6, 1);
}

.register-form{
  flex: 1;
  padding: 40px 50px;
  height: 100%;

  display: flex;
  flex-direction: column;
}

.buttons, .title{
  display: flex;
}

.title button{
  align-self: flex-start;
  margin-top: 8px;
}

.inputs{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex: 1;
  margin-top: 40px;
}

.inline-container{
  display: flex;
  width: 100%;
}

.left, .right{
  flex-basis: 0;
  flex-grow: 1;
  flex: 1;
  width: 40%;
}

.left{
  padding-right: 20px;
}

.right{
  padding-left: 20px;
}
</style>