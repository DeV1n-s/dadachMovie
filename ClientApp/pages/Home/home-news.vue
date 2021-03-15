<template>
  <div class="container home-news-grid">
    <div class="home-news">
      <h4 class="mr-0 mb-3">
        <strong
          ><i class="fa fa-newspaper-o" aria-hidden="true"></i> اخبار</strong
        >
      </h4>
      <section id="work-a" class="text-center py-3 mr-1">
        <div class="container">
          <div class="items">
            <div class="item">
              <div class="item-image">
                <img
                  src="https://valamovie.art/wp-content/uploads/pedro-pascal.jpg"
                  alt=""
                />
              </div>
              <div class="item-text">
                <div class="item-text-wrap">
                  <h5 class="item-text-category">خبر جدید و قشنگ</h5>
                  <p class="item-text-title">اخبار جدید سینما</p>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-image">
                <img
                  src="https://cdn.zoomg.ir/2021/1/rami-malek-wallpaper.jpg?w=768"
                  alt=""
                />
              </div>
              <div class="item-text">
                <div class="item-text-wrap">
                  <p class="item-text-category">طراحی مفهومی</p>
                  <h2 class="item-text-title">Beziar Curve</h2>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-image">
                <img
                  src="https://cdn.zoomg.ir/2021/1/zoe-saldana-as-nyota-uhura-1920x1080-xtrafondos.com.jpg"
                  alt=""
                />
              </div>
              <div class="item-text">
                <div class="item-text-wrap">
                  <p class="item-text-category">عکاسی</p>
                  <h2 class="item-text-title">Dock Ponder</h2>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-image">
                <img
                  src="https://cdn.zoomg.ir/2021/1/mando-baby-yoda.jpg"
                  alt=""
                />
              </div>
              <div class="item-text">
                <div class="item-text-wrap">
                  <p class="item-text-category">وب اپ</p>
                  <h2 class="item-text-title">Resturant App</h2>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-image">
                <img
                  src="https://newsmedia.tasnimnews.com/Tasnim/Uploaded/Image/1399/10/20/1399102012090280721988514.jpeg"
                  alt=""
                />
              </div>
              <div class="item-text">
                <div class="item-text-wrap">
                  <p class="item-text-category">شبکه های اجتماعی</p>
                  <h2 class="item-text-title">FriendFeed</h2>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
h4 {
  padding: 10px;
  padding-left: 25px;
  color: #ccc;
  margin: 0;
}
h4 strong {
  z-index: 2;
  background: #24282f;
  padding: 4px 8px;
}
h4 span {
  font-size: 0.7em;
  color: #aaa;
  margin-left: 10px;
}
h4:after {
  content: '';
  z-index: 1;
  bottom: 50%;
  margin-bottom: -2px;
  height: 2px;
  left: 0;
  right: 0;
  background: #1f63d8;
}
.item {
  margin: 0.15rem;
  border-radius: 5px;
  box-shadow: 1px 1px 1px 1px #8888;
}
</style>
