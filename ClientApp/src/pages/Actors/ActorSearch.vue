<template>
  <div class="col-md-3 col-xs-12 col-sm-12">
    <div class="sidebar">
      <div class="searh-form">
        <h4 class="sb-title">Search celebrity</h4>
        <form class="form-style-1 celebrity-form" action="#">
          <div class="row">
            <div class="col-md-12 form-it">
              <label>hsl fhcd'v</label>
              <input type="text" placeholder="Enter keywords" />
            </div>

            <div class="col-md-12 form-it">
              <label>جنسیت</label>
              <select>
                <option value="range">زن</option>
                <option value="saab">مرد</option>
              </select>
            </div>

            <div class="col-md-12 ">
              <input class="submit" type="submit" value="ثبت" />
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
          <a href="#"><img src="images/uploads/ava2.jpg" alt=""/></a>
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
export default {};
</script>

<style></style>
