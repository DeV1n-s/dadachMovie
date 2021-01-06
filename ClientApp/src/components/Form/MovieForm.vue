<template>
  <div>
    <form action="/action_page.php">
      <form-input
        label="نام فیلم"
        :required="true"
        id="name"
        v-model="MovieData.title"
      />

      <form-input
        label="توضیحات کوتاه"
        :required="true"
        id="name"
        v-model="MovieData.shortDescription"
      />
      <form-input
        label="توضیحات کامل"
        :required="true"
        id="name"
        v-model="MovieData.description"
      />

      <label for="country">سبک</label>
      <select id="country" name="country" v-model="genres">
        <option v-for="Genre in Genres" :key="Genre.id" :value="Genre.id">{{
          Genre.name
        }}</option>
      </select>
      <label for=""> نمره فیلم از 10</label>
      <input
        type="number"
        id="tentacles"
        name="tentacles"
        min="0"
        max="10"
        v-model="MovieData.rate"
      />

      <label for="start">تاریخ انتشار</label>

      <input
        type="date"
        id="start"
        name="trip-start"
        min="0000-11-11"
        max="2020-12-30"
        v-model="MovieData.releaseDate"
      />
      <label for="fname">کارگردان </label>
      <select name="country" v-model="directors">
        <option v-for="People in Peoples" :key="People.id" :value="People.id">{{
          People.name
        }}</option>
      </select>
      <label for="fname">بازیگران </label>
      <select id="countr" name="country" v-model="preCasters">
        <option
          v-for="People in Peoples"
          :key="People.id"
          :value="{
            PersonId: People.id,
            Character: People.name
          }"
          >{{ People.name }}</option
        >
      </select>
      <button class="btn-success btn-add" @click.prevent="castPush">
        اضافه کردن بازیگر
      </button>
      <div class="table-c">
        <tbody>
          <tr v-for="(Cast, index) in MovieData.casts" :key="Cast.Character">
            <td>
              <p class="td-p">{{ Cast.Character }}</p>
            </td>
            <td>
              <button
                class="btn btn-lg btn-danger"
                @click.prevent="castDelete(index)"
              >
                حذف
              </button>
            </td>
          </tr>
        </tbody>
      </div>

      <model-select
        class="nationality"
        :options="options"
        v-model="countries"
        placeholder="کشور"
      >
      </model-select>

      <label for="fname">تصویر </label>
      <div class="img-show" v-if="isEditMode">
        <img :src="MovieData.picture" alt="" />
      </div>
      <input type="file" class="custom-file-input" @change="onFileSelected" />
      <label for="checkbox" class="cinema-carpet">روی پرده سینما </label>
      <input type="checkbox" id="checkbox" v-model="MovieData.inTheaters" />

      <button
        type="submit"
        @click.prevent="sendData"
        class="btn btn-success btn-block"
      >
        ثبت
      </button>
      <router-link to="/MoviePanels">
        <button type="submit" class="btn btn-danger btn-block">
          بازگشت
        </button>
      </router-link>
    </form>
  </div>
</template>

<script>
import axios from 'axios';
import FormInput from './FormInput';
export default {
  props: ['Peoples', 'Genres'],
  // provide() {
  //   return {
  //     $validator: this.$validator
  //   };
  // },
  components: {
    FormInput
  },
  data() {
    return {
      id: '',
      isEditMode: false,
      options: [],
      MovieData: {
        title: '',
        rate: '',
        releaseDate: '',
        directors: [],
        casts: [],
        shortDescription: '',
        description: '',
        genres: [],
        picture: null,
        inTheaters: false,
        countries: []
      },
      countries: '',
      genres: '',
      directors: [],
      GenresIds: '',
      preCasters: []
    };
  },
  methods: {
    countryMaker() {
      this.Countries.forEach(c => {
        let cData = { value: '', text: '' };
        cData.value = c.id;
        cData.text = c.nationality;
        this.options.push(cData);
      });
    },
    dataSync() {
      axios.get('/api/Movies/' + this.$route.params.id).then(res => {
        this.MovieData = res.data;
        console.log(res.data);
        this.genres = this.MovieData.genres[0].name;
        console.log(this.genres);
      });
    },
    castDelete(id) {
      this.MovieData.casts.splice(id, 1);
    },

    castPush() {
      this.MovieData.casts.push(this.preCasters);
    },
    submitData(event) {
      axios.post('/api/Movies', event).then(res => {
        console.log(res.data);
        console.log(event);
        this.$router.push('/Moviepanel');
      });
    },
    editData($event) {
      axios
        .put('/api/Movies/' + this.$route.params.id, $event)
        .then(res => {
          console.log(res);
          this.$router.push('/Moviepanel');
        })
        .then((this.isEditMode = false));
    },
    sendData() {
      this.MovieData.countries.push(this.countries);
      this.MovieData.directors.push(this.directors);
      this.MovieData.genres.push(this.genres);

      let form = new FormData();

      form.append('Title', this.MovieData.title);
      form.append('Rate', this.MovieData.rate);
      form.append('DirectorsId', JSON.stringify(this.MovieData.directors));
      form.append('ShortDescription', this.MovieData.shortDescription);
      form.append('Description', this.MovieData.description);
      form.append('GenresId', JSON.stringify(this.MovieData.genres));
      form.append('Cast', JSON.stringify(this.MovieData.casts));
      form.append('Picture', this.MovieData.picture);
      form.append('InTheaters', this.MovieData.inTheaters);
      form.append('releaseDate', this.MovieData.releaseDate);
      form.append('CountriesId', JSON.stringify(this.MovieData.countries));
      if (!this.isEditMode) this.submitData(form);
      else this.editData(form);
      // this.$emit('SubmitData', form);
    },
    onFileSelected(event) {
      this.MovieData.picture = event.target.files[0];
    }
  },
  mounted() {
    this.countryMaker();
    if (this.$route.params.id != undefined) {
      console.log(this.$route.params.id);
      this.id = this.$route.params.id;
      this.isEditMode = true;
      this.dataSync();
    }
    this.$store.dispatch('GetCountry');
  },
  computed: {
    Countries: function() {
      return this.$store.getters.GetCountry;
    }
  }
};
</script>

<style>
.nationality {
  margin-top: 1.5rem;
  margin-bottom: 1.5rem;
  float: right;
  direction: rtl;
}
.country-select {
  padding-top: 2rem;
  padding-bottom: 2rem;
  width: 50%;
}
.country-select input,
.country-select option {
  width: 100%;
}
.img-show {
  max-height: 330px;
  max-width: 250px;
  margin-bottom: 1.5rem;
}
label {
  color: rgba(41, 37, 37, 0.733);
  margin-bottom: 3px;
  margin-top: 3px;
}
textarea {
  height: 170px;
  border-radius: 10px;
}
input {
  border-radius: 10px;
}
select {
  border-radius: 10px;
}
button.btn-success.btn-add {
  margin-top: 0.75rem;
}
</style>
