<template>
  <div>
    <div class="hero user-hero">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="hero-ct">
              <h1>دانیال شکوه منش</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="page-single">
      <div class="container">
        <div class="row ipad-width">
          <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="user-information">
              <div class="user-img">
                <a href="#"
                  ><img
                    src="http://localhost:5000/people/3d582288-f039-4c56-aa4e-38670b0a73a9.jpg"
                    alt=""/><br
                /></a>
                <a href="#" class="redbtn">تغییر عکس پروفایل</a>
              </div>
              <div class="user-fav">
                <p>جزئیات</p>
                <ul>
                  <li class="active"><a href="userprofile.html">پروفایل</a></li>
                  <li>
                    <a href="userfavoritelist.html">فیلم های مورد علاقه </a>
                  </li>
                </ul>
              </div>
              <div class="user-fav">
                <ul>
                  <li><a href="#">تغییر کلمه عبور</a></li>
                  <li><a href="#">خارج شدن</a></li>
                </ul>
              </div>
            </div>
          </div>
          <div class="col-md-9 col-sm-12 col-xs-12">
            <div class="form-style-1 user-pro" action="#">
              <form action="#" class="user">
                <h4>جزئیات حساب</h4>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label>نام کاربری</label>
                    <input type="text" placeholder="DeV1" />
                  </div>
                  <div class="col-md-6 form-it">
                    <label>پست الکترونیکی</label>
                    <input
                      type="text"
                      placeholder="danialshokouhmanesh@gmail.com"
                    />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label>نام</label>
                    <input type="text" placeholder="دانیال " />
                  </div>
                  <div class="col-md-6 form-it">
                    <label>نام خانوادگی</label>
                    <input type="text" placeholder="شکوه منش" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label>کشور</label>
                    <select>
                      <option value="united">ایران</option>
                      <option value="saab">سایر</option>
                    </select>
                  </div>
                  <div class="col-md-6 form-it">
                    <label>شهر</label>
                    <select>
                      <option value="united">کرج</option>
                      <option value="saab">دیگر شهر ها</option>
                    </select>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <input class="submit" type="submit" value="ذخیره" />
                  </div>
                </div>
              </form>
              <form action="#" class="password">
                <h4>تغییر رمز عبور</h4>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label>رمز عبور قبلی</label>
                    <input type="text" placeholder="**********" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label>رمز عبور جدید</label>
                    <input type="text" placeholder="***************" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6 form-it">
                    <label> تایید رمز عبور جدید</label>
                    <input type="text" placeholder="*************** " />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-2">
                    <input class="submit" type="submit" value="تغییر" />
                  </div>
                </div>
              </form>
            </div>
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
