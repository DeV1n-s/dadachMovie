<template>
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
            <img :src="Movie.img" alt="" />
            <div class="movie-btn">
              <div class="btn-transform transform-vertical red">
                <div>
                  <a href="#" class="item item-1 redbtn">
                    <i class="ion-play"></i>مشاهده تریلر</a
                  >
                </div>
                <div>
                  <a href="#" class="item item-2 redbtn fancybox-media hvr-grow"
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
                      </div>
                      <div class="col-md-4 col-xs-12 col-sm-12">
                        <div class="sb-it">
                          <h6>کارگردان</h6>
                          <p>
                            <a href="#">{{ Movie.Director }}</a>
                          </p>
                        </div>
                        <div class="sb-it">
                          <h6>ستاره ها</h6>
                          <p>
                            {{ Movie.Cast }}
                          </p>
                        </div>
                        <div class="sb-it">
                          <h6>ژانر</h6>
                          <p>
                            {{ Movie.Genre }}
                          </p>
                        </div>
                        <div class="sb-it">
                          <h6>تاریخ انتشار</h6>
                          <p>{{ Movie.Release }}</p>
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
  computed: {
    Movie() {
      return this.$store.getters.Movie(parseInt(this.$route.params.id));
    }
  }
};
</script>

<style scoped>
p {
  font-size: 2rem;
}
h5 {
  color: aliceblue;
}
i {
  margin: 5px;
}
</style>
