<template>
  <div class="login-wrapper" id="login-content">
    <div class="login-content">
      <a href="#" class="close">x</a>
      <h3>ورود</h3>
      <form method="post" action="#">
        <div class="row">
          <label for="username">
            پست الکترونیکی
            <input
              type="text"
              name="username"
              id="username"
              v-model="loginData.emailAddress"
            />
            <small class="t-warning" v-if="isEmailEmpty"
              >لطفا پست الکترونیکی را وارد کنید
            </small>
          </label>
        </div>

        <div class="row">
          <label for="password">
            رمز عبور:
            <input
              v-model="loginData.password"
              type="password"
              name="password"
              id="password"
            />
            <small class="t-warning" v-if="isPassEmpty"
              >لطفا رمز عبور را وارد کنید
            </small>
          </label>
        </div>
        <div class="row">
          <div class="remember">
            <div>
              <input type="checkbox" name="remember" value="Remember me" /><span
                >مرا به خاطر بسپار</span
              >
            </div>
            <a href="#">فراموشی رمز عبور</a>
          </div>
        </div>
        <div class="row">
          <button type="submit" @click.prevent="switchAuthMode">
            وارد شوید
          </button>
          <small class="t-warning" v-if="isLogFaile">
            نام کاربری یا رمز عبور اشتباه است</small
          >
        </div>
      </form>
      <div class="row">
        <p>شبکه های اجتماعی ما</p>
        <div class="social-btn-2">
          <a class="fb" href="#"><i class="ion-social-facebook"></i>فیسبوک </a>
          <a class="tw" href="#"><i class="ion-social-twitter"></i>تویتر</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isPassEmpty: false,
      isEmailEmpty: false,
      isLogFaile: false,
      loginData: {
        emailAddress: '',
        password: ''
      }
    };
  },
  methods: {
    logInVal() {
      if (this.loginData.emailAddress === '') {
        this.isEmailEmpty = true;
        return;
      }
      if (this.loginData.password === '') {
        this.isPassEmpty = true;
        return;
      }
    },
    logCheck() {
      if (!this.$store.getters.isAuthGet) {
        this.isLogFaile = true;
        return;
      }
    },
    async switchAuthMode() {
      this.logInVal();
      this.$store.dispatch('login', this.loginData);
      await console.log(this.$store.getters.isAuthGet);
      this.logCheck();
      this.$router.push('/');
      this.$router.reload('/');
    }
  }
};
</script>

<style>
.t-warning {
  color: brown;
}
</style>
