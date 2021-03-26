<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <h4 class="mt-3">دسته بندی</h4>
            <category-form />
            <!--  News Table -->
            <category-table />
            <h4 class="mt-3">اخبار</h4>
            <!-- News Table -->
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
import CategoryForm from '../../../components/Forms/CategoryForm.vue';
import CategoryTable from './CategoryTable.vue';
import NewsTable from './NewsTable.vue';

export default {
  components: {
    AdminNav,
    AdminFooter,
    AdminSide,
    CategoryForm,
    CategoryTable,
    NewsTable
  }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
