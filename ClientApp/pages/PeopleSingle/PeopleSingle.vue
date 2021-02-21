<template>
  <div dir="rtl">
    <nav-bar />
    <div class="container">
      <div class="header-container">
        <img
          src="https://s17.postimg.cc/ypm5ye95r/image.jpg"
          alt=""
          class="header-image"
        />
        <div class="header">
          <h1 class="main-heading">{{ peopleData.name }}</h1>
          <span
            class="tag"
            v-for="category in peopleCategory"
            :key="category"
            >{{ category }}</span
          >

          <div class="stats">
            <span class="stat-module">
              فیلم های سینمایی :
              <span class="stat-number">{{ movieCount }}</span>
            </span>
            <span class="stat-module">
              سریال ها : <span class="stat-number">29</span>
            </span>
          </div>
          <div class="stats">
            <span class="stat-module">
              تاریخ تولد :
              <span class="stat-number"> {{ peopleData.dateOfBirth }}</span>
            </span>
            <span class="stat-module">
              ملیت :
              <span class="stat-number"> {{ peopleData.nationality }}</span>
            </span>
          </div>
        </div>
        <!-- END header -->
      </div>

      <div class="body">
        <div class="row">
          <div class="body-info col-md-9 mt-2">
            <p class="short-bio">
              {{ peopleData.shortBio }}
            </p>
            <p class="biography">
              {{ peopleData.biography }}
            </p>
          </div>
          <img
            :src="peopleData.picture"
            alt="Hugh Jackman"
            class="body-image col-md-3"
          />
        </div>
        <div class="body-more">
          <span></span>
          <span></span>
          <span></span>
        </div>
        <div class="card u-clearfix">
          <span class="card-heading">فیلم ها</span>
          <span class="card-more">
            <svg
              fill="#777777"
              height="18"
              viewBox="0 0 24 24"
              width="18"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path d="M0 0h24v24H0z" fill="none" />
              <path
                d="M6 10c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2zm12 0c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2zm-6 0c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2z"
              />
            </svg>
          </span>
          <ul class="card-list">
            <li v-for="movie in moviePoeple" class="mr-1" :key="movie.id">
              <nuxt-link
                class="genre-name-list"
                :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
              >
                <img height="150px" width="130px" :src="movie.picture" alt="" />
              </nuxt-link>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <footer-app />
  </div>
</template>

<script>
import axios from 'axios';
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
export default {
  data() {
    return {
      id: this.$route.params.id,
      peopleData: '',
      peopleCategory: [],
      movieCount: '',
      moviePoeple: []
    };
  },
  methods: {
    getSinglePeople() {
      axios.get('/api/people/' + this.id).then(res => {
        this.peopleData = res.data;
        this.peopleCategory = res.data.categories;
      });
    },
    getPeopleMovie() {
      axios.get('/api/people/' + this.id + '/castMovies').then(res => {
        this.movieCount = res.data.totalItems;
        this.moviePoeple = res.data.items;
        console.log(this.moviePoeple);
      });
    }
  },
  mounted() {
    this.getSinglePeople();
    this.getPeopleMovie();
  },
  components: { FooterApp, NavBar }
};
</script>

<style scoped>
.short-bio {
  font-size: 18px;
}
.biography {
  font-size: 14px;
}
*,
*:before,
*:after {
  box-sizing: inherit;
}

.u-float-right {
  float: right;
}

.u-flex-center {
  display: -webkit-flex;
  display: flex;
  -webkit-justify-content: center;
  justify-content: center;
  -webkit-align-items: center;
  align-items: center;
}

.u-clearfix:before,
.u-clearfix:after {
  content: ' ';
  display: table;
}

.u-clearfix:after {
  clear: both;
}

.u-clearfix {
  *zoom: 1;
}

.container {
  box-shadow: 0 0 50px rgba(0, 0, 0, 0.3);
  margin: 10px auto;
  overflow: hidden;
}

.header-container {
  position: relative;
}

.header-image {
  width: 100%;
  position: absolute;
  top: 0;
  z-index: -1;
  height: auto;
  /* -webkit-animation: zoomEffect 35s infinite;
  animation: zoomEffect 35s infinite;
  -webkit-animation-timing-function: linear;
  animation-timing-function: linear;
  -webkit-animation-direction: alternate;
  animation-direction: alternate;
  -webkit-backface-visibility: hidden; */
  backface-visibility: hidden;
}

@-webkit-keyframes zoomEffect {
  0% {
    -webkit-transform: scale(1) translateX(0);
    transform: scale(1) translateX(0);
  }
  100% {
    -webkit-transform: scale(1.2) translateX(-360px) translateY(-80px);
    transform: scale(1.2) translateX(-360px) translateY(-80px);
  }
}

@keyframes zoomEffect {
  0% {
    -webkit-transform: scale(1) translateX(0) translateY(0);
    transform: scale(1) translateX(0) translateY(0);
  }
  100% {
    -webkit-transform: scale(1.2) translateX(-360px) translateY(-80px);
    transform: scale(1.2) translateX(-360px) translateY(-80px);
  }
}

.header {
  color: #fff;
  padding: 15px;
  height: 300px;
}

.header > svg {
  cursor: pointer;
}

.main-heading {
  color: #fff;
  font-size: 40px;
  font-weight: 300;
  margin-bottom: 12px;
  margin-right: 0.5rem;
}

.tag {
  background-color: rgba(255, 255, 255, 0.35);
  border-radius: 20px;
  font-size: 11px;
  margin-right: 8px;
  padding: 4px 10px;
  text-transform: uppercase;
}

.stats {
  margin-top: 35px;
}

.stat-module {
  display: inline-block;
  font-size: 12px;
  margin-right: 20px;
  text-transform: uppercase;
}

.stat-number {
  display: inline-block;
  font-weight: 600;
  margin-left: 4px;
}

.overlay-header {
  background-color: #eee;
  height: 100px;
  margin: -50px 0 0 -25%;
  transform: rotate(-10deg);
  width: 150%;
  z-index: 0;
}

.body {
  background-color: #eee;
  color: #555;
  margin-top: -50px;
  padding: 0 15px 15px;
  position: relative;
}

.body-image {
  border-radius: 100%;
  box-shadow: 5px 10px 75px rgba(0, 0, 0, 0.4);
  float: left;
  margin: -90px 0 20px;
  position: relative;
  z-index: 2;
}

.body-action-button {
  background-color: #383838;
  border-radius: 50%;
  box-shadow: 1px 2px 12px rgba(0, 0, 0, 0.4);
  cursor: pointer;
  height: 40px;
  position: absolute;
  right: 15px;
  top: -97px;
  width: 40px;
}

.body-stats {
  display: inline-block;
  font-size: 12px;
  font-weight: 700;
  float: left;
  margin: -14px 0 0 30px;
  position: relative;
  text-transform: uppercase;
  width: 20%;
}

.body-stats > span {
  display: inline-block;
  font-weight: 900;
  margin-top: 8px;
}

.body-info {
  clear: left;
  position: relative;
  max-height: 100px;
  overflow: hidden;
  transition: all 600ms ease-out;
}

.body-more {
  background: -moz-linear-gradient(
    top,
    rgba(0, 0, 0, 0) 0%,
    rgba(238, 238, 238, 1) 100%
  );
  background: -webkit-linear-gradient(
    top,
    rgba(0, 0, 0, 0) 0%,
    rgba(238, 238, 238, 1) 100%
  );
  background: linear-gradient(
    to bottom,
    rgba(0, 0, 0, 0) 0%,
    rgba(238, 238, 238, 1) 100%
  );
  filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#00000000', endColorstr='#eeeeee',GradientType=0 );
  cursor: pointer;
  margin: -57px auto 0px;
  padding: 20px 0 20px;
  position: relative;
  text-align: center;
}

.body-more span {
  background-color: #fff;
  border-radius: 50%;
  box-shadow: 1px 1px 5px rgba(0, 0, 0, 0.3);
  display: inline-block;
  height: 6px;
  margin-right: 2px;
  width: 6px;
}

.card {
  background: #fff;
  border-radius: 2px;
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.15);
  margin-top: 15px;
  padding: 10px;
}

.card-heading {
  font-size: 12px;
  text-transform: uppercase;
}

.card-more {
  cursor: pointer;
  float: right;
}

.card-list {
  list-style-type: none;
  margin: 10px 0 0;
  overflow-x: scroll;
  padding: 0;
  white-space: nowrap;
}

.card-list::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 2px rgba(0, 0, 0, 0.3);
  border-radius: 2px;
  background-color: #f5f5f5;
}

.card-list::-webkit-scrollbar {
  height: 3px;
  background-color: #f5f5f5;
}

.card-list::-webkit-scrollbar-thumb {
  border-radius: 10px;
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.2);
  background-color: #ddd;
}

.card-list li {
  display: inline;
  margin-left: 10px;
}

.card-list li:first-child {
  margin-left: 0;
}
</style>
