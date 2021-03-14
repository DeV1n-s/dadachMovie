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
                @click="getMovieSrtReleaseDate"
                :class="[isSrtRealeseDate ? 'srt-option-active' : 'srt-option']"
              >
                <i class="fa fa-calendar"></i>
                تاریخ اکران
              </p>
              <p
                class="srt-option mt-2"
                @click="getMovieSrtTitle"
                :class="[isSrtName ? 'srt-option-active' : 'srt-option']"
              >
                <i class="fa fa-paragraph"></i>
                نام فیلم
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
    <div class="row itms itemcont">
      <div class="col-md-6 mb-3" v-for="series in seriesData" :key="series.id">
        <nuxt-link :to="{ name: 'SingleSeries-id', params: { id: series.id } }">
          <div
            class="movie-card bxs2"
            :style="{
              backgroundImage: `url('${series.picture}')`
            }"
          >
            <div class="movie-card__overlay"></div>
            <div class="movie-card__share">
              <button class="movie-card__icon">
                <i class="fa fa-heart"></i>
              </button>
              <button class="movie-card__icon">
                <i class="fa fa-star"></i>
              </button>
              <button class="movie-card__icon">
                <i class="fa fa-tv"></i>
              </button>
            </div>
            <div class="movie-card__content">
              <div class="movie-card__header">
                <h1 class="movie-card__title">{{ series.title }}</h1>
                <h4 class="movie-card__info mt-2 text-white">
                  تعداد فصل : {{ series.episodes }}
                </h4>
                <h4 class="movie-card__info mt-2 text-white">
                  روز پخش : {{ series.airDay }}
                </h4>
              </div>
              <p class="movie-card__desc text-white">
                {{ series.shortDescription }}
              </p>
            </div>
          </div>
        </nuxt-link>
      </div>
      <div class="pagination py-1">
        <div class="pagination:container">
          <div class="pagination:number arrow">
            <svg width="18" height="18">
              <use xlink:href="#left" />
            </svg>
            <span class="arrow:text">قبل</span>
          </div>
          <div class="pagination:number">
            <nuxt-link
              v-for="p in pagination"
              :key="p"
              active-class="active"
              :to="{ name: 'Movies-Page-id', params: { id: p } }"
              >{{ p }}</nuxt-link
            >
          </div>
          <!-- <div class="pagination:number">
            1
          </div>
          <div class="pagination:number">
            2
          </div>

          <div class="pagination:number pagination:active">
            3
          </div>

          <div class="pagination:number">
            4
          </div>

          <div class="pagination:number">
            540
          </div> -->

          <div class="pagination:number arrow">
            <span class="arrow:text">بعد</span>
            <svg width="18" height="18">
              <use xlink:href="#right" />
            </svg>
          </div>
        </div>

        <svg class="hide">
          <symbol
            id="left"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M15 19l-7-7 7-7"
            ></path>
          </symbol>
          <symbol
            id="right"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M9 5l7 7-7 7"
            ></path>
          </symbol>
        </svg>

        <!-- <div class="num-container">
          <a href="#">&laquo;</a>
          <nuxt-link
            v-for="p in pagination"
            :key="p"
            active-class="active"
            :to="{ name: 'Movies-Page-id', params: { id: p } }"
            >{{ p }}</nuxt-link
          >
          <a href="#">&raquo;</a>
        </div> -->
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      id: this.$route.params.id,
      seriesData: '',
      pageNum: '',
      pagination: [],
      isSrtName: false,
      isSrtRealeseDate: false
    };
  },
  methods: {
    async getMovieSrtReleaseDate() {
      await axios
        .get(`/api/series?SortBy=releaseDate&Page=${this.id}&PageSize=6`)
        .then(res => {
          this.seriesData = res.data.items;
          this.pageNum = Math.ceil(res.data.totalItems / 6);
          this.pageMaker(this.pageNum);
          this.isSrtName = true;
          this.isSrtName = false;
          this.isSrtRealeseDate = true;
        });
    },
    async getMovieSrtTitle() {
      await axios
        .get(`/api/series?SortBy=title&Page=${this.id}&PageSize=6`)
        .then(res => {
          this.seriesData = res.data.items;
          this.pageNum = Math.ceil(res.data.totalItems / 6);
          this.pageMaker(this.pageNum);
          this.isSrtName = true;
          this.isSrtRealeseDate = false;
        });
    },

    async getMovie() {
      await axios.get(`/api/series?Page=${this.id}&PageSize=6`).then(res => {
        this.seriesData = res.data.items;
        this.pageNum = Math.ceil(res.data.totalItems / 6);
        this.pageMaker(this.pageNum);
      });
    },
    pageMaker(p) {
      for (let i = 1; i <= p; i++) {
        this.pagination.push(i);
      }
    }
  },
  mounted() {
    this.getMovie();
  }
};
</script>

<style scoped>
:root {
  --bg-page: #1a1a1a;
  --text-color: #f3f3f3;
  --card-bg: #de6161;
  --icon-bg: #45423c;
  --blue: #0870f8;
  --blue-rgb: 8, 112, 248;
  --orange: #ff9232;
  --g-purple: linear-gradient(30deg, #85f, #9966ff);
  --g-yellow: linear-gradient(30deg, #fc0, #fc0);
  --g-red: linear-gradient(30deg, #f36, #f24);
  --g-blue: linear-gradient(30deg, #0cf, #0af);
  --g-purple: linear-gradient(30deg, #85f, #9966ff);
  --range: 0%;
  --shadow: rgba(0, 6, 39, 0.1);
  --light-shadow: rgba(255, 255, 255, 0.8);
  --light-shadow-2: rgba(255, 255, 255, 0.1);
}

.pagination {
  padding: 0 10px;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  background: var(--bg-page);
  color: var(--text-color);
  box-sizing: border-box;
  font-size: 16px;
  font-weight: 400;
  user-select: none;
  transition: all 200ms ease;
}

.hide {
  display: none;
  visibility: hidden;
  height: 0;
}

.pagination\:container {
  display: flex;
  align-items: center;
}

.arrow\:text {
  display: block;
  vertical-align: middle;
  font-size: 13px;
  vertical-align: middle;
}

.pagination\:number {
  --size: 32px;
  --margin: 6px;
  margin: 0 var(--margin);
  border-radius: 6px;
  background: #de6161;
  max-width: auto;
  min-width: var(--size);
  height: var(--size);
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  padding: 0 6px;
}
@media (hover: hover) {
  .pagination\:number:hover {
    background: #ffbc00;
  }
}
.pagination\:number:active {
  background: #ffbc00;
}

.pagination\:active {
  background: #ffbc00;
  position: relative;
}
.active:hover {
  color: #0d0d0c !important;
}
.row.itms.itemcont {
  margin-left: 0.4rem;
}
.pagination {
  width: 98.2%;
  margin-left: 0.1rem !important;
}
.card_right.mr-1 {
  width: 350px;
}
.wrapper:hover {
  scale: 1.5;
}
.itemcont {
  padding-right: 15px;
  padding-left: 15px;
  margin-right: auto;
  margin-left: auto;
}
.itms {
  font-size: 14px;
  color: #cfd6e1;
  line-height: 1.5;
  font-weight: 400;
  overflow-x: hidden;
}

.movie-card {
  background-size: contain;
  background-repeat: no-repeat;
  width: 100%;
  max-width: 800px;
  height: 100%;
  max-height: 300px;
  display: block;
  margin: 2vh auto;
  border-radius: 8px;
  position: relative;
  @media screen and (max-width: 800px) {
    width: 95%;
    max-width: 95%;
  }
}
@media screen and (max-width: 600px) {
  .movie-card {
    background-position: 50% 0%;
    background-size: cover;
    height: 400px;
  }
}
.movie-card:hover {
  transform: scale(1.02);
  transition: all 0.4s;
}

.movie-card__overlay {
  width: 100%;
  height: 100%;
  border-radius: 8px;
  background: linear-gradient(
    to right,
    rgba(42, 159, 255, 0.2) 0%,
    #212120 60%,
    #212120 100%
  );
  background-blend-mode: multiply;
  position: absolute;
  top: 0;
  bottom: 0;
  right: 0;
  left: 0;
}
@media screen and (max-width: 600px) {
  .movie-card__overlay {
    background: linear-gradient(
      to bottom,
      rgba(42, 159, 255, 0.2) 0%,
      #212120 60%,
      #212120 100%
    );
  }
}
.movie-card__share {
  padding: 1em;
  display: inline-block;
  width: 100%;
  max-width: 130px;
}
@media screen and (max-width: 600px) {
  .movie-card__share {
    display: block;
    width: 100%;
  }
}
.movie-card__icon {
  color: #ffffff;
  mix-blend-mode: lighten;
  opacity: 0.4;
  background: none;
  padding: 0;
}
.movie-card__icon:hover {
  opacity: 1;
  mix-blend-mode: lighten;
}
.movie-card__icon:not(:first-of-type) {
  margin-left: 5px;
}
.movie-card__icon i {
  font-size: 1.2em;
}
.movie-card__content {
  width: 100%;
  max-width: 370px;
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  position: relative;
  float: right;
  padding-right: 1em;
  padding-bottom: 1em;
}
@media screen and (max-width: 1000px) {
  .movie-card__content {
    width: 50%;
  }
}
@media screen and (max-width: 600px) {
  .movie-card__content {
    margin-top: 4.2em;
    width: 100%;
    float: inherit;
    max-width: 100%;
    padding: 0 1em 1em;
  }
}
.movie-card__header {
  margin-bottom: 2em;
  margin-top: 5vh;
}
.movie-card__title {
  color: #ffffff;
  margin-bottom: 0.75em;
  opacity: 0.85;
}
.movie-card__info {
  letter-spacing: 2px;
  font-size: 1em;
  color: #2a9fff;
  line-height: 1;
  margin: 0;
  font-weight: 700;
  opacity: 0.5;
}
.movie-card__desc {
  font-weight: 300;
  opacity: 0.84;
  margin-bottom: 2em;
}

h1,
h2,
h3 {
  letter-spacing: 2px;
  line-height: 1;
}

h1 {
  font-size: 30px !important;
}
.btn {
  padding: 0.5rem 2rem;
  background-color: rgba(255, 255, 255, 0.4);
  color: white;
}

.btn-outline {
  background-color: transparent;
  border: 0px solid #ffffff;
}

.btn::before {
  content: '\f05a';
  vertical-align: left;
  font-size: 1em;
  padding-right: 0.6em;
}

.btn-outline:hover {
  border-color: #2a9fff;
  color: #2a9fff;
  box-shadow: 0px 1px 8px 0px rgba(245, 199, 0, 0.2);
}
.blur_back {
  position: absolute;
  top: 0;
  z-index: 1;
  height: 100%;
  right: 0;
  background-size: cover;
  border-radius: 11px;
}
.row.itms.itemcont {
  padding-bottom: 1rem;
}

#ave {
  box-shadow: 10px 10px 150px -45px rgba(199, 147, 75, 0.7);
  margin-bottom: 250px;
}
#ave:hover {
  box-shadow: 0px 0px 120px -55px rgba(199, 147, 75, 0.7);
}
.bxs1 {
  box-shadow: -15px -10px 150px -35px rgba(255, 0, 0.7);
}
.bxs2 {
  box-shadow: 0px 0px 150px -45px rgba(255, 51, 0, 0.5);
}
.bxs3 {
  box-shadow: 0px 0px 150px -45px rgba(255, 51, 0, 0.5);
}
.bxs4 {
  box-shadow: 15px 10px 150px -35px rgba(255, 0, 0.7);
}
</style>
