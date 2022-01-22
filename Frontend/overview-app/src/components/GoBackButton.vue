<template>
  <button @click="goBack">
    <img :src="image" alt="">
  </button>
</template>

<script>
export default {
  name: "GoBackButton",
  data(){
    return{
      imageSrc: 'go-back-icon-brown.svg'
    }
  },
  computed: {
    image: function () {
      return require('@/assets/' + this.imageSrc)
    }
  },
  methods: {
    goBack: function () {
      this.$router.back()
    }
  }
}
</script>

<style scoped>
button{
  all: unset;
  cursor: pointer;
  margin-left: 25px;
  transform: scale(1.3);
}
</style>