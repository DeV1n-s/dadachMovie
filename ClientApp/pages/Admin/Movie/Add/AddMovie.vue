<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <div class="row mt-2">
              <div class="col-md-6">
                <button
                  class="btn btn-block btn-success"
                  :disabled="isMovieMode"
                  @click="isMovieMode = true"
                >
                  افزودن فیلم
                </button>
              </div>
              <div class="col-md-6">
                <button
                  class="btn btn-block btn-success"
                  :disabled="!isMovieMode"
                  @click="isMovieMode = false"
                >
                  افزودن سریال
                </button>
              </div>
            </div>
            <transition name="fade">
              <div v-if="isMovieMode">
                <h3 class="mt-2">افزودن فیلم سینمایی</h3>
                <movie-form />
              </div>
            </transition>
            <transition name="fade">
              <div v-if="!isMovieMode">
                <h3 class="mt-2">افزودن سریال</h3>
                <series-form />
              </div>
            </transition>
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>
<script>
import AdminFooter from '../../../../components/Admin/AdminFooter.vue';
import AdminNav from '../../../../components/Admin/AdminNav.vue';
import AdminSide from '../../../../components/Admin/AdminSide.vue';
import MovieForm from '../../../../components/Forms/MovieForm.vue';
import SeriesForm from '../../../../components/Forms/SeriesForm.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, MovieForm, SeriesForm },
  data() {
    return {
      isMovieMode: true
    };
  }
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
