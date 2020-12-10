<template>
  <div>
    <div class="hero mv-single-hero">
      <div class="container">
        <div class="row">
          <div class="col-md-12"></div>
        </div>
      </div>
    </div>
    <div class="container"></div>
    <div class="page-single movie-single movie_single">
      <div class="container">
        <div class="row ipad-width2">
          <div class="col-md-4 col-sm-12 col-xs-12">
            <div class="movie-img sticky-sb">
              <img :src="Movie.picture" alt="" />
              <div class="movie-btn">
                <div class="btn-transform transform-vertical red">
                  <div>
                    <a href="#" class="item item-1 redbtn">
                      <i class="ion-play"></i>مشاهده تریلر</a
                    >
                  </div>
                  <div>
                    <a
                      href="#"
                      class="item item-2 redbtn fancybox-media hvr-grow"
                      ><i class="ion-play"></i
                    ></a>
                  </div>
                </div>
                <div class="btn-transform transform-vertical">
                  <div>
                    <a href="#" class="item item-1 yellowbtn">
                      <i class="ion-card"></i> خرید بلیط</a
                    >
                  </div>
                  <div>
                    <a href="#" class="item item-2 yellowbtn"
                      ><i class="ion-card"></i
                    ></a>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-8 col-sm-12 col-xs-12">
            <div class="movie-single-ct main-content">
              <h1 class="bd-hd">{{ Movie.title }}</h1>
              <div class="social-btn">
                <a href="#" class="parent-btn"
                  ><i class="ion-heart"></i> اضافه کردن به لیست مورد علاقه
                </a>
                <div class="hover-bnt">
                  <a href="#" class="parent-btn"
                    ><i class="ion-android-share-alt"></i>انتشار</a
                  >
                  <div class="hvr-item">
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-facebook"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-twitter"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-googleplus"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-youtube"></i
                    ></a>
                  </div>
                </div>
              </div>
              <div class="movie-rate">
                <div class="rate">
                  <i class="ion-android-star"></i>
                  <p><span>8.1</span> /10<br /></p>
                  <div class="rate-star">
                    <p>امتیاز کاربران</p>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star-outline"></i>
                  </div>
                </div>
              </div>
              <div class="movie-tabs">
                <div class="tabs">
                  <div class="tab-content">
                    <div id="overview" class="tab active">
                      <div class="row">
                        <div class="col-md-8 col-sm-12 col-xs-12">
                          <h5>{{ Movie.shortPara }}</h5>
                          <hr />
                          <p>{{ Movie.longPara }}</p>
                          <!-- movie user review -->
                          <div id="reviews">
                            <div class="row">
                              <div class="rv-hd">
                                <div class="div">
                                  <h2>نظرات کاربران</h2>
                                </div>
                                <a href="#" class="redbtn rw-btn"
                                  >نظر خود را بنویسید
                                </a>
                              </div>
                              <div class="topbar-filter">
                                <p>تعداد نظرات : <span>25</span></p>
                              </div>
                              <div class="mv-user-review-item">
                                <div class="user-infor">
                                  <img
                                    class="user-rw-pic"
                                    src="http://localhost:5000/movies/20bc0c81-b9a2-4b5b-9188-d8151556dc99.jpg"
                                    alt=""
                                  />
                                  <div>
                                    <h3>بهترین فیلم این جهان</h3>
                                    <div class="no-star">
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star last"></i>
                                    </div>
                                    <p class="time">
                                      12 آبان 1398
                                      <a href="#"> ملا عمر از کابل</a>
                                    </p>
                                  </div>
                                </div>
                                <p>
                                  بعد از دیدن این فیلم یک دست و پایم که از
                                  نوزادی قطع شده بود رشد کرد و نیز همسرم بعد از
                                  20 سال باردار شد
                                </p>
                                <hr />
                              </div>
                              <div class="mv-user-review-item">
                                <div class="user-infor">
                                  <img
                                    class="user-rw-pic"
                                    src="http://localhost:5000/people/3d582288-f039-4c56-aa4e-38670b0a73a9.jpg"
                                    alt=""
                                  />
                                  <div>
                                    <p class="time">
                                      12 آبان 1398
                                      <a href="#"> دانیال از ایران </a>
                                    </p>
                                    <div class="no-star">
                                      <i class="ion-android-star"></i>
                                      <i class="ion-android-star last"></i>
                                      <i class="ion-android-star last"></i>
                                      <i class="ion-android-star last"></i>
                                      <i class="ion-android-star last"></i>
                                      <i class="ion-android-star last"></i>
                                    </div>
                                    <h3>
                                      افتضاح بود
                                    </h3>
                                  </div>
                                </div>
                                <p>
                                  بعد از دیدن این فیلم دچار یک سری مشکلات گوارشی
                                  شدم
                                </p>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="col-md-4 col-xs-12 col-sm-12">
                          <div class="sb-it">
                            <h6>کارگردان</h6>
                            <p>
                              <a href="#">{{ Diractor }}</a>
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>ستاره ها</h6>
                            <p v-for="cast in Cast" :key="cast">
                              {{ cast.personName }}
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>ژانر</h6>
                            <p>
                              {{ Movie.genres[0].name }}
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>تاریخ انتشار</h6>
                            <p>{{ Movie.releaseDate }}</p>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      Diractor: '',
      Cast: ''
    };
  },
  computed: {
    Movie() {
      return this.$store.getters.Movie(parseInt(this.$route.params.id));
    }
  },
  mounted() {
    this.Diractor = this.Movie.directors[0].personName;
    this.Cast = this.Movie.casters;
  }
};
</script>

<style scoped>
.rw-btn {
  margin-left: 1.7rem;
  margin-bottom: 1.9rem;
}
p {
  font-size: 2rem;
}
h5 {
  color: aliceblue;
}
i {
  margin: 5px;
}
h6 {
  margin-top: 0.38rem;
}

#reviews {
  margin-top: 5rem;
  margin-right: 1rem;
}
img.user-rw-pic {
  float: right;
  width: 80px;
  height: 80px;
  border-radius: 80px;
  margin: 0.5rem;
}
</style>
