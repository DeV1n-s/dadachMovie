<template>
  <div class="container">
    <div id="showcase" dir="ltr">
      <div class="container">
        <div class="carousel-head">
          <b-carousel
            id="carousel-fade"
            style="text-shadow: 0px 0px 2px #000"
            fade
            indicators
            img-width="1024"
            img-height="480"
          >
            <b-carousel-slide
              v-for="movie in sliderData"
              :key="movie.id"
              :caption="movie.title"
              :img-src="movie.bannerImage"
            ></b-carousel-slide>
          </b-carousel>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      sliderData: []
    };
  },
  methods: {
    getSliderMovie() {
      axios.get('api/movies?PageSize=3').then(res => {
        this.sliderData = res.data.items;
        console.log(this.sliderData);
      });
    }
  },
  mounted() {
    this.getSliderMovie();
  }
};
</script>

<style scoped></style>
