<template>
  <div class="req-body mt-5">
    <div id="login-container">
      <div class="profile-img">
        <img
          src="http://localhost:5000/series/54ba415a-c1d9-4460-aa3d-ebd75ab2788e.jpg"
          alt="rounded"
          class="rounded-circle cursor-pointer"
          height="109"
          width="110"
        />
      </div>

      <h5 class="req-title">
        درخواست پخش فیلم مختار نامه
      </h5>
      <div class="row">
        <div class="col-md-10">
          <div class="description mt-4">
            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با
            استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در
            ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و
            کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی
            در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را
            می طلبد تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی
            الخصوص طراحان خلاقی و فرهنگ پیشرو در زبان فارسی ایجاد کرد. در این
            صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها و
            شرایط سخت تایپ به پایان رسد وزمان مورد نیاز شامل حروفچینی دستاوردهای
            اصلی و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد
            استفاده قرار گیرد.
          </div>
        </div>
        <div class="col-md-2 mt-4 req-side h-100">
          <p class="text-muted mr-1">
            <a href="" class="profile-link">
              Saied-Rezaie
            </a>
          </p>
          <p class="text-muted mr-1">
            سعید رضایان
          </p>
          <p class="text-muted mr-1">
            کاربر ویژه
          </p>
          <p class="text-muted mr-1">
            09xxxxxxxx
          </p>
          <div class="social-icons">
            <img
              src="http://localhost:5000/SocialIcon/WhatsApp.svg"
              height="30px"
              alt=""
              class="cursor-pointer"
            />
            <img
              src="http://localhost:5000/SocialIcon/telegram.svg"
              height="22px"
              alt=""
              class="cursor-pointer"
            />
          </div>
        </div>
      </div>

      <footer>
        <div class="likes">
          <p class="req-footer-text">
            بیست دقیقه پیش || 12:28‍ :2021/01/12
          </p>
        </div>
        <div class="projects">
          <p class="bg-danger req-footer-text px-1">بررسی نشده</p>
        </div>
      </footer>
    </div>
    <transition name="slide-fade">
      <div class="answer-box mt-3 card-body" v-if="isAnswerMode">
        <div class="card-header mb-4">
          <h6>
            <i class="fa fa-check text-success"></i>
            افزودن پاسخ جدید
          </h6>
        </div>

        <textarea
          placeholder="پاسخ خود را بنویسید"
          name=""
          id=""
          cols="80"
          rows="6"
          class="mr-4 form-control"
        ></textarea>
      </div>
    </transition>
    <div class="btns mt-5 mb-4">
      <button
        class="btn btn-success"
        @click="isAnswerMode = true"
        v-if="!isAnswerMode"
      >
        <i class="fa fa-paper-plane btnBlock"></i>
        ثبت پاسخ
      </button>
      <button class="btn btn-success" v-if="isAnswerMode">
        <i class="fa fa-save btnBlock"></i>
        ذخیره تغیرات
      </button>
      <button
        class="btn btn-danger"
        v-if="isAnswerMode"
        @click="isAnswerMode = false"
      >
        <i class="fa fa-arrow-left  btnBlock"></i>
        بازگشت
      </button>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isAnswerMode: false
    };
  }
};
</script>

<style scoped>
/* .req-body {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  font-family: 'Roboto', arial, sans-serif;
  color: #222;
} */

#login-container {
  height: 315px;
  width: 800px;
  padding: 20px;
  border-radius: 5px;
  background: #fffffb;
  position: relative;
  box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.5);
}
#login-container .profile-img {
  height: 100px;
  width: 100px;
  background: url('https://images.unsplash.com/photo-1504933350103-e840ede978d4?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=564&q=80');
  background-size: cover;
  background-position: center;
  position: absolute;
  top: -25px;
  left: -25px;
  border-radius: 50%;
  box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.5);
}
.description {
  font-size: 12.5px;
}
#login-container .description {
  margin-bottom: 20px;
}
#login-container .social {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: calc(100% - 40px);
  margin: 0 auto;
}
#login-container .social a {
  text-align: center;
  border: solid 2px #ff6b6c;
  width: 75px;
  padding: 5px 0;
  border-radius: 5px;
}
#login-container .social a:hover {
  background: #ff6b6c;
  color: white;
  cursor: pointer;
}
#login-container button {
  width: 80%;
  height: 80px;
  font-size: 2rem;
  margin: 30px 10% 0 10%;
  color: #fffffb;
  border: none;
  box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.5);
  border-radius: 5px;
  background: linear-gradient(45deg, #ff6b6c, #ffc145, #ffc145, #ff6b6c);
  background-size: 300% 300%;
  outline: none;
  transition: all 200ms ease-in-out;
}
#login-container button:hover {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5);
  transform: translateY(2px);
  -webkit-animation: gradientBG 1.5s ease-in-out forwards;
  animation: gradientBG 1.5s ease-in-out forwards;
  cursor: pointer;
}
#login-container button:active {
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.5);
  transform: translateY(4px);
}
#login-container footer {
  left: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #5b5f97;
  color: white;
  width: 100%;
  position: absolute;
  bottom: 0;
  height: 30px;
  padding: 0 20px;
  margin-left: -20px;
  border-bottom-left-radius: 5px;
  border-bottom-right-radius: 5px;
}
#login-container footer div {
  display: flex;
}
#login-container footer div .fa-heart {
  color: #ff6b6c;
}
#login-container footer div p:first-child {
  margin-right: 10px;

  padding-right: 10px;
}

@-webkit-keyframes gradientBG {
  0% {
    background-position: 0% 50%;
  }
  100% {
    background-position: 100% 50%;
  }
}
@keyframes gradientBG {
  0% {
    background-position: 0% 50%;
  }
  100% {
    background-position: 100% 50%;
  }
}
.req-title {
  margin-top: 1rem;
}
.req-side {
  border-right: 1px solid gray;
  font-size: 14px;
  height: 100vh;
}
.req-footer-text {
  margin-top: 10px;
}
.projects p {
  border-radius: 7px;
}
.btn {
  -webkit-box-shadow: 5px 5px 5px 0px #000000, inset 4px 4px 15px 0px #000000,
    5px 5px 15px 5px rgba(111, 255, 36, 0);
  box-shadow: 5px 5px 5px 0px #000000, inset 4px 4px 15px 0px #000000,
    5px 5px 15px 5px rgba(111, 255, 36, 0);
}
.answer-box {
  width: 800px;
  padding: 10px;
  border-radius: 5px;
  background: #fffffb;
  position: relative;
  box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.5);
}
textarea {
  width: 740px;
}
.social-icons img {
  transition: 0.7s;
}

.social-icons img:hover {
  transform: scale(1.2);
}
.profile-img img {
  transition: 0.7s;
}

.profile-img img:hover {
  transform: scale(1.3);
}
.profile-link {
  text-decoration: none;
  transition: 0.7s;
}
.profile-link:hover {
  font-size: 13.5px;
  color: #01dffc;
}

.slide-fade-enter-active {
  transition: all 0.5s ease;
}
.slide-fade-leave-active {
  transition: all 0.5s cubic-bezier(1, 0.5, 0.8, 1);
}
.slide-fade-enter, .slide-fade-leave-to
/* .slide-fade-leave-active below version 2.1.8 */ {
  transform: translateX(10px);
  opacity: 0;
}
</style>
