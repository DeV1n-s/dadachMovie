<template>
  <div>
    <p class="form-group">
      <validation-provider rules="required" v-slot="{ errors }">
        <label for="name">{{ label }}</label>

        <input
          :type="type"
          :id="id"
          :placeholder="label"
          :value="value"
          :required="required"
          :max="max"
          :min="min"
          v-on:input="updateValue($event.target.value)"
          class="form-control"
        />

        <span class="warn-input d-block">
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
  // inject: {
  //   $validator: '$validator'
  // },
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
    max: {
      type: Number
    },
    min: {
      type: Number
    },
    type: { type: String, default: 'text' },
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
label {
  margin-bottom: 8px !important;
  margin-top: 0.95rem;
  margin-right: 3px;
  font-size: 15px;
}
/* input {
  height: 30px;
  border-radius: 20px;
} */

p {
  padding-top: 4px;
}
</style>
