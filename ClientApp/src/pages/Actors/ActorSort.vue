<template>
  <div class="topbar-filter">
    <p>
      درکل <span>{{ Peoples.length }} بازیگر</span> پیدا شد
    </p>
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
