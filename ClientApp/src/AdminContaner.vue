<template>
  <div id="wrapper">
    <nav-bar />
    <side-bar />

    <div id="page-wrapper">
      <div id="page-inner">
        <div class="row">
          <div class="col-md-12 ">
            <div class="welcome-admin">
              <h2>پنل ادمین</h2>
              <h5>دانیال شکوه منش عزیز خوش آمدی !</h5>
            </div>
            <router-view />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import '../public/Admin/css/bootstrap.css';
import '../public/Admin/css/font-awesome.css';
import '../public/Admin/css/custom.css';
import NavBar from './components/Admin/AdminNav';

import SideBar from './components/Admin/SideBar.vue';
export default {
  name: 'AdminContainer',
  components: {
    NavBar,
    SideBar
  },
  methods: {
    log() {
      this.$store.dispatch('autoLog');
    }
  },
  created() {
    this.log();
  }
};
</script>

<style scoped>
.welcome-admin {
  margin-right: 20px;
}
</style>
