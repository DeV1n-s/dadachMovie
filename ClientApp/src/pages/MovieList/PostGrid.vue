<template>
  <div>
    <div
      class="movie-item-style-2"
      v-for="MovieList in MovieLists"
      :key="MovieList"
    >
      <img :src="MovieList.picture" alt="" />
      <div class="mv-item-infor">
        <h5>
          <router-link
            :to="{ name: 'MovieSingle', params: { id: MovieList.id } }"
          >
            {{ MovieList.title }}
          </router-link>
        </h5>
        <p class="rate">
          <i class="ion-android-star"></i><span>{{ MovieList.rate }}</span> /10
        </p>
        <p class="describe">
          {{ MovieList.shortDescription }}
        </p>
        <p class="run-time">سال انتشار :{{ MovieList.releaseDate }}</p>
        <p>کارگردان : {{ Diractor }}</p>
        <p>
          ستاره ها :
          <span v-for="cast in Cast" :key="cast"
            >{{ cast.personName }} {{ ' ' }}</span
          >
        </p>
        <p>
          ژانر : <span> {{ MovieList.genres[0].name }} </span>
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
export default {
  data() {
    return {
      // MovieLists: this.$store.getters.GetMovies,
      // Cast: this.$store.getters.GetMovies,
      Diractor: []
    };
  },
  mounted() {
    this.$store.dispatch('getMovie');
  },
  computed: {
    MovieLists: function() {
      return this.$store.getters.GetMovies;
    },
    Cast: function() {
      return this.$store.getters.GetMovies;
    }
  }
};
</script>

<style scoped>
h5 a {
  color: rgba(149, 165, 3, 0.897) !important;
  margin-bottom: 5px !important;
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
  margin-left: 1em;
}
</style>
