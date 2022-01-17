<template>
  <button class="image-button" @click="task">
    <img :src="image">
    <p>{{ caption }}</p>
  </button>
</template>

<script>
export default {
  name: "ImageButton",
  props: {
    imageSrc: String,
    caption: String,
    task: Function,
  },
  computed: {
    image: function () {
      return require('@/assets/' + this.imageSrc)
    }
  }
}
</script>

<style scoped>
  .image-button{
    all: unset;

    height: 40px;
    padding: 5px 20px;
    margin: 0 10px;

    display: flex;
    justify-content: center;
    align-items: center;

    background-color: rgba(88, 47, 14, 1);
    color: rgba(255, 255, 255, 1);
    cursor: pointer;

    font-weight: 700;
    text-decoration: none;
  }

  .image-button img{
    margin-right: 15px;
    width: 20px;
    height: 20px;
  }
</style>