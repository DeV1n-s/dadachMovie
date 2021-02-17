<template>
  <div class="register-form">
    <div class="mains">
      <section class="signup">
        <!-- <img src="images/signup-bg.jpg" alt=""> -->
        <div class="container">
          <div class="signup-content">
            <form method="POST" id="signup-form" class="signup-form">
              <h2 class="form-title">ساخت حساب کاربری</h2>
              <div class="form-group">
                <input
                  type="text"
                  class="form-input"
                  name="name"
                  id="name"
                  placeholder="نام"
                  v-model="regData.firstName"
                />
              </div>
              <div class="form-group">
                <input
                  type="text"
                  class="form-input"
                  name="name"
                  id="name"
                  placeholder="نام خانوادگی"
                  v-model="regData.lastName"
                />
              </div>
              <div class="form-group">
                <input
                  type="email"
                  class="form-input"
                  name="email"
                  id="email"
                  placeholder="پست الکترونیکی"
                  v-model="regData.emailAddress"
                />
              </div>
              <div class="form-group">
                <div class="input_container">
                  <input
                    type="password"
                    @input="checkPassword"
                    v-model="password"
                    autocomplete="off"
                    placeholder="رمز عبور"
                  />
                  <ul>
                    <li v-bind:class="{ is_valid: contains_eight_characters }">
                      شامل 6 کاراکتر
                    </li>
                    <li v-bind:class="{ is_valid: contains_number }">
                      شامل اعداد
                    </li>
                    <li v-bind:class="{ is_valid: contains_uppercase }">
                      شامل حروف کوچک بزرگ
                    </li>
                    <li v-bind:class="{ is_valid: contains_special_character }">
                      شامل اعداد
                    </li>
                  </ul>

                  <div
                    class="checkmark_container"
                    v-bind:class="{ show_checkmark: valid_password }"
                  >
                    <svg width="50%" height="50%" viewBox="0 0 140 100">
                      <path
                        class="checkmark"
                        v-bind:class="{ checked: valid_password }"
                        d="M10,50 l25,40 l95,-70"
                      />
                    </svg>
                  </div>
                </div>

                <span
                  toggle="#password"
                  class="zmdi zmdi-eye field-icon toggle-password"
                ></span>
              </div>
              <div class="form-group">
                <input
                  type="password"
                  class="form-input"
                  name="re_password"
                  id="re_password"
                  placeholder="تکرار رمز عبور"
                  v-model="cPassword"
                />
                <small class="text-danger" v-if="!isPassSame">
                  ! رمز عبور یکسان نیست
                </small>
              </div>
              <div class="form-group">
                <input
                  type="checkbox"
                  name="agree-term"
                  id="agree-term"
                  class="agree-term"
                />
                <label for="agree-term" class="label-agree-term"
                  ><span><span></span></span>
                  با تمامی قوانین و مقررات داداچ مویی موافقم
                </label>
              </div>
              <div class="form-group">
                <input
                  type="submit"
                  name="submit"
                  id="submit"
                  class="form-submit"
                  value="ثبت نام"
                  @click.prevent="subData"
                />
              </div>
              <small class=" text-danger" v-if="!isFormValid">
                خطا ! لطفا تمامی ورودی ها را تکمیل کنید
              </small>
            </form>
            <p class="loginhere">
              حساب کاربری دارید؟
              <nuxt-link to="/login" class="loginhere-link"
                >وارد شوید</nuxt-link
              >
            </p>
          </div>
        </div>
        <div class="alert-modal">
          <b-alert
            :show="dismissCountDown"
            variant="success"
            @dismissed="dismissCountDown = 0"
            @dismiss-count-down="countDownChanged"
          >
            <p>ثبت نام با موفقیت انجام شد</p>
            <p>{{ dismissCountDown }}</p>
            <b-progress :max="dismissSecs" height="4px"></b-progress>
          </b-alert>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
import FormInput from '../../components/Forms/FormInput';
import axios from 'axios';
export default {
  components: {
    FormInput
  },
  data() {
    return {
      password: null,
      password_length: 0,
      contains_eight_characters: false,
      contains_number: false,
      contains_uppercase: false,
      contains_special_character: false,
      valid_password: false,
      dismissSecs: 4,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      isFormValid: true,
      isPassSame: true,
      regData: {
        emailAddress: '',
        password: '',
        firstName: '',
        lastName: ''
      },
      cPassword: ''
    };
  },
  methods: {
    checkPassword() {
      this.password_length = this.password.length;
      const format = /[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;

      if (this.password_length > 6) {
        this.contains_eight_characters = true;
      } else {
        this.contains_eight_characters = false;
      }

      this.contains_number = /\d/.test(this.password);
      this.contains_uppercase = /[A-Z]/.test(this.password);
      this.contains_special_character = format.test(this.password);

      if (
        this.contains_eight_characters === true &&
        this.contains_special_character === true &&
        this.contains_uppercase === true &&
        this.contains_number === true
      ) {
        this.valid_password = true;
      } else {
        this.valid_password = false;
      }
    }
  },
  passCheck() {
    if (this.cPassword != this.regData.password) {
      this.isPassSame = false;
    }
  },
  countDownChanged(dismissCountDown) {
    this.dismissCountDown = dismissCountDown;
  },
  showAlert() {
    this.dismissCountDown = this.dismissSecs;
  },
  valCheck() {
    if (
      this.regData.emailAddress == '' ||
      this.regData.password == '' ||
      this.regData.firstName == '' ||
      this.regData.lastName == '' ||
      this.cPassword == ''
    ) {
      this.isFormValid = false;
      return;
    }
    if (this.regData.password != this.cPassword) {
      this.isPassSame = false;
      return;
    }
  },
  changeRoute() {
    setTimeout(this.$router.push('/login'), 4000);
  },
  subData() {
    (this.isFormValid = true), (this.isPassSame = true);
    this.valCheck();
    this.passCheck();
    axios.post('/api/accounts/Register', this.regData).then(res => {
      console.log(res.statusText);
      if (res.statusText == 'OK') {
        this.showAlert();
        this.changeRoute();
      }
    });
  }
};
</script>

<style scoped>
h2 {
  text-align: center;
  color: #fff;
  font-weight: 400;
}

ul {
  padding-left: 20px;
  display: flex;
  flex-direction: column;
}

ul li {
  list-style-type: none;
}

li {
  margin-bottom: 8px;
  color: #525f7f;
  position: relative;
}

li:before {
  content: '';
  width: 0%;
  height: 2px;
  background: #2ecc71;
  position: absolute;
  left: 0;
  top: 50%;
  display: block;
  transition: all 0.6s cubic-bezier(0.175, 0.885, 0.32, 1.275);
}

#app {
  width: 400px;
}

/* Password Input --------- */

.input_container {
  position: relative;

  border-radius: 6px;
  background: #fff;
}

input[type='password'] {
  line-height: 1.5;
  display: block;
  color: rgba(136, 152, 170, 1);
  font-weight: 300;
  width: 100%;
  height: calc(2.75rem + 2px);
  padding: 0.625rem 0.75rem;
  border-radius: 0.25rem;
  background-color: #fff;
  transition: border-color 0.4s ease;
  border: 1px solid #cad1d7;
  outline: 0;
}

input[type='password']:focus {
  border-color: rgba(50, 151, 211, 0.45);
}

/* Checkmark & Strikethrough --------- */

.is_valid {
  color: rgba(136, 152, 170, 0.8);
}
.is_valid:before {
  width: 100%;
}

.checkmark_container {
  border-radius: 50%;
  position: absolute;
  top: -15px;
  right: -15px;
  background: #2ecc71;
  width: 50px;
  height: 50px;
  visibility: hidden;
  opacity: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: opacity 0.4s ease;
}

.show_checkmark {
  visibility: visible;
  opacity: 1;
}

.checkmark {
  width: 100%;
  height: 100%;
  fill: none;
  stroke: white;
  stroke-width: 15;
  stroke-linecap: round;
  stroke-dasharray: 180;
  stroke-dashoffset: 180;
}

.checked {
  animation: draw 0.5s ease forwards;
}

@keyframes draw {
  to {
    stroke-dashoffset: 0;
  }
}
register-form {
  height: 100vh;
}
.alert-modal {
  margin-left: 2rem;
  position: absolute;
  width: 25%;
  top: 100%;
}
/* @extend display-flex; */
display-flex,
.display-flex,
.display-flex-center {
  display: flex;
  display: -webkit-flex;
}

/* @extend list-type-ulli; */
list-type-ulli {
  list-style-type: none;
  margin: 0;
  padding: 0;
}

/* Montserrat-300 - latin */
a:focus,
a:active {
  text-decoration: none;
  outline: none;
  transition: all 300ms ease 0s;
  -moz-transition: all 300ms ease 0s;
  -webkit-transition: all 300ms ease 0s;
  -o-transition: all 300ms ease 0s;
  -ms-transition: all 300ms ease 0s;
}

input,
select,
textarea {
  outline: none;
  appearance: unset !important;
  -moz-appearance: unset !important;
  -webkit-appearance: unset !important;
  -o-appearance: unset !important;
  -ms-appearance: unset !important;
}

input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  appearance: none !important;
  -moz-appearance: none !important;
  -webkit-appearance: none !important;
  -o-appearance: none !important;
  -ms-appearance: none !important;
  margin: 0;
}

input:focus,
select:focus,
textarea:focus {
  outline: none;
  box-shadow: none !important;
  -moz-box-shadow: none !important;
  -webkit-box-shadow: none !important;
  -o-box-shadow: none !important;
  -ms-box-shadow: none !important;
}

input[type='checkbox'] {
  appearance: checkbox !important;
  -moz-appearance: checkbox !important;
  -webkit-appearance: checkbox !important;
  -o-appearance: checkbox !important;
  -ms-appearance: checkbox !important;
}

input[type='radio'] {
  appearance: radio !important;
  -moz-appearance: radio !important;
  -webkit-appearance: radio !important;
  -o-appearance: radio !important;
  -ms-appearance: radio !important;
}

img {
  max-width: 100%;
  height: auto;
}

figure {
  margin: 0;
}

p {
  margin-bottom: 0px;
  font-size: 15px;
  color: #777;
}

h2 {
  line-height: 1.66;
  margin: 0;
  padding: 0;
  /* font-weight: 900; */
  color: #222;
  font-size: 24px;
  text-transform: uppercase;
  text-align: center;
  margin-bottom: 40px;
}

.clear {
  clear: both;
}

.register-form {
  font-size: 14px;
  line-height: 1.8;
  color: #222;
  /* font-weight: 400; */
  background-image: url('https://cdn.wallpapersafari.com/4/44/YfT0Oo.jpg') !important;
  background-repeat: no-repeat;
  background-size: cover;
  -moz-background-size: cover;
  -webkit-background-size: cover;
  -o-background-size: cover;
  -ms-background-size: cover;
  background-position: center center;
  padding: 115px 0;
}

.container {
  width: 660px;
  position: relative;
  margin: 0 auto;
}

.display-flex {
  justify-content: space-between;
  -moz-justify-content: space-between;
  -webkit-justify-content: space-between;
  -o-justify-content: space-between;
  -ms-justify-content: space-between;
  align-items: center;
  -moz-align-items: center;
  -webkit-align-items: center;
  -o-align-items: center;
  -ms-align-items: center;
}

.display-flex-center {
  justify-content: center;
  -moz-justify-content: center;
  -webkit-justify-content: center;
  -o-justify-content: center;
  -ms-justify-content: center;
  align-items: center;
  -moz-align-items: center;
  -webkit-align-items: center;
  -o-align-items: center;
  -ms-align-items: center;
}

.position-center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -moz-transform: translate(-50%, -50%);
  -webkit-transform: translate(-50%, -50%);
  -o-transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
}

.signup-content {
  background: #fff;
  border-radius: 10px;
  -moz-border-radius: 10px;
  -webkit-border-radius: 10px;
  -o-border-radius: 10px;
  -ms-border-radius: 10px;
  padding: 50px 85px;
}

.form-group {
  overflow: hidden;
  margin-bottom: 20px;
}

.form-input {
  width: 100%;
  border: 1px solid #ebebeb;
  border-radius: 5px;
  -moz-border-radius: 5px;
  -webkit-border-radius: 5px;
  -o-border-radius: 5px;
  -ms-border-radius: 5px;
  padding: 17px 20px;
  box-sizing: border-box;
  font-size: 14px;
  /* font-weight: 500; */
  color: #222;
}
.form-input::-webkit-input-placeholder {
  color: #999;
}
.form-input::-moz-placeholder {
  color: #999;
}
.form-input:-ms-input-placeholder {
  color: #999;
}
.form-input:-moz-placeholder {
  color: #999;
}

.form-input:focus {
  border: 1px solid transparent;
  -webkit-border-image-source: -webkit-linear-gradient(
    to right,
    #9face6,
    #74ebd5
  );
  -moz-border-image-source: -moz-linear-gradient(to right, #9face6, #74ebd5);
  -o-border-image-source: -o-linear-gradient(to right, #9face6, #74ebd5);
  border-image-source: linear-gradient(to right, #9face6, #74ebd5);
  -webkit-border-image-slice: 1;
  border-image-slice: 1;
  border-radius: 5px;
  -moz-border-radius: 5px;
  -webkit-border-radius: 5px;
  -o-border-radius: 5px;
  -ms-border-radius: 5px;
  background-origin: border-box;
  background-clip: content-box, border-box;
}
.form-input:focus::-webkit-input-placeholder {
  color: #222;
}
.form-input:focus::-moz-placeholder {
  color: #222;
}
.form-input:focus:-ms-input-placeholder {
  color: #222;
}
.form-input:focus:-moz-placeholder {
  color: #222;
}

.form-submit {
  width: 100%;
  border-radius: 5px;
  -moz-border-radius: 5px;
  -webkit-border-radius: 5px;
  -o-border-radius: 5px;
  -ms-border-radius: 5px;
  padding: 17px 20px;
  box-sizing: border-box;
  font-size: 14px;
  /* font-weight: 700; */
  color: #fff;
  text-transform: uppercase;
  border: none;
  background-image: -moz-linear-gradient(to left, #74ebd5, #9face6);
  background-image: -ms-linear-gradient(to left, #74ebd5, #9face6);
  background-image: -o-linear-gradient(to left, #74ebd5, #9face6);
  background-image: -webkit-linear-gradient(to left, #74ebd5, #9face6);
  background-image: linear-gradient(to left, #74ebd5, #9face6);
}

input[type='checkbox']:not(old) {
  width: 2em;
  margin: 0;
  padding: 0;
  font-size: 1em;
  display: none;
}

input[type='checkbox']:not(old) + label {
  display: inline-block;
  margin-top: 7px;
  margin-bottom: 25px;
}

input[type='checkbox']:not(old) + label > span {
  display: inline-block;
  width: 13px;
  height: 13px;
  margin-right: 15px;
  margin-bottom: 3px;
  border: 1px solid #ebebeb;
  border-radius: 2px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  -o-border-radius: 2px;
  -ms-border-radius: 2px;
  background: white;
  background-image: -moz-linear-gradient(white, white);
  background-image: -ms-linear-gradient(white, white);
  background-image: -o-linear-gradient(white, white);
  background-image: -webkit-linear-gradient(white, white);
  background-image: linear-gradient(white, white);
  vertical-align: bottom;
}

input[type='checkbox']:not(old):checked + label > span {
  background-image: -moz-linear-gradient(white, white);
  background-image: -ms-linear-gradient(white, white);
  background-image: -o-linear-gradient(white, white);
  background-image: -webkit-linear-gradient(white, white);
  background-image: linear-gradient(white, white);
}

input[type='checkbox']:not(old):checked + label > span:before {
  content: '\f26b';
  display: block;
  color: #222;
  font-size: 11px;
  line-height: 1.2;
  text-align: center;
  /* font-weight: bold; */
}

.label-agree-term {
  font-size: 12px;
  font-weight: 600;
  color: #555;
}

.term-service {
  color: #555;
}

.loginhere {
  color: #555;
  font-weight: 500;
  text-align: center;
  margin-top: 91px;
  margin-bottom: 5px;
}
input:-moz-placeholder {
  text-align: right;
}
::-webkit-input-placeholder {
  text-align: right;
}

ul {
  font-size: 12px;
}
.loginhere-link {
  font-weight: 700;
  color: #222;
}

.field-icon {
  float: right;
  margin-right: 17px;
  margin-top: -32px;
  position: relative;
  z-index: 2;
  color: #555;
}

@media screen and (max-width: 768px) {
  .container {
    width: calc(100% - 40px);
    max-width: 100%;
  }
}
@media screen and (max-width: 480px) {
  .signup-content {
    padding: 50px 25px;
  }
}

/*# sourceMappingURL=style.css.map */
</style>
