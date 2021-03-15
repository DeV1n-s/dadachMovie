<template>
  <div
    class="container mb-5"
    dir="rtl"
    data-aos="fade-right"
    data-aos-duration="1000"
  >
    <h4 class="mr-0 mb-3">
      <strong class="y-color">
        <i class="fa fa-calendar" aria-hidden="true"></i> جدول هفتگی پخش
        سریال‌ها</strong
      >
    </h4>
    <div class="series-calendar mt-4">
      <div class="card main-card">
        <div class="card-body">
          <div class="row">
            <div class="col-md-2">
              <ul class="list-group list-group-flush">
                <li class="calendar-day text-muted p-0">
                  <p class=" y-color p-0 m-0">شنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">یک‌شنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">دوشنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">سه‌شنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">چهار‌شنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">پنج‌شنبه</p>
                </li>
                <li class="calendar-day text-muted p-0">
                  <p class="text-white">جمعه</p>
                </li>
              </ul>
            </div>
            <div class="col-md-8 mt-4">
              <div class="row">
                <div class="col-md-6 mt-2">
                  <div class="card series-gird-card">
                    <div class="card-body series-card">
                      <p class="card-title ml-2">
                        Arrow
                      </p>
                      <div class="card-text ml-5 mt-2">
                        <p>
                          S1E05 || 2014
                        </p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 mt-2">
                  <div class="card series-gird-card">
                    <div class="card-body series-card">
                      <p class="card-title ml-2">
                        Arrow
                      </p>
                      <div class="card-text ml-5 mt-2">
                        <p>
                          S1E05 || 2014
                        </p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 mt-2">
                  <div class="card series-gird-card">
                    <div class="card-body series-card">
                      <p class="card-title ml-2">
                        Arrow
                      </p>
                      <div class="card-text ml-5 mt-2">
                        <p>
                          S1E05 || 2014
                        </p>
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
</template>

<script>
import axios from 'axios';
//import VueAos from 'vue-aos';
import AOS from 'aos';
import 'aos/dist/aos.css';
export default {
  data() {
    return {
      // dateOfWeek=1
    };
  },
  methods: {
    getSeries(date) {
      axios.get(`/api/series?filter=Title=*${date}`).then(res => {
        console.log(res.data.items);
      });
    }
  },
  mounted() {
    this.getSeries(1);
    AOS.init();
  }
};
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
.series-calendar {
  width: 85%;
  margin-right: 2.5rem;
}
.calendar-day {
  font-size: 16px;
}
.card-title {
  display: block;
  color: #5236a5;
  font-weight: 500;
  float: left;
  font-size: 20px;
}

.card-body .series-card {
  padding: 0.25rem;
}
.card-text {
  float: left;
  font-size: 12px;
}
.main-card {
  background-color: #797376ab;
  border-radius: 15px;
  -webkit-box-shadow: -1px 7px 6px 5px rgba(150, 150, 150, 0.93);
  box-shadow: 0px 0px 15px 5px rgba(150, 150, 150, 0.93);
}
li.calendar-day.text-muted.list-group-item.p-0 {
  background-color: inherit;
}
.series-gird-card {
  background-color: #fffaffe3;
  border-radius: 8px;
  transition: 0.3s;
  box-shadow: 0 3px 10px rgb(3 3 3 / 11%);
  -webkit-box-shadow: -1px 7px 6px 5px rgba(194, 189, 189, 0.93);
  box-shadow: 0px 0px 3px 3px rgba(211, 207, 207, 0.93);
}
.series-gird-card:hover {
  transform: scale(1.01);
}
li {
  list-style-type: none;
  border-bottom: 0.75px solid rgba(46, 45, 45, 0.863);
}
p.text-white {
  margin-bottom: 2px;
  margin-top: 10px;
}
</style>
