<template>
  <form action="/action_page.php" class="form-group">
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
      <label class="type-p"> </label>
    </div>
    <div class="boxes">
      <input type="checkbox" id="box-1" v-model="CastData.isCast" />
      <label for="box-1">بازیگر</label>

      <input type="checkbox" id="box-2" checked v-model="CastData.isDiractor" />
      <label for="box-2">کاردگردان </label>
    </div>
    <div class="file-upload">
      <label for="fname">تصویر </label>
      <input type="file" class="custom-file-input" @change="onFileSelected" />
    </div>
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
.file-upload {
  margin-right: 13px;
  margin-bottom: 5px;
}
.type-p {
  font-size: 1.7rem;
  margin-right: 13px;
}
.boxes {
  margin: auto;
  padding: 20px;
}

/*Checkboxes styles*/
input[type='checkbox'] {
  display: none;
}

input[type='checkbox'] + label {
  display: block;
  position: relative;
  /* padding-left: 35px; */
  margin-bottom: 20px;
  /* font: 14px/20px 'Open Sans', Arial, sans-serif; */

  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
}

input[type='checkbox'] + label:last-child {
  margin-bottom: 0;
}

input[type='checkbox'] + label:before {
  content: '';
  display: block;
  width: 20px;
  height: 20px;
  border: 1px solid #035a20;
  position: absolute;
  left: 0;
  top: 0;
  opacity: 0.6;
  -webkit-transition: all 0.12s, border-color 0.08s;
  transition: all 0.12s, border-color 0.08s;
}

input[type='checkbox']:checked + label:before {
  width: 10px;
  top: -5px;
  left: 5px;
  border-radius: 0;
  opacity: 1;
  border-top-color: transparent;
  border-left-color: transparent;
  -webkit-transform: rotate(45deg);
  transform: rotate(45deg);
}
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
label {
  margin-top: 1.5rem;
  margin-right: 0.4rem;
}
</style>
