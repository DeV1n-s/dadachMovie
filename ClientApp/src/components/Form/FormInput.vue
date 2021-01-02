<template>
  <div>
    <label>{{ label }}</label>
    <p>
      <validation-provider rules="required" v-slot="{ errors }">
        <input
          class="input"
          type="text"
          :id="id"
          :placeholder="label"
          :value="value"
          :required="required"
          v-on:input="updateValue($event.target.value)"
        />
        <span class="warn-input ">
          <small>{{ errors[0] }} </small></span
        >
      </validation-provider>
    </p>
  </div>
</template>

<script>
import { ValidationProvider, extend } from 'vee-validate';
import { required } from 'vee-validate/dist/rules';
extend('required', {
  ...required,
  message: `  این فیلد نیمتواند خالی باشد `
});

export default {
  inject: {
    $validator: '$validator'
  },
  components: {
    ValidationProvider
  },
  data() {
    return {
      isValid: false
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
    }
  }
};
</script>
<style scoped>
.warn-input {
  color: brown;
}
</style>
