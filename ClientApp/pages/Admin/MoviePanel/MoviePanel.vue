<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <div class="row mt-1">
              <div class="col-md-6">
                <button
                  class="btn btn-block btn-success"
                  @click="isMovieMode = true"
                  :disabled="isMovieMode"
                >
                  مدیریت فیلم ها
                </button>
              </div>
              <div class="col-md-6">
                <button
                  class="btn btn-block btn-success"
                  @click="isMovieMode = false"
                  :disabled="!isMovieMode"
                >
                  مدیریت سریال ها
                </button>
              </div>
            </div>
            <transition name="fade">
              <movie-table v-if="isMovieMode" />
            </transition>
            <transition name="fade">
              <series-table v-if="!isMovieMode" />
            </transition>
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>
<script>
import AdminFooter from '../../../components/Admin/AdminFooter.vue';
import AdminNav from '../../../components/Admin/AdminNav.vue';
import AdminSide from '../../../components/Admin/AdminSide.vue';
import MovieTable from './MovieTable.vue';
import SeriesTable from './SeriesTable.vue';

export default {
  data() {
    return {
      isMovieMode: true
    };
  },
  components: { AdminNav, AdminFooter, AdminSide, MovieTable, SeriesTable }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
