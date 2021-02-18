<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <h3 class="mt-2">لیست هنرمندان</h3>
            <people-table />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>
<script>
import AdminFooter from '../../../components/Admin/AdminFooter.vue';
import AdminNav from '../../../components/Admin/AdminNav.vue';
import AdminSide from '../../../components/Admin/AdminSide.vue';
import PeopleTable from './PeopleTable.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, PeopleTable }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
