<template>
  <div>
    <app-header />
    <router-view />
    <app-footer />
  </div>
</template>

<script>
import appHeader from './components/Header/Header';
import appFooter from './components/Footer';
export default {
  name: 'HomeContainer',
  components: {
    appHeader,
    appFooter
  },
  methods: {
    log() {
      console.log('hello');
      this.$store.dispatch('autoLog');
    }
  },
  created() {
    this.log();
  }
};
</script>

<style></style>
