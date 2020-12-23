<template>
  <div>
    <form action="/action_page.php">
      <label for="fname">نام فیلم </label>
      <input type="text" id="fname" v-model="MovieData.Title" />

      <label for="lname">توضیحات کوتاه</label>
      <input type="text" v-model="MovieData.ShortPara" />
      <label for="lname">شرح کامل</label>
      <textarea v-model="MovieData.LongPara"></textarea>
      <label for="country">سبک</label>
      <select id="country" name="country" v-model="GenresIds">
        <option v-for="Genre in Genres" :key="Genre.id" :value="Genre.id">{{
          Genre.name
        }}</option>
      </select>
      <label for="tentacles">نمره فیلم از 10</label>

      <input
        type="number"
        id="tentacles"
        name="tentacles"
        min="0"
        max="10"
        v-model="MovieData.Rate"
      />
      <label for="start">تاریخ انتشار</label>

      <input
        type="date"
        id="start"
        name="trip-start"
        min="0000-11-11"
        max="2020-12-30"
        v-model="MovieData.ReleaseDate"
      />
      <label for="fname">کارگردان </label>
      <select name="country" v-model="Directors">
        <option v-for="People in Peoples" :key="People.id" :value="People.id">{{
          People.name
        }}</option>
      </select>
      <label for="fname">بازیگران </label>
      <select id="countr" name="country" v-model="preCasters">
        <option
          v-for="People in Peoples"
          :key="People.id"
          :value="{
            PersonId: People.id,
            Character: People.name
          }"
          >{{ People.name }}</option
        >
      </select>
      <button class="btn-success btn-add" @click.prevent="castPush">
        اضافه کردن بازیگر
      </button>
      <div class="table-c">
        <tbody>
          <tr v-for="(Cast, index) in MovieData.Casters" :key="Cast">
            <td>
              <p class="td-p">{{ Cast.Character }}</p>
            </td>
            <td>
              <button
                class="btn btn-lg btn-danger"
                @click.prevent="castDelete(index)"
              >
                حذف
              </button>
            </td>
          </tr>
        </tbody>
      </div>
      <label for="fname">تصویر </label>
      <input type="file" class="custom-file-input" @change="onFileSelected" />
      <label for="checkbox" class="cinema-carpet">روی پرده سینما </label>
      <input type="checkbox" id="checkbox" v-model="MovieData.InTheaters" />

      <button
        type="submit"
        @click.prevent="submitData"
        class="btn btn-success btn-block"
      >
        ثبت
      </button>
      <router-link to="/MoviePanel">
        <button type="submit" class="btn btn-danger btn-block">
          بازگشت
        </button>
      </router-link>
    </form>
  </div>
</template>

<script>
export default {
  props: ['Peoples', 'Genres'],

  data() {
    return {
      MovieData: {
        Title: '',
        Rate: '',
        ReleaseDate: '',
        Directors: [],
        Casters: [],
        ShortPara: '',
        LongPara: '',
        GenresIds: [],
        Picture: null,
        InTheaters: false
      },
      Directors: [],
      GenresIds: '',
      preCasters: []
    };
  },
  methods: {
    castDelete(id) {
      this.MovieData.Casters.splice(id, 1);
    },

    castPush() {
      this.MovieData.Casters.push(this.preCasters);
    },
    submitData() {
      this.MovieData.Directors.push(this.Directors);
      this.MovieData.GenresIds.push(this.GenresIds);

      const form = new FormData();
      // this.formAppender('Title', this.MovieData.Title);
      form.append('Title', this.MovieData.Title);
      form.append('Rate', this.MovieData.Rate);
      form.append('DirectorsId', JSON.stringify(this.MovieData.Directors));
      form.append('ShortDescription', this.MovieData.ShortPara);
      form.append('Description', this.MovieData.LongPara);
      form.append('GenresId', JSON.stringify(this.MovieData.GenresIds));
      form.append('Cast', JSON.stringify(this.MovieData.Casters));
      form.append('Picture', this.MovieData.Picture);
      form.append('InTheaters', this.MovieData.InTheaters);
      form.append('ReleaseDate', this.MovieData.ReleaseDate);
      this.$emit('SubmitData', form);
    },
    onFileSelected(event) {
      this.MovieData.Picture = event.target.files[0];
    }
  }
};
</script>

<style></style>
