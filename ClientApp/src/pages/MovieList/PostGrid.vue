<template>
  <div>
    <div
      class="movie-item-style-2"
      v-for="MovieList in MovieLists"
      :key="MovieList"
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
          <span v-for="cast in Cast" :key="cast"
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
export default {
  data() {
    return {
      MovieLists: this.$store.getters.GetMovies,
      Cast: this.$store.getters.GetMovies,
      Diractor: this.$store.getters.GetMovies[0].directors
    };
  },
  mounted() {
    this.$store.dispatch('getMovie');
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
