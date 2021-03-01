<template>
  <div>
    <div class="sort-row mr-1">
      <div class="row mr-5">
        <div class="col-md-3">
          <p>مرتب سازی بر اساس :</p>
        </div>
        <div class="col-md 7">
          <div class="sort-select">
            <div class="select">
              <select name="slct" id="slct">
                <option value="1"><span>نمره</span> </option>
                <option value="2"><span>زمان</span> </option>
                <option value="3"><span>تاریخ</span></option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="movie-list-grid">
      <div class="container">
        <div
          class="movie_card"
          id="bright"
          v-for="movie in movieData"
          :key="movie.id"
        >
          <nuxt-link
            class="genre-name-list"
            :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
          >
            <div class="info_section">
              <div class="movie_header">
                <!-- <img class="locandina" :src="movie.picture" /> -->
                <h4 class="text-white mb-3">{{ movie.title }}</h4>
                <div class="ltr-dir">
                  <h4 class="ltr-dir">{{ movie.releaseDate }}</h4>
                </div>
                <span class="minutes"> {{ movie.lenght }} دقیقه</span>
                <p class="movie-quality mt-3">
                  <span class="y-color">4k</span> | 1080p | 720p
                </p>
                <p class="cast-list">
                  رضا هیتون , سجاد اسپپان , علی کارپر , ....
                </p>
              </div>

              <div class="movie_desc mr-5">
                <p class="text" v-if="movie.shortDescription.length < 500">
                  {{ movie.shortDescription }}
                </p>
                <p class="text" v-else>
                  {{ movie.shortDescription.substring(0, 500) + '..' }}
                </p>
              </div>
            </div>
            <div
              class="blur_back bright_back"
              :style="{
                backgroundImage: `url('${movie.bannerImage}')`
              }"
            ></div>
          </nuxt-link>
        </div>

        <!-- <div
          class="wrapper mt-3 mb-2"
          v-for="movie in movieData"
          :key="movie.id"
        >
          <nuxt-link
            class="genre-name-list"
            :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
          >
            <div class="main_card">
              <div class="card_left">
                <div class="img_container">
                  <img :src="movie.picture" alt="" />
                </div>
              </div>
              <div class="card_right mr-1">
                <div class="card_datails mt-2">
                  <h4>نام فیلم : {{ movie.title }}</h4>
                  <div class="card_cat d-block">
                    <p class="year">سال ساخت : {{ movie.releaseDate }}</p>
                    <p class="genre">
                      ژانر : Action | Adventure
                    </p>
                    <p class="time">
                      زمان :
                      {{ movie.lenght }}
                      دقیقه
                    </p>
                  </div>
                  <p class="disc" v-if="movie.shortDescription.length < 90">
                    {{ movie.shortDescription }}
                  </p>
                  <p class="disc" v-else>
                    {{ movie.shortDescription.substring(0, 90) + '..' }}
                  </p>
                </div>
              </div>
            </div>
          </nuxt-link>
        </div> -->
      </div>
      <div class="pagination">
        <div class="num-container">
          <a href="#">&laquo;</a>
          <nuxt-link
            v-for="p in pagination"
            :key="p"
            active-class="active"
            :to="{ name: 'Movies-Page-id', params: { id: p } }"
            >{{ p }}</nuxt-link
          >
          <a href="#">&raquo;</a>
        </div>
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
      movieData: '',
      pageNum: '',
      pagination: []
    };
  },
  methods: {
    async getMovie() {
      await axios.get(`/api/movies?Page=${this.id}&PageSize=6`).then(res => {
        this.movieData = res.data.items;
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
.movie_card {
  position: relative;
  display: block;
  width: 95%;
  height: 270px;
  margin-top: 1.5rem;
  margin-right: 0.75rem;
  /* margin: 100px auto; */
  overflow: hidden;
  border-radius: 10px;
  transition: all 0.4s;
}
.movie_card:hover {
  transform: scale(1.02);
  transition: all 0.4s;
}
.movie_card .info_section {
  position: relative;
  width: 100%;
  height: 100%;
  background-blend-mode: multiply;
  z-index: 2;
  border-radius: 10px;
}
.movie_card .info_section .movie_header {
  position: relative;
  padding: 25px;
  height: 40%;
}
.movie_card .info_section .movie_header h1 {
  color: #fff;
  font-weight: 400;
}
.movie_card .info_section .movie_header h4 {
  color: #9ac7fa;
  font-weight: 400;
}
.movie_card .info_section .movie_header .minutes {
  display: inline-block;
  margin-top: 10px;
  color: #fff;
  padding: 5px;
  border-radius: 5px;
  border: 1px solid rgba(255, 255, 255, 0.13);
}
.movie_card .info_section .movie_header .type {
  display: inline-block;
  color: #cee4fd;
  margin-left: 10px;
}
.movie_card .info_section .movie_header .locandina {
  position: relative;
  float: left;
  margin-right: 20px;
  height: 120px;
  box-shadow: 0 0 20px -10px rgba(0, 0, 0, 0.5);
}
.movie_card .info_section .movie_desc {
  padding: 25px;
  height: 50%;
}
.movie_card .info_section .movie_desc .text {
  color: #cfd6e1;
}
.movie_card .info_section .movie_social {
  height: 10%;
  padding-left: 15px;
  padding-bottom: 20px;
}
.movie_card .info_section .movie_social ul {
  list-style: none;
  padding: 0;
}
.movie_card .info_section .movie_social ul li {
  display: inline-block;
  color: rgba(255, 255, 255, 0.4);
  transition: color 0.3s;
  transition-delay: 0.15s;
  margin: 0 10px;
}
.movie_card .info_section .movie_social ul li:hover {
  transition: color 0.3s;
  color: rgba(255, 255, 255, 0.8);
}
.movie_card .info_section .movie_social ul li i {
  font-size: 19px;
  cursor: pointer;
}
.movie_card .blur_back {
  position: absolute;
  top: 0;
  z-index: 1;
  height: 100%;
  right: 0;
  background-size: cover;
  border-radius: 11px;
}
.movie_desc.mr-5 {
  width: 40%;
}
.text {
  color: white;
  font-size: 15px;
  position: absolute;
  top: 20%;
  left: 18%;
  transform: translate(-30%, -30%);
  text-align: right;
  width: inherit;
}

@media screen and (min-width: 768px) {
  .movie_header {
    width: 60%;
  }

  .movie_desc {
    width: 50%;
  }

  .info_section {
    background: linear-gradient(to right, #0d0d0c 50%, transparent 100%);
  }

  .blur_back {
    width: 80%;
    background-position: -100% 10% !important;
  }
}
@media screen and (max-width: 1708px) {
  .movie_card {
    width: 90%;
  }
}
@media screen and (max-width: 1608px) {
  .movie_card {
    width: 80%;
  }
}
@media screen and (max-width: 1408px) {
  .movie_card {
    width: 70%;
  }
}
@media screen and (max-width: 768px) {
  .movie_card {
    width: 60%;
  }

  .blur_back {
    width: 100%;
    background-position: 50% 50% !important;
  }

  .movie_header {
    width: 100%;
    margin-top: 85px;
  }

  .movie_desc {
    width: 100%;
  }

  .info_section {
    background: linear-gradient(to top, #141413 50%, transparent 100%);
    display: inline-grid;
  }
}
#bright {
  box-shadow: 0px 0px 150px -45px rgba(255, 51, 0, 0.5);
}
#bright:hover {
  box-shadow: 0px 0px 120px -55px rgba(255, 51, 0, 0.5);
}

.bright_back {
  background: url('https://occ-0-2433-448.1.nflxso.net/art/cd5c9/3e192edf2027c536e25bb5d3b6ac93ced77cd5c9.jpg');
}

.card_right.mr-1 {
  width: 350px;
}
wrapper:hover {
  scale: 1.5;
}
.movie-quality {
  font-size: 14px;
  color: #fff;
}
.cast-list {
  font-size: 12px;
  color: #fff;
}
</style>
