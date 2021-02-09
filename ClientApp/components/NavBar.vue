<template>
  <div>
    <nav
      id="nav-bar"
      class="navbar navbar-icon-top navbar-expand-lg navbar-dark bg-dark sticky-top"
    >
      <div class="container">
        <a class="navbar-brand" href="#">داداچ مویی</a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav">
            <li class="nav-item ">
              <nuxt-link class="nav-link" to="/home" active-class="active">
                <i class="fa fa-home"></i> خانه
              </nuxt-link>
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="navbarDropdown"
                role="button"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                <i class="fa fa-film"> </i> فیلم ها
              </a>
              <div class="dropdown-menu " aria-labelledby="navbarDropdown">
                <nuxt-link class="dropdown-item" to="/movies">
                  سینمایی</nuxt-link
                >
                <div class="dropdown-divider"></div>

                <a class="dropdown-item" href="/series"> سریال</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="#">تریلر ها </a>
              </div>
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="navbarDropdown"
                role="button"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                <i class="fa fa-eercast"> </i> هنرمندان
              </a>
              <div class="dropdown-menu " aria-labelledby="navbarDropdown">
                <nuxt-link class="dropdown-item" to="/people/cast">
                  بازیگران</nuxt-link
                >
                <div class="dropdown-divider"></div>

                <a class="dropdown-item" href="#"> کارگردانان</a>
              </div>
            </li>

            <li class="nav-item">
              <a class="nav-link" href="#">
                <i class="fa fa-newspaper-o"></i> اخبار
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">
                <i class="fa fa-info"></i> درباره ما
              </a>
            </li>
            <li class="nav-item" v-if="isLogin">
              <nuxt-link class="nav-link" to="/userprofile">
                <i class="fa fa-user"></i> پروفایل کاربری
              </nuxt-link>
            </li>
            <li class="nav-item" v-if="isAdmin">
              <nuxt-link class="nav-link" to="/admin" active-class="active">
                <i class="fa fa-user-plus"></i>پنل ادمین
              </nuxt-link>
            </li>
          </ul>
          <!-- LogItem -->
          <ul class="navbar-nav mr-auto ml-5" v-if="isLogin">
            <li class="nav-item">
              <a class="nav-link" href="#">
                <i class="fa fa-bell">
                  <span class="badge badge-info">11</span>
                </i>
                اعلانات
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">
                <i class="fa fa-envelope">
                  <span class="badge badge-success">11</span>
                </i>
                پیام ها
              </a>
            </li>

            <li class="nav-item dropdown mt-2">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <img
                  :src="currentUser.picture"
                  class="profile-image img-circle"/><b class="caret"></b
              ></a>
              <div class="dropdown-menu " aria-labelledby="navbarDropdown">
                <nuxt-link class="dropdown-item" to="/userprofile">
                  ویرایش پروفایل
                  <i class="fa fa-cog"></i>
                </nuxt-link>
                <div class="dropdown-divider"></div>

                <a class="dropdown-item" href="/home" @click="logOut">
                  خروج <i class="fa fa-sign-out"></i
                ></a>
              </div>
            </li>
          </ul>
          <!-- notLog -->
          <ul class="navbar-nav mr-auto ml-5" v-if="!isLogin">
            <li class="nav-item">
              <a class="nav-link" href="/login">
                <i class="fa fa-sign-in" aria-hidden="true"></i>

                ورود
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/register">
                <i class="fa fa-registered" aria-hidden="true"></i>

                ثبت نام
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import axios from 'axios';
export default {
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
      if (this.token != null) {
        this.isLogin = true;
      }
    },
    logOut() {
      this.$store.dispatch('logOut');
    },
    async getCurrentUser() {
      if (this.tokenId) {
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
              // console.log(this.currentUser.roles[0]);
              if (this.currentUser.roles[0] === 'Admin') {
                this.isAdmin = true;
              }
            });
        } catch (error) {
          console.log(error);
          this.$store.dispatch('logOut');
        }
      }
    }
  },
  async created() {
    this.autoLog();
    this.token = localStorage.getItem('token');
    this.logCheck();
    //this.adminChecker();

    await this.getCurrentUser();
  }
};
</script>

<style></style>
