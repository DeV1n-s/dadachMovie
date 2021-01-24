<template>
  <div dir="rtl">
    <div class="col-md-3 mt-3">
      <div class="card text-center bg-primary text-white mb-3">
        <div class="card-body">
          <h3>فیلم ها</h3>
          <h4 class="display-4"><i class="fa fa-film"></i> 4</h4>
          <a href="categories.html" class="btn btn-outline-light btn-sm"
            >مشاهده</a
          >
        </div>
      </div>
      <div class="card text-center bg-success text-white mb-3">
        <div class="card-body">
          <h3>هنرمندان</h3>
          <h4 class="display-4">
            <i class="fa fa-eercast ml-1"></i>{{ peopleCount }}
          </h4>
          <nuxt-link to="/PeoplePanel" class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
      <div class="card text-center bg-warning text-white mb-3">
        <div class="card-body">
          <h3></h3>
          <h4 class="display-4 ">
            اخبار
            <span class="d-block"> <i class="fa fa-pencil "></i> 6 </span>
          </h4>
          <a href="posts.html" class="btn btn-outline-light btn-sm">مشاهده</a>
        </div>
      </div>
      <div class="card text-center bg-danger text-white mb-3">
        <div class="card-body">
          <h3>کاربران</h3>
          <h4 class="display-4">
            <i class="fa fa-users"></i> {{ usersCount }}
          </h4>
          <nuxt-link to="/userpanel" class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      usersCount: '',
      token: ''
    };
  },
  methods: {
    getUsers() {
      axios
        .get('/api/accounts/Users', {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          this.usersCount = res.data.totalItems;
        });
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    this.$store.dispatch('GetPeoples');
    this.getUsers();
  },
  computed: {
    peopleCount: function() {
      return this.$store.getters.GetPeopleCount;
    }
  }
};
</script>

<style scoped>
.card {
  width: 200px;
}
</style>
