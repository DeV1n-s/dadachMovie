<template>
  <div class="container" dir="rtl">
    <nav-bar />
    <div class="row mt-2">
      <div class="col-md-9">
        <div class="card news-body-card">
          <div class="card-body mr-2">
            <h5 class="news-title mb-3">
              ساخت سریال لایو اکشن فرنچایز ‘’G.I. Joe’’ تایید شد
            </h5>
            <small class="text-muted mb-2">
              <i class="fa fa-calendar"></i>
              23 مهر 1397
            </small>
            <img
              class="newssingle-img mt-3"
              src="http://localhost:5000/SeedData/newssingle.jpg"
              alt=""
            />
            <small class="d-block mt-4 mb-2">
              <i class="fa fa-user "></i>
              <span class=" news-writer">
                نوشته شده توسط
                <a href="#" class="author-link">
                  دانیال شکوه منش
                </a>
              </span>
              <span class="badge bg-warning text-dark">
                <a href="" class="category-link">سریال های خارجی</a>
              </span>
            </small>

            <p class="news-body">
              پس از انتشار فیلم‌های ‘’G.I Joe: The Rise of Cobra’’ و ‘’G.I. Joe:
              Retaliation’’، کمپانی پارامونت پیکچرز تصمیم گرفت تا با شروع پروسه
              تولید فیلم ‘’Snake Eyes: G.I. Joe Origins’’ و پرداختن به ریشه‌های
              شکل گیری داستان اصلی این فرنچایز، یک ریبوت کامل را دسترس طرفداران
              قرار دهد. فیلم ‘’Snake Eyes: G.I. Joe Origins’’ در ابتدا برای
              انتشار در ماه مارچ ۲۰۲۱ برنامه ریزی شده بود اما به دلیل مشکلات
              ناشی از ویروس COVID-19 انتشار آن به تاریخ ۲۲ اکتبر (۳۰ مهر ۱۴۰۰)
              موکول شد. با این حال این اثر، تنها پروژه‌ای نیست که طرفداران این
              فرنچایز می‌بایست در انتظار آن بمانند. به گزارش وبسایت ددلاین،
              کمپانی آمازون در نظر دارد تا با هم‌کاری کمپانی پارامونت سریال
              جدیدی را براساس فرنچایز ‘’G.I Joe’’ تولید کند. داستان این سریال
              حول شخصیت لیدی جی جریان خواهد داشت اما هنوز اطلاعات چندانی در مورد
              اتفاقات آن در دسترس نیست. براساس گزارش منتشر شده، اریک اولسن
              (Erick Oleson) شورانر فصل سوم سریال ‘’Daredevil’’، به عنوان شورانر
              و تهیه کننده اجرایی در این پروژه حضور خواهد داشت. اگر در خاطرتان
              باشد، در جریان دنباله سینمایی این مجموعه آدرین پالیکی (Adrienne
              Palicki) ایفاگر نقش این شخصیت بوده است اما مشخص نیست که آیا وی در
              این سریال مجددا در قالب شخصیت مذکور بازمی‌گردد یا خیر.
            </p>
            <p class="tag text-primary">
              <i class="fa fa-tag"></i>
              برچسب ها :
            </p>
            <div class="tags">
              <span class="badge bg-light text-dark">سریال</span>
              <span class="badge bg-light text-dark">اخبار</span>

              <span class="badge bg-light text-dark">سینمایی</span>

              <span class="badge bg-light text-dark">دانلود سریال</span>

              <span class="badge bg-light text-dark">اخبار حارجی</span>

              <span class="badge bg-light text-dark">اخبار سینما</span>
              <span class="badge bg-light text-dark">سریال جدید</span>

              <span class="badge bg-light text-dark">فیلم جدید</span>

              <span class="badge bg-light text-dark">داداچ مووی</span>
            </div>
            <div class="comments mt-5">
              <h5 class="text-primary cm-title">
                <i class="fa fa-comments"></i>
                نظرات کاربران
              </h5>
              <div class="y-line"></div>
              <div class="row">
                <div class="col-md-10">
                  <div class="form__group">
                    <textarea
                      id="message"
                      class="form__field"
                      placeholder="نظر خود را بنویسید"
                      rows="2"
                    ></textarea>
                    <label for="message" class="form__label"
                      >نظر خود را بنویسید
                    </label>
                  </div>
                </div>
                <div class="col-md-2">
                  <button class="btn btn-block btn-success">
                    ثبت نظر
                  </button>
                </div>
              </div>
              <div class="cm-card">
                <div class="card mt-2 cm-box">
                  <div class="cm-card-body card-body">
                    <div class="row">
                      <div class="col-md-2">
                        <img
                          src="http://localhost:5000/series/54ba415a-c1d9-4460-aa3d-ebd75ab2788e.jpg"
                          class="img img-rounded img-fluid"
                        />
                        <p class="text-secondary text-center d-flex mt-1">
                          <i class="fa fa-calendar ml-1"></i>
                          25/12/1399
                        </p>
                      </div>
                      <div class="col-md-10">
                        <div class="row">
                          <div class="col-md-4">
                            <strong>احمد مرتضوی</strong>
                          </div>
                          <div class="col-md-8 ">
                            <i
                              class="fa fa-heart text-danger fa-2x ml-2  cursor-pointer float-left"
                            ></i>
                            <i
                              class="fa fa-reply fa-2x ml-3 cursor-pointer float-left"
                            ></i>
                          </div>
                        </div>

                        <div class="row mt-2">
                          <div class="col-md-8">
                            متن کامنت
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
      <div class="col-md-3">
        <div class="card category-card">
          <h5 class="mr-2 mt-1">
            <i class="fa fa-list-alt" aria-hidden="true"></i>

            دسته بندی ها
          </h5>
          <ul>
            <li>
              <i class="fa fa-chevron-left"></i>
              <a href="" class="list-link">
                سینما خارجی
                <span class="  badge-num badge-primary">2</span>
              </a>
            </li>
            <li>
              <i class="fa fa-chevron-left"></i>
              <a href="" class="list-link">
                سینما داخلی
                <span class="  badge-num badge-primary">2</span>
              </a>
            </li>
            <li>
              <i class="fa fa-chevron-left"></i>
              <a href="" class="list-link">
                سریال خارجی
                <span class="  badge-num badge-primary">2</span>
              </a>
            </li>
            <li>
              <i class="fa fa-chevron-left"></i>
              <a href="" class="list-link">
                سریال خارجی
                <span class="  badge-num badge-primary">2</span>
              </a>
            </li>
          </ul>
        </div>
        <div class="card suggest-article-card mt-3">
          <h5 class="mr-2 mt-1">
            <i class="fa fa-newspaper-o"></i>

            مطالب پیشنهادی
          </h5>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
          <div class="row sug-row">
            <div class="col-md-4">
              <a href="" class="d-flex">
                <img
                  src="http://localhost:5000/SeedData/sugnews.jpg"
                  height="40px"
                  width="70px"
                  alt=""
                  class="sug-news-img"
                />
              </a>
            </div>
            <div class="col-md-7">
              <p>ساخت فیلم ‘’Ray Donovan’’ تایید شد</p>
            </div>
          </div>
        </div>
        <div class="card  mt-3">
          <h5 class="mr-2 mt-1">
            <i class="fa fa-tag"></i>

            برچسب ها
          </h5>
          <div class="card-tags mb-2 mr-3">
            <span
              style="
            font-size:18px
            "
              class="badge bg-light text-dark"
              >فیلم جدید</span
            >
            <span style=" font-size:8px" class="badge bg-light text-dark"
              >فیلم جدید</span
            >
            <span class="badge bg-light text-dark">فیلم جدید</span>
            <span class="badge bg-light text-dark">فیلم جدید</span>
            <span class="badge bg-light text-dark">فیلم جدید</span>
            <span class="badge bg-light text-dark">فیلم جدید</span>
          </div>
        </div>
        <div class="card joinus-card mt-3">
          <h5 class="text-white mr-2 mt-2">
            <i class="fa fa-rss"></i>
            به ما بپیوندید
          </h5>
          <p class="text-white mr-1">
            با عضویت در باشگاه اطلاع رسانی ما همواره از آخرین اخبار دنیای سینما
            و سریال مطلع باشید
          </p>

          <nuxt-link class="btn btn-block btn-dark mb-2 " to="/register">
            همین حالا ثبت نام کنید !
          </nuxt-link>
        </div>
      </div>
    </div>
    <footer-app />
  </div>
</template>

<script>
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
export default {
  components: {
    FooterApp,
    NavBar
  }
};
</script>

<style scoped>
.container {
  background-color: #1d2024 !important;
}
.card {
  background-color: rgb(226, 223, 223);
  border-radius: 5px;
}
small {
  font-size: 11px;
}
.badge {
  font-size: 11px;
  padding: 0.2rem;
  border-radius: 6px 0 0 6px;
  box-shadow: 2px 2px 2px 2px #8888;
}
.news-writer {
  color: #444444;
  background: #ffffff;
  text-shadow: 1px 0px 1px #cccccc, 0px 1px 1px #eeeeee, 2px 1px 1px #cccccc,
    1px 2px 1px #eeeeee, 3px 2px 1px #cccccc, 2px 3px 1px #eeeeee,
    4px 3px 1px #cccccc, 3px 4px 1px #eeeeee, 5px 4px 1px #cccccc,
    4px 5px 1px #eeeeee, 6px 5px 1px #cccccc, 5px 6px 1px #eeeeee,
    7px 6px 1px #cccccc;
}
.author-link {
  text-decoration: none;
  transition: all 0.6s;
}
.author-link:hover {
  font-size: 13px;
}
.news-body {
  font-size: 13px;
}
.category-link {
  color: #1d2024;
  text-decoration: none;
  transition: all 0.6s;
}

.category-link:hover {
  font-size: 13px;
}

.news-title {
  color: transparent;
  background: #4b4a4a;
  -webkit-background-clip: text;
  -moz-background-clip: text;
  background-clip: text;
  text-shadow: 0px 2px 2px rgba(199, 198, 198, 0.5);
}
.newssingle-img {
  max-width: 99%;
  max-height: 48%;

  box-shadow: 2.5px 2.5px 2.5px 2.5px #8888;
  border-radius: 10px;
}
ul li {
  list-style: none;
  border-bottom: 1.5px dotted #1d2024;
  padding-top: 1rem;
  padding-bottom: 0.4rem;
  font-weight: bold;
}
ul li:hover {
  color: red;
}
.list-link {
  color: #1d2024;
  text-decoration: none;
  font-size: 13px;
}
.list-link:hover {
  color: red;
}
.category-card {
  padding-left: 1rem;
}
.badge-num {
  position: absolute;
  padding: 0px 6px;
  border-radius: 50%;
  transition: all 0.8s;
}
.badge-num:hover {
  padding: 2px 8px;
}
span.badge-num.badge-primary {
  left: 47px;
}
.joinus-card {
  background-color: #f99500;
}
.joinus-card p {
  font-size: 13px;
}
.joinus-card a {
  width: 90%;
  margin-right: 0.7rem;
}
.sug-row {
  margin-right: 0.1px;
}
.sug-news-img {
  border-radius: 5px;
  box-shadow: 2px 2px 2px 2px #8888;
}
p.tag {
  margin-bottom: 3px;
  font-size: 14px;
  color: #444444;
  text-shadow: 1px 0px 1px #cccccc, 0px 1px 1px #eeeeee, 2px 1px 1px #cccccc,
    1px 2px 1px #eeeeee, 3px 2px 1px #cccccc, 2px 3px 1px #eeeeee,
    4px 3px 1px #cccccc, 3px 4px 1px #eeeeee, 5px 4px 1px #cccccc,
    4px 5px 1px #eeeeee, 6px 5px 1px #cccccc, 5px 6px 1px #eeeeee,
    7px 6px 1px #cccccc;
}
.tags .badge {
  border-radius: 4px;
  box-shadow: 0;
}
.card-tags span {
  margin-bottom: 5px;
}
.cm-title {
  color: #444444;
  text-shadow: 1px 0px 1px #cccccc, 0px 1px 1px #eeeeee, 2px 1px 1px #cccccc,
    1px 2px 1px #eeeeee, 3px 2px 1px #cccccc, 2px 3px 1px #eeeeee,
    4px 3px 1px #cccccc, 3px 4px 1px #eeeeee, 5px 4px 1px #cccccc,
    4px 5px 1px #eeeeee, 6px 5px 1px #cccccc, 5px 6px 1px #eeeeee,
    7px 6px 1px #cccccc;
}
.form__group {
  position: relative;
  padding: 15px 0 0;
  margin-top: 4px;
}

.form__field {
  font-family: inherit;
  width: 100%;
  border: 0;
  border-bottom: 1px solid #d2d2d2;
  outline: 0;
  font-size: 16px;
  color: #212121;
  padding: 0px 0;
  background: transparent;
  transition: border-color 0.2s;
}

.form__field::placeholder {
  color: transparent;
}

.form__field:placeholder-shown ~ .form__label {
  font-size: 16px;
  cursor: text;
  top: 20px;
}

label,
.form__field:focus ~ .form__label {
  position: absolute;
  top: 0;
  display: block;
  transition: 0.2s;
  font-size: 12px;
  color: #9b9b9b;
}

.form__field:focus ~ .form__label {
  color: #009788;
}

.form__field:focus {
  padding-bottom: 6px;
  border-bottom: 2px solid #009788;
}
button.btn.btn-success {
  margin-top: 34px;
}
.cm-card {
  width: 80%;
}
.cm-card-body {
  background-color: #eeeeee;
  border-radius: 8px;
  -webkit-box-shadow: 0px 0px 0px 5px #a0a0a0, inset 0px 10px 27px -8px #141414,
    5px 5px 15px 5px rgba(0, 0, 0, 0);
  box-shadow: 0px 0px 0px 5px #a0a0a0, inset 0px 10px 27px -8px #141414,
    5px 5px 15px 5px rgba(0, 0, 0, 0);
}
.img-rounded {
  border-radius: 50%;
}
</style>
