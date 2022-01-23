<template>
  <section id="app">
    <top-panel v-if="isLogged" :email="email" @logout="logout"/>
    <div class="app-blur-container">
      <div class="sub-container">
        <router-view @login="login"/>
      </div>
    </div>
  </section>
</template>

<script>
import TopPanel from "@/components/TopPanel"
import {CookieService} from "@/services/cookie-service";

export default {
  name: "App",
  components: {
    TopPanel
  },

  data(){
    return {
      isLogged: false,
      email: ''
    }
  },

  methods: {
    login: function ({token, email}) {
      CookieService.setCookie('USER_SESSION', token)
      localStorage.setItem('email', email)
      this.email = email
      this.isLogged = true
    },

    logout: function () {
      CookieService.deleteCookie('USER_SESSION')
      localStorage.removeItem('email')
      this.isLogged = false
    }
  },

  created() {
    let item = localStorage.getItem('email')

    if(item){
      this.email = item
      this.isLogged = true
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Lora:wght@500;600;700&display=swap');

*{
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  font-family: 'Lora', serif;
  font-size: 14px;
}

#app{
  min-height: 100vh;
  display: flex;

  background-image: url('assets/main-background.jpg');
  background-size: cover;
  background-attachment: fixed;
  background-position: center;
}

.app-blur-container{
  flex: 1;
  display: flex;
  justify-content: center;
  background-color: rgba(165, 128, 91, 0.7);
}

.sub-container{
  display: flex;
  width: 100vw;
  max-width: 1600px;
}
</style>
