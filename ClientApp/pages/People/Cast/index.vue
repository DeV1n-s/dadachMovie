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
                  <h1>لیست بازیگران</h1>
                </div>
              </div>
            </div>
          </header>
          <people-grid />
          <footer-app />
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import FooterApp from "../../../components/FooterApp.vue";
import NavBar from "../../../components/NavBar.vue";
import PeopleGrid from "./PeopleGrid";
export default {
  components: {
    NavBar,
    FooterApp,
    PeopleGrid
  }
};
</script>

<style></style>
