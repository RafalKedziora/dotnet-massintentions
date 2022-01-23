<template>
  <div class="intention-input__item">
    <label
      :for="name"
      :class="{'label-big': big}"
    >{{ label }}</label>
    <textarea
      v-if="inputType === 'textarea'"
      v-model="inputValue"
      minlength="20"
      maxlength="500"
      @input="emitData"
      required="required"
      :class="{'input-big': big}"
    />
    <input
      v-else
      :type="inputType"
      :id="name"
      v-model="inputValue"
      @input="emitData"
      minlength="2"
      maxlength="60"
      required="required"
      :class="{'input-big': big}"
    >
  </div>
</template>

<script>
export default {
  name: "InputWithLabel",
  props: {
    label: String,
    name: String,
    value: String,
    inputType: String,
    big: Boolean
  },
  data(){
    return{
      inputValue: this.value
    }
  },
  methods:{
    emitData: function () {
      this.$emit('input', this.inputValue)
    }
  }
}
</script>

<style scoped>
.label-big{
  font-size: 2rem !important;
  font-weight: 700;
  margin-bottom: 12px;
}

.input-big{
  height: 50px !important;
  font-size: 1.5rem !important;
}

.intention-input__item{
  display: flex;
  flex-direction: column;
  margin: 10px 15px;
}

.intention-input__item label{
  margin-bottom: 6px;
  font-size: 1.1rem;
  font-weight: 700;
  color: rgba(57, 29, 6, 1);
}

.intention-input__item input,
.intention-input__item textarea{
  width: 100%;
  background-color: rgba(166, 138, 100, 1);
  color: rgba(57, 29, 6, 0.9);
  height: 30px;
  border: 0;
  padding-left: 10px;
}

.intention-input__item textarea{
  padding-top: 10px;
  flex: 1;
  resize: vertical;
}
</style>