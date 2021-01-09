<template>
  <nav class="navbar-default navbar-side" role="navigation">
    <div class="sidebar-collapse">
      <ul class="nav" id="main-menu">
        <li class="text-center">
          <img
            src="people/3d582288-f039-4c56-aa4e-38670b0a73a9.jpg"
            class="user-image img-responsive"
          />
        </li>

        <li>
          <router-link to="/Dashbord" active-class="active-menu">
            داشبورد
          </router-link>
        </li>

        <li>
          <a href="#"> مدیریت کاربران</a>
        </li>
        <li>
          <router-link to="/MoviePanels" active-class="active-menu"
            >مدیریت فیلم ها</router-link
          >
        </li>
        <li>
          <a href="#"> مدیریت اخبار</a>
        </li>
        <li>
          <router-link to="/CastPanels" active-class="active-menu">
            مدیریت افراد
          </router-link>
        </li>
        <li>
          <a href="#"> نظرات کاربران </a>
        </li>
        <li>
          <a href="http://localhost:8080/UserProfile"> ویرایش پروفایل </a>
        </li>
        <li>
          <a href="http://localhost:8080/"> نمایش سایت</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {};
</script>

<style>
router-link {
  margin-right: 5px;
}
</style>
