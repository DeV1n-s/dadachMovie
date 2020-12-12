<template>
  <div class="movie-items" dir="ltr">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8">
          <div class="title-hd">
            <router-link to="/MovieList" class="viewall"
              >مشاهده همه <i class="ion-ios-arrow-right"></i
            ></router-link>
            <h2>اکران شده</h2>
          </div>
          <div class="tabs">
            <div class="tab-content">
              <div id="tab1" class="tab active">
                <div class="row">
                  <div class="slick-multiItem">
                    <div
                      class="slide-it"
                      v-for="intTH in moviesInTheater"
                      :key="intTH.id"
                    >
                      <div class="movie-item">
                        <div class="mv-img">
                          <img :src="intTH.picture" alt="" class="img-t" />
                        </div>
                        <div class="hvr-inner">
                          <router-link
                            :to="{
                              name: 'MovieSingle',
                              params: { id: intTH.id }
                            }"
                          >
                            مشاهده
                            <i class="ion-android-arrow-dropright"></i>
                          </router-link>
                        </div>
                        <div class="title-in">
                          <h6>
                            <router-link
                              :to="{
                                name: 'MovieSingle',
                                params: { id: intTH.id }
                              }"
                            >
                              {{ intTH.title }}</router-link
                            >
                          </h6>
                          <p>
                            <i class="ion-android-star"></i
                            ><span>{{ intTH.rate }}</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab2" class="tab">
                <div class="row">
                  <div class="slick-multiItem">
                    <div
                      class="slide-it"
                      v-for="intTH in moviesInTheater"
                      :key="intTH.id"
                    >
                      <div class="movie-item">
                        <div class="mv-img">
                          <img :src="intTH.picture" alt="" class="img-t" />
                        </div>
                        <div class="hvr-inner">
                          <router-link
                            :to="{
                              name: 'MovieSingle',
                              params: { id: intTH.id }
                            }"
                          >
                            مشاهده
                            <i class="ion-android-arrow-dropright"></i>
                          </router-link>
                        </div>
                        <div class="title-in">
                          <h6>
                            <router-link
                              :to="{
                                name: 'MovieSingle',
                                params: { id: intTH.id }
                              }"
                            >
                              {{ intTH.title }}</router-link
                            >
                          </h6>
                          <p>
                            <i class="ion-android-star"></i
                            ><span>{{ intTH.rate }}</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab3" class="tab">
                <div class="row">
                  <div class="slick-multiItem"></div>
                </div>
              </div>
              <div id="tab4" class="tab">
                <div class="row">
                  <div class="slick-multiItem"></div>
                </div>
              </div>
            </div>
          </div>
          <div class="title-hd">
            <router-link to="/MoiveList" class="viewall"
              >مشاهده همه <i class="ion-ios-arrow-right"></i
            ></router-link>
            <h2>در حال اکران</h2>
          </div>
          <div class="tabs">
            <div class="tab-content">
              <div id="tab21" class="tab">
                <div class="row">
                  <div class="slick-multiItem"></div>
                </div>
              </div>
              <div id="tab22" class="tab active">
                <div class="row">
                  <div class="slick-multiItem">
                    <div
                      class="slide-it"
                      v-for="Upcomming in moviesUpcomming"
                      :key="Upcomming.id"
                    >
                      <div class="movie-item">
                        <div class="mv-img">
                          <img :src="Upcomming.picture" alt="" class="img-t" />
                        </div>
                        <div class="hvr-inner">
                          <router-link
                            :to="{
                              name: 'MovieSingle',
                              params: { id: Upcomming.id }
                            }"
                          >
                            مشاهده
                            <i class="ion-android-arrow-dropright"></i>
                          </router-link>
                        </div>
                        <div class="title-in">
                          <h6>
                            <router-link
                              :to="{
                                name: 'MovieSingle',
                                params: { id: Upcomming.id }
                              }"
                            >
                              {{ Upcomming.title }}</router-link
                            >
                          </h6>
                          <p>
                            <i class="ion-android-star"></i
                            ><span>{{ Upcomming.rate }}</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab23" class="tab">
                <div class="row">
                  <div class="slick-multiItem">
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item1.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Interstellar</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item2.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The revenant</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item3.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Die hard</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item4.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The walk</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item5.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Interstellar</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item6.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The revenant</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item7.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Die hard</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item8.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The walk</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item3.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Die hard</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div id="tab24" class="tab">
                <div class="row">
                  <div class="slick-multiItem">
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item5.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Interstellar</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item6.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The revenant</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item7.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Die hard</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item8.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">The walk</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="slide-it">
                      <div class="movie-item">
                        <div class="mv-img">
                          <img
                            src="images/uploads/mv-item3.jpg"
                            alt=""
                            width="185"
                            height="284"
                          />
                        </div>
                        <div class="hvr-inner">
                          <a href="moviesingle.html">
                            Read more
                            <i class="ion-android-arrow-dropright"></i>
                          </a>
                        </div>
                        <div class="title-in">
                          <h6><a href="#">Die hard</a></h6>
                          <p>
                            <i class="ion-android-star"></i><span>7.4</span> /10
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="sidebar">
            <div class="ads"></div>
            <div class="celebrities">
              <h4 class="sb-title">بازیگران پیشنهادی</h4>
              <div class="celeb-item">
                <a href="#"
                  ><img
                    src="images/uploads/ava1.jpg"
                    alt=""
                    width="70"
                    height="70"
                /></a>
                <div class="celeb-author">
                  <h6><a href="#">Samuel N. Jack</a></h6>
                  <span>Actor</span>
                </div>
              </div>
              <div class="celeb-item">
                <a href="#"
                  ><img
                    src="images/uploads/ava2.jpg"
                    alt=""
                    width="70"
                    height="70"
                /></a>
                <div class="celeb-author">
                  <h6><a href="#">Benjamin Carroll</a></h6>
                  <span>Actor</span>
                </div>
              </div>
              <div class="celeb-item">
                <a href="#"
                  ><img
                    src="images/uploads/ava3.jpg"
                    alt=""
                    width="70"
                    height="70"
                /></a>
                <div class="celeb-author">
                  <h6><a href="#">Beverly Griffin</a></h6>
                  <span>Actor</span>
                </div>
              </div>
              <div class="celeb-item">
                <a href="#"
                  ><img
                    src="images/uploads/ava4.jpg"
                    alt=""
                    width="70"
                    height="70"
                /></a>
                <div class="celeb-author">
                  <h6><a href="#">Justin Weaver</a></h6>
                  <span>Actor</span>
                </div>
              </div>
              <router-link to="/actorlist" class="btn"
                >مشاهده همه بازیگران<i class="ion-ios-arrow-right"></i
              ></router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import axios from 'axios';
export default {
  data() {
    return {
      moviesInTheater: this.$store.getters.getTop.inTheaters,
      movies: this.$store.getters.getTop,
      moviesUpcomming: this.$store.getters.getTop.upcomingReleases
    };
  },
  methods: {},
  mounted() {
    this.$store.dispatch('getTopMovie');
    console.log(this.moviesUpcomming);
  }
};
</script>

<style>
img.img-t {
  height: 250px;
}
</style>
