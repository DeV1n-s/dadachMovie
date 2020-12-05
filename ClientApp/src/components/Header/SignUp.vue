<template>
  <div class="login-wrapper" id="signup-content">
    <div class="login-content">
      <a href="#" class="close">x</a>
      <h3>ثبت نام</h3>
      <form method="post" action="#">
        <div class="row">
          <label for="username-2">
            نام کاربری:
            <input type="text" name="username" id="username-2" />
          </label>
        </div>

        <div class="row">
          <label for="email-2">
            پست الکترونیکی :
            <input type="password" name="email" id="email-2" />
          </label>
        </div>
        <div class="row">
          <label for="password-2">
            رمز عبور :
            <input type="password" name="password" id="password-2" />
          </label>
        </div>
        <div class="row">
          <label for="repassword-2">
            تکرار رمز عبور
            <input type="password" name="password" id="repassword-2" />
          </label>
        </div>
        <div class="row">
          <button type="submit">ثبت نام</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
