<template>
  <div class="container">
    <div
      class="in-theater"
      data-aos="fade-up"
      data-aos-delay="250"
      data-aos-duration="2500"
    >
      <h4 class="mr-0 mb-3">
        <strong><i class="fa fa-film ml-1 "></i> روی پرده سینما ...</strong>
      </h4>
      <div class="row mr-4">
        <div
          class="card col-md-3"
          v-for="movie in inTheaterMovie"
          :key="movie.id"
        >
          <nuxt-link
            class="genre-name-list"
            :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
          >
            <div
              class="img1"
              :style="{
                backgroundImage: `url('${movie.picture}')`
              }"
            ></div>
            <div
              class="img2"
              :style="{
                backgroundImage: `url('${movie.picture}')`
              }"
            ></div>
            <div class="title">{{ movie.title }}</div>
            <div class="text">
              {{ movie.shortDescription }}
            </div>
            <a href="#"
              ><div class="catagory">
                <i class="fa fa-clock-o"></i>

                {{ movie.lenght }}
                دقیقه
              </div>
            </a>
            <a href="#"
              ><div class="views">
                <i class="fa fa-calendar" aria-hidden="true"></i>

                {{ movie.releaseDate }}
              </div>
            </a>
          </nuxt-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
//import VueAos from 'vue-aos';
import AOS from 'aos';
import 'aos/dist/aos.css';
export default {
  data() {
    return {
      inTheaterMovie: []
    };
  },
  methods: {
    getInTheater() {
      axios.get('/api/movies/InTheaters?PageSize=4').then(res => {
        res.data.items.forEach(q => {
          this.inTheaterMovie.push(q);
        });
        console.log(res.data.items);
      });
    }
  },
  created() {},
  mounted() {
    this.getInTheater();
    AOS.init();
  }
};
</script>

<style scoped>
h4 {
  padding: 10px;
  padding-left: 25px;
  color: #ccc;
  margin: 0;
}
h4 strong {
  z-index: 2;
  background: #24282f;
  padding: 4px 8px;
}
h4 span {
  font-size: 0.7em;
  color: #aaa;
  margin-left: 10px;
}
h4:after {
  content: '';
  z-index: 1;
  bottom: 50%;
  margin-bottom: -2px;
  height: 2px;
  left: 0;
  right: 0;
  background: #1f63d8;
}
.row.mr-4 {
  box-shadow: aqua;
  /* box-shadow: 1px 1px 2px 2px #8888; */
  border-radius: 11px;
}

.row .mr-4 {
  margin-top: 0 !important;
  padding-top: 0 !important;
}
a {
  text-decoration: none;
  color: #000;
}

.card {
  position: relative;
  overflow: hidden;
  width: 320px;
  height: 450px;
  margin: 50px auto;
  background: #2a264f;
  border: 5px solid #1a163f;
  border-radius: 3px;
  box-shadow: 0 0 10px #2a264f;
}

.card .img1 {
  position: absolute;
  top: 0;
  left: 0;
  height: 60%;
  width: 100%;
  background-image: url(http://cima4u.tv/wp-content/uploads/1-71.jpg);
  background-size: 310px 440px;
  background-position: left top;
  transition: all 0.5s ease-in-out;
}

.card .img2 {
  position: absolute;
  bottom: 0;
  left: 0;
  height: 40%;
  width: 100%;
  background-image: url(http://cima4u.tv/wp-content/uploads/1-71.jpg);
  background-size: 310px 440px;
  background-position: left bottom;
  transition: all 0.5s ease-in-out;
}

.card .title {
  height: 22%;
  width: 100%;
  font-size: 20px;
  text-align: center;
  font-weight: 700;
  color: #fffc;
  padding: 15px 10px;
  position: absolute;
  bottom: 0;
  left: 0;
  box-shadow: 0 -95px 28px -25px #000 inset;
}

.card .text {
  position: absolute;
  bottom: 80px;
  height: 120px;
  padding: 15px 10px;
  text-align: center;
  font-size: 17px;
  color: #fff;
  transform: rotate(90deg);
  transform-origin: 0 100px;
  opacity: 0;
  transition: all 0.5s ease;
}

.card .catagory {
  position: absolute;
  left: 10px;
  top: 140px;
  padding: 3px 10px;
  font-size: 15px;
  font-weight: 700;
  text-align: center;
  background: #2a264f;
  color: #fff;
  border-radius: 5px;
  transform: translate(-160px, 0);
  transition: all 0.5s ease;
}

.card .views {
  position: absolute;
  left: 10px;
  top: 175px;
  padding: 3px 10px;
  font-size: 15px;
  font-weight: 700;
  text-align: center;
  background: #8b2463;
  color: #fff;
  border-radius: 5px;
  transform: translate(-160px, 0);
  transition: all 0.5s ease 0.15s;
}

.card:hover .img1 {
  transform: rotate(10deg) scale(1.3) translate(20px, 0);
  transform-origin: 300px 300px;
  opacity: 0.5;
}

.card:hover .img2 {
  transform: rotate(90deg) translate(0px, 150px);
  transform-origin: -20px 200px;
}

.card:hover .text {
  opacity: 0.8;
  transform: rotate(0deg);
}

.card:hover .views,
.card:hover .catagory {
  transform: translate(0);
}

h4.mb-2 {
  margin-bottom: 1.5rem !important;
}
</style>
