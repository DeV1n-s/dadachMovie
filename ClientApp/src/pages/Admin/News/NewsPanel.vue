<template>
  <div class="movie-items mt-5">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8"></div>
        <h2>لیست خبرها</h2>

        <table class="table table-hover">
          <thead class="font-size">
            <tr>
              <th>#</th>
              <th>عنوان خبر</th>
              <th>دسته بندی</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(News, index) in newsData" :key="News">
              <td class="t-num">{{ index }}</td>
              <td>{{ News.title }}</td>
              <td>{{ News.category }}</td>

              <td>
                <button class="btn btn-lg btn-warning">ویرایش</button>
                <button class="btn btn-lg btn-danger">حذف</button>
              </td>
            </tr>
          </tbody>
        </table>
        <router-link to="/NewsAdd">
          <button class="btn btn-success btn-block m-x">
            افزودن خبر جدید
          </button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newsData: this.$store.getters.GetPosts
    };
  }
};
</script>

<style scoped>
.row.ipad-width {
  margin-top: 30rem;
}
table {
  background-color: navajowhite;
}
caption,
th,
td {
  font-weight: normal;
  text-align: right;
}
h2 {
  color: navajowhite;
  margin-bottom: 8px;
}
.t-num {
  width: 20%;
}
.font-size {
  font-size: 2rem;
}
.btn {
  margin: 0.5rem;
}
</style>
