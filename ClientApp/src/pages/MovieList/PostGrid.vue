<template>
  <div>
    <div class="flex-wrap-movielist">
      <div
        class="movie-item-style-2 movie-item-style-1"
        v-for="MovieList in MovieLists"
        :key="MovieList.id"
      >
        <img class="movie-gird-img" :src="MovieList.picture" alt="" />
        <div class="hvr-inner">
          <router-link
            :to="{ name: 'MovieSingle', params: { id: MovieList.id } }"
          >
            مشاهده <i class="ion-android-arrow-dropright"></i>
          </router-link>
        </div>
        <div class="mv-item-infor">
          <h6>
            <a href="#"> {{ MovieList.title }}</a>
          </h6>
          <h5>{{ MovieList.genres[0].name }}</h5>
          <p class="rate">
            <i class="ion-android-star"></i
            ><span>{{ MovieList.rate }}</span> /10
          </p>
        </div>
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
.flex-wrap-movielist {
  margin-right: 0rem;
}
h5 {
  color: rgb(94, 87, 87);
}
p {
  padding: 0;
}
.movie-gird-img {
  border-radius: 20px;
}
.hvr-inner {
  margin-right: 2.9767rem;
}
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
