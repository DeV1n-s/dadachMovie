<template>
  <div>
    <div class="hero common-hero">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="hero-ct">
              <h1>اخبار</h1>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="page-single">
      <div class="container">
        <div class="row">
          <news-grid />
          <search-news />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import SearchNews from './SearchNews.vue';
import NewsGrid from './NewsGrid.vue';
export default {
  components: { SearchNews, NewsGrid }
};
</script>

<style></style>
