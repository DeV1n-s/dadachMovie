<template>
  <div>
    <div class="celebrity-items">
      <div class="ceb-item" v-for="People in Peoples" :key="People.id">
        <a href="celebritysingle.html"><img :src="People.picture" alt=""/></a>
        <div class="ceb-infor">
          <h2>
            <a href="celebritylist.html">{{ People.name }}</a>
          </h2>
          <span>{{ People.biography }}</span>
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
export default {
  data() {
    return {
      Peoples: this.$store.getters.GetPeaple
    };
  },
  mounted() {
    this.$store.dispatch('GetPeoples');
  }
};
</script>

<style></style>
