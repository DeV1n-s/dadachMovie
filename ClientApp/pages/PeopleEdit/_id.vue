<template>
  <add-people />
</template>

<script>
import AddPeople from './AddPeople';
export default {
  asyncData({ params }) {
    return { id: params.id };
  },
  components: {
    AddPeople
  }
};
</script>

<style></style>
