<template>
  <div class="loader">{{ searchingText }}</div>
</template>

<script>
export default {
  name: "Loader",
  data(){
    return{
      dots: 1,
      dotInterval : undefined,
    }
  },
  computed: {
    searchingText: function () {
      return `Ładowanie danych${'.'.repeat(this.dots)}`
    }
  },
  methods: {
    updateDots: function () {
      this.dotInterval = setInterval(() => this.dots = (this.dots % 3) + 1, 500)
    },

    stopUpdatingDots: function () {
      clearInterval(this.dotInterval);
    }
  },
  created() {
    this.updateDots();
  },
  destroyed() {
    this.stopUpdatingDots();
  }
}
</script>

<style scoped>
.loader{
  font-size: 1.2rem;
  font-weight: bold;
  color: rgba(57, 29, 6, 0.8);
}
</style>