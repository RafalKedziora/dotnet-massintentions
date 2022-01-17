<template>
  <section class="intention-list">
    <div class="title-section">
      <h1>
        Wyszukiwanie intencji mszalnych
      </h1>
      <image-button
        caption="Dodaj nową intencję"
        image-src="add-icon.svg"
        :task="goToAddMenu"
      />
    </div>

    <intention-filters @filter="setFilters"></intention-filters>

    <div v-if="intentionsCount > 0">
      <intention-table
        :intentions="intentions"
        :column-names="columns"
        :filters="filters"
      />
    </div>
    <div v-else>No intentions are found</div>
  </section>
</template>

<script>
import IntentionTable from "@/components/IntentionTable"
import IntentionFilters from "@/components/IntentionFilters"
import ImageButton from "@/components/ImageButton"
import {IntentionApiService} from "@/services/intention-api-service"

const APIService = new IntentionApiService()

export default {
  name: "IntentionList",

  components: {
    IntentionTable,
    IntentionFilters,
    ImageButton
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
      filters: {}
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

    goToAddMenu: function () {
      this.$router.push('/mass/add')
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
</style>