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
                <option value="1"><span>نام</span> </option>
                <option value="2"><span>سن</span> </option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="people-list-grid">
      <div class="container">
        <main class="page-content">
          <div
            class="card"
            v-for="cast in Cast"
            :key="cast.id"
            :style="{ backgroundImage: `url('${cast.picture}')` }"
            style="background-size: 240px 350px;"
          >
            <div class="content">
              <h2 class="title">{{ cast.name }}</h2>
              <p class="copy">
                {{ cast.shortBio }}
              </p>
              <nuxt-link
                class="genre-name-list"
                :to="{ name: 'PeopleSingle-id', params: { id: cast.id } }"
              >
                <button class="btn">مشاهده</button>
              </nuxt-link>
            </div>
          </div>
        </main>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  // data() {
  //   return {
  //     Cast: this.$store.getters.GetPeaple
  //   };
  // },
  mounted() {
    this.$store.dispatch('GetPeoples');
    console.log(this.Cast);
  },
  computed: {
    Cast: function() {
      return this.$store.getters.GetPeaple;
    }
  }
};
</script>

<style scoped>
.card {
  background-image: 240px 350px;
}
</style>
