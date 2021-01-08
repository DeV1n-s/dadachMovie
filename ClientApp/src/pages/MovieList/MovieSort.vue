<template>
  <div class="topbar-filter">
    <label>
      تعداد فیلم :
      <span class="length"> {{ MovieLists.length }} </span>
    </label>
    <label class="mr-6">چینش بر اساس :</label>
    <select>
      <option value="popularity">تاریخ</option>
      <option value="popularity">اسم</option>
      <option value="rating">نمره</option>
    </select>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch('getMovie');
  },
  computed: {
    MovieLists: function() {
      return this.$store.getters.GetMovies;
    }
  }
};
</script>

<style scoped>
label {
  margin-right: 2rem;
}
.length {
  color: bisque !important;
}
.mr-6 {
  margin-right: 25rem;
}
</style>
