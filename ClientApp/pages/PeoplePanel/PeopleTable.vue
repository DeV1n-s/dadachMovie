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
          :rows="Peoples"
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
          field: 'name'
        },

        {
          label: 'تاریخ تولد',
          field: 'dateOfBirth'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],

      isEditMode: false,
      id: null
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
    }
  },
  async mounted() {
    await this.$store.dispatch('GetPeoples');
  },
  computed: {
    Peoples: function() {
      return this.$store.getters.GetPeaple;
    }
  },
  components: {
    VueGoodTable
  }
};
</script>
