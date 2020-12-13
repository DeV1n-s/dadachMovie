<template>
  <div class="latestnew">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8">
          <div class="title-hd">
            <h2>آخرین اخبار</h2>
          </div>
          <div class="tabs">
            <ul class="tab-links-3">
              <li class="active"><a href="#tab31">#Movies </a></li>
              <li><a href="#tab32"> #TV Shows </a></li>
              <li><a href="#tab33"> # Celebs</a></li>
            </ul>
            <div class="tab-content">
              <div id="tab31" class="tab active">
                <div class="row">
                  <div class="blog-item-style-1">
                    <img
                      src="images/uploads/blog-it1.jpg"
                      alt=""
                      width="170"
                      height="250"
                    />
                    <div class="blog-it-infor">
                      <h3>
                        <a href="#"
                          >Brie Larson to play first female white house
                          candidate Victoria Woodull in Amazon film</a
                        >
                      </h3>
                      <span class="time">13 hours ago</span>
                      <p>
                        Exclusive: <span>Amazon Studios </span>has acquired
                        Victoria Woodhull, with Oscar winning Room star
                        <span>Brie Larson</span> polsed to produce, and play the
                        first female candidate for the presidency of the United
                        States. Amazon bought it in a pitch package deal.
                        <span> Ben Kopit</span>, who wrote the Warner Bros film
                        <span>Libertine</span> that has...
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab32" class="tab">
                <div class="row">
                  <div class="blog-item-style-1">
                    <img
                      src="images/uploads/blog-it2.jpg"
                      alt=""
                      width="170"
                      height="250"
                    />
                    <div class="blog-it-infor">
                      <h3><a href="#">Tab 2</a></h3>
                      <span class="time">13 hours ago</span>
                      <p>
                        Exclusive: <span>Amazon Studios </span>has acquired
                        Victoria Woodhull, with Oscar winning Room star
                        <span>Brie Larson</span> polsed to produce, and play the
                        first female candidate for the presidency of the United
                        States. Amazon bought it in a pitch package deal.
                        <span> Ben Kopit</span>, who wrote the Warner Bros film
                        <span>Libertine</span> that has...
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab33" class="tab">
                <div class="row">
                  <div class="blog-item-style-1">
                    <img
                      src="images/uploads/blog-it1.jpg"
                      alt=""
                      width="170"
                      height="250"
                    />
                    <div class="blog-it-infor">
                      <h3><a href="#">Tab 3</a></h3>
                      <span class="time">13 hours ago</span>
                      <p>
                        Exclusive: <span>Amazon Studios </span>has acquired
                        Victoria Woodhull, with Oscar winning Room star
                        <span>Brie Larson</span> polsed to produce, and play the
                        first female candidate for the presidency of the United
                        States. Amazon bought it in a pitch package deal.
                        <span> Ben Kopit</span>, who wrote the Warner Bros film
                        <span>Libertine</span> that has...
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="morenew">
            <div class="title-hd">
              <h3>More news on Blockbuster</h3>
              <a href="#" class="viewall"
                >See all Movies news<i class="ion-ios-arrow-right"></i
              ></a>
            </div>
            <div class="more-items">
              <div class="left">
                <div class="more-it">
                  <h6>
                    <a href="#"
                      >Michael Shannon Frontrunner to play Cable in “Deadpool
                      2”</a
                    >
                  </h6>
                  <span class="time">13 hours ago</span>
                </div>
                <div class="more-it">
                  <h6>
                    <a href="#"
                      >French cannibal horror “Raw” inspires L.A. theater to
                      hand out “Barf Bags”</a
                    >
                  </h6>

                  <span class="time">13 hours ago</span>
                </div>
              </div>
              <div class="right">
                <div class="more-it">
                  <h6>
                    <a href="#"
                      >Laura Dern in talks to join Justin Kelly’s biopic “JT
                      Leroy”</a
                    >
                  </h6>
                  <span class="time">13 hours ago</span>
                </div>
                <div class="more-it">
                  <h6>
                    <a href="#"
                      >China punishes more than 300 cinemas for box office
                      cheating</a
                    >
                  </h6>
                  <span class="time">13 hours ago</span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-4" dir="ltr">
          <div class="sidebar">
            <div class="sb-facebook sb-it">
              <h4 class="sb-title">شبکه های اجتماعی</h4>
            </div>
            <div class="sb-twitter sb-it">
              <h4 class="sb-title"></h4>
              <div class="slick-tw">
                <div class="tweet item" id="">
                  <p></p>
                </div>
                <div class="tweet item" id="">
                  <!-- Put your 2nd twiter account id here -->
                </div>
              </div>
            </div>
            <div class="celebrities">
              <h4 class="sb-title">IMDB برترین فیلم های</h4>
              <div
                class="celeb-item"
                v-for="(imbd, index) in topImbds"
                :key="index"
              >
                <a href="#"
                  ><img :src="imbd.image" alt="" width="70" height="70"
                /></a>
                <div class="celeb-author">
                  <h6>
                    <a href="#">{{ imbd.title }}</a>
                  </h6>
                  <span>{{ imbd.year }}</span>
                </div>
              </div>
              <router-link to="/actorlist" class="btn"
                >مشاهده همه فیلم ها<i class="ion-ios-arrow-right"></i
              ></router-link>
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
      topImbds: []
    };
  },
  methods: {
    filterImbd() {
      for (let i = 0; i < 5; i++) {
        this.topImbds.push(this.$store.getters.GetTopImbd.items[i]);
      }
    }
  },
  mounted() {
    this.$store.dispatch('Top250Movies');
    this.filterImbd();
  }
};
</script>

<style>
.celebrities {
  padding-bottom: 6rem;
}
</style>
