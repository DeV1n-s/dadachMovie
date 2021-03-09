<template>
  <div>
    <div>
      <h3 class="mt-2">لیست فیلم ها</h3>
      <hr />
      <div class="row">
        <div class="col-md-12">
          <vue-good-table
            :sort-options="{
              enabled: true
            }"
            :columns="columns"
            :rows="Movies"
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
                <nuxt-link
                  :to="{ name: 'MovieEdit-id', params: { id: props.row.id } }"
                >
                  <button
                    class="btn  btn-warning"
                    @click="editBtn(props.row.id)"
                  >
                    ویرایش
                  </button>
                </nuxt-link>
                <button
                  class="btn btn-danger"
                  @click="deleteButton(props.row.id)"
                >
                  حذف
                </button>
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
    <div class="alert-modal">
      <b-alert
        :show="dismissCountDown"
        variant="success"
        @dismissed="dismissCountDown = 0"
        @dismiss-count-down="countDownChanged"
      >
        <p>ایتم مورد نظر با موفقیت حذف شد</p>
        <p>{{ dismissCountDown }}</p>
        <b-progress :max="dismissSecs" height="4px"></b-progress>
      </b-alert>
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
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      columns: [
        {
          label: 'نام فیلم',
          field: 'title'
        },

        {
          label: 'زمان',
          field: 'lenght'
        },

        {
          label: 'تاریخ انتشار',
          field: 'releaseDate'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      token: '',
      isEditMode: false,
      id: null
    };
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    editBtn(id) {
      this.isEditMode = true;
      this.id = id;
    },

    onFileSelected(event) {
      this.castEdit.picture = event.target.files[0];
      // this.$refs.file.files[0];
    },
    deleteButton(id) {
      axios
        .delete('/api/movies/' + id, {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => {
          console.log(res);
          this.$store.dispatch('getMovie');
        });
      this.showAlert();
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    this.$store.dispatch('getMovie');
  },
  computed: {
    Movies: function() {
      return this.$store.getters.GetMovies;
    }
  },
  components: {
    VueGoodTable
  }
};
</script>
<style scoped>
.alert-modal {
  position: fixed;
  bottom: 0.5rem;
}
</style>
