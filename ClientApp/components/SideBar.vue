<template>
  <div class="sidenav container ">
    <div class="side-item ">
      <div class="input-group search-box ">
        <div class="form-outline ">
          <input
            type="search"
            id="form1"
            class="form-control"
            placeholder="عنوان فیلم یا سریال "
          />
        </div>
        <button type="button" class="btn btn-sm h-10 btn-primary">
          <i class="fa fa-search"></i>
        </button>
        <hr />
      </div>
      <div class="social-media">
        <h5>شبکه های اجتماعی ما</h5>
        <div class="row mr-auto">
          <a href="#" class="fa fa-facebook"></a>
          <a href="#" class="fa fa-twitter"></a>
          <a href="#" class="fa fa-telegram"></a>
          <a href="#" class="fa fa-instagram"></a>
        </div>
      </div>
      <hr />
      <div class="most-rate-movie">
        <h6 class="mb-1">آخرین سریال های بروز شده</h6>
        <div class="most-rate-box">
          <div class="most-rate" v-for="series in lastSeries" :key="series.id">
            <img
              :src="series.bannerImage"
              alt="Responsive image"
              class="series-banner"
            />
            <div class="content">
              <div class="row">
                <h5 class="mrate-detail mt-2 mr-4 text-warning col-md-6">
                  {{ series.title }}
                </h5>
                <p class="mb-2">
                  روز پخش :
                  {{ series.airDay }}
                </p>
              </div>
              <div class="row">
                <button class="btn btn-outline-success mr-4 mb-1">
                  مشاهده
                </button>
              </div>
            </div>
          </div>

          <button class="btn btn-block btn-outline-info my-2">
            مشاهده همه فیلم ها
          </button>
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
                فیلم های قشنگفیلم های قشنگفیلم های قشنگفیلم گ
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
                فیلم های قشنگفیلم های قشنگفیلم های قشنگفیلم گ
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
                فیلم های قشنگفیلم های قشنگفیلم های قشنگفیلم گ
              </p>
            </div>
          </div>
          <button class="btn btn-block btn-outline-info my-2">
            مشاهده همه فیلم ها
          </button>
        </div>
      </div>
      <hr />
      <div class="genre-list">
        <h5 class="mb-3">ژانر ها</h5>
        <div class="row">
          <div class="col-md-5 mr-3" v-for="genre in Genres" :key="genre.id">
            <div class="d-flex">
              <span class="mr-auto ">{{ genre.moviesCount }}</span>
              <nuxt-link
                class="genre-name-list"
                :to="{ name: 'MovieGenre-id', params: { id: genre.id } }"
              >
                <P>{{ genre.name }}</P>
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
      lastSeries: []
    };
  },
  methods: {
    async getLastSeries() {
      await axios.get('/api/series?PageSize=5').then(res => {
        this.lastSeries = res.data.items;
        console.log(this.lastSeries);
      });
    }
  },

  mounted() {
    this.$store.dispatch('GetGenres');
    this.getLastSeries();
  },
  computed: {
    Genres: function() {
      return this.$store.getters.GetGenres;
    }
  }
};
</script>

<style scoped>
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
</style>
