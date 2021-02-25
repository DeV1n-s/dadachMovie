<template>
  <div id="home-section" dir="rtl">
    <nav-bar />
    <side-bar />
    <div class="main">
      <search-box class="mt-1" />
      <home-slider />

      <hr />
      <soon-movie />
      <hr />
      <in-theater />
      <hr />
      <series-calender />
      <hr />
      <home-news />

      <footer-app />
    </div>
  </div>
</template>

<script>
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
import SideBar from '../../components/SideBar.vue';
import HomeSlider from './home-slider.vue';
import InTheater from './in-theater.vue';
import HomeNews from './home-news';
import SoonMovie from './soon-movie';
import SearchBox from './Search-Box';
import SeriesCalender from './series-calender.vue';
export default {
  components: {
    FooterApp,
    HomeNews,
    NavBar,
    SideBar,
    HomeSlider,
    InTheater,
    SoonMovie,
    SearchBox,
    SeriesCalender
  }
};
</script>

<style scoped>
section#home-heading {
  width: 55%;
  margin-right: 20.5%;
}
b-carousel {
  width: 100%;
}
.carousel-head {
  width: 98%;
}
</style>
