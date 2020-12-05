<template>
  <div>
    <div
      class="movie-item-style-2"
      v-for="MovieList in MovieLists"
      :key="MovieList"
    >
      <img :src="MovieList.img" alt="" />
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
          {{ MovieList.shortPara }}
        </p>
        <p class="run-time">
          <span>سال انتشار :{{ MovieList.Release }}</span>
        </p>
        <p>کارگردان : {{ MovieList.Director }}</p>
        <p>ستاره ها : {{ MovieList.Cast }}</p>
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
      MovieLists: this.$store.getters.GetMovies
    };
  }
};
</script>

<style scoped>
.movie-item-style-2 {
  font-size: 1.75rem;
}
img {
  margin-left: 0.5em;
}
</style>
