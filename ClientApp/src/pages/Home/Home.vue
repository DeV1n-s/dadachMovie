<template>
  <div>
    <appHeader />
    <appBody />
    <appNews />
  </div>
</template>

<script>
import appHeader from './Header';
import appBody from './Body';
import appNews from './News';
export default {
  components: {
    appHeader,
    appBody,
    appNews
  }
};
</script>

<style></style>
