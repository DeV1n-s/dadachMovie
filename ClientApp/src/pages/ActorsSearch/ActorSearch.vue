<template>
  <div class="col-md-3 col-xs-12 col-sm-12">
    <div class="sidebar">
      <div class="searh-form">
        <h4 class="sb-title">جست و جوی بازیگر</h4>
        <form class="form-style-1 celebrity-form" action="#">
          <div class="row">
            <div class="col-md-12 form-it">
              <label>نام بازیگر</label>
              <input
                type="text"
                placeholder="کلین مورفی"
                v-model="searchTitle"
              />
            </div>
            <p class="danger-red" v-if="!isSearchValid">
              لطفا نام بازیگر را وارد کنید
            </p>
            <div class="col-md-12 ">
              <router-link
                :to="{ name: 'ActorListsSearch', params: { id: cSearchTitle } }"
              >
                <input
                  class="submit"
                  type="submit"
                  value="جست و جو"
                  @click="submitSearch"
                />
              </router-link>
            </div>
          </div>
        </form>
      </div>
      <div class="ads"></div>
      <div class="celebrities">
        <h4 class="sb-title">بازیگران پیشنهادی</h4>
        <div class="celeb-item">
          <a href="#"><img src="images/uploads/ava1.jpg" alt=""/></a>
          <div class="celeb-author">
            <h6><a href="#">Samuel N. Jack</a></h6>
            <span>Actor</span>
          </div>
        </div>
        <div class="celeb-item">
          <div class="celeb-author">
            <h6><a href="#">Benjamin Carroll</a></h6>
            <span>Actor</span>
          </div>
        </div>
        <div class="celeb-item">
          <a href="#"><img src="images/uploads/ava3.jpg" alt=""/></a>
          <div class="celeb-author">
            <h6><a href="#">Beverly Griffin</a></h6>
            <span>Actor</span>
          </div>
        </div>
        <div class="celeb-item">
          <a href="#"><img src="images/uploads/ava4.jpg" alt=""/></a>
          <div class="celeb-author">
            <h6><a href="#">Justin Weaver</a></h6>
            <span>Actor</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isSearchValid: true,
      searchTitle: '',
      cSearchTitle: '/'
    };
  },
  methods: {
    submitSearch() {
      if (this.searchTitle === '') {
        this.isSearchValid = false;
        return;
      } else this.cSearchTitle = this.searchTitle;
    }
  }
};
</script>

<style>
.danger-red {
  color: rgb(224, 16, 16);
}
</style>
