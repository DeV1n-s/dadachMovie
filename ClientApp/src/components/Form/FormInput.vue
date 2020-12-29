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
        @input="$emit('input', $event.target.value)"
      />
    </p>
  </div>
</template>

<script>
export default {
  model: {
    event: 'changed'
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
  }

  // methods: {
  //   updateValue: function(value) {
  //     this.$emit('input', value);
  //   }
  // }
};
</script>
