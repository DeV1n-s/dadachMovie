<template>
  <div class="hero common-hero">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <div class="hero-ct">
            <h1>لیست بازیگران</h1>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!--  -->

  <div class="page-single">
    <div class="container">
      <div class="row ipad-width2">
        <!--  -->
        <div class="col-md-9 col-sm-12 col-xs-12">
          <!--  -->

          <actor-sort />
          <!--  -->
          <actor-grid />
        </div>
        <!--  -->

        <actor-search />
        <!--  -->
      </div>
    </div>
  </div>
</template>

<script>
import ActorSort from './ActorSort.vue';
import ActorSearch from './ActorSearch.vue';
import ActorGrid from './ActorGrid.vue';

export default {
  components: { ActorSort, ActorSearch, ActorGrid }
};
</script>

<style></style>
