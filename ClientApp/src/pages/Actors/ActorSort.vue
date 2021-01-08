<template>
  <div class="topbar-filter">
    <label>
      تعداد بازیگران :
      <span class="length">{{ Peoples.length }} </span>
    </label>
    <label class="mr-6">چینش بر اساس :</label>
    <select>
      <option value="popularity">سن</option>
      <option value="popularity">اسم</option>
    </select>
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
