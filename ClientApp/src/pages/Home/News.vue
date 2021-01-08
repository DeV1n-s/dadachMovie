<template>
  <div class="latestnew full-width">
    <div class="row">
      <div class="col-md-9">
        <div class="ads adsv2">
          <img src="images/uploads/ads2.png" alt="" />
        </div>
        <div class="title-hd">
          <h2>آخرین اخبار</h2>
          <a href="bloggrid.html" class="viewall"
            >مشاهده همه اخبار <i class="ion-ios-arrow-right"></i
          ></a>
        </div>
        <div class="latestnewv2">
          <div class="blog-item-style-2">
            <a href="blogdetail.html"
              ><img src="images/uploads/blogv21.jpg" alt=""
            /></a>
            <div class="blog-it-infor">
              <h3>
                <a href="blogdetail.html"
                  >Godzilla: King Of The Monsters Adds O’Shea Jackson Jr</a
                >
              </h3>
              <span class="time">27 Mar 2017</span>
              <p>
                Looks like Kong: Skull Island started a tradition with its
                casting of Straight ...
              </p>
            </div>
          </div>
          <div class="blog-item-style-2">
            <a href="blogdetail.html"
              ><img src="images/uploads/blogv22.jpg" alt=""
            /></a>
            <div class="blog-it-infor">
              <h3>
                <a href="blogdetail.html"
                  >First Official Images of Alicia Vikander As Tomb Raider’s
                  Lara Croft</a
                >
              </h3>
              <span class="time">27 Mar 2017</span>
              <p>
                Aside from the her digital incarnation, the most recognisable
                image of Tomb ...
              </p>
            </div>
          </div>
          <div class="blog-item-style-2">
            <a href="blogdetail.html"
              ><img src="images/uploads/blogv23.jpg" alt=""
            /></a>
            <div class="blog-it-infor">
              <h3>
                <a href="blogdetail.html"
                  >New Spider-Man: Homecoming Poster Finds Peter Parker At
                  Rest</a
                >
              </h3>
              <span class="time">27 Mar 2017</span>
              <p>
                He might be a primary protector of New York City, but at heart,
                Peter Parker is ...
              </p>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-3">
        <div class="sidebar">
          <div class="sb-facebook sb-it">
            <h4 class="sb-title">ما را دنبال کنید</h4>
          </div>

          <div class="sb-facebook sb-it">
            <h4 class="sb-title">250 فیلم برتر IMDB</h4>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  methods: {
    filterImbd() {
      for (let i = 0; i < 5; i++) {
        this.topImbds.push(this.$store.getters.GetTopImbd[i]);
      }
    }
  },
  mounted() {
    this.$store.dispatch('Top250Movies');
    this.filterImbd();
  },
  computed: {
    topImbds: function() {
      return this.$store.getters.GetTopImbd;
    }
  }
};
</script>

<style>
.celebrities {
  padding-bottom: 6rem;
}
</style>
