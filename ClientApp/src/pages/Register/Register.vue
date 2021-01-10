<template>
  <div class="main">
    <div class="container">
      <div class="signup-content">
        <form method="POST" id="signup-form" class="signup-form">
          <h2>ثبت نام کنید</h2>
          <p class="desc">
            عضو خانواده هفتصد ملیونی داداچ مویی شوید!
          </p>
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
              v-model="regData.lastName"
              type="text"
              class="form-input"
              name="name"
              id="name"
              placeholder="نام خانوادگی"
            />
          </div>
          <div class="form-group">
            <input
              v-model="regData.emailAddress"
              type="email"
              class="form-input"
              name="email"
              id="email"
              placeholder="ایمیل"
            />
          </div>
          <div class="form-group">
            <input
              v-model="regData.password"
              type="text"
              class="form-input"
              name="password"
              id="password"
              placeholder="رمز عبور"
            />
            <span
              toggle="#password"
              class="zmdi zmdi-eye field-icon toggle-password"
            ></span>
          </div>
          <div class="form-group">
            <input
              v-model="cPassword"
              type="text"
              class="form-input"
              name="password"
              id="password"
              placeholder="تکرار رمز عبور"
            />
            <span
              toggle="#password"
              class="zmdi zmdi-eye field-icon toggle-password"
            ></span>
          </div>

          <div class="form-group">
            <input
              type="checkbox"
              name="agree-term"
              id="agree-term"
              class="agree-term mr-2"
            />
          </div>
          <label for="agree-term" class="label-agree-term">
            با تمامی شرایط و قوانین داداچ مویی موافقم
          </label>
          <div class="form-group">
            <a href="http://localhost:8080/" class="submit-link submit">خانه</a>
            <a @click="submitData" href="#" class="submit-link submit"
              >ثبت نام
            </a>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      isPassSame: true,
      regData: {
        emailAddress: '',
        password: '',
        firstName: '',
        lastName: '',
        countryId: 155
      },
      cPassword: ''
    };
  },

  methods: {
    submitData() {
      if (this.regData.password !== this.cPassword) {
        this.isPassSame = false;
        return;
      }
      axios
        .post('/api/accounts/Register', this.regData)
        .then(res => console.log(res.data));
    }
  }
};
</script>

<style scoped>
a.submit-link.submit {
  margin-right: 0.5rem;
}
form#signup-form {
  padding-top: 9rem !important;
}
.mr-2 {
  margin-right: 2rem;
}
p {
  color: white !important;
}
/* @extend display-flex; */
display-flex {
  display: flex;
  display: -webkit-flex;
}

/* @extend list-type-ulli; */
list-type-ulli {
  list-style-type: none;
  margin: 0;
  padding: 0;
}

/* poppins-300 - latin */

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

input:-webkit-autofill {
  box-shadow: 0 0 0 30px transparent inset;
  -moz-box-shadow: 0 0 0 30px transparent inset;
  -webkit-box-shadow: 0 0 0 30px transparent inset;
  -o-box-shadow: 0 0 0 30px transparent inset;
  -ms-box-shadow: 0 0 0 30px transparent inset;
  background-color: transparent !important;
}

img {
  max-width: 100%;
  height: auto;
}

figure {
  margin: 0;
}

p {
  margin-bottom: 32px;
  margin-top: 0px;
  font-weight: 400;
}
p span {
  font-weight: bold;
}

h2 {
  line-height: 1.2;
  margin: 0;
  padding: 0;
  font-weight: bold;
  color: #fff;
  font-family: 'Poppins';
  font-size: 36px;
  margin-bottom: 10px;
}

.clear {
  clear: both;
}

.main {
  font-size: 14px !important;
  line-height: 1.8 !important;
  color: #fff !important;
  font-weight: 600;
  font-family: 'Poppins' !important;
  margin: 0px !important;
  background-image: url('../../../public/images/body-bg.jpg') !important;
  background-repeat: no-repeat !important;
  background-size: cover !important;
  -moz-background-size: cover !important;
  -webkit-background-size: cover !important;
  -o-background-size: cover !important;
  -ms-background-size: cover !important;
  background-position: center center !important;
}

.main {
  position: relative;
  /* background-image: url('../../../public/images/container-bg.png');
  background-repeat: no-repeat;
  background-size: cover;
  height: 100%; */
}
.signup-content {
  margin-top: 17rem;
}
.container {
  height: 100vh;
  /* margin-top: 120px !important; */
  /* margin-bottom: 70px !important; */
  width: 1123px !important;
  /* padding-top: 135px !important; */
  /* padding-bottom: 115px !important; */
  background-image: url('../../../public/images/container-bg.png') !important;
  background-repeat: no-repeat !important;
  background-size: cover !important;
  -moz-background-size: cover !important;
  -webkit-background-size: cover !important;
  -o-background-size: cover !important;
  -ms-background-size: cover !important;
  background-position: center center !important;
  overflow: hidden !important;
}

.signup-content {
  width: 562px;
  margin-right: 0px;
  background: rgba(177, 135, 77, 0.75);
  float: right;
}

.signup-form {
  padding: 54px 80px 36px 55px;
}

.form-group {
  margin-bottom: 23px;
}

input {
  border: none;
  box-sizing: border-box;
  border-bottom: 1px solid #ebebeb;
  background: transparent;
  width: 100%;
  display: block;
  color: #fff;
  font-weight: bold;
  font-family: 'Poppins';
  font-size: 14px;
  padding: 3px 0;
}
input::-webkit-input-placeholder {
  font-weight: 400;
  color: #fff;
}
input::-moz-placeholder {
  font-weight: 400;
  color: #fff;
}
input:-ms-input-placeholder {
  font-weight: 400;
  color: #fff;
}
input:-moz-placeholder {
  font-weight: 400;
  color: #fff;
}
input:focus {
  font-weight: bold;
}

.field-icon {
  float: right;
  margin-right: 0px;
  margin-top: -22px;
  position: relative;
  z-index: 2;
  color: #fff;
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
  margin-bottom: 25px;
}

input[type='checkbox']:not(old) + label > span {
  display: inline-block;
  width: 13px;
  height: 13px;
  margin-right: 15px;
  margin-bottom: 4px;
  border: 1px solid #fff;
  border-radius: 2px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  -o-border-radius: 2px;
  -ms-border-radius: 2px;
  background: transparent;
  vertical-align: bottom;
}

input[type='checkbox']:not(old):checked + label > span {
  background: transparent;
}

input[type='checkbox']:not(old):checked + label > span:before {
  content: '\f26b';
  display: block;
  color: #fff;
  font-size: 11px;
  line-height: 1.2;
  text-align: center;
  font-family: 'Material-Design-Iconic-Font';
  font-weight: bold;
}

.label-agree-term {
  font-size: 13px;
  font-weight: 400;
  color: #fff;
}

.term-service {
  color: #fff;
}

.form-submit {
  width: auto;
  display: inline-block;
  border: none;
  background: #fff;
  color: #b18757;
  padding: 10px;
  height: 50px;
  box-shadow: 0px 15px 9.9px 0.1px rgba(0, 0, 0, 0.15);
  -moz-box-shadow: 0px 15px 9.9px 0.1px rgba(0, 0, 0, 0.15);
  -webkit-box-shadow: 0px 15px 9.9px 0.1px rgba(0, 0, 0, 0.15);
  -o-box-shadow: 0px 15px 9.9px 0.1px rgba(0, 0, 0, 0.15);
  -ms-box-shadow: 0px 15px 9.9px 0.1px rgba(0, 0, 0, 0.15);
  margin-right: 25px;
}
.form-submit:hover {
  background-color: #e6e6e6;
}

.submit {
  width: 130px;
  border-radius: 25px;
  -moz-border-radius: 25px;
  -webkit-border-radius: 25px;
  -o-border-radius: 25px;
  -ms-border-radius: 25px;
  text-transform: uppercase;
  font-size: 13px;
  cursor: pointer;
}

.submit-link {
  border: 2px solid #fff;
  text-decoration: none;
  display: inline-block;
  vertical-align: middle;
  padding: 12px 0;
  text-align: center;
  color: #fff;
}
.submit-link:hover {
  background: #fff;
  color: #b18757;
}

@media screen and (max-width: 992px) {
  .container {
    width: calc(100% - 30px);
    max-width: 100%;
    margin: 0 auto;
  }

  .signup-content {
    width: 100%;
  }
}
@media screen and (max-width: 480px) {
  .submit {
    width: 100%;
  }

  .form-submit {
    margin-bottom: 20px;
    margin-right: 0px;
  }

  .signup-form {
    padding: 54px 30px 36px 30px;
  }
}

/*# sourceMappingURL=style.css.map */
</style>
