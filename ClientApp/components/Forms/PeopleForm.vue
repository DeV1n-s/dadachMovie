<template>
  <div>
    <form class="mt-5">
      <div class="row">
        <div class="col-md-6">
          <div class="form-group">
            <label for="exampleFormControlInput1"></label>
            <form-input
              label="نام بازیگر"
              :required="true"
              id="name"
              v-model="CastData.name"
            />
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group mt-4 f-check">
            <div class="form-check">
              <label class="form-check-label c-check " for="flexCheckDefault">
                بازیگر
              </label>
              <input
                class="form-check-input mr-5"
                type="checkbox"
                value=""
                v-model="CastData.isCast"
                id="flexCheckDefault"
              />
            </div>
            <div class="form-check">
              <label class="form-check-label" for="flexCheckDefault">
                کارگردان
              </label>
              <input
                class="form-check-input mr-5"
                type="checkbox"
                value=""
                id="flexCheckDefault"
                v-model="CastData.isDiractor"
              />
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="form-group">
            <div class="form-group">
              <label for="exampleFormControlInput1"></label>
              <form-input
                label="توضیحات کوتاه"
                :required="true"
                id="name"
                v-model="CastData.shortBio"
              />
            </div>
          </div>
        </div>
      </div>
      <div class="row mt-2">
        <div class="col-md-6">
          <model-select
            class="nationality"
            :options="options"
            placeholder="ملیت"
            v-model="CastData.countryId"
          >
          </model-select>
        </div>
        <div class="col-md-6">
          <label for="start" class="d-block">تاریخ تولد :</label>

          <input
            class="w-100"
            type="date"
            id="start"
            name="trip-start"
            value="2018-07-22"
            min="0000-01-01"
            max="2999-12-31"
            v-model="CastData.dateOfBirth"
          />
        </div>
      </div>
      <div class="row mt-5">
        <div class="col-md-12">
          <div class="form-group">
            <label for="exampleFormControlTextarea2">بیوگرافی</label>
            <textarea
              class="form-control rounded-0"
              id="exampleFormControlTextarea2"
              rows="6"
              v-model="CastData.biography"
            ></textarea>
          </div>
        </div>
      </div>
      <div class="custom-file">
        <label class="custom-file-label " for="customFile"
          >تصویر را انتخاب کنید</label
        >
        <input
          type="file"
          class="custom-file-input"
          id="customFile"
          @change="onFileSelected"
        />
      </div>
    </form>
    <form>
      <div class="btns mt-3">
        <nuxt-link to="/admin">
          <button class="btn btn-danger">بازگشت</button>
        </nuxt-link>

        <button class="btn btn-success" @click.prevent="subData">
          ثبت بازیگر
        </button>
      </div>
    </form>
    <div class="alert-modal">
      <b-alert
        :show="dismissCountDown"
        variant="success"
        @dismissed="dismissCountDown = 0"
        @dismiss-count-down="countDownChanged"
      >
        <p>ژانر با موفقیت اضافه شد</p>
        <p>{{ dismissCountDown }}</p>
        <b-progress :max="dismissSecs" height="4px"></b-progress>
      </b-alert>
    </div>
  </div>
</template>

<script>
import 'vue-search-select/dist/VueSearchSelect.css';
import { ModelSelect } from 'vue-search-select';
import FormInput from './FormInput.vue';
import axios from 'axios';
export default {
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
        countryId: ''
      },
      options: [],
      country: [],
      token: '',
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false
    };
  },
  components: {
    ModelSelect,
    FormInput
  },
  methods: {
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

    onFileSelected(event) {
      this.CastData.picture = event.target.files[0];
    },
    changeRoute() {
      this.$router.push('/admin');
    },
    async subData() {
      const form = new FormData();
      for (const property in this.CastData) {
        form.append(`${this.capFstLet(property)}`, this.CastData[property]);
      }
      await axios
        .post('/api/people', form, {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          console.log(res.data);
        });
      this.showAlert();
      setTimeout(this.changeRoute(), 3000);
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    this.GetCountry();
  }
};
</script>

<style scoped>
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
  font-size: 0.9rem !important;
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
