<template>
  <div id="home-section" dir="rtl">
    <nav-bar />
    <side-bar />
    <div class="main">
      <home-slider />

      <section id="home-heading" class="p-5">
        <div class="conrainer">
          <div class="dark-overlay">
            <div class="row">
              <div class="col">
                <div class="container pt-5">
                  <p d-none d-md-block>داداچ مویی محبوب ترین وبسایت فیلم</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <hr />
      <soon-movie />
      <hr />
      <in-theater />
      <hr />
      <home-news />

      <footer-app />
    </div>
  </div>
</template>

<script>
import FooterApp from "../../components/FooterApp.vue";
import NavBar from "../../components/NavBar.vue";
import SideBar from "../../components/SideBar.vue";
import HomeSlider from "./home-slider.vue";
import InTheater from "./in-theater.vue";
import HomeNews from "./home-news";
import SoonMovie from "./soon-movie";
export default {
  components: {
    FooterApp,
    HomeNews,
    NavBar,
    SideBar,
    HomeSlider,
    InTheater,
    SoonMovie
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
