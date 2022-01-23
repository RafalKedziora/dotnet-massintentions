<template>
  <section class="intention-list">
    <div class="title-section">
      <h1>
        Pulpit ambony
      </h1>
    </div>
    <intention-table
      v-if="intentionsCount > 0"
      :intentions="intentions"
      :column-names="columns"
    />
    <loader v-else></loader>
  </section>
</template>

<script>
import IntentionTable from "@/components/IntentionTable"
import Loader from "@/components/Loader"
import {ApiService} from "@/services/api-service"

const APIService = new ApiService()

export default {
  name: "Desktop",

  components: {
    IntentionTable,
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
      ]
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
  padding: 60px 50px 40px 50px;
}

.buttons{
  display: flex;
}
</style>