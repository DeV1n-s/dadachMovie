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
      <div class="img-show" v-if="isEditMode">
        <img :src="CastData.picture" alt="" />
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
      <div class="btns mt-4 mb-4">
        <nuxt-link to="/admin">
          <button class="btn btn-danger">بازگشت</button>
        </nuxt-link>

        <button class="btn btn-success" @click.prevent="sendData">
          ثبت بازیگر
        </button>
      </div>
    </form>
    <div class="alert alert-danger mt-8" v-if="!isFormValid">
      <p>خطا ! لطفا تمامی موارد خواسته شده را تکمیل کنید</p>
    </div>
    <div class="alert-modal">
      <b-alert
        :show="dismissCountDown"
        variant="success"
        @dismissed="dismissCountDown = 0"
        @dismiss-count-down="countDownChanged"
      >
        <p>بازیگر با موفقیت اضافه شد</p>
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
      isFormValid: true,
      isEditMode: false,
      id: this.$route.params.id,
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
    checkEditMode() {
      if (this.id != undefined) {
        console.log(this.id);
        this.isEditMode = true;
        axios.get('/api/people/' + this.id).then(res => {
          this.CastData = res.data;
          console.log(res.data);
        });
      }
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

    onFileSelected(event) {
      this.CastData.picture = event.target.files[0];
    },
    changeRoute() {
      this.$router.push('/admin');
    },
    async SubmitData(form) {
      try {
        await axios
          .post('/api/people', form, {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          })
          .then(res => {
            console.log(res);
            this.$router.push('/CastPanel');
          });
        this.showAlert();
        setTimeout(this.changeRoute(), 3000);
      } catch (error) {
        console.log(error);
        this.isFormValid = false;
      }
    },
    async EdittData($event) {
      await axios
        .put(
          '/api/people/' + this.id,

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
    },

    sendData() {
      const form = new FormData();
      console.log(this.CastData);
      for (const property in this.CastData) {
        form.append(`${this.capFstLet(property)}`, this.CastData[property]);
      }
      if (!this.isEditMode) this.SubmitData(form);
      else this.EdittData(form);
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    this.checkEditMode();
    this.GetCountry();
    console.log(this.token);
  }
};
</script>

<style scoped>
.mt-8 {
  margin-top: 4.5rem !important;
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
