<template>
  <div class="movie-items mt-5">
    <div class="container">
      <div class="row ipad-width">
        <div class="col-md-8"></div>
        <h2>لیست فیلم ها</h2>

        <table class="table table-hover">
          <thead class="font-size">
            <tr>
              <th>#</th>
              <th>نام بازیگر</th>
              <th>تاریخ تولد</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(People, index) in Peoples" :key="People.id">
              <td class="t-num">{{ index + 1 }}</td>
              <td>{{ People.name }}</td>
              <td>{{ People.dateOfBirth }}</td>
              <td>
                <button
                  class="btn btn-lg btn-warning"
                  @click.prevent="editBtn(People.id)"
                >
                  ویرایش
                </button>
                <button
                  class="btn btn-lg btn-danger"
                  @click="deleteButton(People.id)"
                >
                  حذف
                </button>
              </td>
            </tr>
          </tbody>
        </table>
        <router-link to="/CastAdd">
          <button class="btn btn-success btn-block m-x">
            افزودن بازیگر جدید
          </button>
        </router-link>
      </div>
      <transition name="slide" mode="out-in">
        <div v-if="isEditMode">
          <form action="/action_page.php">
            <label for="fname">نام بازیگر </label>
            <input type="text" id="fname" v-model="castEdit.name" />

            <label for="lname">توضیحات کوتاه</label>
            <input type="text" v-model="castEdit.shortBio" />
            <label for="lname">بیوگرافی</label>
            <textarea v-model="castEdit.biography"></textarea>
            <label for="start">تاریخ تولد</label>

            <input
              type="date"
              id="start"
              name="trip-start"
              min="0000-11-11"
              max="2020-12-30"
              v-model="castEdit.dateOfBirth"
            />
            <label for="fname">ملیت </label>
            <input type="text" v-model="castEdit.nationality" />
            <div class="types">
              <h6>سمت ها :</h6>
              <label class="container"
                >بازیگر
                <input
                  type="checkbox"
                  checked="checked"
                  v-model="castEdit.isCast"
                />
                <span class="checkmark"></span>
              </label>
              <label class="container"
                >کاردگردان
                <input type="checkbox" v-model="castEdit.isDiractor" />
                <span class="checkmark"></span>
              </label>
            </div>
            <img class="edit-img" :src="castEdit.picture" alt="" />

            <input
              type="file"
              class="custom-file-input"
              @change="onFileSelected"
            />

            <button
              type="submit"
              @click.prevent="submitEdit(castEdit.id)"
              class="btn btn-success btn-block"
            >
              ثبت
            </button>
            <router-link to="/CastPanel">
              <button
                type="submit"
                class="btn btn-danger btn-block"
                @click="isEditMode = false"
              >
                لغو
              </button>
            </router-link>
          </form>
        </div>
      </transition>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      isEditMode: false,
      castEdit: {
        id: null,
        name: '',
        shortBio: '',
        biography: '',
        dateOfBirth: '',
        picture: '',
        nationality: '',
        isCast: '',
        isDirector: ''
      },

      Peoples: this.$store.getters.GetPeaple
    };
  },
  methods: {
    editBtn(id) {
      this.isEditMode = true;
      this.castEdit.id = id;
      axios
        .get('http://localhost:8080/api/people/' + id)
        .then(res => (this.castEdit = res.data))
        .then(console.log(this.castEdit));
    },
    async submitEdit(id) {
      const form = new FormData();
      form.append('id', this.castEdit.id);
      form.append('Name', this.castEdit.name);
      form.append('ShortBio', this.castEdit.shortBio);
      form.append('Biography', this.castEdit.biography);
      form.append('DateOfBirth', this.castEdit.dateOfBirth);
      form.append('Picture', this.castEdit.picture);
      form.append('Nationality', this.castEdit.nationality);
      form.append('IsCast', this.castEdit.isCast);
      form.append('IsDirector', this.castEdit.isDirector);
      console.log(this.castEdit);
      await axios.put('http://localhost:8080/api/people/' + id, form);

      this.isEditMode = false;
    },
    onFileSelected(event) {
      this.castEdit.picture = event.target.files[0];
      // this.$refs.file.files[0];
    },
    deleteButton(id) {
      axios
        .delete('http://localhost:8080/api/people/' + id)
        .then(res => console.log(res));
    }
  },
  mounted() {
    this.$store.dispatch('GetPeoples');
    // console.log(object);
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
