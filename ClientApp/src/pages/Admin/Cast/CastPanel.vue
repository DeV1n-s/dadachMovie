<template>
  <div>
    <hr />
    <div class="row">
      <h2>لیست بازیگران</h2>

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
      >
        <template slot="table-row" slot-scope="props">
          <span v-if="props.column.field == 'actions'">
            <button
              class="btn btn-lg btn-table-warning"
              @click="editBtn(props.row.id)"
            >
              ویرایش
            </button>
            <button
              class="btn btn-lg btn-table-danger"
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

      <router-link to="/CastAdd">
        <button class="btn btn-success btn-block m-x">
          افزودن بازیگر جدید
        </button>
      </router-link>
    </div>
    <transition name="slide" mode="out-in">
      <div v-if="isEditMode">
        <people-from :ID="id" :IsEditMode="isEditMode" />
      </div>
    </transition>
  </div>
</template>

<script>
import axios from 'axios';
import PeopleFrom from '../../../components/Form/PeopleFrom.vue';
export default {
  components: { PeopleFrom },
  data() {
    return {
      columns: [
        {
          label: 'نام بازیگر',
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
  }
};
</script>

<style scoped>
input[type='checkbox'] {
  /* padding: 2rem; */
  margin-right: 1rem;
}
.types h6 {
  padding-bottom: 0.5rem;
  color: #ccc;
}
.types label {
  padding-right: 0;
  padding-left: 1rem;
}
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 25px;
  width: 25px;
  background-color: #eee;
}

/* On mouse-over, add a grey background color */
.container:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.container input:checked ~ .checkmark {
  background-color: #2196f3;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
  content: '';
  position: absolute;
  display: none;
}

/* Show the checkmark when checked */
.container input:checked ~ .checkmark:after {
  display: block;
}

/* Style the checkmark/indicator */
.container .checkmark:after {
  left: 9px;
  top: 5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
}
.custom-file-input::-webkit-file-upload-button {
  background-color: antiquewhite;
  visibility: hidden;
}
.custom-file-input::before {
  background-color: antiquewhite;
  content: 'تصویری را انتخاب کنید';
  display: inline-block;
  /* background: linear-gradient(top, #f9f9f9, #e3e3e3); */
  border: 1px solid #999;
  border-radius: 3px;
  padding: 5px 8px;
  outline: none;
  white-space: nowrap;
  -webkit-user-select: none;
  cursor: pointer;
  text-shadow: 1px 1px #fff;
  font-weight: 700;
  font-size: 10pt;
}
.custom-file-input:hover::before {
  border-color: black;
}
.custom-file-input:active::before {
  background: -webkit-linear-gradient(top, #e3e3e3, #f9f9f9);
}
.edit-img {
  margin: 2rem;
  width: 350px;
  height: 350px;
}

.row.ipad-width {
  margin-top: 30rem;
}
table {
  background-color: navajowhite;
}
caption,
th,
td {
  font-weight: normal;
  text-align: right;
}
h2 {
  /* color: black; */
  margin-bottom: 8px;
}
.t-num {
  width: 20%;
}
.font-size {
  font-size: 2rem;
}
.btn {
  margin: 0.5rem;
}
/*  */
.slide-enter-active {
  animation: slide-in 200ms ease-out forwards;
}
.slide-leave-active {
  animation: slide-out 200ms ease-out forwards;
}
@keyframes slide-in {
  from {
    transform: translateY(-30px);
    opacity: 0;
  }
  to {
    transform: translateY(0);
    opacity: 1;
  }
}
@keyframes slide-out {
  from {
    transform: translateY(0);
    opacity: 1;
  }
  to {
    transform: translateY(-30px);
    opacity: 0;
  }
}
</style>
