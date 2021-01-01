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
          <tr v-for="(genres, index) in genresData" :key="genres.id">
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
        <form-input
          label="نام ژانر"
          :required="true"
          id="name"
          v-model="Genre"
          class="form-input"
        />

        <button
          v-if="!isEditMode"
          class="btn btn-lg btn-success mr-1 btn-cstm"
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
import FormInput from '../../../components/Form/FormInput';

import axios from 'axios';

export default {
  components: {
    FormInput
  },
  data() {
    return {
      isEditMode: false,
      Genre: '',
      GenreId: ''
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
      axios.post('http://localhost:8080/api/Genres', { name: this.Genre });
    },
    deleteButton(id) {
      axios
        .delete('http://localhost:8080/api/Genres/' + id)
        .then(res => console.log(res.data));
    },
    subEditGenre(id) {
      axios.put('http://localhost:8080/api/Genres/' + id, { name: this.Genre });
    }
  },
  mounted() {
    this.$store.dispatch('GetGenres');
  },
  computed: {
    genresData: function() {
      return this.$store.getters.GetGenres;
    }
  }
};
</script>

<style scoped>
.form-input {
  margin-bottom: 2rem;
}
.btn-cstm {
  height: 35px;
  margin-top: 2.55rem;
}
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
