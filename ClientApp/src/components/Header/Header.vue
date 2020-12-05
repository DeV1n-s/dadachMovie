<template>
  <div id="preloader">
    <img class="logo" src="images/logo1.png" alt="" width="119" height="58" />
    <div id="status">
      <span></span>
      <span></span>
    </div>
  </div>
  <loginForm />
  <signUp />
  <navBar />
</template>

<script>
import loginForm from './LoginForm';
import signUp from './SignUp';
import navBar from './NavBar';
export default {
  components: {
    loginForm,
    signUp,
    navBar
  }
};
</script>

<style></style>
