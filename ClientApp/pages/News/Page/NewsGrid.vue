<template>
  <div>
    <div class="sort-row mr-1">
      <div class="row mr-5">
        <div class="col-md-3">
          <p class="mt-2 pb-0">
            <i class="fa fa-sort"></i>
            مرتب سازی بر اساس :
          </p>
        </div>
        <div class="col-md-9">
          <div class="sort-select">
            <div class="select d-flex justify-content-around">
              <p class="srt-option mt-2">
                <i class="fa fa-calendar"></i>
                تاریخ انتشار
              </p>
              <p class="srt-option mt-2">
                <i class="fa fa-paragraph"></i>
                عنوان خبر
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
      <div class="content-wrapper">
        <div class="news-card">
          <a href="#" class="news-card__card-link"></a>
          <img
            src="http://localhost:5000/SeedData/news.jpg"
            alt=""
            class="news-card__image"
          />
          <div class="news-card__text-wrapper">
            <h2 class="news-card__title">
              خبر جدید
            </h2>
            <div class="news-card__post-date badge badge-dark p-1">
              <i class="fa fa-calendar"></i>
              23/مهر/1398
            </div>
            <div class="news-card__details-wrapper">
              <p class="news-card__excerpt">
                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
                استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله
                در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد
                نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.
                کتابهای زیادی در شصت و سه درصد گذشته،&hellip;
              </p>
              <a href="#" class="news-card__read-more text-center"
                >مشاهده<i class="fas fa-long-arrow-alt-right"></i
              ></a>
            </div>
          </div>
        </div>
        <div class="news-card">
          <a href="#" class="news-card__card-link"></a>
          <img
            src="http://localhost:5000/SeedData/news.jpg"
            alt=""
            class="news-card__image"
          />
          <div class="news-card__text-wrapper">
            <h2 class="news-card__title">خبر جدید</h2>
            <div class="news-card__post-date badge badge-dark p-1">
              <i class="fa fa-calendar"></i>
              23/مهر/1398
            </div>
            <div class="news-card__details-wrapper">
              <p class="news-card__excerpt">
                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
                استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله
                در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد
                نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.
                کتابهای زیادی در شصت و سه درصد گذشته،&hellip;
              </p>
              <a href="#" class="news-card__read-more text-center"
                >مشاهده<i class="fas fa-long-arrow-alt-right"></i
              ></a>
            </div>
          </div>
        </div>
        <div class="news-card">
          <a href="#" class="news-card__card-link"></a>
          <img
            src="http://localhost:5000/SeedData/news.jpg"
            alt=""
            class="news-card__image"
          />
          <div class="news-card__text-wrapper">
            <h2 class="news-card__title ">خبر جدید</h2>
            <div class="news-card__post-date badge badge-dark p-1">
              <i class="fa fa-calendar"></i>
              23/مهر/1398
            </div>
            <div class="news-card__details-wrapper">
              <p class="news-card__excerpt">
                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
                استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله
                در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد
                نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.
                کتابهای زیادی در شصت و سه درصد گذشته،&hellip;
              </p>
              <a href="#" class="news-card__read-more text-center"
                >مشاهده<i class="fas fa-long-arrow-alt-right"></i
              ></a>
            </div>
          </div>
        </div>
        <div class="news-card">
          <a href="#" class="news-card__card-link"></a>
          <img
            src="http://localhost:5000/SeedData/news.jpg"
            alt=""
            class="news-card__image"
          />
          <div class="news-card__text-wrapper">
            <h2 class="news-card__title ">خبر جدید</h2>
            <div class="news-card__post-date badge badge-dark p-1">
              <i class="fa fa-calendar"></i>
              23/مهر/1398
            </div>
            <div class="news-card__details-wrapper">
              <p class="news-card__excerpt">
                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
                استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله
                در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد
                نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.
                کتابهای زیادی در شصت و سه درصد گذشته،&hellip;
              </p>
              <a href="#" class="news-card__read-more text-center"
                >مشاهده<i class="fas fa-long-arrow-alt-right"></i
              ></a>
            </div>
          </div>
        </div>
        <div class="news-card">
          <a href="#" class="news-card__card-link"></a>
          <img
            src="http://localhost:5000/SeedData/news.jpg"
            alt=""
            class="news-card__image"
          />
          <div class="news-card__text-wrapper">
            <h2 class="news-card__title">خبر جدید</h2>
            <div class="news-card__post-date badge badge-dark p-1">
              <i class="fa fa-calendar"></i>
              23/مهر/1398
            </div>
            <div class="news-card__details-wrapper">
              <p class="news-card__excerpt">
                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
                استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله
                در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد
                نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد.
                کتابهای زیادی در شصت و سه درصد گذشته،&hellip;
              </p>
              <a href="#" class="news-card__read-more text-center"
                >مشاهده<i class="fas fa-long-arrow-alt-right"></i
              ></a>
            </div>
          </div>
        </div>
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
      pagination: []
    };
  },
  methods: {
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
svg {
  color: white;
}
span.arrow\:text {
  color: white;
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

/*  */

.content-wrapper {
  margin: 0 auto;
  max-width: 1200px;
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
  padding: 0.5rem;
}

.news-card {
  border: 0px solid aqua;
  margin: 0.5rem;
  position: relative;
  height: 12rem;
  overflow: hidden;
  border-radius: 0.5rem;
  flex: 1;
  min-width: 290px;
  box-shadow: 0 0 1rem rgba(0, 0, 0, 0.5);
  -webkit-backface-visibility: hidden;
  -moz-backface-visibility: hidden;
  -webkit-transform: translate3d(0, 0, 0);
  -moz-transform: translate3d(0, 0, 0);
}

@media (min-width: 900px) {
  .news-card {
    height: 20rem;
  }
}

.news-card::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0)
    linear-gradient(to bottom, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0.7) 80%);
  z-index: 0;
}

.news-card__card-link {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 1;
  /*     background: rgba(255,0,0,.5); */
}

.news-card__image {
  width: 100%;
  height: 100%;
  display: block;
  object-fit: cover;
  transition: transform 3s ease;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  position: relative;
  z-index: -1;
}

.news-card__text-wrapper {
  position: absolute;
  bottom: 0rem;
  padding: 1rem;
  color: white;
  /*     background-color: rgba(0, 0, 0, 0.4); */
  transition: background-color 1.5s ease;
}

.news-card__title {
  transition: color 1s ease;
  margin-bottom: 0.5rem;
  font-size: 20px;
}

.news-card__post-date {
  font-size: 0.7rem;
  margin-bottom: 0.5rem;
  color: #ccc;
}

.news-card__details-wrapper {
  max-height: 0;
  opacity: 0;
  transition: max-height 1.5s ease, opacity 1s ease;
}

@media (min-width: 900px) {
  .news-card:hover .news-card__details-wrapper {
    max-height: 20rem;
    opacity: 1;
  }
  .news-card:hover .news-card__text-wrapper {
    background-color: rgba(0, 0, 0, 0.6);
  }
  .news-card:hover .news-card__title {
    color: yellow;
  }
  .news-card:hover .news-card__image {
    transform: scale(1.2);
    z-index: -1;
  }
}

.news-card__excerpt {
  font-weight: 300;
}

.news-card__read-more {
  background: black;
  color: #bbb;
  display: block;
  padding: 0.4rem 0.6rem;
  border-radius: 0.3rem;
  margin-top: 1rem;
  border: 1px solid #444;
  font-size: 0.8rem;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  text-decoration: none;
  width: 7rem;
  margin-left: auto;
  position: relative;
  z-index: 5;
  transition: all 0.6s;
}
.news-card__read-more:hover {
  transform: scale(1.05);
}

.news-card__read-more i {
  position: relative;
  left: 0.2rem;
  color: #888;
  transition: left 0.5s ease, color 0.6s ease;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
}

.news-card__read-more:hover i {
  left: 0.5rem;
  color: yellow;
}
</style>
