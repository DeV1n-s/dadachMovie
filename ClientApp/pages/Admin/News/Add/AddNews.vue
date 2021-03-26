<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <h3 class="mt-2">افزودن خبر</h3>
            <!--  newsForm -->
            <news-form />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>
<script>
import AdminFooter from '../../../../components/Admin/AdminFooter.vue';
import AdminNav from '../../../../components/Admin/AdminNav.vue';
import AdminSide from '../../../../components/Admin/AdminSide.vue';
import NewsForm from '../../../../components/Forms/NewsForm.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, NewsForm }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
