<template>
  <div class="movie-items mt-5">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8"></div>
        <h2>لیست فیلم ها</h2>

        <table class="table table-hover">
          <thead class="font-size">
            <tr>
              <th>#</th>
              <th>نام بازیگر</th>
              <th>تاریخ تولد</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="People in Peoples" :key="People.id">
              <td class="t-num">{{ People.id }}</td>
              <td>{{ People.name }}</td>
              <td>{{ People.dateOfBirth }}</td>
              <td>
                <button class="btn btn-lg btn-warning">ویرایش</button>
                <button
                  class="btn btn-lg btn-danger"
                  @click="deleteButton(People.id)"
                >
                  حذف
                </button>
              </td>
            </tr>
          </tbody>
        </table>
        <router-link to="/CastAdd">
          <button class="btn btn-success btn-block m-x">
            افزودن بازیگر جدید
          </button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      Peoples: this.$store.getters.GetPeaple
    };
  },
  methods: {
    deleteButton(id) {
      console.log(id);
      axios
        .delete('http://localhost:8080/api/people/' + id)
        .then(res => console.log(res));
    }
  },
  mounted() {
    this.$store.dispatch('GetPeoples');
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
