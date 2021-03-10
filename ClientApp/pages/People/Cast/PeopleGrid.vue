<template>
  <div>
    <div class="sort-row mr-1">
      <div class="row mr-5">
        <div class="col-md-3">
          <p>مرتب سازی بر اساس :</p>
        </div>
        <div class="col-md-9">
          <div class="sort-select">
            <div class="select d-flex justify-content-around">
              <p
                class="srt-option mt-2"
                @click="getMovieSrtTitle"
                :class="[isSrtName ? 'srt-option-active' : 'srt-option']"
              >
                <i class="fa fa-paragraph"></i>
                نام بازیگر
              </p>
              <p
                class="srt-option mt-2"
                @click="getMovieSrtReleaseDate"
                :class="[isSrtRealeseDate ? 'srt-option-active' : 'srt-option']"
              >
                <i class="fa fa-calendar"></i>
                تاریه تولد
              </p>
              <!-- <p class="srt-option mt-2">
                <i class="fa fa-clock-o"></i>
                زمان فیلم
              </p> -->
              <!-- <select name="slct" id="slct">
                <option value="1"><span>تاریخ فیلم</span> </option>
                <option value="2"
                  ><span @change="getMovieSrtTitle">زمان فیلم</span>
                </option>
                <option value="3"><span> نمره IMDB</span></option>
              </select> -->
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="people-list-grid">
      <div class="container">
        <main class="page-content">
          <div
            class="card"
            v-for="cast in Cast"
            :key="cast.id"
            :style="{ backgroundImage: `url('${cast.picture}')` }"
            style="background-size: 240px 350px;"
          >
            <div class="content">
              <h2 class="title">{{ cast.name }}</h2>
              <p class="copy">
                {{ cast.shortBio }}
              </p>
              <nuxt-link
                class="genre-name-list"
                :to="{ name: 'PeopleSingle-id', params: { id: cast.id } }"
              >
                <button class="btn">مشاهده</button>
              </nuxt-link>
            </div>
          </div>
        </main>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      isSrtName: false,
      isSrtRealeseDate: false
    };
  },
  methods: {
    async getMovieSrtReleaseDate() {
      await axios
        .get(`/api/movies?SortBy=releaseDate&Page=${this.id}&PageSize=6`)
        .then(res => {
          this.movieData = res.data.items;

          this.isSrtName = true;
          this.isSrtName = false;
          this.isSrtRealeseDate = true;
        });
    },
    async getMovieSrtTitle() {
      await axios.get(`/api/people?Filter=name`).then(res => {
        this.movieData = res.data.items;

        this.isSrtName = true;
        this.isSrtRealeseDate = false;
      });
    }
  },
  mounted() {
    this.$store.dispatch('GetPeoples');
    console.log(this.Cast);
  },
  computed: {
    Cast: function() {
      return this.$store.getters.GetPeaple;
    }
  }
};
</script>

<style scoped>
.card {
  background-image: 240px 350px;
}
</style>
