<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <h3 class="mt-2">آمار و ارقام</h3>

            <div class="submit-graph ">
              <p class="statistics text-primary">تاریخ ثبت نام</p>
              <table id="q-graph" class="mr-2">
                <tbody>
                  <tr class="qtr" id="q1">
                    <th scope="row">25/8/99</th>
                    <td class="sent bar" style="height: 111px;">
                      <p>18,450.00</p>
                    </td>
                  </tr>
                  <tr class="qtr" id="q2">
                    <th scope="row">26/8/99</th>
                    <td class="sent bar" style="height: 206px;">
                      <p>34,340.72</p>
                    </td>
                  </tr>
                  <tr class="qtr" id="q3">
                    <th scope="row">27/8/99</th>
                    <td class="sent bar" style="height: 259px;">
                      <p>43,145.52</p>
                    </td>
                  </tr>
                  <tr class="qtr" id="q4">
                    <th scope="row">28/8/99</th>
                    <td class="sent bar" style="height: 50px;">
                      <p>18,415.96</p>
                    </td>
                  </tr>
                  <tr class="qtr" id="q5">
                    <th scope="row">29/8/99</th>
                    <td class="sent bar" style="height: 110px;">
                      <p>18,415.96</p>
                    </td>
                  </tr>
                  <tr class="qtr" id="q6">
                    <th scope="row">30/8/99</th>
                    <td class="sent bar" style="height: 190px;">
                      <p>18,415.96</p>
                    </td>
                  </tr>
                </tbody>
              </table>

              <div id="ticks">
                <div class="tick" style="height: 59px;">
                  <p>50,000</p>
                </div>
                <div class="tick" style="height: 59px;">
                  <p>40,000</p>
                </div>
                <div class="tick" style="height: 59px;">
                  <p>30,000</p>
                </div>
                <div class="tick" style="height: 59px;">
                  <p>20,000</p>
                </div>
                <div class="tick" style="height: 59px;">
                  <p>10,000</p>
                </div>
              </div>
              <div class="more-statistics mt-4">
                <div class="container">
                  <!-- DONUT CHART BLOCK (LEFT-CONTAINER) -->
                  <div class="donut-chart-block block">
                    <h2 class="titular">فیلم \ ژانر</h2>
                    <div class="donut-chart">
                      <!-- PORCIONES GRAFICO CIRCULAR
                            ELIMINADO #donut-chart
                            MODIFICADO CSS de .donut-chart -->
                      <div id="porcion1" class="recorte">
                        <div class="quesito ios" data-rel="21"></div>
                      </div>
                      <div id="porcion2" class="recorte">
                        <div class="quesito mac" data-rel="39"></div>
                      </div>
                      <div id="porcion3" class="recorte">
                        <div class="quesito win" data-rel="31"></div>
                      </div>
                      <div id="porcionFin" class="recorte">
                        <div class="quesito linux" data-rel="9"></div>
                      </div>
                      <!-- FIN AÑADIDO GRÄFICO -->
                    </div>
                    <ul class="os-percentages horizontal-list">
                      <li>
                        <p class="ios os scnd-font-color">ترسناک</p>
                        <p class="os-percentage">21<sup>%</sup></p>
                      </li>
                      <li>
                        <p class="mac os scnd-font-color">اکشن</p>
                        <p class="os-percentage">39<sup>%</sup></p>
                      </li>
                      <li>
                        <p class="linux os scnd-font-color">اجتماعی</p>
                        <p class="os-percentage">9<sup>%</sup></p>
                      </li>
                      <li>
                        <p class="win os scnd-font-color">کمدی</p>
                        <p class="os-percentage">31<sup>%</sup></p>
                      </li>
                    </ul>
                  </div>
                  <!-- LINE CHART BLOCK (LEFT-CONTAINER) -->
                  <div class="line-chart-block block">
                    <div class="line-chart">
                      <div class="grafico">
                        <ul class="eje-y">
                          <li data-ejeY="30"></li>
                          <li data-ejeY="20"></li>
                          <li data-ejeY="10"></li>
                          <li data-ejeY="0"></li>
                        </ul>
                        <ul class="eje-x">
                          <li>مهر</li>
                          <li>آبان</li>
                          <li>آذر</li>
                        </ul>
                        <span data-valor="25">
                          <span data-valor="8">
                            <span data-valor="13">
                              <span data-valor="5">
                                <span data-valor="23">
                                  <span data-valor="12">
                                    <span data-valor="15"> </span
                                  ></span>
                                </span>
                              </span>
                            </span>
                          </span>
                        </span>
                      </div>
                    </div>
                    <ul class="time-lenght horizontal-list color-light ml-5">
                      <p>اخبار پست شده در ماه</p>
                    </ul>
                    <ul class="month-data clear">
                      <li>
                        <p>مهر<span class="scnd-font-color"> 1399</span></p>
                        <p>
                          <span class="entypo-plus increment"> </span>21<sup
                          ></sup>
                        </p>
                      </li>
                      <li>
                        <p>آبان<span class="scnd-font-color"> 1399</span></p>
                        <p>
                          <span class="entypo-plus increment"> </span>48<sup
                          ></sup>
                        </p>
                      </li>
                      <li>
                        <p>آذر<span class="scnd-font-color"> 1399</span></p>
                        <p>
                          <span class="entypo-plus increment"> </span>35<sup
                          ></sup>
                        </p>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import AdminFooter from '../../components/Admin/AdminFooter.vue';
import AdminNav from '../../components/Admin/AdminNav.vue';
import AdminSide from '../../components/Admin/AdminSide.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
