<template>
  <div class="login-wrapper" id="login-content">
    <div class="login-content">
      <a href="#" class="close">x</a>
      <h3>ورود</h3>
      <form method="post" action="#">
        <div class="row">
          <label for="username">
            نام کاربری:
            <input type="text" name="username" id="username" />
          </label>
        </div>

        <div class="row">
          <label for="password">
            رمز عبور:
            <input
              type="password"
              name="password"
              id="password"
              placeholder="******"
            />
          </label>
        </div>
        <div class="row">
          <div class="remember">
            <div>
              <input type="checkbox" name="remember" value="Remember me" /><span
                >مرا به خاطر بسپار</span
              >
            </div>
            <a href="#">فراموشی رمز عبور</a>
          </div>
        </div>
        <div class="row">
          <button type="submit">وارد شوید</button>
        </div>
      </form>
      <div class="row">
        <p>شبکه های اجتماعی ما</p>
        <div class="social-btn-2">
          <a class="fb" href="#"><i class="ion-social-facebook"></i>فیسبوک </a>
          <a class="tw" href="#"><i class="ion-social-twitter"></i>تویتر</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
