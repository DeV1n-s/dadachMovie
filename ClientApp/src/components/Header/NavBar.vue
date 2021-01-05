<template>
  <header class="ht-header">
    <div class="container">
      <nav class="navbar navbar-default navbar-custom">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="nav navbar-nav flex-child-menu">
          <div
            class="navbar-toggle"
            data-toggle="collapse"
            data-target="#bs-example-navbar-collapse-1"
          >
            <span class="sr-only">Toggle navigation</span>
            <div id="nav-icon1">
              <span></span>
              <span></span>
              <span></span>
            </div>
          </div>
          <a href="#"
            ><img
              class="logo "
              src="images/logo1.png"
              alt=""
              width="119"
              height="58"
          /></a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div
          class="collapse navbar-collapse flex-parent"
          id="bs-example-navbar-collapse-1"
        >
          <ul class="nav navbar-nav flex-child-menu menu-left">
            <li class="hidden">
              <a href="#page-top"></a>
            </li>
            <li class="dropdown first">
              <a
                href="http://localhost:8080/"
                class="nav navbar-nav flex-child-menu"
              >
                خانه
              </a>
            </li>
            <li class="dropdown first">
              <router-link
                class="nav navbar-nav flex-child-menu"
                to="/MovieList"
              >
                فیلم ها
              </router-link>
            </li>

            <li class="dropdown first">
              <router-link
                class="nav navbar-nav flex-child-menu"
                to="/ActorList"
              >
                بازیگران
              </router-link>
            </li>
            <li class="dropdown first">
              <router-link class="nav navbar-nav flex-child-menu" to="/News">
                اخبار
              </router-link>
            </li>
            <li class="dropdown first" v-if="isLogin">
              <router-link
                class="nav navbar-nav flex-child-menu"
                to="/UserProfile"
              >
                پروفایل کاربری
              </router-link>
            </li>
            <li class="dropdown first" v-if="isLogin">
              <router-link
                to="/Dashbord"
                class="nav navbar-nav flex-child-menu"
              >
                پنل ادمین
              </router-link>
            </li>
          </ul>
          <ul class="nav navbar-nav flex-child-menu menu-right">
            <li v-if="!isLogin" class="loginLink"><a href="">ورود</a></li>
            <li v-if="!isLogin" class="btn signupLink">
              <a href="#">ثبت نام</a>
            </li>
          </ul>
          <ul class="nav navbar-nav flex-child-menu menu-right">
            <li v-if="isLogin" class="btn " @click="logOut">
              <a type="submit" href="http://localhost:8080/">خروج</a>
            </li>
          </ul>
        </div>
        <!-- /.navbar-collapse -->
      </nav>

      <!-- top search form -->
      <div class="top-search">
        <input
          dir="ltr"
          type="text"
          :placeholder="
            isSearchValid
              ? 'جست و جو در بین فیلم ها '
              : 'لطفا نام فیلم را وارد کنید'
          "
          v-model="searchTitle"
        />

        <router-link
          :to="{ name: 'MovieListTitleSearch', params: { id: pSearchTitle } }"
        >
          <button class="btn btn-blue" @click="search">جست و جو</button>
        </router-link>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      isSearchValid: true,
      searchTitle: '',
      pSearchTitle: '$'
    };
  },
  methods: {
    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.Auth.isAuth = false;
      this.$router.replace('/');
      console.log(this.$store.getters.isAuthGet);
    },
    search() {
      if (this.searchTitle === '') {
        this.isSearchValid = false;
        this.$router.push('/');
        return;
      } else {
        this.pSearchTitle = this.searchTitle;
        console.log(this.$store.getters.GetSearchTitleMovie);
        this.$store.dispatch('MovieSearchTitle', this.searchTitle);
      }
    }
  },
  computed: {
    isLogin: function() {
      return this.$store.getters.isAuthGet;
    }
  }
};
</script>

<style>
.dropdown-menu {
  float: right !important;
  text-align: center !important;
}
.btn-blue {
  background-color: #abb7c4;
}
button.btn.btn-blue {
  margin-bottom: 0;
  height: 45px;
}
</style>
