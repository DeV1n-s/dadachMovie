<template>
  <div class="movie-items mt-5" dir="right">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8"></div>
        <h3>برا ثبت فیلم فیلد های زیر را تکمیل کنید</h3>

        <div>
          <form action="/action_page.php">
            <label for="fname">نام فیلم </label>
            <input type="text" id="fname" v-model="MovieData.title" />

            <label for="lname">توضیحات کوتاه</label>
            <input type="text" v-model="MovieData.shortPara" />
            <label for="lname">شرح کامل</label>
            <textarea v-model="MovieData.longPara"></textarea>
            <label for="country">سبک</label>
            <select id="country" name="country" v-model="MovieData.Genre">
              <option value="action">اکشن</option>
            </select>
            <label for="tentacles">نمره فیلم از 10</label>

            <input
              type="number"
              id="tentacles"
              name="tentacles"
              min="0"
              max="10"
              v-model="MovieData.rate"
            />
            <label for="start">تاریخ انتشار</label>

            <input
              type="date"
              id="start"
              name="trip-start"
              min="0000-11-11"
              max="2020-12-30"
              v-model="MovieData.Release"
            />
            <label for="fname">کارگردان </label>
            <input type="text" v-model="MovieData.Director" />
            <label for="fname">بازیگران </label>
            <input type="text" v-model="MovieData.Cast" />
            <label for="fname">تصویر </label>
            <input type="file" class="custom-file-input" />

            <button
              type="submit"
              @click.prevent="submitData"
              class="btn btn-success btn-block"
            >
              ثبت
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      MovieData: {
        title: '',
        rate: '',
        ReleaseDate: null,
        Director: '',
        Casters: '',
        shortPara: '',
        longPara: '',
        GenresIds: '',
        Picture: ''
      }
    };
  },
  methods: {
    submitData() {
      axios
        .post('http://localhost:5000/api/movies', JSON.parse(this.MovieData))
        .then(res => console.log(res));
    },
    getPeople() {
      axios
        .get('http://localhost:5000/api/people')

        .then(res => console.log(res.data));
    }
  },

  //get/getPeople
  mounted() {
    // this.$store.dispatch('getPeople');
    // console.log(this.$store.getters.People);
    this.getPeople();
  }
};
</script>

<style scoped>
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
  padding: 12px 20px;
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
