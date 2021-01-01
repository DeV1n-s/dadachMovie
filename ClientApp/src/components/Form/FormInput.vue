<template>
  <div>
    <label>{{ label }}</label>
    <p>
      <input
        class="input"
        type="text"
        :id="id"
        :placeholder="label"
        :value="value"
        :required="required"
        v-on:input="updateValue($event.target.value)"
      />
    </p>
    <small class="warn-input" v-if="!isValid"
      >{{ label }} نمیتواند خالی باشد
    </small>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isValid: true
    };
  },
  props: {
    id: {
      type: String
    },
    label: {
      type: String,
      required: true
    },
    value: {
      type: String
    },
    required: {
      type: Boolean,
      default: false
    }
  },

  methods: {
    updateValue: function(value) {
      this.$emit('input', value);
      if (value == '') {
        this.isValid = false;
        console.log(this.isValid);
      }
    }
  }
};
</script>
<style scoped>
.warn-input {
  color: brown;
}
</style>
