<template>
  <div class="intention-filters">
    <input-with-label
      label="Data mszy"
      name="massDate"
      input-type="date"
      v-model="filters.massDate"
      @input="emitData"
      class="intention-filter"
    >
    </input-with-label>
    <input-with-label
      label="Tytuł"
      name="title"
      input-type="text"
      v-model="filters.title"
      @input="emitData"
      class="intention-filter"
    >
    </input-with-label>
    <input-with-label
      label="Kategoria"
      name="category"
      input-type="text"
      v-model="filters.category"
      @input="emitData"
      class="intention-filter"
    >
    </input-with-label>
  </div>
</template>

<script>
import InputWithLabel from "@/components/InputWithLabel";

export default {
  name: "IntentionFilters",
  components: {
    InputWithLabel
  },
  data() {
    return {
      filters: {
        massDate: '',
        title: '',
        category: '',
      }
    }
  },

  computed: {
    regexFilters: function () {
      const resultObj = {}

      for(const key in this.filters){
        resultObj[key] = new RegExp(this.filters[key], 'i')
      }

      return resultObj
    }
  },

  methods: {
    emitData: function () {
      this.$emit('filter', this.regexFilters)
    }
  }
}
</script>

<style scoped>
 .intention-filters{
   height: 90px;
   background-color: rgba(80, 44, 15, 0.2);
   margin: 20px 0;
   padding: 0 20px;

   display: flex;
   align-items: center;
 }

 .intention-filter{
   width: 200px;
 }
</style>