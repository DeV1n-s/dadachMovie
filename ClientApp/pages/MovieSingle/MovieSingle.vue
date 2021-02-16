<template>
  <div dir="rtl">
    <nav-bar />
    <section id="home-section">
      <div class="container">
        <div class="maind">
          <div class="movie-single">
            <div class="header">
              <header
                id="single-header"
                :style="{
                  backgroundImage: `url('${movieDetail.bannerImage}')`
                }"
              >
                <div class="container">
                  <div class="row">
                    <div class="col-md-6 m-auto text-center"></div>
                  </div>
                </div>
              </header>
              <div class="row">
                <div class="col-md-3">
                  <img :src="movieDetail.picture" alt="" />
                  <div class="single-movie-btns">
                    <div class="btn mt-3">
                      <button>مشاهده پیشنمایش</button>
                    </div>
                    <button
                      class="btn btn-danger mr-3 btn-favorit"
                      @click="addFavoritMovie"
                      :disabled="!canFavorit"
                    >
                      <i class="fa fa-heart" aria-hidden="true"></i> مورد علاقه
                    </button>
                    <small class="text-danger mt-1" v-if="!canFavorit">
                      {{ movieDetail.title }}

                      از پیش در لیست علاقه مندی شما وجود دارد !
                    </small>
                  </div>
                  <div class="movie-details mt-4">
                    <p>
                      <span class="y-color">
                        <i class="fa fa-imdb fa-2x"></i>
                        نمره :</span
                      >
                      {{ movieDetail.imdbRate }}
                    </p>
                    <p>
                      <span class="y-color">
                        <i class="fa fa-star"></i> نمره منتقدین :
                      </span>
                      {{ movieDetail.metacriticRate }}
                    </p>
                    <p>
                      <span class="y-color">
                        <i class="fa fa-star"></i> نمره کاربران :
                      </span>
                      {{ movieDetail.averageUserRate }}
                    </p>
                    <p>
                      <span class="y-color">
                        <i class="fa fa-clock-o" aria-hidden="true"></i> زمان :
                      </span>
                      {{ movieDetail.lenght }}
                      دقیقه
                    </p>
                    <p>
                      <span class="y-color">
                        <i class="fa fa-calendar" aria-hidden="true"></i> سال
                        ساخت :</span
                      >
                      2020/12/12
                    </p>
                    <p>
                      <span class="y-color">
                        <i class="fa fa-file-video-o" aria-hidden="true"></i>
                        کارگردان :</span
                      >
                      <span v-for="d in director" :key="d.personId">
                        {{ d.personName }}
                      </span>
                    </p>
                    <p class="d-block">
                      <span class="y-color">
                        <i class="fa fa-eercast" aria-hidden="true"></i>
                        بازیگران: </span
                      ><span class="d-block">
                        <span v-for="cast in casts" :key="cast.personId">
                          {{ cast.character }} ,
                        </span>
                      </span>
                    </p>
                  </div>
                </div>
                <div class="col-md-8">
                  <div class="image">
                    <h2 class="mb-2">
                      <span class="movie-name">{{ movieDetail.title }}</span>
                      <span class="genre mb-2 d-block">
                        <span v-for="g in genres" :key="g.id"
                          >{{ g.name }} ,
                        </span></span
                      >
                    </h2>

                    <p class="para">
                      {{ movieDetail.description }}
                    </p>
                  </div>

                  <div class="download-box d-block w-100 mb-2">
                    <h3 class="text-white">
                      <i class="fa fa-download mr-1" aria-hidden="true"></i>
                      لینک دانلود
                      <div class="y-line"></div>
                      <div class="download-boxes mt-4 mb-3">
                        <div class="col-md-12">
                          <div class="panel-group margin_0" id="accordion1">
                            <div class="panel panel-default">
                              <div class="panel-heading">
                                <h4 class="panel-title">
                                  <a
                                    class="collapsed"
                                    data-toggle="collapse"
                                    data-parent="#accordion1"
                                    href="#collapse1"
                                  >
                                    <i class="rt-icon2-bubble highlight"></i>
                                    کیفیت بالا
                                  </a>
                                </h4>
                              </div>
                              <div
                                style="height: 0px;"
                                id="collapse1"
                                class="panel-collapse collapse"
                              >
                                <div class="panel-body">
                                  <div class="download-text mr-4 mt-3">
                                    <div class="row">
                                      <span class="download-text-tt">
                                        دانلود فیلم {{ movieDetail.title }}
                                        با کیفیت بالا
                                      </span>
                                      <span class="mr-auto">
                                        <button class="btn btn-success ml-4">
                                          دانلود با لینک مستقیم
                                        </button>
                                      </span>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                            <div class="panel panel-default">
                              <div class="panel-heading">
                                <h4 class="panel-title">
                                  <a
                                    data-toggle="collapse"
                                    data-parent="#accordion1"
                                    href="#collapse2"
                                    class="collapsed"
                                  >
                                    <i class="rt-icon2-bubble highlight"></i>
                                    کیفیت متوسط
                                  </a>
                                </h4>
                              </div>
                              <div
                                style="height: 0px;"
                                id="collapse2"
                                class="panel-collapse collapse"
                              >
                                <div class="panel-body">
                                  <div class="download-text mr-4 mt-3">
                                    <div class="row">
                                      <span class="download-text-tt">
                                        دانلود فیلم {{ movieDetail.title }}
                                        با کیفیت بالا
                                      </span>
                                      <span class="mr-auto">
                                        <button class="btn btn-success ml-4">
                                          دانلود با لینک مستقیم
                                        </button>
                                      </span>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                            <div class="panel panel-default">
                              <div class="panel-heading">
                                <h4 class="panel-title">
                                  <a
                                    data-toggle="collapse"
                                    data-parent="#accordion1"
                                    href="#collapse3"
                                    class="collapsed"
                                  >
                                    <i class="rt-icon2-bubble highlight"></i>
                                    کیفیت پایین
                                  </a>
                                </h4>
                              </div>
                              <div
                                style="height: 0px;"
                                id="collapse3"
                                class="panel-collapse collapse"
                              >
                                <div class="panel-body">
                                  <div class="download-text mr-4 mt-3">
                                    <div class="row">
                                      <span class="download-text-tt">
                                        دانلود فیلم {{ movieDetail.title }}
                                        با کیفیت بالا
                                      </span>
                                      <span class="mr-auto">
                                        <button class="btn btn-success ml-4">
                                          دانلود با لینک مستقیم
                                        </button>
                                      </span>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </h3>
                  </div>

                  <div class="comments ">
                    <h3>
                      <i class="fa fa-comments-o  ml-1" aria-hidden="true"></i>

                      نظرات کاربران
                      <span class="comment-length text-muted">
                        ({{ commentLength }})
                      </span>
                    </h3>
                    <div class="y-line"></div>
                    <div class="comment_block">
                      <div class="create_new_comment">
                        <div class="row">
                          <div class="input_comment d-flex col-md-8">
                            <input
                              type="text"
                              placeholder="نظر خود را بنویسید "
                              v-model="userComemnt.content"
                            />
                          </div>
                          <input
                            class="col-md-2"
                            type="number"
                            placeholder="نمره "
                          />
                          <button
                            class="btn btn-success"
                            @click.prevent="subComment"
                          >
                            ثبت نظر
                          </button>
                        </div>
                      </div>

                      <div class="new_comment">
                        <ul
                          class="user_comment"
                          v-for="c in comments"
                          :key="c.id"
                        >
                          <div class="user_avatar">
                            <img :src="c.userPicture" />
                          </div>
                          <div class="comment_body">
                            <p>
                              {{ c.content }}
                            </p>
                          </div>

                          <div class="comment_toolbar">
                            <div class="comment_details">
                              <ul>
                                <li>
                                  <i class="fa fa-calendar"></i
                                  >{{ c.createdAt }}
                                </li>
                                <li>
                                  <i class="fa fa-pencil"></i>
                                  <span class="user">
                                    {{ c.userFullName }}</span
                                  >
                                </li>
                              </ul>
                            </div>
                          </div>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row"></div>
              <div class="photo">
                <!-- <a target="_blank" href="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"></a>
                            <a target="_blank" href="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"></a>
                            <a target="_blank" href="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"></a> -->
              </div>

              <div class="more ">
                <h2>فیلم های محبوب</h2>
                <div class="d-flex justify-content-center">
                  <a href="">
                    <img
                      src="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"
                      alt=""
                    />
                  </a>
                  <a href="">
                    <img
                      src="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"
                      alt=""
                    />
                  </a>
                  <a href="">
                    <img
                      src="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"
                      alt=""
                    />
                  </a>
                  <a href="">
                    <img
                      src="https://valamovie.art/wp-content/uploads/A1FJwUVg84sQSjHVz5jVMXQvifJ.jpg"
                      alt=""
                    />
                  </a>
                </div>
              </div>
            </div>
          </div>

          <footer-app />
        </div>
      </div>
      <div class="alert-modal">
        <b-alert
          :show="dismissCountDown"
          variant="success"
          @dismissed="dismissCountDown = 0"
          @dismiss-count-down="countDownChanged"
        >
          <p>نظر با موفقیت ثبت شد</p>
          <p>{{ dismissCountDown }}</p>
          <b-progress :max="dismissSecs" height="4px"></b-progress>
        </b-alert>
      </div>
    </section>
  </div>
</template>

<script>
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
import axios from 'axios';
export default {
  data() {
    return {
      id: this.$route.params.id,
      canFavorit: true,
      token: '',
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      movieDetail: '',
      casts: '',
      director: [],
      genres: [],
      comments: [],
      userComemnt: {
        movieId: this.$route.params.id,
        content: ''
      }
    };
  },
  methods: {
    async addFavoritMovie() {
      try {
        await axios
          .post(
            '/api/movies/SaveUserFavoriteMovies',
            {
              movieId: this.id
            },
            {
              headers: {
                Authorization: `bearer ${this.token}`
              }
            }
          )
          .then(res => console.log(res.data));
      } catch (error) {
        console.log(error);
        this.canFavorit = false;
        console.log(this.canFavorit);
      }
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    getMovie() {
      axios.get('/api/movies/' + this.id).then(res => {
        this.movieDetail = res.data;
        this.casts = res.data.casts;
        this.director = res.data.directors;
        this.genres = res.data.genres;
        this.comments = res.data.comments;
        console.log(this.movieDetail);
      });
    },
    postComment() {
      axios.post('/api/movies/AddUserComment', this.userComemnt, {
        headers: {
          Authorization: `bearer ${this.token}`
        }
      });
      this.getMovie();
    },
    subComment() {
      this.showAlert();
      this.postComment();
    }
  },
  components: {
    NavBar,
    FooterApp
  },
  mounted() {
    this.getMovie();
    this.token = localStorage.getItem('token');
  },
  computed: {
    commentLength() {
      return this.comments.length;
    }
  }
};
</script>

<style scoped>
.panel-default > .panel-heading {
  background-color: transparent;
  border: medium none;
  border-radius: 0;
  color: inherit;
  padding: 0;
  position: relative;
}
.panel-heading .panel-title > a {
  background-color: #87c540;
  border: medium none;
  color: #ffffff;
  display: block;
  font-family: Arial, Helvetica, sans-serif;
  line-height: 28px;
  padding: 11px 65px 11px 40px;
  word-wrap: break-word;
  box-shadow: 2px 2px 5px #87c540;
}

.panel-heading .panel-title > a::after {
  bottom: 0;
  content: '▲';
  font-family: 'Roboto', sans-serif;
  font-size: 20px;
  font-weight: 300;
  letter-spacing: -1px;
  line-height: 48px;
  position: absolute;
  right: 0;
  text-align: center;
  top: 0;
  width: 60px;
}
.panel-heading .panel-title > a.collapsed::after {
  content: '▼';
}
.panel-body {
  background: azure;
  color: #171414;
  height: 100px;
  overflow: hidden;
  font-size: 20px;
}
.download-text {
  border: 1px solid #ffbc00;
  background-color: #f7b500;
  padding: 0.5rem 1.3rem 0.5rem 0.1rem;
  margin-left: 8px;
  border-radius: 8px;
  text-shadow: 2px 2px 4px #000000;
  box-shadow: 2px 2px 4px #ffbc00;
}
.download-text-tt {
  margin-top: 5px;
  margin-right: 5px;
}
.download-box {
  margin-top: 25rem;
}
.comment-length {
  font-size: 15px;
}
.alert-modal {
  float: left !important;
  margin-right: 1rem;
  margin-top: 1rem;
  position: fixed;
  width: 25%;
  top: 80%;
  right: 72%;
}
.comment_block .create_new_comment .input_comment {
  display: inline-block;
  vertical-align: middle;
  margin-left: -15px !important;
  width: calc(100% - 75px);
}
.header {
  background: #171414 !important;
}
.input_comment.d-flex.col-md-8 {
  height: 59px !important;
  margin-top: 0.45px;
}
.btn-favorit {
  width: 197px;
}
.single-movie-btns {
  margin-right: 10%;
}
.movie-single .btn button {
  width: 200px !important;
}
</style>
