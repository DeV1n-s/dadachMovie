<template>
  <div>
    <form class="mt-5">
      <div class="row">
        <div class="col-md-6">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="نام فیلم"
              :required="true"
              id="name"
              v-model="movieData.title"
            />
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="شناسه IMDB"
              :required="true"
              id="name"
              v-model="movieData.imdbId"
            />
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6 mt-4">
          <label for="start" class="d-block">تاریخ شروع</label>

          <VueCtkDateTimePicker v-model="movieData.startDate" />
        </div>
        <div class="col-md-6 mt-4">
          <label for="start" class="d-block">تاریخ پایان</label>

          <VueCtkDateTimePicker v-model="movieData.endDate" />
        </div>
      </div>
      <div class="row mt-4">
        <div class="col-md-6">
          <div>
            <label class="typo__label">بازیگران</label>
            <multiselect
              v-model="caValue"
              tag-placeholder="Add this as new tag"
              placeholder="جست و جو در بین بازیگران"
              label="name"
              track-by="name"
              :options="PeaopleOption"
              :multiple="true"
              :taggable="true"
              @tag="addTag"
              :close-on-select="false"
              :clear-on-select="false"
              :preserve-search="true"
              :preselect-first="true"
            ></multiselect>
          </div>
        </div>
        <div class="col-md-6">
          <div>
            <label class="typo__label">کارگردان</label>
            <multiselect
              label="name"
              v-model="dValue"
              :options="PeaopleOption"
              :searchable="false"
              :close-on-select="false"
              :show-labels="false"
              placeholder="کارگردان را انتخاب کنید"
            ></multiselect>
          </div>
        </div>
      </div>
      <div class="row mt-4">
        <div class="col-md-6 mt-3">
          <div>
            <label class="typo__label">کشور سازنده</label>
            <multiselect
              v-model="cValue"
              tag-placeholder="Add this as new tag"
              placeholder="جست و جو در بین کشور های سازنده"
              label="text"
              track-by="name"
              :options="options"
              :multiple="true"
              :taggable="true"
              @tag="addTag"
              :close-on-select="false"
              :clear-on-select="false"
              :preserve-search="true"
              :preselect-first="true"
            ></multiselect>
          </div>
        </div>
        <div class="col-md-6 mt-3">
          <div>
            <label class="typo__label">ژانر</label>
            <multiselect
              v-model="gValue"
              tag-placeholder="Add this as new tag"
              placeholder="جست و جو در ژانر ها"
              label="name"
              track-by="name"
              :options="GenreOption"
              :multiple="true"
              :taggable="true"
              @tag="addTag"
              :close-on-select="false"
              :clear-on-select="false"
              :preserve-search="true"
              :preselect-first="true"
            ></multiselect>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="تعداد فصل"
              :required="true"
              id="name"
              v-model="movieData.Seasons"
              type="number"
            />
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="وضعیت"
              :required="true"
              id="name"
              v-model="movieData.status"
            />
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-md-12">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="توضیحات کوتاه"
              :required="true"
              id="name"
              v-model="movieData.shortDescription"
            />
          </div>
        </div>
      </div>
      <div class="row mt-5">
        <div class="col-md-12">
          <div class="form-group">
            <label for="exampleFormControlTextarea2" class="textarea-label"
              >شرح کامل :</label
            >
            <textarea
              class="form-control rounded-0"
              id="exampleFormControlTextarea2"
              rows="6"
              v-model="movieData.description"
            ></textarea>
          </div>
        </div>
      </div>
      <div class="row mt-4">
        <div class="col-md-6">
          <img
            v-if="isEditMode"
            :src="this.movieData.picture"
            class="th-img"
            alt=""
          />
          <div class="custom-file">
            <label class="custom-file-label " for="customFile"
              >تصویر بندانگشتی را انتخاب کنید</label
            >
            <input
              type="file"
              class="custom-file-input"
              id="customFile"
              @change="onFileSelectedTh"
            />
          </div>
        </div>
        <div class="col-md-6">
          <img
            v-if="isEditMode"
            :src="this.movieData.bannerImage"
            class="banner-img"
            alt=""
          />
          <div class="custom-file">
            <label class="custom-file-label " for="customFile"
              >تصویر بنر را انتخاب کنید</label
            >
            <input
              type="file"
              class="custom-file-input"
              id="customFile"
              @change="onFileSelectedBn"
            />
          </div>
        </div>
      </div>

      <div class="btns mt-4 mb-4">
        <nuxt-link to="/admin">
          <button class="btn btn-danger">بازگشت</button>
        </nuxt-link>

        <button class="btn btn-success" @click.prevent="sendData">
          ثبت فیلم
        </button>
      </div>
    </form>
    <div class="alert alert-danger mt-8" v-if="!isFormValid">
      <p>خطا ! لطفا تمامی موارد خواسته شده را وارد کنید</p>
      <p v-if="!isImdbValid">شناسه IMDB باید با tt شروع شود</p>
    </div>
    <div class="alert-modal">
      <b-alert
        :show="dismissCountDown"
        variant="success"
        @dismissed="dismissCountDown = 0"
        @dismiss-count-down="countDownChanged"
      >
        <p>فیلم با موفقیت اضافه شد</p>
        <p>{{ dismissCountDown }}</p>
        <b-progress :max="dismissSecs" height="4px"></b-progress>
      </b-alert>
    </div>
  </div>
</template>

<script>
import Multiselect from 'vue-multiselect';
import VueCtkDateTimePicker from 'vue-ctk-date-time-picker';
import 'vue-ctk-date-time-picker/dist/vue-ctk-date-time-picker.css';
import 'vue-search-select/dist/VueSearchSelect.css';
import { ModelSelect } from 'vue-search-select';
import FormInput from './FormInput.vue';
import axios from 'axios';
export default {
  data() {
    return {
      isImdbValid: true,
      isFormValid: true,
      isEditMode: false,
      id: this.$route.params.id,
      name: '',
      options: [],
      country: [],
      token: '',
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      cValue: [],
      gValue: [],
      caValue: [],
      dValue: [],
      movieData: {
        title: '',
        shortDescription: '',
        description: '',
        startDate: '',
        endDate: '',
        lenght: '',
        status: '',
        imdbId: '',
        picture: '',
        bannerImage: '',
        seasons: '',
        Lenght: 2,
        episodes: 1
      },
      movieDetail: {
        CastsJson: [],
        GenresIdJson: [],
        DirectorsIdJson: [],
        CountriesIdJson: []
      }
    };
  },
  components: {
    ModelSelect,
    FormInput,
    Multiselect,
    VueCtkDateTimePicker: VueCtkDateTimePicker
  },
  methods: {
    imdbChecker() {
      let n = this.movieData.imdbId.includes('tt');

      if (!n) {
        this.isImdbValid = false;
      }
    },
    checkEditMode() {
      if (this.id != undefined) {
        console.log(this.id);
        this.isEditMode = true;
        axios.get('/api/series/' + this.id).then(res => {
          this.movieData = res.data;
          this.movieData.endDate = '';
          this.movieData.startDate = '';
          console.log(res.data);
        });
      }
    },
    castMaker() {
      this.caValue.forEach(q => {
        let castObject = { personId: '', character: '' };
        castObject.personId = q.id;
        castObject.character = q.name;
        this.movieDetail.CastsJson.push(castObject);
      });
    },
    genreMaker() {
      this.gValue.forEach(q => {
        this.movieDetail.GenresIdJson.push(q.id);
      });
    },
    diractorMaker() {
      this.movieDetail.DirectorsIdJson.push(this.dValue.id);
    },
    countryMaker() {
      console.log(this.cValue.id);
      this.cValue.forEach(q => {
        this.movieDetail.CountriesIdJson.push(q.value);
      });
      // this.movieDetail.CountriesIdJson.push(this.cValue.id);
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    capFstLet(str) {
      const capitalized = str.charAt(0).toUpperCase() + str.slice(1);

      return capitalized;
    },
    GetCountry() {
      axios.get('/api/countries').then(res => {
        res.data.items.forEach(q => {
          let cData = { value: '', text: '' };
          cData.value = q.id;
          cData.text = q.nationality;
          this.options.push(cData);
        });
      });
    },

    onFileSelectedTh(event) {
      this.movieData.picture = event.target.files[0];
    },
    onFileSelectedBn(event) {
      this.movieData.bannerImage = event.target.files[0];
    },
    changeRoute() {
      setTimeout(this.$router.push('/admin'), 3000);
    },
    async SubmitData(form) {
      try {
        await axios
          .post(
            '/api/series',

            form,
            {
              headers: {
                Authorization: `bearer ${this.token}`
              }
            }
          )
          .then(res => console.log(res.data));
        this.showAlert();
        this.changeRoute();
      } catch (error) {
        console.log(error);
        this.isFormValid = false;
      }
    },
    async EdittData($event) {
      try {
        await axios
          .put(
            '/api/series/' + this.id,

            $event,
            {
              headers: {
                Authorization: ` Bearer ${this.token}`
              }
            }
          )
          .then(res => console.log(res.data));

        this.isEditMode = false;
        this.showAlert();
        setTimeout(this.changeRoute(), 3000);
      } catch (error) {
        console.log(error);
        this.isFormValid = true;
      }
    },

    sendData() {
      this.castMaker();
      this.genreMaker();
      this.diractorMaker();
      this.countryMaker();
      this.imdbChecker();
      console.log(this.movieData);
      const form = new FormData();
      for (const property in this.movieData) {
        form.append(`${this.capFstLet(property)}`, this.movieData[property]);
      }
      form.append(
        'CountriesIdJson',
        JSON.stringify(this.movieDetail.CountriesIdJson)
      );
      form.append(
        'DirectorsIdJson',
        JSON.stringify(this.movieDetail.DirectorsIdJson)
      );

      form.append(
        'GenresIdJson',
        JSON.stringify(this.movieDetail.GenresIdJson)
      );

      form.append('CastsJson', JSON.stringify(this.movieDetail.CastsJson));

      if (!this.isEditMode) this.SubmitData(form);
      else this.EdittData(form);
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    console.log(this.token);
    this.checkEditMode();
    this.GetCountry();
    this.$store.dispatch('GetGenres');
    this.$store.dispatch('GetPeoples');
  },
  computed: {
    GenreOption: function() {
      return this.$store.getters.GetGenres;
    },
    PeaopleOption: function() {
      return this.$store.getters.GetPeaple;
    }
  }
};
</script>

<style scoped>
.mt-8 {
  margin-top: 5.5rem;
}
.th-img {
  width: 300px;
  height: 400px;
}

.banner-img {
  width: 400px;
  height: 400px;
}
.textarea-label {
  font-size: 20px;
}
.btn-add {
  margin-right: 1px;
  height: 47px;
  margin-top: 0.5px;
}
.check-box {
  margin-top: 1.5rem;
}

.check-box label {
  font-size: 18px !important;
}
.img-show img {
  height: 350px;
  width: 300px;
  margin-right: 0.5rem;
}
.alert-modal {
  float: left !important;
  margin-right: 1rem;
  margin-top: 1rem;
  position: fixed;
  width: 25%;
  top: 80%;
  right: 72%;
}
label.form-check-label {
  font-size: 1.2rem !important;
}
.c-check {
  margin-left: 1.1rem;
}
.text.default {
  margin-left: 0.5rem;
}
.f-check {
  margin-top: 2.3rem !important;
}
.btns {
  float: left;
}
</style>
