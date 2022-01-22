<template>
  <form class="intention-add" @submit.prevent="saveChanges">
    <div class="title-section">
      <h1>
        Dodawanie nowej intencji
      </h1>
      <div class="buttons">
        <image-button
          caption="Zapisz"
          image-src="save-icon.svg"
          :task="saveChanges"
        />
      </div>

    </div>
    <div class="inputs">
      <input-with-label
        label="Nazwa"
        name="title"
        input-type="text"
        v-model="category.name"
      />
    </div>
  </form>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel"
import ImageButton from "@/components/ImageButton"
import {ApiService} from "@/services/api-service"
const APIService = new ApiService()

export default {
  name: "CategoryAdd",
  components: {
    InputWithLabel,
    ImageButton
  },

  data(){
    return {
      category: {
        name: ''
      },
      categories: undefined,
    }
  },

  computed: {
    apiModel: function () {
      return {
        name: this.category.name,
      }
    }
  },

  methods: {
    saveChanges: async function () {
      if(this.categories.find(x => x.name === this.category.name)){
        console.log("Category already exists");
        // tu bedzie popup
        return;
      }

      const [error] = await APIService.addCategory(this.apiModel);

      if(error){
        console.error(error)
        return
      }

      await this.$router.push('/')
    },
  },

  async created(){
    const [categoryError, categories] = await APIService.getCategories()

    if(categoryError){
      await this.$router.push('/404')
    }

    this.categories = categories
  },
}
</script>

<style scoped>
.title-section{
  display: flex;
  justify-content: space-between;
  height: 60px;
}

.title-section h1{
  font-size: 2rem;
  color: rgba(57, 29, 6, 1);
}

.intention-add{
  flex: 1;
  padding: 40px 50px;
  height: 100%;

  display: flex;
  flex-direction: column;
}

.buttons{
  display: flex;
}

.inputs{
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  flex: 1;
}

.inline-container{
  display: flex;
}

.left, .right{
  flex-basis: 0;
  flex-grow: 1;
  flex: 1;
  width: 40%;
}

.fill-container{
  height: 100%;
}
</style>