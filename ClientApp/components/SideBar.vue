<template>
  <div class="sidenav container ">
    <div class="side-item ">
      <div class="social-media mt-1">
        <h5>شبکه های اجتماعی ما</h5>
        <div class="row mr-auto">
          <div class="social-container">
            <ul class="social-icons">
              <li>
                <a class="social-i" href="#"><i class="fa fa-instagram"></i></a>
              </li>
              <li>
                <a class="social-i" href="#"><i class="fa fa-twitter"></i></a>
              </li>
              <li>
                <a class="social-i" href="#"><i class="fa fa-linkedin"></i></a>
              </li>
              <li>
                <a class="social-i" href="#"><i class="fa fa-codepen"></i></a>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <hr />
      <div class="most-rate-movie">
        <h6 class="mb-1">آخرین سریال های بروز شده</h6>

        <div class="most-rate-box row">
          <div
            class="most-rate col-md-3 pl-0"
            v-for="series in lastSeries"
            :key="series.id"
          >
            <nuxt-link
              class="genre-name-list p-0 update-sr"
              :to="{ name: 'SingleSeries-id', params: { id: series.id } }"
            >
              <img
                :src="series.picture"
                alt="Responsive image"
                class="series-banner"
              />
            </nuxt-link>
          </div>
          <nuxt-link to="/series/page/1" class="mx-auto w-100">
            <button class="btn btn-block btn-outline-info my-2">
              مشاهده همه سریال ها
            </button>
          </nuxt-link>
        </div>
      </div>
      <hr />
      <div class="most-rate-movie">
        <h6 class="mb-1">محبوب ترین ها از دیدگاه کاربران</h6>
        <div class="most-rate-box">
          <div class="most-rate">
            <img
              src="https://www.uptvs.com/wp-contents/uploads/2021/01/halka-jadval.jpg"
              alt="Responsive image"
            />
            <div class="content">
              <p class="mrate-detail">
                فیلم حلقه
              </p>
            </div>
          </div>
          <div class="most-rate">
            <img
              src="https://www.uptvs.com/wp-contents/uploads/2021/01/halka-jadval.jpg"
              alt="Responsive image"
            />
            <div class="content">
              <p class="mrate-detail">
                فیلم حلقه
              </p>
            </div>
          </div>
          <div class="most-rate">
            <img
              src="https://www.uptvs.com/wp-contents/uploads/2021/01/halka-jadval.jpg"
              alt="Responsive image"
            />
            <div class="content">
              <p class="mrate-detail">
                فیلم حلقه
              </p>
            </div>
          </div>
          <nuxt-link to="/movies">
            <button class="btn btn-block btn-outline-info my-2">
              مشاهده همه فیلم ها
            </button>
          </nuxt-link>
        </div>
      </div>
      <hr />
      <div class="cast-show">
        <h5 class="mb-3">بازیگران پیشنهادی</h5>
        <div class="row" v-for="c in castTop" :key="c.id">
          <div class="col-md-4">
            <nuxt-link
              :to="{ name: 'PeopleSingle-id', params: { id: c.id } }"
              class=""
            >
              <img
                :src="c.picture"
                class="rounded-circle"
                alt=""
                width="85px"
                height="70px"
              />
            </nuxt-link>
          </div>
          <div class="col-md-7 text-white mt-1">
            <h6 class="mt-2">{{ c.name }}</h6>
            <p>{{ c.nationality }}</p>
          </div>
        </div>
      </div>
      <hr />

      <div class="genre-list">
        <h5 class="mb-3">ژانر ها</h5>
        <div class="row">
          <div class="col-md-4 " v-for="genre in Genres" :key="genre.id">
            <div class="d-flex">
              <span class="">{{ genre.moviesCount }}</span>
              <nuxt-link
                class="genre-name-list"
                :to="{ name: 'MovieGenre-id', params: { id: genre.id } }"
              >
                <P class="ml-auto">{{ genre.name }}</P>
              </nuxt-link>
            </div>
          </div>
        </div>
      </div>
      <hr />
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      lastSeries: [],
      castTop: []
    };
  },
  methods: {
    async getLastSeries() {
      await axios.get('/api/series?PageSize=5').then(res => {
        this.lastSeries = res.data.items;
      });
    },
    async getTopCast() {
      await axios.get('/api/people?PageSize=5').then(res => {
        this.castTop = res.data.items;
      });
    }
  },

  mounted() {
    this.$store.dispatch('GetGenres');
    this.getLastSeries();
    this.getTopCast();
  },
  computed: {
    Genres: function() {
      return this.$store.getters.GetGenres;
    }
  }
};
</script>

<style scoped>
.social-i {
  padding: 0;
}

.social-container {
  width: 400px;

  text-align: center;
}

.social-icons {
  padding: 0;
  list-style: none;
  margin: 1em;
}
.social-icons li {
  display: inline-block;
  margin: 0.15em;
  position: relative;
  font-size: 1.2em;
}
.social-icons i {
  color: #fff;
  position: absolute;
  top: 11px;
  left: 11px;
  transition: all 265ms ease-out;
}
.social-icons a {
  display: inline-block;
}
.social-icons a:before {
  transform: scale(1);
  -ms-transform: scale(1);
  -webkit-transform: scale(1);
  content: ' ';
  width: 45px;
  height: 45px;
  border-radius: 100%;
  display: block;
  background: linear-gradient(45deg, #00b5f5, #002a8f);
  transition: all 265ms ease-out;
}
.social-icons a:hover:before {
  transform: scale(0);
  transition: all 265ms ease-in;
}
.social-icons a:hover i {
  transform: scale(2.2);
  -ms-transform: scale(2.2);
  -webkit-transform: scale(2.2);
  color: #00b5f5;
  background: -webkit-linear-gradient(45deg, #00b5f5, #002a8f);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  transition: all 265ms ease-in;
}

.series-banner {
  height: 120px !important;
}
.side-item {
  margin-right: 0rem !important;
}
.genre-name-list p {
  margin-bottom: 5px !important;
  font-size: 13px !important;
}
.genre-name-list p:hover {
  color: #17a2b8 !important;
}

button.btn.btn-outline-success.mr-4.mb-1 {
  height: 35px !important;
  margin-bottom: 20px !important;
}
.series-view-link {
  font-size: 12px;
  color: rgb(255, 255, 255);
}

.series-view-link:hover {
  color: #17a2b8;
  font-size: 15px;
}

.update-sr {
  -webkit-filter: grayscale(100%);
  filter: grayscale(100%);
  transition: all 1s;
}
.update-sr:hover {
  -webkit-filter: grayscale(0%);
  filter: grayscale(0%);
  transform: scale(1.2, 1.1);
  border-radius: 10px 0 10px 0;
}
.genre-list span {
  margin-left: 10%;
}

.mrate-detail {
  position: absolute;
  bottom: 0;
  background: rgb(0, 0, 0);
  background: rgba(0, 0, 0, 0.5); /* Black see-through */
  color: #f1f1f1;
  width: 100%;
  transition: 0.5s ease;
  opacity: 0;
  color: white;
  text-align: center;
  font-size: 1.5rem;
}
.container:hover .mrate-detail:hover {
  opacity: 1;
}

.most-rate .content:hover {
  position: absolute;
  bottom: 0;
  background: rgb(0, 0, 0);
  background: rgba(0, 0, 0, 0);
}
.cast-show .row {
  margin-top: 0.2rem;
  margin-right: 3%;
  transition: all 265ms ease-out;
}
.cast-show .row:hover {
  /* -ms-transform: rotate(10deg);  */
  /* transform: rotate(10deg); */
  margin-right: 8%;
  transform: scale(1.1);
}
.col-md-7.text-white.mt-1 {
  font-size: 11px;
  margin-right: auto;
  direction: ltr !important;
  float: left;
}
</style>
