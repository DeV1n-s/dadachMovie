<template>
  <div>
    <div
      class="movie-item-style-2"
      v-for="MovieList in movieData"
      :key="MovieList.id"
    >
      <img :src="MovieList.picture" alt="" />
      <div class="mv-item-infor">
        <h6>
          <router-link
            :to="{ name: 'MovieSingle', params: { id: MovieList.id } }"
          >
            {{ MovieList.title }}
          </router-link>
        </h6>
        <p class="rate">
          <i class="ion-android-star"></i><span>{{ MovieList.rate }}</span> /10
        </p>
        <p class="describe">
          {{ MovieList.shortDescription }}
        </p>
        <p class="run-time">
          <span>سال انتشار :{{ MovieList.releaseDate }}</span>
        </p>
        <p>کارگردان : {{ Diractor }}</p>
        <p>
          ستاره ها :
          <span v-for="cast in Cast" :key="cast.id"
            >{{ cast.personName }} {{ ' ' }}</span
          >
        </p>
        <p>
          ژانر : <span> {{ MovieList.genres }} </span>
        </p>
      </div>
    </div>
    <div class="topbar-filter">
      <div class="pagination2">
        <span>صفحه 1 از 2</span>
        <a class="active" href="#">1</a>
        <a href="#">2</a>
        <a href="#"><i class="ion-arrow-right-b"></i></a>
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
  mounted() {
    axios.get('/api/movies?Filter=genres.id==' + this.id).then(res => {
      this.movieData = res.data;
      console.log(res.data);
    });
    console.log(this.movieData);
    console.log(this.id);
  },
  computed: {
    MovieLists: function() {
      return this.$store.getters.GetMovies;
    },
    Cast: function() {
      return this.$store.getters.GetMovies;
    },
    Diractor: function() {
      return this.$store.getters.GetMovies[0].directors;
    }
  }
};
</script>

<style scoped>
.movie_list .movie-item-style-2 img,
.movie_single .movie-item-style-2 img,
.userfav_list .movie-item-style-2 img {
  width: 170px !important;
  height: 250px !important;
}

.movie-item-style-2 {
  font-size: 1.75rem;
}
img {
  margin-left: 0.5em;
}
</style>
