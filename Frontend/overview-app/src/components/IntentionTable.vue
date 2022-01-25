<template>
  <table class="intention-table">
    <thead>
      <tr>
        <th v-for="(name, index) in columnNames" :key="index">
          {{ name }}
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="intention in filteredIntentions" :key="intention.id">
        <td>
          <router-link v-if="isAdmin" :to="`/mass/${intention.id}`">{{ intention.title }}</router-link>
          <p v-else>{{ intention.title }}</p>
        </td>
        <td v-for="(value, index) in viewable(intention)" :key="index">
          {{ value }}
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import { ApiService } from "@/services/api-service"
const APIService = new ApiService()

export default {
  name: "IntentionTable",
  props: {
    intentions: Array,
    columnNames: Array,
    filters: Object,
    isDesktop: Boolean
  },
  data(){
    return {
      isAdmin: false,
    }
  },
  computed: {
    filteredIntentions: function () {
      let filteredItems = [...this.intentions.map(x => Object.assign({}, x))]

      for(const key in this.filters){
        filteredItems = filteredItems.filter(x => this.filters[key].test(x[key]))
      }

      return filteredItems
    }
  },

  methods: {
    viewable: function (intention) {
      let res = {...intention}

      delete res.id
      delete res.title
      return res
    }
  },

  async created() {
    if(this.isDesktop){
      return
    }

    const email = encodeURI(localStorage.getItem('email'))
    const [roleError, role] = await APIService.getRoleByEmail(email)

    if(!roleError && role === 'Admin'){
      this.isAdmin = true
    }
  }
}
</script>

<style scoped>
table{
  min-width: 800px;
  overflow-x: scroll;
}

table, tr, th{
  border-collapse: collapse;
}

th, td{
  padding: 10px 20px;
  color: rgba(255, 255, 255, 1);
}

table{
  width: 100%;
  margin: 20px 0;
}

thead{
  height: 50px;
  background-color: rgba(88, 47, 14, 0.8);
}

tbody tr{
  height: 40px;
  text-align: center;
  background-color: rgba(127, 79, 36, 0.6);
  white-space: pre-wrap;
}

td a {
  color: rgba(255, 255, 255, 1);
}
</style>