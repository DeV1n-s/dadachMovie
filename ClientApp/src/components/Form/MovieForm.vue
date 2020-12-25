<template>
  <div>
    <form action="/action_page.php">
      <label for="fname">نام فیلم </label>
      <input type="text" id="fname" v-model="MovieData.title" />

      <label for="lname">توضیحات کوتاه</label>
      <input type="text" v-model="MovieData.shortDescription" />
      <label for="lname">شرح کامل</label>
      <textarea v-model="MovieData.description"></textarea>
      <label for="country">سبک</label>
      <select id="country" name="country" v-model="genres">
        <option v-for="Genre in Genres" :key="Genre.id" :value="Genre.id">{{
          Genre.name
        }}</option>
      </select>
      <label for="tentacles">نمره فیلم از 10</label>

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
          <tr v-for="(Cast, index) in MovieData.casts" :key="Cast">
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
      <div class="country-select">
        <input list="brow" v-model="countries" />
        <datalist id="brow">
          <option
            v-for="Country in Countries"
            :key="Country"
            :value="Country.id"
            >{{ Country.name }}
          </option>
        </datalist>
      </div>
      <label for="fname">تصویر </label>
      <div class="img-show" v-if="IsEditMode">
        <img :src="MovieData.picture" alt="" />
      </div>
      <input type="file" class="custom-file-input" @change="onFileSelected" />
      <label for="checkbox" class="cinema-carpet">روی پرده سینما </label>
      <input type="checkbox" id="checkbox" v-model="MovieData.inTheaters" />

      <button
        type="submit"
        @click.prevent="submitData"
        class="btn btn-success btn-block"
      >
        ثبت
      </button>
      <router-link to="/MoviePanel">
        <button type="submit" class="btn btn-danger btn-block">
          بازگشت
        </button>
      </router-link>
    </form>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  props: ['Peoples', 'Genres', 'IsEditMode', 'ID'],

  data() {
    return {
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
      preCasters: [],
      Countries: this.$store.getters.GetCountry
    };
  },
  methods: {
    castDelete(id) {
      this.MovieData.casts.splice(id, 1);
    },

    castPush() {
      this.MovieData.casts.push(this.preCasters);
    },
    submitData() {
      this.MovieData.countries.push(this.countries);
      this.MovieData.directors.push(this.directors);
      this.MovieData.genres.push(this.genres);

      const form = new FormData();
      // this.formAppender('Title', this.MovieData.Title);
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
      this.$emit('SubmitData', form);
    },
    onFileSelected(event) {
      this.MovieData.picture = event.target.files[0];
    }
  },
  mounted() {
    if (this.IsEditMode) {
      axios.get('http://localhost:8080/api/Movies/' + this.ID).then(res => {
        this.MovieData = res.data;
        console.log(res.data);
        this.genres = this.MovieData.genres[0].name;
        console.log(this.genres);
      });
    }
    this.$store.dispatch('GetCountry');
  }
};
</script>

<style>
.country-select {
  padding-top: 2rem;
  padding-bottom: 2rem;
  width: 50%;
  text-align: center;
}
.country-select input,
.country-select option {
  width: 100%;
  text-align: center;
}
.img-show {
  max-height: 330px;
  max-width: 250px;
  margin-bottom: 1.5rem;
}
label {
  color: aliceblue;
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
