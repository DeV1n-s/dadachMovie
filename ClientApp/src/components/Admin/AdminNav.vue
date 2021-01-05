<template>
  <nav
    class="navbar navbar-default navbar-cls-top "
    role="navigation"
    style="margin-bottom: 0"
  >
    <div class="navbar-header">
      <button
        type="button"
        class="navbar-toggle"
        data-toggle="collapse"
        data-target=".sidebar-collapse"
      >
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="index.html">داداچ مویی</a>
    </div>
    <div
      style="color: white;
padding: 15px 50px 5px 50px;
float: right;
font-size: 16px;"
    >
      آخرین ورود: 30دی 1399 &nbsp;
      <a
        @click="logOut"
        href="http://localhost:8080/"
        class="btn btn-danger square-btn-adjust"
        >خروج</a
      >
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

<style></style>
