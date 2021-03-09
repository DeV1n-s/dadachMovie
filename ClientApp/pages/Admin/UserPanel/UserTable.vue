<template>
  <div>
    <hr />
    <div class="row">
      <div class="col-md-12">
        <vue-good-table
          :sort-options="{
            enabled: true
          }"
          :columns="columns"
          :rows="users"
          :rtl="true"
          :lineNumbers="true"
          :pagination-options="{
            enabled: true,
            prevLabel: 'قبل',
            nextLabel: 'بعد',
            rowsPerPageLabel: 'تعداد رکورد'
          }"
          :search-options="{
            enabled: true
          }"
          theme="nocturnal"
          styleClass="vgt-table striped"
        >
          <template slot="table-row" slot-scope="props">
            <span v-if="props.column.field == 'actions'">
              <router-link
                :to="{
                  name: 'CastEdit',
                  params: { id: props.row.id }
                }"
              >
                <button class="btn  btn-warning" @click="editBtn(props.row.id)">
                  ویرایش
                </button>
              </router-link>
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
          label: 'نام ',
          field: 'firstName'
        },

        {
          label: 'نام خانوادگی',
          field: 'lastName'
        },
        {
          label: 'پست الکترونیکی',
          field: 'emailAddress'
        },
        {
          label: 'تاریخ ثبت نام',
          field: 'registerDate'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      users: '',
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

    onFileSelected(event) {
      this.castEdit.picture = event.target.files[0];
      // this.$refs.file.files[0];
    },
    deleteButton(id) {
      axios.delete('/api/people/' + id).then(res => console.log(res));
    },
    getUsers() {
      axios
        .get('/api/accounts/Users', {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          this.users = res.data.items;
        });
    }
  },
  async mounted() {
    this.token = localStorage.getItem('token');
    this.getUsers();
  },
  computed: {},
  components: {
    VueGoodTable
  }
};
</script>
