<template>
  <form class="intention-edit" @submit.prevent="saveChanges">
    <div class="title-section">
      <aside class="title">
        <h1>
          Edycja danych
        </h1>
        <go-back-button />
      </aside>
      <aside class="buttons">
        <image-button
          caption="Usuń"
          image-src="remove-icon.svg"
          :task="deleteItem"
        />
        <image-button
          caption="Zapisz"
          image-src="save-icon.svg"
          :task="() => ''"
        />
      </aside>

    </div>
    <div class="inputs" v-if="intention !== undefined" >
      <input-with-label
        label="Tytuł"
        name="title"
        input-type="text"
        v-model="intention.title"
      />
      <div class="inline-container">
        <div class="left">
          <input-with-label
            label="Data mszy"
            name="massDate"
            input-type="datetime-local"
            v-model="intention.massDate"
          />
        </div>
        <div class="right">
          <select-with-label
            label="Kategoria"
            name="category"
            :all-values="categories"
            property-to-ref="id"
            property-to-show="name"
            v-model="intention.category"
          />
        </div>
      </div>
      <input-with-label
        label="Treść intencji"
        name="content"
        input-type="textarea"
        v-model="intention.content"
        class="fill-container"
      />
    </div>
    <loader v-else></loader>
  </form>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel"
import SelectWithLabel from "@/components/SelectWithLabel"
import ImageButton from "@/components/ImageButton"
import GoBackButton from "@/components/GoBackButton"
import Loader from "@/components/Loader"
import {ApiService} from "@/services/api-service"
const APIService = new ApiService()

export default {
  name: "IntentionEdit",
  components: {
    InputWithLabel,
    SelectWithLabel,
    ImageButton,
    GoBackButton,
    Loader
  },

  data(){
    return {
      intention: undefined,
      categories: undefined,
      apiError: 'Błąd 403: edycja rekordu niedozwolona'
    }
  },

  computed: {
    apiModel: function () {
      return {
        id: this.intention.id,
        title: this.intention.title,
        content: this.intention.content,
        massDate: this.intention.massDate,
        categoryId: this.intention.category.id
      }
    }
  },

  methods: {
    saveChanges: async function () {
      const [error] = await APIService.updateIntention(
        this.intention.id,
        this.apiModel
      );

      if(error){
        console.error(error)
        return
      }

      await this.$router.push('/list')
    },

    deleteItem: async function () {
      const [error] = await APIService.deleteIntention(this.intention.id);

      if(error){
        console.error(error)
        return
      }

      await this.$router.push('/list')
    }
  },

  async created(){
    const [intentionError, intention] = await APIService.getIntentionById(this.$route.params.id)
    const [categoryError, categories] = await APIService.getCategories()

    if(intentionError || categoryError){
      if(categories === 403){
        console.error(this.apiError)
        await this.$router.push('/list')
      }

      await this.$router.push('/404')
    }

    this.intention = intention
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

h1{
  font-size: 2rem;
  color: rgba(57, 29, 6, 1);
}

.intention-edit{
  flex: 1;
  padding: 80px 50px 40px 50px;
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
  flex: 1;
}
</style>