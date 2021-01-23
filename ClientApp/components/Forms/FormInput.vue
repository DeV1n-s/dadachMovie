<template>
  <div>
    <p>
      <validation-provider rules="required" v-slot="{ errors }">
        <input
          type="text"
          :id="id"
          :placeholder="label"
          :value="value"
          :required="required"
          v-on:input="updateValue($event.target.value)"
          class="form__field"
        />
        <label for="name" class="form__label">{{ label }}</label>

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
  margin-bottom: 0px !important;
  margin-top: 0.95rem;
  margin-right: 3px;
}
/* input {
  height: 30px;
  border-radius: 20px;
} */
.form__group {
  position: relative;
  padding: 15px 0 0;
  margin-top: 10px;
  width: 50%;
}

.form__field {
  margin-top: 0.5rem;
  font-family: inherit;
  width: 100%;
  border: 0;
  border-bottom: 2px solid #9b9b9b;
  outline: 0;
  font-size: 0.9rem;
  color: black;
  padding: 10px 0;
  background: transparent;
  transition: border-color 0.2s;
}
.form__field::placeholder {
  color: transparent;
}
.form__field:placeholder-shown ~ .form__label {
  font-size: 1.3rem;
  cursor: text;
  top: 20px;
}

.form__label {
  position: absolute;
  top: 0;
  display: block;
  transition: 0.2s;
  font-size: 1rem;
  color: #9b9b9b;
}

.form__field:focus {
  padding-bottom: 6px;
  font-weight: 400;
  border-width: 3px;
  border-image: linear-gradient(to right, #11998e, #38ef7d);
  border-image-slice: 1;
}
.form__field:focus ~ .form__label {
  position: absolute;
  top: 0;
  display: block;
  transition: 0.2s;
  font-size: 1rem;
  color: #11998e;
  font-weight: 700;
}

/* reset input */
.form__field:required,
.form__field:invalid {
  box-shadow: none;
}

/* demo */
body {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  font-size: 1.5rem;
  background-color: #222222;
}
p {
  padding-top: 4px;
}
</style>
