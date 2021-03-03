<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <request-app />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import AdminNav from '../../../components/Admin/AdminNav.vue';
import AdminFooter from '../../../components/Admin/AdminFooter.vue';
import AdminSide from '../../../components/Admin/AdminSide.vue';
import RequestApp from './RequestApp.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, RequestApp }
};
</script>

<style></style>
