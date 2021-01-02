<template>
  <div class="login-wrapper" id="signup-content">
    <div class="login-content">
      <a href="#" class="close">x</a>
      <h3>ثبت نام</h3>
      <form method="post" action="#">
        <div class="row">
          <form-input label="نام کاربری" :required="true" id="name" />
        </div>

        <div class="row">
          <form-input
            label="پست الکترونیکی"
            :required="true"
            id="name"
            v-model="regData.emailAddress"
          />
        </div>
        <div class="row">
          <form-input
            label="رمز عبور"
            :required="true"
            id="name"
            v-model="regData.password"
          />
          <small>رمز عبور باید شامل حروف کوچک و بزرگ و سیمبول ها باشد</small>
        </div>
        <div class="row">
          <form-input
            label="تکرار رمز عبور"
            :required="true"
            id="name"
            v-model="cPassword"
            :fr="password"
          />

          <small class="s-warning" v-if="!isPassSame"
            >پسورد و تکرار آن مشابه نیستند
          </small>
        </div>
        <div class="row">
          <button type="submit" @click.prevent="submitData()">ثبت نام</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import FormInput from '../../components/Form/FormInput';

export default {
  components: {
    FormInput
  },
  data() {
    return {
      isPassSame: true,
      regData: {
        // userName: '',
        emailAddress: '',
        password: ''
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
.overlay .login-content p {
  margin-bottom: 4px;
  margin-top: 5px;
}

form-input {
  margin-bottom: 0px !important;
  margin-top: 0px !important;
}
small {
  font-size: 10px;
  color: #696868;
}
</style>
