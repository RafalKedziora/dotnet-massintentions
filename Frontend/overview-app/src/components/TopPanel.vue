<template>
  <div class="top-panel">
    <div class="info-container">
      <img :src="image('user-icon.svg')" alt="">
      <p>{{ email }}</p>
      <img :src="image('login-icon.svg')" alt="" @click="logout">
    </div>
  </div>
</template>

<script>
export default {
  name: "TopPanel",

  props: {
    email: String
  },

  methods: {
    image: function (imageSrc) {
      return require('@/assets/' + imageSrc)
    },

    logout: function () {
      this.$emit('logout')
      this.$router.push('/login')
    }
  }
}
</script>

<style scoped>
.top-panel{
  height: 35px;
  width: 100vw;
  position: fixed;
  top: 0;
  background-color: rgba(57, 29, 6, 1);
  display: flex;
  justify-content: flex-end;
}

.info-container{
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-right: 30px;
}

img{
  width: 25px;
  height: auto;
}

img:first-child{
  margin-right: 15px;
}

img:last-child{
  margin-right: 15px;
  cursor: pointer;
}

p{
  margin-right: 50px;
  color: rgba(255, 255, 255, 1);
  font-weight: 700;
}
</style>