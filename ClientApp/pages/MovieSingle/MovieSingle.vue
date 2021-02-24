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
                        <a
                          type="button"
                          class=""
                          data-toggle="modal"
                          data-target="#exampleModalCenter"
                        >
                          مشاهده عوامل
                        </a>
                      </span>
                    </p>
                  </div>
                </div>
                <div class="col-md-8">
                  <h2 class="mb-2 single-header text-white mt-3">
                    <span class="movie-name y-color">{{
                      movieDetail.title
                    }}</span>
                    <span class="genre mb-2 d-block">
                      {{ genres.map(g => g.name).join(' , ') }}
                    </span>
                  </h2>
                  <div class="image mt-4">
                    <div class="single-body y-color">
                      <b-tabs content-class="mt-3" fill>
                        <b-tab title="داستان فیلم" active>
                          <p class="para m-0">
                            {{ movieDetail.description }}
                          </p>
                        </b-tab>
                        <b-tab title="نقد و بررسی"
                          ><p class="para m-0">I'm the second tab</p></b-tab
                        >
                        <b-tab title="جوایز و افتخارات">
                          <p class="para m-0">I'm the second tab</p></b-tab
                        >
                      </b-tabs>
                    </div>
                    <!--  -->
                  </div>

                  <div class="download-box d-block w-100 mb-3">
                    <h3 class="text-white">
                      <h4>
                        <i class="fa fa-download mr-1" aria-hidden="true"></i>
                        لینک دانلود
                      </h4>
                      <div class="y-line"></div>
                      <div class="download-boxes my-5">
                        <div class="col-md-12">
                          <div class="demo">
                            <div class="container">
                              <div class="row">
                                <div class="col-md-12">
                                  <div
                                    class="panel-group"
                                    id="accordion"
                                    role="tablist"
                                    aria-multiselectable="true"
                                  >
                                    <div class="panel panel-default">
                                      <div
                                        class="panel-heading"
                                        role="tab"
                                        id="headingOne"
                                      >
                                        <h4 class="panel-title">
                                          <a
                                            role="button"
                                            data-toggle="collapse"
                                            data-parent="#accordion"
                                            href="#collapseOne"
                                            aria-expanded="true"
                                            aria-controls="collapseOne"
                                          >
                                            لینک دانلود با کیفیت بالا
                                          </a>
                                        </h4>
                                      </div>
                                      <div
                                        id="collapseOne"
                                        class="panel-collapse collapse in"
                                        role="tabpanel"
                                        aria-labelledby="headingOne"
                                      >
                                        <div class="panel-body">
                                          <p>
                                            کیفیت :BluRay 1080 Full HD :::
                                            انکودر iFT حجم 11GB
                                          </p>
                                          <div class="dl-btns">
                                            <div class="flex-grid-center">
                                              <div
                                                class="pure-button fuller-button blue"
                                              >
                                                <i class="fa fa-link  fa-x"></i>
                                                لینک دانلود مستقیم
                                              </div>
                                              <div
                                                class="pure-button fuller-button red"
                                              >
                                                <i
                                                  class="fa fa-image align-middle"
                                                ></i>
                                                نمونه کیفیت
                                              </div>
                                              <div
                                                class="pure-button fuller-button white"
                                              >
                                                <i
                                                  class="fa fa-tv align-middle"
                                                ></i>
                                                پخش آنلاین
                                              </div>
                                            </div>
                                          </div>
                                        </div>
                                      </div>
                                    </div>
                                    <div class="panel panel-default">
                                      <div
                                        class="panel-heading"
                                        role="tab"
                                        id="headingTwo"
                                      >
                                        <h4 class="panel-title">
                                          <a
                                            class="collapsed"
                                            role="button"
                                            data-toggle="collapse"
                                            data-parent="#accordion"
                                            href="#collapseTwo"
                                            aria-expanded="false"
                                            aria-controls="collapseTwo"
                                          >
                                            لینک دانلود با کیفیت متوسط
                                          </a>
                                        </h4>
                                      </div>
                                      <div
                                        id="collapseTwo"
                                        class="panel-collapse collapse"
                                        role="tabpanel"
                                        aria-labelledby="headingTwo"
                                      >
                                        <div class="panel-body">
                                          <p>
                                            Lorem ipsum dolor sit amet,
                                            consectetur adipiscing elit.
                                            Praesent nisl lorem, dictum id
                                            pellentesque at, vestibulum ut arcu.
                                            Curabitur erat libero, egestas eu
                                            tincidunt ac, rutrum ac justo.
                                            Vivamus condimentum laoreet lectus,
                                            blandit posuere tortor aliquam
                                            vitae. Curabitur molestie eros.
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                    <div class="panel panel-default">
                                      <div
                                        class="panel-heading"
                                        role="tab"
                                        id="headingThree"
                                      >
                                        <h4 class="panel-title">
                                          <a
                                            class="collapsed"
                                            role="button"
                                            data-toggle="collapse"
                                            data-parent="#accordion"
                                            href="#collapseThree"
                                            aria-expanded="false"
                                            aria-controls="collapseThree"
                                          >
                                            لینک دانلود با کیفیت پایین
                                          </a>
                                        </h4>
                                      </div>
                                      <div
                                        id="collapseThree"
                                        class="panel-collapse collapse"
                                        role="tabpanel"
                                        aria-labelledby="headingThree"
                                      >
                                        <div class="panel-body">
                                          <p>
                                            Lorem ipsum dolor sit amet,
                                            consectetur adipiscing elit.
                                            Praesent nisl lorem, dictum id
                                            pellentesque at, vestibulum ut arcu.
                                            Curabitur erat libero, egestas eu
                                            tincidunt ac, rutrum ac justo.
                                            Vivamus condimentum laoreet lectus,
                                            blandit posuere tortor aliquam
                                            vitae. Curabitur molestie eros.
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
                      </div>
                    </h3>
                  </div>

                  <div class="comments ">
                    <h3>
                      <h4>
                        <i
                          class="fa fa-comments-o  ml-1"
                          aria-hidden="true"
                        ></i>

                        نظرات کاربران

                        <span class="comment-length text-muted">
                          ({{ commentLength }})
                        </span>
                      </h4>
                    </h3>
                    <div class="y-line"></div>
                    <div class="comment_block">
                      <div class="create_new_comment p-0 m-0">
                        <form>
                          <div class="row">
                            <div class="group col-md-8">
                              <textarea
                                type="textarea"
                                rows="1"
                                required="required"
                                v-model="userComemnt.content"
                              ></textarea>

                              <label>نظر خود را بنویسید</label>
                            </div>
                            <div class="group col-md-1">
                              <input type="number" required="required" /><span
                                class="highlight"
                              ></span
                              ><span class="bar"></span>
                              <label>نمره</label>
                            </div>
                            <div class="col-md-1">
                              <div class="multi-button sub-cm-btn">
                                <button @click.prevent="subComment">
                                  ثبت نظر
                                </button>
                              </div>
                            </div>
                          </div>
                        </form>
                      </div>

                      <div class="container">
                        <div
                          class="card mt-2 cm-box"
                          v-for="c in comments"
                          :key="c.id"
                        >
                          <div class="card-body">
                            <div class="row">
                              <div class="col-md-2">
                                <img
                                  :src="c.userPicture"
                                  class="img img-rounded img-fluid"
                                />
                                <p class="text-secondary text-center">
                                  <i class="fa fa-calendar"></i
                                  >{{ c.createdAt }}
                                </p>
                              </div>
                              <div class="col-md-10">
                                <p>
                                  <a class="float-left"
                                    ><strong>{{ c.userFullName }}</strong></a
                                  >
                                  <span class="float-right"
                                    ><i class="text-warning fa fa-star"></i
                                  ></span>
                                  <span class="float-right"
                                    ><i class="text-warning fa fa-star"></i
                                  ></span>
                                  <span class="float-right"
                                    ><i class="text-warning fa fa-star"></i
                                  ></span>
                                  <span class="float-right"
                                    ><i class="text-warning fa fa-star"></i
                                  ></span>
                                </p>
                                <div class="clearfix"></div>
                                <p>
                                  {{ c.content }}
                                </p>
                                <p class="mt-4">
                                  <a
                                    class="float-right btn btn-outline-primary  ml-2"
                                  >
                                    <i class="fa fa-reply"></i> پاسخ</a
                                  >
                                  <a
                                    class="float-right btn text-white btn-danger"
                                  >
                                    <i class="fa fa-heart"></i> پسندیدن</a
                                  >
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
              <div class="row"></div>
              <div class="photo"></div>

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
    <!--  -->
    <div
      class="modal fade"
      id="exampleModalCenter"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">لیست عوامل</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <div class="cast-list">
              <h5>
                بازیگران :
              </h5>
              <div>
                <span class="d-block">
                  <span v-for="cast in casts" :key="cast.personId">
                    {{ cast.character }} ,
                  </span>
                </span>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-primary" data-dismiss="modal">
              بستن
            </button>
          </div>
        </div>
      </div>
    </div>
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
  line-height: 28px;
  padding: 11px 65px 11px 40px;
  word-wrap: break-word;
  box-shadow: 2px 2px 5px #87c540;
}

.panel-heading .panel-title > a::after {
  bottom: 0;
  /* content: '▲'; */
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
  /* content: '▼'; */
}
.panel-body {
  height: 180px;
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
  margin-top: 15rem;
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
  /* margin-left: -15px !important; */
  width: calc(100% - 75px);
}
.header {
  background: #1d2024 !important;
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

.single-body {
  background: #ce5937;
  background: -moz-linear-gradient(left, #ce5937 0%, #1c6ea4 81%, #c59237 100%);
  background: -webkit-linear-gradient(
    left,
    #ce5937 0%,
    #1c6ea4 81%,
    #c59237 100%
  );
  background: linear-gradient(to right, #ce5937 0%, #1c6ea4 81%, #c59237 100%);

  color: rgb(175, 110, 30) !important;
  font-size: 15px !important;
}

p.para.m-0 {
  background-color: rgb(224, 221, 221);
  -webkit-box-shadow: 5px 5px 5px 0px #000000, inset 4px 4px 15px 0px #000000,
    5px 5px 15px 5px rgba(0, 0, 0, 0);
  box-shadow: 5px 5px 5px 0px #000000, inset 4px 4px 15px 0px #000000,
    5px 5px 15px 5px rgba(0, 0, 0, 0);
  padding: 1rem;
  color: #000000 !important;
  font-size: 16px;
  border: 5px hidden #1c6ea4;
  border-radius: 0px 0px 0px 40px;
}
.single-body.y-color {
  border-radius: 8px;
  box-shadow: 2px 2px 2px 2px #8888;
}

.demo {
  background: linear-gradient(to right, #4e42b9, #e98223);
  padding-top: 1rem;
  border-radius: 20px;
  -webkit-box-shadow: 5px 5px 15px 5px #ff8080, -9px 5px 15px 5px #ffe488,
    -7px -5px 15px 5px #8cff85, 12px -5px 15px 5px #80c7ff,
    12px 10px 15px 7px #e488ff, -10px 10px 15px 7px #ff616b,
    -10px -7px 27px 1px #8e5cff, -50px -50px 0px -30px rgba(255, 154, 26, 0);
  box-shadow: 5px 5px 5px 5px #ff8080, -5px 5px 5px 5px #ffe488,
    -7px -5px 5px 5px #8cff85, -2px -5px 6px 4px #80c7fe,
    2px 0px 7px 7px #e488ff, -10px 10px 5px 7px #ff616b,
    -10px -7px 5px 1px #8e5cff, -50px -50px 0px -30px rgb(255 154 26 / 0%);
}
a:hover,
a:focus {
  text-decoration: none;
  outline: none;
}
#accordion .panel {
  border: none;
  border-radius: 5px;
  box-shadow: none;
  margin-bottom: 10px;
  background: transparent;
}
#accordion .panel-heading {
  padding: 0;
  border: none;
  border-radius: 5px;
  background: transparent;
  position: relative;
}
#accordion .panel-title a {
  display: block;
  padding: 20px 30px;
  margin: 0;
  background: rgba(0, 0, 0, 0.4);
  font-size: 17px;
  font-weight: bold;
  color: #fff;
  text-transform: uppercase;
  letter-spacing: 1px;
  border: none;
  border-radius: 5px;
  position: relative;
}
#accordion .panel-title a.collapsed {
  border: none;
}
#accordion .panel-title a:before,
#accordion .panel-title a.collapsed:before {
  content: '\f107';
  font-family: 'Font Awesome 5 Free';
  width: 30px;
  height: 30px;
  line-height: 27px;
  text-align: center;
  font-size: 25px;
  font-weight: 900;
  color: #fff;
  position: absolute;
  top: 15px;
  right: 30px;
  transform: rotate(180deg);
  transition: all 0.4s cubic-bezier(0.08, 1.09, 0.32, 1.275);
}
#accordion .panel-title a.collapsed:before {
  color: rgba(255, 255, 255, 0.5);
  transform: rotate(0deg);
}
#accordion .panel-body {
  padding: 20px 30px;
  background: rgba(0, 0, 0, 0.1);
  font-size: 15px;
  color: #fff;
  line-height: 28px;
  letter-spacing: 1px;
  border-top: none;
  border-radius: 5px;
}
.panel-body p {
  text-shadow: 1px -1px 0 #767676, -1px 2px 1px #737272, -2px 4px 1px #767474,
    -40px -33px 0px rgba(206, 89, 55, 0);
}
.flex-grid-center {
  display: flex;
  float: left;
  margin: 0em 0;
}
#accordion .panel-body {
  height: 180px !important;
}

.panel-body[data-v-374c7078] {
  height: 180px;
}

.fuller-button {
  color: white;
  background: none;
  border-radius: 0;
  padding: 0.4em 0.6em;
  letter-spacing: 2.05px;
  font-size: 0.7em;
  transition: background-color 0.3s, box-shadow 0.3s, color 0.3s;
  margin: 1em;
}
.fuller-button.blue {
  box-shadow: inset 0 0 1em rgba(0, 170, 170, 0.5),
    0 0 1em rgba(0, 170, 170, 0.5);
  border: #0dd solid 2px;
}
.fuller-button.blue:hover {
  background-color: #0dd;
  box-shadow: inset 0 0 0 rgba(0, 170, 170, 0.5),
    0 0 1.5em rgba(0, 170, 170, 0.7);
}
.fuller-button.red {
  box-shadow: inset 0 0 1em rgba(251, 81, 81, 0.4),
    0 0 1em rgba(251, 81, 81, 0.4);
  border: #fb5454 solid 2px;
}
.fuller-button.red:hover {
  background-color: #fb5454;
  box-shadow: inset 0 0 0 rgba(251, 81, 81, 0.4),
    0 0 1.5em rgba(251, 81, 81, 0.6);
}
.fuller-button.white {
  box-shadow: inset 0 0 0.8em rgba(255, 255, 255, 0.3),
    0 0 0.8em rgba(255, 255, 255, 0.3);
  border: #fff solid 2px;
}
.fuller-button.white:hover {
  color: rgba(0, 0, 0, 0.8);
  background-color: #fff;
  box-shadow: inset 0 0 0 rgba(255, 255, 255, 0.3),
    0 0 1.2em rgba(255, 255, 255, 0.5);
}

.pure-control-group {
  display: flex;
  flex-direction: column;
  position: relative;
  padding: 0 1em 2.6em 1em;
}

.pure-form .pure-control-group label {
  text-align: left;
  position: absolute;
  left: 0;
  top: 15%;
  z-index: 0;
  letter-spacing: 0;
  margin: 0 1em;
}

.pure-form .pure-control-group input {
  background: none;
  box-shadow: none;
  padding-left: 0;
  border-radius: 0;
  border: none;
  border-bottom: 2px solid rgba(255, 255, 255, 0.4);
  position: relative;
  z-index: 1;
  color: #fff;
}

.pure-form .pure-control-group input:focus {
  border-bottom: 2px solid white;
}

.pure-form .pure-control-group textarea {
  background: none;
  box-shadow: none;
  border-radius: 0;
  border: none;
  border-left: 2px solid rgba(255, 255, 255, 0.4);
  resize: none;
  height: 8em;
  color: #fff;
}

.pure-form .pure-control-group textarea:focus {
  border-left: 2px solid white;
}

.pure-form .pure-control-group input[type='email']:focus:invalid {
  color: #fff;
}

.pure-form .pure-control-group input[type='email']:invalid {
  color: #fb5454;
}

.pure-form button {
  margin: 0.5em 1em;
}

form {
  width: 100%;
}

form hr.sep {
  background: #2196f3;
  box-shadow: none;
  border: none;
  height: 2px;
  width: 25%;
  margin: 0px auto 45px auto;
}
form .emoji {
  font-size: 1.2em;
}

.group {
  position: relative;
  margin: 45px 0;
}

textarea {
  resize: none;
  width: 100%;
}
input {
  width: 100px;
}
input:focus ~ .bar:before {
  width: 50px;
}
input,
textarea {
  background: none;
  color: #c6c6c6;
  font-size: 18px;
  padding: 10px 10px 10px 5px;
  display: block;
  /* width: 520px; */
  border: none;
  border-radius: 0;
  border-bottom: 1px solid #c6c6c6;
}
input:focus,
textarea:focus {
  outline: none;
}
input:focus ~ label,
input:valid ~ label,
textarea:focus ~ label,
textarea:valid ~ label {
  top: -14px;
  font-size: 12px;
  color: #ffbc00;
}

textarea:focus ~ .bar:before {
  width: 320px;
}

input[type='password'] {
  letter-spacing: 0.3em;
}

label {
  color: #c6c6c6;
  font-size: 16px;
  font-weight: normal;
  position: absolute;
  pointer-events: none;

  top: 10px;
  transition: 300ms ease all;
}

.bar:before {
  content: '';
  height: 2px;
  width: 0;
  bottom: 0px;
  position: absolute;
  background: #ffbc00;
  transition: 300ms ease all;
  left: 0%;
}
.sub-cm-btn {
  margin-top: 3.6rem;
  margin-right: 3rem;
}
multi-button {
  filter: drop-shadow(3px 10px 15px rgba(0, 0, 0, 0.45));
}
.multi-button button {
  height: 40px;
  width: 100px;
  font-weight: bold;
  color: white;
  font-size: 1rem;
  border: none;
  margin: -5px;
  padding: 0;
  stroke: black;
  outline: none;
  background: linear-gradient(to bottom, #bada55, #da55bb);
  transition: all 1s;
}
.multi-button :nth-child(1) {
  border-radius: 20px 0 0 20px;
}
.multi-button :nth-child(3) {
  border-radius: 0 20px 20px 0;
}

button:hover {
  cursor: pointer;
  filter: drop-shadow(3px 5px 5px rgba(0, 0, 0, 0.45));
  background: linear-gradient(to bottom, #ade004, #e714b6);
  transition: all 1s;
  transform: scale(1.04);
}
button:active {
  filter: none;
  transform: scale(0.95);
}
.movie-name {
  color: #e0dfdc;
  text-shadow: 0 -1px 0 #fff, 0 1px 0 #2e2e2e, 0 3px 0 #2a2a2a, 0 4px 0 #282828,
    0 5px 0 #262626, 0 7px 0 #222, 0 8px 0 #202020, 0 10px 0 #1c1c1c,
    -40px -33px 0px rgba(206, 89, 55, 0);
}
.cm-box {
  border-radius: 20px;
  box-shadow: 3px 3px 3px 3px #8888;
  transition: all 1s;
}
.cm-box:hover {
  transform: scale(0.97);
}
</style>
