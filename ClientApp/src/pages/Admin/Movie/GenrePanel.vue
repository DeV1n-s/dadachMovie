<template>
  <div>
    <div class="row">
      <table class="table table-hover">
        <thead class="font-size">
          <tr>
            <th>#</th>
            <th>عنوان ژانر</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(genres, index) in genresData" :key="genres">
            <td class="t-num">{{ index + 1 }}</td>
            <td>
              {{ genres.name }}
            </td>
            <td>
              <button
                class="btn btn-lg btn-danger"
                @click="deleteButton(genres.id)"
              >
                حذف
              </button>
              <button
                class="btn btn-lg btn-warning mr-1"
                @click.prevent="editGenre(genres.id)"
              >
                ویرایش
              </button>
            </td>
          </tr>
        </tbody>
      </table>
      <div class="row d-flex">
        <label for="">نام ژانر :</label>
        <input type="text" v-model="Genre" />
        <button
          v-if="!isEditMode"
          class="btn btn-lg btn-success mr-1"
          @click="submitGenre"
        >
          افزودن
        </button>
        <button
          v-if="isEditMode"
          class="btn btn-lg btn-success mr-1"
          @click="subEditGenre(GenreId)"
        >
          ویرایش
        </button>
        <button
          v-if="isEditMode"
          class="btn btn-lg btn-danger mr-1"
          @click="(isEditMode = false), (Genre = '')"
        >
          لفو
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      isEditMode: false,
      Genre: '',
      GenreId: '',
      genresData: this.$store.getters.GetGenres
    };
  },
  methods: {
    editGenre(id) {
      this.isEditMode = true;
      axios.get('http://localhost:8080/api/Genres/' + id).then(res => {
        this.Genre = res.data.name;
        this.GenreId = res.data.id;
      });
    },
    submitGenre() {
      const form = new FormData();
      form.append('name', this.Genre);
      axios.post('http://localhost:8080/api/Genres', form);
    },
    deleteButton(id) {
      axios
        .delete('http://localhost:8080/api/Genres/' + id)
        .then(res => console.log(res.data));
    },
    subEditGenre(id) {
      const form = new FormData();
      form.append('name', this.Genre);
      axios.put('http://localhost:8080/api/Genres/' + id, form);
    }
  },
  mounted() {
    this.$store.dispatch('GetGenres');
  }
};
</script>

<style scoped>
table.table.table-hover {
  width: 55%;
}
label {
  margin: 0.5rem;
  color: aliceblue;
}
.mr-1 {
  margin-right: 0.7rem;
}
input {
  width: 30%;
}
.d-flex {
  display: flex;
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
/*  */
</style>
