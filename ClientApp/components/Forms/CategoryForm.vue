<template>
  <div>
    <div class="row">
      <div class="col-md-5">
        <form-input label="عنوان دسته" :required="true" id="name" />
      </div>
      <div class="col-md-5">
        <form-input
          label="رنگ دسته"
          :required="true"
          id="name"
          type="color"
          value="#ff0000"
        />
      </div>
      <div class="col-md-2 mt-5">
        <button class="btn btn-success">ثبت دسته جدید</button>
      </div>
    </div>
  </div>
</template>

<script>
import FormInput from './FormInput';
export default {
  components: {
    FormInput
  }
};
</script>

<style></style>
