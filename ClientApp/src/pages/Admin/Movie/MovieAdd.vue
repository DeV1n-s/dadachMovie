<template>
  <div>
    <hr />
    <div class="row">
      <h3>برا ثبت فیلم فیلد های زیر را تکمیل کنید</h3>
      <movie-form
        :Peoples="Peoples"
        :Genres="Genres"
        :IsEditMode="isEditMode"
      />
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import MovieForm from '../../../components/Form/MovieForm.vue';

export default {
  components: {
    MovieForm
  },
  data() {
    return {
      isEditMode: false
    };
  },
  methods: {
    getGenre() {
      axios.get('/api/genres').then(res => (this.Genres = res.data));
    }
  },

  mounted() {
    this.$store.dispatch('GetPeoples');
    this.$store.dispatch('GetGenres');
    this.getGenre();
  },
  computed: {
    Peoples: function() {
      return this.$store.getters.GetPeaple;
    },
    Genres: function() {
      return this.$store.getters.GetGenres;
    }
  }
};
</script>

<style scoped>
.cinema-carpet {
  padding-top: 1rem;
  padding-bottom: 1rem;
  margin-left: 0.5rem;
}

.table-c {
  padding: 0 !important;
  margin-bottom: 1rem;
  margin-top: 1rem;
}
.td-p {
  margin: 1rem;
}
th,
td {
  padding: 0 !important;
}
button.btn-success.btn-add {
  padding: 0.25rem;
  border-radius: 5px;
  width: 20%;
  margin-bottom: 0.75rem;
}
table,
th,
td {
  border: 0.05px solid rgb(129, 129, 129);
}

td {
  width: 80%;
}
td {
  color: #e3e3e3;
}
btn-danger {
  color: #e3e3e3 !important;
}
textarea {
  height: 150px !important;
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
h3,
label {
  color: #ccc;
}
input[type='text'],
select {
  width: 100%;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type='submit'] {
  width: 100%;
  background-color: #4caf50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type='submit']:hover {
  background-color: #45a049;
}

div {
  border-radius: 5px;
  /* background-color: #f2f2f2; */
  padding: 20px;
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
  color: navajowhite;
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
</style>
