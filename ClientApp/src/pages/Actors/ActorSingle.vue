<template>
  <div>
    <div class="hero hero3">
      <div class="container">
        <div class="row">
          <div class="col-md-12"></div>
        </div>
      </div>
    </div>
    <div class="page-single movie-single cebleb-single">
      <div class="container">
        <div class="row ipad-width">
          <div class="col-md-4 col-sm-12 col-xs-12">
            <div class="mv-ceb">
              <img :src="People.picture" alt="" />
            </div>
          </div>
          <div class="col-md-8 col-sm-12 col-xs-12">
            <div class="movie-single-ct">
              <h1 class="bd-hd">{{ People.name }}</h1>
              <div class="movie-tabs">
                <div class="tabs">
                  <div class="tab-content">
                    <div id="overviewceb" class="tab active">
                      <div class="row">
                        <div class="col-md-8 col-sm-12 col-xs-12">
                          <p>
                            {{ People.shortBio }}
                          </p>
                          <p>
                            {{ People.biography }}
                          </p>
                        </div>
                        <div class="col-md-4 col-xs-12 col-sm-12">
                          <div class="sb-it">
                            <h6>اسم کامل</h6>
                            <p>
                              <a href="#">{{ People.name }}</a>
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>تاریخ تولد</h6>
                            <p>{{ People.dateOfBirth }}</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div id="mediaceb" class="tab">
                      <div class="row">
                        <div class="rv-hd">
                          <div></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    People() {
      return this.$store.getters.Peoples(parseInt(this.$route.params.id));
    }
  }
};
</script>

<style></style>
