<template>
  <app-header />
  <router-view />
  <app-footer />
</template>

<script>
import appHeader from './components/Header/Header';
import appFooter from './components/Footer';
export default {
  name: 'App',
  components: {
    appHeader,
    appFooter
  }
};
</script>

<style></style>
