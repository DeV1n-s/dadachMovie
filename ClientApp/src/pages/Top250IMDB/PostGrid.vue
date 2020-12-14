<template>
  <div>
    <div
      class="movie-item-style-2"
      v-for="MovieList in topImbds"
      :key="MovieList"
    >
      <img :src="MovieList.image" alt="" />
      <div class="mv-item-infor">
        <h6>
          <router-link
            :to="{ name: 'Top250Single', params: { id: MovieList.id } }"
          >
            {{ MovieList.title }}
          </router-link>
        </h6>
        <p class="rate">
          <i class="ion-android-star"></i
          ><span>{{ MovieList.imDbRating }}</span> /10
        </p>
        <h6 class="rank">رتبه {{ MovieList.rank }}</h6>
        <p class="describe">
          {{ MovieList.fullTitle }}
        </p>
        <p class="run-time">
          <span>سال انتشار :{{ MovieList.year }}</span>
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
      topImbds: []
    };
  },
  methods: {
    filterImbd() {
      for (let i = 0; i < 10; i++) {
        this.topImbds.push(this.$store.getters.GetTopImbd[i]);
      }
    }
  },
  mounted() {
    this.$store.dispatch('Top250Movies');
    this.filterImbd();
  }
};
</script>

<style scoped>
.rank {
  padding-bottom: 1rem;
  padding-top: 1rem;
  color: aliceblue;
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
