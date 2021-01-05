<template>
  <div>
    <hr />
    <div class="row">
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-red set-icon"> </span>
          <div class="text-box">
            <p class="main-text">پیام ها</p>
            <p class="text-muted">120 جدید</p>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-green set-icon"> </span>
          <div class="text-box">
            <p class="main-text">نظرات</p>
            <p class="text-muted">50</p>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-blue set-icon"> </span>
          <div class="text-box">
            <p class="main-text">تعداد کاربران</p>
            <p class="text-muted">120</p>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-brown set-icon"> </span>
          <div class="text-box">
            <p class="main-text">تعداد فیلم ها</p>
            <p class="text-muted">{{ MovieTotal }}</p>
          </div>
        </div>
      </div>
    </div>
    <!-- /. ROW  -->
    <hr />
    <div class="row">
      <div class="col-md-6 col-sm-12 col-xs-12">
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-blue"> </span>
          <div class="text-box">
            <p class="main-text">آخرین خبر</p>
            <p class="text-muted">خبر اکران فیلم جدید</p>
            <p class="text-muted">50 دقیقه پیش</p>
            <hr />
            <p class="text-muted">
              <span class="text-muted color-bottom-txt"
                ><i class="fa fa-edit"></i>
                فیلم جدید قراره به زودی در اکرانگاه اکران شود
              </span>
            </p>
          </div>
        </div>
      </div>

      <div class="col-md-3 col-sm-12 col-xs-12">
        <div class="panel back-dash">
          <strong> &nbsp; لورم</strong>
          <p class="text-muted">
            لورم ایپسوم لورم ایپسوم لورم ایپسوم لورم ایپسوم لورم ایپسوم لورم
            ایپسوم لورم ایپسوم لورم ایپسوم
          </p>
        </div>
      </div>
      <div class="col-md-3 col-sm-12 col-xs-12 ">
        <div class="panel ">
          <div class="main-temp-back">
            <div class="panel-body">
              <div class="row">
                <div class="col-xs-6">
                  <i class="fa fa-cloud fa-3x"></i> البرز
                </div>
                <div class="col-xs-6">
                  <div class="text-temp">10°</div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel panel-back noti-box">
          <span class="icon-box bg-color-green set-icon"> </span>
          <div class="text-box">
            <p class="main-text">خوب</p>
            <p class="text-muted">سرعت لود شدن</p>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-md-6 col-sm-12 col-xs-12">
        <div class="chat-panel panel panel-default chat-boder chat-panel-head">
          <div class="panel-heading">
            <i class="fa fa-comments fa-fw"></i>
            یادداشت ها
            <div class="btn-group pull-right">
              <button
                type="button"
                class="btn btn-default btn-xs dropdown-toggle"
                data-toggle="dropdown"
              ></button>
              <ul class="dropdown-menu slidedown">
                <li>
                  <a href="#"> ریلود </a>
                </li>
              </ul>
            </div>
          </div>

          <div class="panel-body">
            <ul class="chat-box">
              <li class="left clearfix">
                <div class="chat-body">
                  <div class="d-block">
                    <small class="pull-left text-muted">
                      <i class="fa fa-clock-o fa-fw"></i>یک روز پیش
                    </small>
                  </div>
                  <strong class="pull-right">دانیال شکوه منش </strong>
                  <p>
                    طراحی ظاهری بهتر شود
                    <small class="pull-left text-muted">
                      انجام نشده
                    </small>
                  </p>
                </div>
              </li>
              <li class="left clearfix">
                <div class="chat-body">
                  <small class="pull-left text-muted">
                    <i class="fa fa-clock-o fa-fw"></i>یک روز پیش
                  </small>

                  <strong class="pull-right">آریا فتحی </strong>
                  <p>
                    نیوز رو راه بنداز حمال
                    <small class="pull-left text-muted">
                      درحال انجام
                    </small>
                  </p>
                </div>
              </li>

              <li class="left clearfix">
                <div class="chat-body">
                  <small class="pull-left text-muted">
                    <i class="fa fa-clock-o fa-fw"></i>یک روز پیش
                  </small>

                  <strong class="pull-right">سجاد حسین پور </strong>
                  <p>
                    بچه ها در کل ریدین
                    <small class="pull-left text-muted">
                      خاتمه یافته
                    </small>
                  </p>
                </div>
              </li>
            </ul>
          </div>

          <div class="panel-footer">
            <div class="input-group">
              <input
                id="btn-input"
                type="text"
                class="form-control input-sm"
                placeholder="چیزی برای یاد داشت بنویسید "
              />
              <span class="input-group-btn">
                <button class="btn btn-warning btn-sm" id="btn-chat">
                  ارسال
                </button>
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch('getMovie');
  },
  computed: {
    MovieTotal: function() {
      return this.$store.getters.GetMovieTotal;
    }
  }
};
</script>

<style>
.d-block {
  display: block;
}
</style>
