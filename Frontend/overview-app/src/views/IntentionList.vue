<template>
  <section class="intention-list">
    <div class="title-section">
      <h1>
        Wyszukiwanie intencji mszalnych
      </h1>
      <aside class="buttons">
        <image-button
          caption="Dodaj nową kategorię"
          image-src="add-icon.svg"
          :task="goToAddCategoryMenu"
        />
        <image-button
          caption="Dodaj nową intencję"
          image-src="add-icon.svg"
          :task="goToAddMassMenu"
        />
      </aside>
    </div>

    <intention-filters @filter="setFilters"></intention-filters>


    <intention-table
      v-if="intentionsCount > 0"
      :intentions="intentions"
      :column-names="columns"
      :filters="filters"
    />
    <loader v-else></loader>
  </section>
</template>

<script>
import IntentionTable from "@/components/IntentionTable"
import IntentionFilters from "@/components/IntentionFilters"
import ImageButton from "@/components/ImageButton"
import Loader from "@/components/Loader"
import {ApiService} from "@/services/api-service"

const APIService = new ApiService()

export default {
  name: "IntentionList",

  components: {
    IntentionTable,
    IntentionFilters,
    ImageButton,
    Loader
  },

  data(){
    return {
      intentions: [],
      intentionsCount: 0,
      columns: [
        'Tytuł',
        'Treść',
        'Data mszy',
        'Kategoria',
        'Data modyfikacji',
      ],
      filters: {},
    }
  },

  async created() {
    const [error, {count, intentions}] = await APIService.getAllIntentions()

    if(error){
      console.log(error)
      return
    }

    intentions.forEach(x => {
      x.category = x.category.name
      x.massDate = x.massDate.replace('T', ' ')
      x.lastModified = x.massDate.replace('T', ' ')
    })

    this.intentions = intentions
    this.intentionsCount = count
  },

  methods: {
    setFilters: function(value) {
      this.filters = value
    },

    goToAddMassMenu: function () {
      this.$router.push('/mass/add')
    },

    goToAddCategoryMenu: function () {
      this.$router.push('/category/add')
    },

    updateDots: function () {
      this.dotInterval = setInterval(() => this.dots = (this.dots % 3) + 1, 500)
    }
  }
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

.intention-list{
  flex: 1;
  padding: 40px 50px;
}

.buttons{
  display: flex;
}
</style>