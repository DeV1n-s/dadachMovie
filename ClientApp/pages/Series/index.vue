<template>
  <div dir="rtl">
    <nav-bar />
    <section id="home-section">
      <div class="container">
        <side-bar />
        <div class="main">
          <header id="page-header">
            <div class="container">
              <div class="row">
                <div class="col-md-6 m-auto text-center">
                  <h1>لیست سریال ها</h1>
                </div>
              </div>
            </div>
          </header>
          <series-grid />

          <footer-app />
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
import SeriesGrid from './SeriesGrid.vue';
export default {
  components: {
    NavBar,
    FooterApp,
    SeriesGrid
  }
};
</script>

<style></style>
