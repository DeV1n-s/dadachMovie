<template>
  <form action="/action_page.php">
    <label for="fname">نام بازیگر </label>
    <input type="text" id="fname" v-model="CastData.name" />

    <label for="lname">توضیحات کوتاه</label>
    <input type="text" v-model="CastData.shortBio" />
    <label for="lname">بیوگرافی</label>
    <textarea v-model="CastData.biography"></textarea>
    <label for="start">تاریخ تولد </label>

    <input
      type="date"
      id="start"
      name="trip-start"
      min="0000-11-11"
      max="2020-12-30"
      v-model="CastData.dateOfBirth"
    />
    <div class="country-select">
      <label for="fname">ملیت </label>

      <input list="brow" v-model="CastData.nationality" />
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
import axios from 'axios';
export default {
  props: ['ID', 'IsEditMode'],
  data() {
    return {
      CastData: {
        name: '',
        shortBio: '',
        biography: '',
        dateOfBirth: '',
        picture: null,
        isCast: false,
        isDiractor: false,
        nationality: ''
      },
      Countries: this.$store.getters.GetCountry
    };
  },
  methods: {
    capFstLet(str) {
      const capitalized = str.charAt(0).toUpperCase() + str.slice(1);

      return capitalized;
    },

    submitData() {
      const form = new FormData();

      for (const property in this.CastData) {
        console.log(`${this.capFstLet(property)}: ${this.CastData[property]}`);
        form.append(`${this.capFstLet(property)}`, this.CastData[property]);
      }
      this.$emit('SubmitData', form);
    },
    onFileSelected(event) {
      this.CastData.picture = event.target.files[0];
      // this.$refs.file.files[0];
    }
  },
  mounted() {
    if (this.IsEditMode) {
      axios
        .get('http://localhost:8080/api/people/' + this.ID)
        .then(res => (this.CastData = res.data))
        .then(console.log(this.CastData));
    }
    this.$store.dispatch('GetCountry');
  }
};
</script>

<style></style>
