<template>
  <header class="ht-header">
    <div class="container">
      <nav class="navbar navbar-default navbar-custom">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header logo">
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
              class="logo"
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
              <a href="http://localhost:8080/" class="btn btn-default">
                خانه
              </a>
            </li>
            <li class="dropdown first">
              <router-link
                class="btn btn-default dropdown-toggle lv1"
                to="/MovieList"
              >
                فیلم ها
              </router-link>
            </li>

            <li class="dropdown first">
              <router-link
                class="btn btn-default dropdown-toggle lv1"
                to="/ActorList"
              >
                بازیگران
              </router-link>
            </li>
            <li class="dropdown first">
              <router-link
                class="btn btn-default dropdown-toggle lv1"
                to="/News"
              >
                اخبار
              </router-link>
            </li>
            <li class="dropdown first">
              <router-link
                class="btn btn-default dropdown-toggle lv1"
                to="/UserProfile"
              >
                پروفایل کاربری
              </router-link>
            </li>
            <li class="dropdown first" v-if="isLogin">
              <a
                class="btn btn-default dropdown-toggle lv1"
                data-toggle="dropdown"
                data-hover="dropdown"
              >
                پنل ادمین
              </a>
              <ul class="dropdown-menu level1">
                <li>
                  <router-link to="/Moviepanel">مدیریت فیلم ها</router-link>
                </li>
                <li><router-link to="/NewsPanel">مدیریت اخبار</router-link></li>
                <li class="it-last">
                  <router-link to="/CastPanel">مدیریت بازیگران</router-link>
                </li>
              </ul>
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
