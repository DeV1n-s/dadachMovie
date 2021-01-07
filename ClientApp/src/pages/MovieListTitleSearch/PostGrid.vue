<template>
  <div>
    <div class="movie-notfound" v-if="movieData == ''">
      <h1>
        متاسفانه موردی یافت نشد :(
      </h1>
    </div>
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
        <p>کارگردان : {{ MovieList.directors }}</p>
        <p>
          ستاره ها :
          <span>{{ MovieList.casts }} {{ ' ' }}</span>
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
      id: this.$route.params.id,
      movieData: [],
      // movieData: this.$store.getters.GetSearchTitleMovie,
      // id: this.$route.params.id,
      // MovieLists: this.$store.getters.GetMovies,
      Cast: this.$store.getters.GetMovies,
      Diractor: this.$store.getters.GetMovies[0].directors
    };
  },
  mounted() {
    axios.get('/api/Movies?filter=Title=*' + this.id).then(res => {
      console.log(res.data.items);
      this.movieData = res.data.items;
      console.log(this.movieData);
    });
  },

  computed: {
    // movieData: function() {
    //   return this.$store.getters.GetSearchTitleMovie;
    // },
    // MovieLists: function() {
    //   return this.$store.getters.GetSearchTitleMovie;
    // }
  }
};
</script>

<style scoped>
.movie-notfound {
  margin-bottom: 8rem;
  margin-top: 1rem;
  margin-left: 0.5rem !important;
  color: blanchedalmond;
}
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
