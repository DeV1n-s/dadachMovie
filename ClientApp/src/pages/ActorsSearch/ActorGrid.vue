<template>
  <div>
    <h1 v-if="Peoples == ''" class="not-found">متاسفانه موردی یافت نشد :(</h1>
    <div class="celebrity-items">
      <div class="ceb-item" v-for="People in Peoples" :key="People.id">
        <router-link :to="{ name: 'ActorSingle', params: { id: People.id } }"
          ><img :src="People.picture" alt=""
        /></router-link>
        <div class="ceb-infor">
          <h2>
            <router-link
              :to="{ name: 'ActorSingle', params: { id: People.id } }"
              >{{ People.name }}</router-link
            >
          </h2>
          <span
            >{{ People.nationality }}/
            <span v-if="People.isCast"> بازیگر</span>
            <span v-if="People.isCast && People.isDirector">--</span>
            <span v-if="People.isDirector">کارگردان</span>
          </span>

          <p class="short-bio">{{ People.shortBio }}</p>
        </div>
      </div>
    </div>
    <div class="topbar-filter">
      <div class="pagination2">
        <span>صفحه 1 از 6</span>

        <a class="active" href="#">1</a>
        <a href="#">2</a>
        <a href="#">3</a>
        <a href="#">4</a>
        <a href="#">5</a>
        <a href="#">6</a>
        <a href="#"><i class="ion-arrow-right-b"></i></a>
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

      Peoples: []
    };
  },
  mounted() {
    axios
      .get('http://localhost:8080/api/People/filter?Name=' + this.id)
      .then(res => (this.Peoples = res.data));
  }
};
</script>

<style scoped>
img {
  height: 200px !important;
  width: 230px !important;
}
.short-bio {
  width: 280px;
}
.not-found {
  margin-bottom: 8rem;
  color: aliceblue;
}
</style>
