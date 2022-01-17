<template>
  <section id="app">
    <div class="app-blur-container">
      <div class="sub-container">
        <router-view />
      </div>
    </div>
  </section>
</template>

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
