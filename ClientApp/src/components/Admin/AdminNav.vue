<template>
  <nav
    class="navbar navbar-default navbar-cls-top "
    role="navigation"
    style="margin-bottom: 0"
  >
    <a class="navbar-brand" href="http://localhost:8080/">داداچ مویی</a>

    <div class="navbar-header">
      <div
        style="color: white;
padding: 15px 50px 5px 50px;
float: right;
font-size: 16px;"
      >
        آخرین ورود : 30 دی 1399 &nbsp;
        <a
          @click="logOut"
          href="http://localhost:8080/"
          class="btn btn-danger square-btn-adjust"
          >خروج</a
        >
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  methods: {
    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.Auth.isAuth = false;
      this.$router.replace('/');
      console.log(this.$store.getters.isAuthGet);
    }
  }
};
</script>

<style>
a.btn.btn-danger.square-btn-adjust {
  border-radius: 10px;
}
</style>
