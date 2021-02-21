<template>
  <div>
    <div class="sort-row mr-1">
      <div class="row mr-5">
        <div class="col-md-3">
          <p>مرتب سازی بر اساس :</p>
        </div>
        <div class="col-md 7">
          <div class="sort-select">
            <div class="select">
              <select name="slct" id="slct">
                <option value="1"><span>نمره</span> </option>
                <option value="2"><span>زمان</span> </option>
                <option value="3"><span>تاریخ</span></option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="movie-list-grid">
      <div class="container">
        <div
          class="wrapper mt-3 mb-2"
          v-for="movie in movieData"
          :key="movie.id"
        >
          <nuxt-link
            class="genre-name-list"
            :to="{ name: 'MovieSingle-id', params: { id: movie.id } }"
          >
            <div class="main_card">
              <div class="card_left">
                <div class="img_container">
                  <img :src="movie.picture" alt="" />
                </div>
              </div>
              <div class="card_right mr-1">
                <div class="card_datails mt-2">
                  <h4>نام فیلم : {{ movie.title }}</h4>
                  <div class="card_cat d-block">
                    <p class="year">سال ساخت : {{ movie.releaseDate }}</p>
                    <p class="genre">
                      ژانر : Action | Adventure
                    </p>
                    <p class="time">
                      زمان :
                      {{ movie.lenght }}
                      دقیقه
                    </p>
                  </div>
                  <p class="disc" v-if="movie.shortDescription.length < 90">
                    {{ movie.shortDescription }}
                  </p>
                  <p class="disc" v-else>
                    {{ movie.shortDescription.substring(0, 90) + '..' }}
                  </p>
                </div>
              </div>
            </div>
          </nuxt-link>
        </div>
      </div>
      <div class="pagination">
        <div class="num-container">
          <a href="#">&laquo;</a>
          <nuxt-link
            v-for="p in pagination"
            :key="p"
            active-class="active"
            :to="{ name: 'Movies-Page-id', params: { id: p } }"
            >{{ p }}</nuxt-link
          >
          <a href="#">&raquo;</a>
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
      id: this.$route.params.id,
      movieData: '',
      pageNum: '',
      pagination: []
    };
  },
  methods: {
    async getMovie() {
      await axios.get(`/api/movies?Page=${this.id}&PageSize=6`).then(res => {
        this.movieData = res.data.items;
        this.pageNum = Math.ceil(res.data.totalItems / 6);
        this.pageMaker(this.pageNum);
      });
    },
    pageMaker(p) {
      for (let i = 1; i <= p; i++) {
        this.pagination.push(i);
      }
    }
  },
  mounted() {
    this.getMovie();
  }
};
</script>

<style scoped>
.card_right.mr-1 {
  width: 350px;
}
wrapper:hover {
  scale: 1.5;
}
</style>
