<template>
  <div class="topbar-filter">
    <label>
      تعداد فیلم :
      <span class="length"> {{ MovieLists.length }} </span>
    </label>
    <label>چینش بر اساس :</label>
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
.length {
  color: bisque !important;
}
</style>
