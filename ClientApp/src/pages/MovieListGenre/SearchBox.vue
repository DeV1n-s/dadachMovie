<template>
  <div class="col-md-4 col-sm-12 col-xs-12">
    <div class="sidebar">
      <div class="searh-form">
        <h4 class="sb-title">جست و جو برای فیلم</h4>
        <form class="form-style-1" action="#">
          <div class="row">
            <div class="col-md-12 form-it">
              <label>نام فیلم </label>
              <input type="text" placeholder="کلمه کلیدی وارد کنید " />
            </div>
            <div class="col-md-12 form-it">
              <label>ژانر</label>
              <div class="group-ip">
                <select name="skills" multiple="" class="ui fluid dropdown">
                  <option value="">ژانر مورد نظرتون را انتخاب کنید </option>
                  <option value="Action1">اکشن</option>
                  <option value="Action1">اکشن</option>
                  <option value="Action1">اکشن</option>
                </select>
              </div>
            </div>
            <div class="col-md-12 form-it">
              <label>امتیاز</label>

              <input type="text" placeholder="امتیاز وارد کنید " />
            </div>
            <div class="col-md-12 form-it">
              <label>سال انتشار</label>
              <div class="row">
                <div class="col-md-6">
                  <select>
                    <option value="range">تا</option>
                    <option value="number">20</option>
                    <option value="number">30</option>
                    <option value="number">40</option>
                  </select>
                </div>
                <div class="col-md-6">
                  <select>
                    <option value="range">از</option>
                    <option value="number">10</option>
                    <option value="number">20</option>
                    <option value="number">30</option>
                  </select>
                </div>
              </div>
            </div>

            <div class="col-md-12 ">
              <input class="submit" type="submit" value="ثبت" />
            </div>
          </div>
        </form>
        <div class="sb-cate sb-it">
          <h4 class="sb-title">ژانر ها</h4>
          <ul>
            <li v-for="GenreList of GenreLists" :key="GenreList.id">
              <router-link
                :to="{ name: 'MovieListGenre', params: { id: GenreList.id } }"
                >{{ GenreList.name }}</router-link
              >
            </li>
          </ul>
        </div>
      </div>
      <div class="ads"></div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      GenreLists: this.$store.getters.GetGenres
    };
  },
  mounted() {
    this.$store.dispatch('GetGenres');
  }
};
</script>

<style></style>
