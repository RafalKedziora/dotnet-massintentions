<template>
  <div class="intention-select__item">
    <label :for="name">{{ label }}</label>
    <select
      :id="name"
      v-model="valueSelected"
      @change="emitData"
    >
      <option
        v-for="unit in allValues"
        :value="unit"
        :label="showValue(unit)"
        :key="refValue(unit)"
      />
    </select>
  </div>
</template>

<script>
export default {
  name: "SelectWithLabel",
  props: {
    label: String,
    name: String,
    allValues: Array,
    value: Object,
    propertyToShow: String,
    propertyToRef: String
  },

  data(){
    return{
      valueSelected: {...this.value}
    }
  },

  methods:{
    emitData: function () {
      this.$emit('input', this.valueSelected)
    },

    showValue: function (unit) {
      return this.getNestedObjectValue({...unit}, this.propertyToShow)
    },

    refValue: function (unit) {
      return this.getNestedObjectValue({...unit}, this.propertyToRef)
    },

    getNestedObjectValue: function (obj, props) {
      let res = {...obj}
      let properties = props.split(".")

      for(let prop of properties){
        if(res[prop] !== undefined){
          res = res[prop]
        }
        else{
          break
        }
      }

      return res
    }
  }
}
</script>

<style scoped>
.intention-select__item{
  display: flex;
  flex-direction: column;
  margin: 10px 15px;
}

.intention-select__item label{
  margin-bottom: 6px;
  font-size: 1.1rem;
  font-weight: 700;
  color: rgba(57, 29, 6, 1);
}

.intention-select__item select{
  width: 100%;
  background-color: rgba(166, 138, 100, 1);
  color: rgba(57, 29, 6, 0.9);
  height: 30px;
  border: 0;
  padding-left: 10px;
}
</style>