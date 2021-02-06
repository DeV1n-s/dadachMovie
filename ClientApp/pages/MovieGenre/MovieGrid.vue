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
    <div class="wrapper row">
      <div
        class="card mr-2 col-md-3"
        v-for="movie in movieData"
        :key="movie.id"
      >
        <img :src="movie.picture" />
        <div class="descriptions">
          <h1>{{ movie.title }}</h1>
          <p>
            {{ movie.shortDescription }}
          </p>
          <nuxt-link
            class="genre-name-list"
            :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
          >
            <button>
              <i class="fa fa-eye"></i>
              مشاهده
            </button>
          </nuxt-link>
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
      movieData: [],
      id: this.$route.params.id
    };
  },
  methods: {
    getGenreMovie() {
      axios.get('/api/movies?genreId=' + this.id).then(res => {
        this.movieData = res.data.items;
        // console.log(res.data);
      });
      console.log(this.movieData);
      // console.log(this.id);
    }
  },
  mounted() {
    this.getGenreMovie();
    this.$store.dispatch('getMovie');
  },
  computed: {
    movieData: function() {
      return this.$store.getters.GetMovies;
    }
  }
};
</script>

<style scoped>
.wrapper {
  /* background-color: #3d3d3d; */
  padding: 0px;
  margin: 0px;
  /* width: 100%;
  height: 100vh; */
}
.wrapper {
  align-items: right;
  margin-top: 2rem;
  margin-right: 1rem;
  width: 100%;
  height: auto;
  display: flex;
  flex-wrap: wrap;
}
.card {
  flex-grow: 0;
  height: 440px;
  box-shadow: 0px 4px 7px rgba(0, 0, 0, 0.5);
  cursor: pointer;
  transition: all 0.5s cubic-bezier(0.8, 0.5, 0.2, 1.4);
  overflow: hidden;
  position: relative;
  transform: scale(0.97);
}
.card.mr-2.col-md-3 {
  padding: 0 !important;
  margin: 0 !important;
}
.card img {
  width: 280px;
  height: 100%;
  transition: all 0.5s cubic-bezier(0.8, 0.5, 0, 1.4);
}
.descriptions {
  position: absolute;
  top: 0px;
  left: 0px;
  background-color: rgba(255, 255, 255, 0.7);
  width: 100%;
  height: 100%;
  transition: all 0.7s ease-in-out;
  padding: 20px;
  box-sizing: border-box;
  clip-path: circle(0% at 100% 100%);
  font-size: 15px;
}
.card:hover .descriptions {
  left: 0px;
  transition: all 0.7s ease-in-out;
  clip-path: circle(75%);
}
.card:hover {
  transition: all 0.5s cubic-bezier(0.8, 0.5, 0.2, 1.4);
  box-shadow: 0px 2px 3px rgba(0, 0, 0, 0.3);
  transform: scale(0.95);
}
.card:hover img {
  transition: all 0.5s cubic-bezier(0.8, 0.5, 0.2, 1.4);
  transform: scale(1.6) rotate(20deg);
  filter: blur(3px);
  width: 100%;
}
.card h1 {
  color: #ff3838;
  letter-spacing: 1px;
  margin: 0px;
  font-size: 22px !important;
}
.card p {
  line-height: 24px;
  margin-top: 1rem;
  /* height: 70%; */
}
.card button {
  width: 90px;
  height: 40px;
  cursor: pointer;
  border-style: none;
  background-color: #ff3838;
  color: #fff;
  font-size: 15px;
  outline: none;
  box-shadow: 0px 2px 3px rgba(0, 0, 0, 0.4);
  transition: all 0.5s ease-in-out;
  border-radius: 0 20px 0 20px;
  margin-top: 1rem;
}
.card button:hover {
  transform: scale(0.95) translateX(-5px);
  transition: all 0.5s ease-in-out;
  margin-bottom: 12rem;
}

/*  footer   */

.youtubeBtn {
  position: fixed;
  left: 50%;
  transform: translatex(-50%);
  bottom: 45px;
  cursor: pointer;
  transition: all 0.3s;
  vertical-align: middle;
  text-align: center;
  display: inline-block;
}
.youtubeBtn i {
  font-size: 20px;
  float: left;
}
.youtubeBtn a {
  color: #ff0000;
  text-shadow: 0px 2px 5px rgba(0, 0, 0, 0.5);
  animation: youtubeAnim 1000ms linear infinite;
  float: right;
}
.youtubeBtn a:hover {
  color: #c9110f;
  transition: all 0.3s ease-in-out;
  text-shadow: none;
}
.youtubeBtn i:active {
  transform: scale(0.9);
  transition: all 0.3s ease-in-out;
}
.youtubeBtn span {
  font-family: 'Lato';
  font-weight: bold;
  color: #fff;
  display: block;
  font-size: 12px;
  float: right;
  line-height: 20px;
  padding-left: 5px;
}

@keyframes youtubeAnim {
  0%,
  100% {
    color: #c9110f;
  }
  50% {
    color: #ff0000;
  }
}
</style>
