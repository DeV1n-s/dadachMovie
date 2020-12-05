<template>
  <div class="hero common-hero">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <div class="hero-ct">
            <h1>
              لیست فیلم ها
            </h1>
            <ul class="breadcumb"></ul>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="page-single movie_list">
    <div class="container">
      <div class="row ipad-width2">
        <div class="col-md-8 col-sm-12 col-xs-12">
          <movieSort />
          <postGrid />
        </div>
        <searchBox />
        <!--  -->
      </div>
    </div>
  </div>
</template>

<script>
import movieSort from './MovieSort';
import searchBox from './SearchBox';
import postGrid from './PostGrid';
export default {
  data() {
    return {};
  },
  components: {
    movieSort,
    searchBox,
    postGrid
  }
};
</script>

<style></style>
