<template>
  <div class="col-md-9 col-sm-12 col-xs-12">
    <div class="row">
      <div
        class="col-md-4 col-sm-12 col-xs-12"
        v-for="Post in PostData"
        :key="Post"
      >
        <div class="blog-item-style-2">
          <router-link :to="{ name: 'NewsSingle', params: { id: Post.id } }"
            ><img :src="Post.img" alt=""
          /></router-link>
          <div class="blog-it-infor">
            <h3>
              <router-link
                :to="{ name: 'NewsSingle', params: { id: Post.id } }"
                >{{ Post.shortPara }}</router-link
              >
            </h3>
            <span class="time">تاریخ</span>
          </div>
        </div>
      </div>
    </div>
    <ul class="pagination">
      <li class="icon-prev">
        <a href="#"><i class="ion-ios-arrow-left"></i></a>
      </li>
      <li class="active"><a href="#">1</a></li>
      <li><a href="#">2</a></li>
      <li><a href="#">3</a></li>
      <li><a href="#">4</a></li>
      <li><a href="#">...</a></li>
      <li><a href="#">21</a></li>
      <li><a href="#">22</a></li>
      <li class="icon-next">
        <a href="#"><i class="ion-ios-arrow-right"></i></a>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      PostData: this.$store.getters.GetPosts
    };
  }
};
</script>

<style scoped>
col-md-1,
.col-md-2,
.col-md-3,
.col-md-4,
.col-md-5,
.col-md-6,
.col-md-7,
.col-md-8,
.col-md-9,
.col-md-10,
.col-md-11,
.col-md-12 {
  float: right;
}
</style>
