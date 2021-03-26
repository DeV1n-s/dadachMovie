<template>
  <div dir="rtl">
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark p-0">
      <div class="container">
        <nuxt-link
          to="/home"
          class="nav-link  nav-title"
          exact-active-class="active"
          >داداچ مویی</nuxt-link
        >
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
              <nuxt-link
                to="/admin"
                class="nav-link "
                exact-active-class="active"
                >داشبورد</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/moviepanel"
                class="nav-link "
                exact-active-class="active"
                >فیلم ها</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/peoplepanel"
                class="nav-link"
                exact-active-class="active"
                >هنرمندان</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/newspanel"
                class="nav-link"
                exact-active-class="active"
                >اخبار</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/userpanel"
                class="nav-link"
                exact-active-class="active"
                >کاربران</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/requestpanel"
                class="nav-link"
                exact-active-class="active"
                >درخواست‌ها</nuxt-link
              >
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
            <h1><i class="fa fa-cog ml-1"></i>داشبورد مدیریت</h1>
          </div>
        </div>
      </div>
    </header>
    <section id="actions" class="py-4 mb-1 bg-light">
      <div class="container">
        <div class="row">
          <div class="col-md-3">
            <nuxt-link to="/admin/movie/add" class="btn btn-primary btn-block">
              <i class="fa fa-plus"></i> افزودن فیلم
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <nuxt-link to="/admin/people/add" class="btn btn-success btn-block">
              <i class="fa fa-plus"></i> افزودن هنرمند
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <a href="#" class="btn btn-warning btn-block">
              <i class="fa fa-plus"></i> افزودن اخبار
            </a>
          </div>
          <div class="col-md-3">
            <a
              href="#"
              class="btn btn-danger btn-block"
              data-toggle="modal"
              data-target="#addCategoryModal"
            >
              <i class="fa fa-plus"></i> افزودن ژانر
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
      token: '',
      isAdmin: false
    };
  },
  methods: {
    autoLog() {
      this.$store.dispatch('autoLog');
    },
    logCheck() {
      if (this.tokenId != '') {
        this.isLogin = true;
      }
    },
    logOut() {
      this.$store.dispatch('logOut');
    },
    async getCurrentUser() {
      try {
        await axios
          .get('/api/accounts/CurrentUser', {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          })
          .then(res => {
            console.log(res);
            this.currentUser = res.data;
            if (this.currentUser.roles[0] === 'Admin') {
              this.isAdmin = true;
            }
            // console.log(this.curentUser);
          });
      } catch (error) {
        console.log(error);
        this.$router.push('/home');
      }
      if (!this.isAdmin) {
        this.$router.push('/home');
      }
    }
  },
  async created() {
    //this.autoLog();
    this.token = localStorage.getItem('token');
    this.logCheck();
    await this.getCurrentUser();
  }
};
</script>

<style scoped>
.nav-title {
  font-size: 20px;
  color: #f5c518;
  text-shadow: 2px 2px #8f0202;
}
.btn-block {
  box-shadow: 5px 5px 5px 5px #888888;
}
</style>
