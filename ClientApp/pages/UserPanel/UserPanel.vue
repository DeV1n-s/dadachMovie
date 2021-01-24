<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <h3 class="mt-2">لیست کاربران</h3>
            <user-table />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>
<script>
import AdminFooter from '../../components/Admin/AdminFooter.vue';
import AdminNav from '../../components/Admin/AdminNav.vue';
import AdminSide from '../../components/Admin/AdminSide.vue';
import UserTable from './UserTable.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, UserTable }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
