<template>
  <div dir="rtl">
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark p-0">
      <div class="container">
        <a href="home" class="navbar-brand">داداچ مویی</a>
        <button
          class="navbar-toggler"
          data-toggle="collapse"
          data-target="#navbarCollapse"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
          <ul class="navbar-nav">
            <li class="nav-item px-2">
              <a href="index.html" class="nav-link active">داشبورد</a>
            </li>
            <li class="nav-item px-2">
              <a href="posts.html" class="nav-link">فیلم ها</a>
            </li>
            <li class="nav-item px-2">
              <a href="categories.html" class="nav-link">هنرمندان</a>
            </li>
            <li class="nav-item px-2">
              <a href="users.html" class="nav-link">کاربران</a>
            </li>
          </ul>

          <ul class="navbar-nav mr-auto">
            <li class="nav-item ">
              <a href="login.html" class="nav-link">
                خوش آمدی
                {{ currentUser.firstName }} {{ currentUser.lastName }}
                !
              </a>
            </li>
            <li class="nav-item">
              <a href="login.html" class="nav-link">
                تاریخ آخرین ورود : 23/7/1399
              </a>
            </li>
            <li class="nav-item">
              <a href="/home" class="nav-link" @click="logOut">
                خروج
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
    <header id="main-header" class="py-2 bg-primary text-white">
      <div class="container">
        <div class="row">
          <div class="col-md-6">
            <h1><i class="fa fa-cog"></i>داشبورد مدیریت</h1>
          </div>
        </div>
      </div>
    </header>
    <section id="actions" class="py-4 mb-4 bg-light">
      <div class="container">
        <div class="row">
          <div class="col-md-3">
            <a href="/addPeople" class="btn btn-primary btn-block">
              <i class="fa fa-plus"></i> اضافه کردن فیلم
            </a>
          </div>
          <div class="col-md-3">
            <nuxt-link to="/addpeople" class="btn btn-success btn-block">
              <i class="fa fa-plus"></i> اضافه کردن هنرمند
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <a href="#" class="btn btn-warning btn-block">
              <i class="fa fa-plus"></i> اضافه کردن اخبار
            </a>
          </div>
          <div class="col-md-3">
            <a
              href="#"
              class="btn btn-danger btn-block"
              data-toggle="modal"
              data-target="#addCategoryModal"
            >
              <i class="fa fa-plus"></i> اضافه کردن ژانر
            </a>
          </div>
        </div>
      </div>
    </section>
    <genre-form />
  </div>
</template>

<script>
import axios from 'axios';
import GenreForm from '../Forms/GenreForm.vue';
export default {
  components: {
    GenreForm
  },
  data() {
    return {
      currentUser: {},
      isLogin: false,
      tokenId: this.$store.getters.isAuthGet,
      token: this.$store.getters.token
    };
  },
  methods: {
    autoLog() {
      this.$store.dispatch('autoLog');
    },
    logCheck() {
      if (this.tokenId) {
        this.isLogin = true;
      }
    },
    logOut() {
      this.$store.dispatch('logOut');
    },
    getCurrentUser() {
      if (this.tokenId) {
        axios
          .get('/api/accounts/CurrentUser', {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          })
          .then(res => {
            this.currentUser = res.data;
            // console.log(this.curentUser);
          });
      }
    }
  },
  async beforeMount() {
    await this.autoLog();
    this.logCheck();
    this.getCurrentUser();
    console.log(this.isLogin);
  }
};
</script>

<style></style>
