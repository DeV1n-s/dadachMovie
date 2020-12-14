<template>
  <div class="topbar-filter">
    <p>تعداد فیلم <span>:15 </span></p>
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
    return {
      MovieLists: this.$store.getters.GetMovies
    };
  },
  mounted() {
    this.$store.dispatch('getMovie');
  }
};
</script>

<style></style>
