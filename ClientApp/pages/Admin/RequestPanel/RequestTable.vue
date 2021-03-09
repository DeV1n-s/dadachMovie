<template>
  <div>
    <hr />
    <div class="row mb-3">
      <div class="col-md-12">
        <div class="wrapper">
          <div class="panel">
            <div class="panel-header">
              <h3 class="title">آمار</h3>
            </div>

            <div class="panel-body">
              <div class="categories d-flex">
                <div class="category">
                  <span> کل درخواست‌ها</span>
                  <span>{{ totalRequests }}</span>
                </div>
                <div class="category">
                  <span>درخواست‌های باز</span>
                  <span>127</span>
                </div>
                <div class="category">
                  <span>درخواست های بسته شده</span>
                  <span>8.648</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <vue-good-table
          :sort-options="{
            enabled: true
          }"
          :columns="columns"
          :rows="requests"
          :rtl="true"
          :lineNumbers="true"
          :pagination-options="{
            enabled: true,
            prevLabel: 'قبل',
            nextLabel: 'بعد',
            rowsPerPageLabel: 'تعداد رکورد',

            ofLabel: 'از',
            pageLabel: 'صفحه', // for 'pages' mode
            allLabel: 'همه',
            firstRecordOnPage: 'index of the first record on the current page',
            lastRecordOnPage: 'index of the last record on the current page',
            totalRecords: 'total number of records',
            currentPage: 'current page',
            totalPage: 'total number of pages',
            infoFn: params => `my own page ${params.firstRecordOnPage}`
          }"
          :search-options="{
            enabled: true
          }"
          theme="nocturnal"
          styleClass="vgt-table striped"
        >
          <template slot="table-row" slot-scope="props">
            <span v-if="props.column.field == 'actions'">
              <nuxt-link to="/admin/request/1">
                <button class="btn  btn-success">
                  مشاهده
                </button>
              </nuxt-link>
            </span>
            <span v-else>
              {{ props.formattedRow[props.column.field] }}
            </span>
          </template>

          <div slot="emptystate">
            <p class="text-center">
              هیچگونه داده ای وجود ندارد :)
            </p>
          </div>
        </vue-good-table>
      </div>
    </div>
  </div>
</template>

<script>
import 'vue-good-table/dist/vue-good-table.css';

import { VueGoodTable } from 'vue-good-table';
import axios from 'axios';
export default {
  data() {
    return {
      columns: [
        {
          label: 'موضوع',
          field: 'subject'
        },

        {
          label: 'وضعیت',
          field: 'status'
        },
        {
          label: 'تاریخ ایجاد',
          field: 'createdAt'
        },
        {
          label: 'آخرین به روز رسانی',
          field: 'updatedAt'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      requests: '',
      totalRequests: '',
      isEditMode: false,
      id: null,
      token: ''
    };
  },
  methods: {
    editBtn(id) {
      this.isEditMode = true;
      this.id = id;
    },

    getRequests() {
      axios
        .get('/api/requests', {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          {
            this.requests = res.data.items;
            this.totalRequests = res.data.totalItems;
          }
        });
    }
  },
  async mounted() {
    this.token = localStorage.getItem('token');
    this.getRequests();
  },
  computed: {},
  components: {
    VueGoodTable
  }
};
</script>

<style scoped>
.panel {
  width: 100%;
  height: 150px;
  background: #838cc7;
  box-shadow: 1px 2px 3px 0px rgba(0, 0, 0, 0.1);
  border-radius: 6px;
  overflow: hidden;
}

.panel-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 30px;
  height: 60px;
  background: #fff;
}

.title {
  color: #5e6977;
  font-weight: 500;
}

.calendar-views span {
  font-size: 14px;
  font-weight: 300;
  color: #bdc6cf;
  padding: 6px 14px;
  border: 2px solid transparent;
}
.panel-body {
  display: flex;
  height: 340px;
}
.categories {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-basis: 100%;
  padding: 39px 0px 41px 26px;
}
.category {
  display: flex;
  flex-direction: row;
}
.category span:first-child {
  font-weight: 300;
  font-size: 14px;
  opacity: 0.6;
  color: #fff;
  margin-bottom: 6px;
}
.category span:last-child {
  font-size: 32px;
  font-weight: 300;
  color: #fff;
}

.chart {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  flex-grow: 2;
  position: relative;
}

.operating-systems {
  display: flex;
  justify-content: space-between;
  width: 215px;
  margin-top: 30px;
  margin-bottom: 50px;
}

.android-os span {
  background: #80b354;
}
.ios-os span {
  background: #f5a623;
}
.windows-os span {
  background: #f8e71c;
}
</style>
