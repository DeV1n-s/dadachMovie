<template>
  <div class="register-form">
    <div class="mains">
      <section class="signup">
        <!-- <img src="images/signup-bg.jpg" alt=""> -->
        <div class="container">
          <div class="signup-content">
            <form method="POST" id="signup-form" class="signup-form">
              <h2 class="form-title">ورود به حساب کاربری</h2>

              <div class="form-group">
                <input
                  type="email"
                  class="form-input"
                  name="email"
                  id="email"
                  placeholder="پست الکترونیکی"
                  v-model="logData.emailAddress"
                />
              </div>
              <div class="form-group">
                <input
                  type="password"
                  class="form-input"
                  name="password"
                  id="password"
                  placeholder="رمز عبور"
                  v-model="logData.password"
                />
                <span
                  toggle="#password"
                  class="zmdi zmdi-eye field-icon toggle-password"
                ></span>
              </div>

              <div class="form-group">
                <input
                  type="submit"
                  name="submit"
                  id="submit"
                  class="form-submit"
                  value="ورود"
                  @click.prevent="subData"
                />
              </div>
              <small class=" text-danger" v-if="!isFormValid">
                خطا ! لطفا تمامی ورودی ها را تکمیل کنید
              </small>
            </form>
            <p class="loginhere">
              حساب کاربری ندارید؟
              <nuxt-link to="/register" class="loginhere-link"
                >ثبت نام کنید</nuxt-link
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
      dismissSecs: 4,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      isFormValid: true,
      isPassSame: true,
      logData: {
        emailAddress: '',
        password: ''
      }
    };
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    valCheck() {
      if (this.logData.emailAddress == '' || this.logData.password == '') {
        this.isFormValid = false;
        return;
      }
    },
    changeRoute() {
      setTimeout(this.$router.push('/'), 4000);
    },
    subData() {
      this.$store.dispatch('login', this.logData);

      //   this.valCheck();
      //   axios.post('/api/accounts/login', this.logData).then(res => {
      //     console.log(res.statusText);
      //     console.log(res);
      //     if (res.statusText == 'OK') {
      //       this.showAlert();
      //       this.changeRoute();
      //     }
      //   });
    }
  }
};
</script>
<style scoped>
.register-form {
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
