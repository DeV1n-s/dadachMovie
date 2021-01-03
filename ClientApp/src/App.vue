<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
export default {
  methods: {
    log() {
      this.$store.dispatch('autoLog');
    }
  },
  created() {
    this.log();
  }
};
</script>
<script></script>
