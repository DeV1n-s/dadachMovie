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
              <th>نام فیلم</th>
              <th>کارگردان</th>
              <th>تاریخ انتشار</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(Movie, index) in MovieLists" :key="Movie">
              <td class="t-num">{{ index + 1 }}</td>
              <td>
                <router-link
                  :to="{ name: 'MovieSingle', params: { id: Movie.id } }"
                >
                  {{ Movie.title }}</router-link
                >
              </td>
              <td>{{ Movie.director }}</td>
              <td>{{ Movie.releaseDate }}</td>
              <td>
                <button
                  class="btn btn-lg btn-warning"
                  @click.prevent="editMovie(Movie.id)"
                >
                  ویرایش
                </button>
                <button
                  class="btn btn-lg btn-danger"
                  @click="deleteButton(Movie.id)"
                >
                  حذف
                </button>
              </td>
            </tr>
          </tbody>
        </table>
        <router-link to="/MovieAdd">
          <button class="btn btn-success btn-block m-x">
            افزودن فیلم جدید
          </button>
        </router-link>
        <button
          class="btn btn-success btn-block m-x"
          @click="isGenreMdoe = !isGenreMdoe"
        >
          مدیریت ژانر ها
        </button>
      </div>
      <transition name="slide" mode="out-in">
        <genre-panel class="genre-panel" v-if="isGenreMdoe" />
      </transition>
      <transition name="slide" mode="out-in">
        <div v-if="isEditMode">
          <movie-form
            :Peoples="Peoples"
            :Genres="Genres"
            @submitData="SubmitData($event)"
            :IsEditMode="isEditMode"
            :ID="MovieEditData.id"
          />
        </div>
      </transition>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import GenrePanel from './GenrePanel';
import MovieForm from '../../../components/Form/MovieForm.vue';

export default {
  components: {
    GenrePanel,
    MovieForm
  },
  data() {
    GenrePanel;
    return {
      isGenreMdoe: false,
      isEditMode: false,
      MovieEditData: {
        id: null,
        title: '',
        rate: '',
        releaseDate: null,
        directors: [],
        casters: [],
        shortPara: '',
        longPara: '',
        genres: [],
        picture: null,
        inTheaters: false
      },
      Directors: [],
      Genres: '',
      preCasters: [],
      Peoples: this.$store.getters.GetPeaple,
      Genress: [],
      MovieLists: this.$store.getters.GetMovies
    };
  },
  methods: {
    castDelete(id) {
      this.MovieEditData.casters.splice(id, 1);
    },
    castPush() {
      this.MovieEditData.casters.push(this.preCasters);
    },
    deleteButton(id) {
      axios.delete('http://localhost:8080/api/Movies/' + id).then(res => {
        console.log(res.data);
      });
    },
    editMovie(id) {
      this.isEditMode = true;
      this.MovieEditData.id = id;

      // console.log(this.MovieEditData);
    },
    getGenre() {
      axios
        .get('http://localhost:8080/api/genres')
        .then(res => (this.Genress = res.data));
    },
    onFileSelected(event) {
      this.MovieEditData.picture = event.target.files[0];
      // this.$refs.file.files[0];
    },
    submitEdit(id) {
      this.MovieEditData.directors = [];
      this.MovieEditData.genres = [];
      this.MovieEditData.directors.push(this.Directors);
      this.MovieEditData.genres.push(this.Genres);
      const form = new FormData();
      form.append('Title', this.MovieEditData.title);
      form.append('Rate', this.MovieEditData.rate);
      form.append('DirectorsId', JSON.stringify(this.MovieEditData.directors));
      form.append('ShortPara', this.MovieEditData.shortPara);
      form.append('Description', this.MovieEditData.longPara);
      form.append('GenresId', JSON.stringify(this.MovieEditData.genres));
      form.append('Cast', JSON.stringify(this.MovieEditData.casters));
      form.append('Picture', this.MovieEditData.picture);
      form.append('InTheaters', this.MovieEditData.inTheaters);
      axios
        .put('http://localhost:8080/api/Movies/' + id, form)
        .then(res => {
          console.log(res);
          this.$router.push('/Moviepanel');
        })
        .then((this.isEditMode = false));
    }
  },
  mounted() {
    this.$store.dispatch('getMovie');
    this.$store.dispatch('GetPeoples');
    this.getGenre();
  }
};
</script>

<style scoped>
.genre-panel {
  margin-top: 4rem;
}
label {
  color: #fff;
  margin-bottom: 0.5rem;
}

.cinema-carpet {
  padding-top: 1rem;
  padding-bottom: 1rem;
  margin-left: 0.5rem;
}

button.btn-success.btn-add {
  padding: 0.25rem;
  border-radius: 5px;
  width: 20%;
  margin-bottom: 0.75rem;
  margin-top: 0.75rem;
}
textarea {
  height: 150px !important;
}
.dl-cast {
  float: left; /* padding-top: .5rem; */
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
