<template>
  <form action="/action_page.php">
    <form-input
      label="نام بازیگر"
      :required="true"
      id="name"
      v-model="CastData.name"
    />

    <form-input
      label="توضیحات کوتاه"
      :required="true"
      id="name"
      v-model="CastData.shortBio"
    />
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
    <model-select
      class="nationality"
      :options="options"
      v-model="CastData.nationality"
      placeholder="ملیت"
    >
    </model-select>

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
      @click.prevent="sendData"
      class="btn btn-success btn-block"
    >
      ثبت
    </button>
    <router-link to="/CastPanels">
      <button type="submit" class="btn btn-danger btn-block">
        بازگشت
      </button>
    </router-link>
  </form>
</template>

<script>
import axios from 'axios';
import FormInput from './FormInput';
// import { dictionary } from '../../components/dic';
export default {
  data() {
    return {
      isEditMode: false,
      id: this.$route.params.id,
      options: [],
      item: {
        value: '',
        text: ''
      },
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
      valMessage: []
    };
  },
  components: {
    FormInput
  },
  methods: {
    capFstLet(str) {
      const capitalized = str.charAt(0).toUpperCase() + str.slice(1);

      return capitalized;
    },
    SubmitData(form) {
      axios.post('/api/people', form).then(res => {
        console.log(res.data);
        this.$router.push('/CastPanel');
      });
    },
    EdittData($event) {
      axios
        .put('/api/people/' + this.id, $event)
        .then(res => console.log(res.data));

      this.isEditMode = false;
    },

    sendData() {
      const form = new FormData();
      for (const property in this.CastData) {
        form.append(`${this.capFstLet(property)}`, this.CastData[property]);
      }
      if (!this.isEditMode) this.SubmitData(form);
      else this.EdittData(form);
    },
    onFileSelected(event) {
      this.CastData.picture = event.target.files[0];
      // this.$refs.file.files[0];
    },
    countryMaker() {
      this.Countries.forEach(c => {
        let cData = { value: '', text: '' };
        cData.value = c.id;
        cData.text = c.nationality;
        this.options.push(cData);
      });
    }
  },
  mounted() {
    if (this.id != undefined) {
      console.log(this.id);
      this.isEditMode = true;
      axios.get('/api/people/' + this.id).then(res => {
        this.CastData = res.data;
        console.log(res.data);
      });
    }
    this.$store.dispatch('GetCountry');

    this.countryMaker();
  },
  computed: {
    Countries: function() {
      return this.$store.getters.GetCountry;
    }
  }
};
</script>

<style scoped>
.nationality {
  margin-top: 1.5rem;
  margin-bottom: 1.5rem;
  float: right;
  direction: rtl;
}
small {
  display: block;
  color: brown;
  margin-top: 1rem;
  margin-bottom: 1rem;
}
</style>
