<template>
  <div>
    <div class="hero common-hero">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="hero-ct">
              <ul class="breadcumb"></ul>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="page-single">
      <div class="container">
        <div class="row">
          <div class="col-md-9 col-sm-12 col-xs-12">
            <div class="blog-detail-ct">
              <h1>{{ News.title }}</h1>
              <span class="time">تاریخ</span>
              <img :src="News.img" alt="" />
              <h3>
                {{ News.shortPara }}
              </h3>
              <hr />
              <p>
                {{ News.description }}
              </p>

              <!-- share link -->
              <div class="flex-it share-tag">
                <div class="social-link">
                  <h4>یه اشتراک گذاری</h4>
                  <a href="#"><i class="ion-social-facebook"></i></a>
                  <a href="#"><i class="ion-social-twitter"></i></a>
                  <a href="#"><i class="ion-social-googleplus"></i></a>
                  <a href="#"><i class="ion-social-pinterest"></i></a>
                  <a href="#"><i class="ion-social-linkedin"></i></a>
                </div>
              </div>
              <!-- comment items -->

              <!-- comment form -->
            </div>
          </div>
          <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="sidebar">
              <div class="sb-search sb-it">
                <h4 class="sb-title">جست و جو</h4>
                <input type="text" placeholder="Enter keywords" />
              </div>
              <div class="sb-cate sb-it">
                <h4 class="sb-title">دسته ها</h4>
                <ul>
                  <li><a href="#">سینما</a></li>
                  <li><a href="#">تلویزیون</a></li>
                  <li><a href="#">سرگرمی</a></li>
                </ul>
              </div>
              <div class="sb-recentpost sb-it">
                <h4 class="sb-title">محبوب ترین ها</h4>
                <div class="recent-item">
                  <span>01</span>
                  <h6>
                    <a href="#"
                      >Korea Box Office: Beauty and the Beast Wins Fourth</a
                    >
                  </h6>
                </div>
                <div class="recent-item">
                  <span>02</span>
                  <h6>
                    <a href="#">Homeland Finale Includes Shocking Death </a>
                  </h6>
                </div>
                <div class="recent-item">
                  <span>03</span>
                  <h6>
                    <a href="#"
                      >Fate of the Furious Reviews What the Critics Saying</a
                    >
                  </h6>
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
    News() {
      return this.$store.getters.post(parseInt(this.$route.params.id));
    }
  }
};
</script>

<style>
h3 {
  color: aliceblue;
}
p {
  font-size: 1.8rem;
}
</style>
