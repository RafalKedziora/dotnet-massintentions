<template>
  <section class="intention-list">
    <div class="title-section">
      <h1>
        Wyszukiwanie intencji mszalnych
      </h1>
      <aside class="buttons" v-if="isAdmin">
        <image-button
          caption="Dodaj nową kategorię"
          image-src="add-category-icon.svg"
          :task="goToAddCategoryMenu"
        />
        <image-button
          caption="Dodaj nową intencję"
          image-src="add-icon.svg"
          :task="goToAddMassMenu"
        />
      </aside>
    </div>
    <intention-filters @filter="setFilters"/>
    <intention-table
      v-if="intentionsCount > 0"
      :intentions="intentions"
      :column-names="columns"
      :filters="filters"
      :is-desktop="false"
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
      isAdmin: false
    }
  },

  async created() {
    const email = encodeURI(localStorage.getItem('email'))
    const [error, {count, intentions}] = await APIService.getAllIntentions()
    const [roleError, role] = await APIService.getRoleByEmail(email)

    if(error){
      console.error(error)
      return
    }

    if(roleError){
      console.error(roleError)
      return
    }

    this.isAdmin = role === 'Admin'

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
  padding: 80px 50px 40px 50px;
}

.buttons{
  display: flex;
}
</style>