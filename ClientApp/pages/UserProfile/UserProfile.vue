<template>
  <div>
    <nav-bar />
    <section id="home-section">
      <div class="container">
        <div class="main">
          <div class="main-profile">
            <div class="container bootstrap snippets bootdey">
              <div class="row">
                <div class="profile-nav col-md-3">
                  <div class="panel">
                    <div class="user-heading round">
                      <a href="#">
                        <img :src="currentUser.picture" alt="" />
                      </a>
                      <h1>{{ currentUser.firstName }}</h1>
                      <p>{{ currentUser.emailAddress }}</p>
                    </div>

                    <ul class="nav nav-pills nav-stacked">
                      <li class="">
                        <a href="#">
                          <i class="fa fa-user"></i> پروفایل کاربری</a
                        >
                      </li>
                      <li></li>
                      <li>
                        <a href="#">
                          <i class="fa fa-edit"></i> ویرایش پروفایل</a
                        >
                      </li>
                    </ul>
                    <div class="roles">
                      <p>نقش ها :</p>
                      <ul>
                        <li v-for="role in roles" :key="role">{{ role }}e</li>
                      </ul>
                    </div>
                  </div>
                </div>
                <div class="profile-info col-md-9">
                  <div class="panel">
                    <div class="bio-graph-heading">
                      یک شروع سخت بهتر است از یک سختیه بی شروع
                    </div>
                    <div class="panel-body bio-graph-info">
                      <h1>مشخصات</h1>
                      <div class="row">
                        <div class="bio-row">
                          <p><span>نام :</span> {{ currentUser.firstName }}</p>
                        </div>
                        <div class="bio-row">
                          <p>
                            <span>فامیلی : </span> {{ currentUser.lastName }}
                          </p>
                        </div>
                        <div class="bio-row">
                          <p><span>کشور :</span> {{ currentUser.country }}</p>
                        </div>
                        <div class="bio-row">
                          <p><span>تاریخ تولد :</span> 23 مهر 1376</p>
                        </div>

                        <div class="bio-row">
                          <p><span>شماره تماس :</span> 09339689095</p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div>
                    <div class="user-interest">
                      <div class="row">
                        <div class="col-md-6">
                          <div class="panel">
                            <div class="panel-body">
                              <div class="bio-chart">
                                <div
                                  style="display:inline;width:100px;height:100px;"
                                >
                                  <canvas width="100" height="100px"></canvas
                                  ><input
                                    class="knob"
                                    data-width="100"
                                    data-height="100"
                                    data-displayprevious="true"
                                    data-thickness=".2"
                                    value=""
                                    data-fgcolor="#e06b7d"
                                    data-bgcolor="#e8e8e8"
                                    style="width: 54px; height: 33px; position: absolute; vertical-align: middle; margin-top: 33px; margin-left: -77px; border: 0px; font-weight: bold; font-style: normal; font-variant: normal; font-stretch: normal; font-size: 20px; line-height: normal; font-family: Arial; text-align: center; color: rgb(224, 107, 125); padding: 0px; -webkit-appearance: none; background: none;"
                                  />
                                </div>
                              </div>
                              <div class="bio-desk">
                                <h4 class="red">نظرات ارسال شده (25)</h4>
                                <p>اون فیلمه</p>
                                <p>همین فیلمه</p>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <div class="panel">
                            <div class="panel-body">
                              <div class="bio-chart">
                                <div
                                  style="display:inline;width:100px;height:100px;"
                                >
                                  <canvas width="100" height="100px"></canvas
                                  ><input
                                    class="knob"
                                    data-width="100"
                                    data-height="100"
                                    data-displayprevious="true"
                                    data-thickness=".2"
                                    value=""
                                    data-fgcolor="#4CC5CD"
                                    data-bgcolor="#e8e8e8"
                                    style="width: 54px; height: 33px; position: absolute; vertical-align: middle; margin-top: 33px; margin-left: -77px; border: 0px; font-weight: bold; font-style: normal; font-variant: normal; font-stretch: normal; font-size: 20px; line-height: normal; font-family: Arial; text-align: center; color: rgb(76, 197, 205); padding: 0px; -webkit-appearance: none; background: none;"
                                  />
                                </div>
                              </div>
                              <div class="bio-desk">
                                <h4 class="terques">فیلم های مورد علاقه</h4>
                                <p>اون فیلمه</p>
                                <p>همین فیلمه</p>
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

          <footer-app />
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import FooterApp from '../../components/FooterApp.vue';
import NavBar from '../../components/NavBar.vue';
import axios from 'axios';
export default {
  data() {
    return {
      token: '',
      currentUser: '',
      roles: []
    };
  },
  methods: {
    getCurrentUser() {
      console.log('ho');
      axios
        .get('/api/accounts/CurrentUser', {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          this.currentUser = res.data;
          this.roles = res.data.roles;
          console.log(this.currentUser);
        });
    }
  },
  async created() {
    this.token = localStorage.getItem('token');
    await this.getCurrentUser();
  },
  components: {
    NavBar,
    FooterApp
  }
};
</script>

<style scoped>
.roles {
  margin-right: 2rem;
  margin-top: 1rem;
  color: aliceblue !important;
  font-size: 18px;
}
ul {
  list-style-type: none;
}
</style>
