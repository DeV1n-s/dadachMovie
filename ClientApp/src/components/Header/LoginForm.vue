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
              placeholder="******"
            />
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
      loginData: {
        emailAddress: '',
        password: ''
      }
    };
  },
  methods: {
    // submitForm() {
    //   this.formIsValid = false;
    //   if (!this.username && !this.password && this.password.length < 6) {
    //     this.formIsValid = false;
    //     return;
    //   }
    // },
    switchAuthMode() {
      this.$store.dispatch('login', this.loginData);
      console.log(this.$store.getters.isAuthGet);
      this.$router.push('/');
      this.$router.reload('/');
    }
  }
};
</script>

<style></style>
