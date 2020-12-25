<template>
  <form action="/action_page.php">
    <label for="fname">نام بازیگر </label>
    <input type="text" id="fname" v-model="CastData.Name" />

    <label for="lname">توضیحات کوتاه</label>
    <input type="text" v-model="CastData.ShortBio" />
    <label for="lname">بیوگرافی</label>
    <textarea v-model="CastData.Biography"></textarea>
    <label for="start">تاریخ تولد </label>

    <input
      type="date"
      id="start"
      name="trip-start"
      min="0000-11-11"
      max="2020-12-30"
      v-model="CastData.DateOfBirth"
    />
    <div class="country-select">
      <label for="fname">ملیت </label>

      <input list="brow" v-model="CastData.Nationality" />
      <datalist id="brow">
        <option v-for="Country in Countries" :key="Country" :value="Country.id"
          >{{ Country.name }}
        </option>
      </datalist>
    </div>
    <div class="types">
      <h6>سمت ها :</h6>
      <label class="container"
        >بازیگر
        <input type="checkbox" checked="checked" v-model="CastData.isCast" />
        <span class="checkmark"></span>
      </label>
      <label class="container"
        >کاردگردان
        <input type="checkbox" v-model="CastData.isDiractor" />
        <span class="checkmark"></span>
      </label>
    </div>

    <label for="fname">تصویر </label>
    <input type="file" class="custom-file-input" @change="onFileSelected" />

    <button
      type="submit"
      @click.prevent="submitData"
      class="btn btn-success btn-block"
    >
      ثبت
    </button>
    <router-link to="/CastPanel">
      <button type="submit" class="btn btn-danger btn-block">
        بازگشت
      </button>
    </router-link>
  </form>
</template>

<script>
export default {
  data() {
    return {
      CastData: {
        Name: '',
        ShortBio: '',
        Biography: '',
        DateOfBirth: '',
        Picture: null,
        isCast: false,
        isDiractor: false,
        Nationality: ''
      },
      countries: '',
      Countries: this.$store.getters.GetCountry
    };
  },
  methods: {
    submitData() {
      const form = new FormData();
      form.append('Name', this.CastData.Name);
      form.append('ShortBio', this.CastData.ShortBio);
      form.append('Biography', this.CastData.Biography);
      form.append('DateOfBirth', this.CastData.DateOfBirth);
      form.append('Picture', this.CastData.Picture);
      form.append('isCast', this.CastData.isCast);

      form.append('IsDirector', this.CastData.isDiractor);
      form.append('CountryId', this.CastData.Nationality);
      this.$emit('SubmitData', form);
    },
    onFileSelected(event) {
      this.CastData.Picture = event.target.files[0];
      // this.$refs.file.files[0];
    }
  },
  mounted() {
    this.$store.dispatch('GetCountry');
  }
};
</script>

<style></style>
