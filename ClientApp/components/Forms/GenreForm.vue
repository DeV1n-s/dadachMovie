<template>
  <div>
    <div class="modal fade" id="addCategoryModal">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header bg-danger text-white">
            <h5 class="modal-title">اضافه کردن ژانر</h5>
            <button class="close" data-dismiss="modal">
              <span>&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <div class="form-group">
                <form-input
                  label="نام ژانر"
                  :required="true"
                  id="name"
                  v-model="genreData.name"
                />
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button
              class="btn btn-success"
              data-dismiss="modal"
              @click="subGenre"
            >
              افزودن
            </button>
          </div>
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
        <p>ژانر با موفقیت اضافه شد</p>
        <p>{{ dismissCountDown }}</p>
        <b-progress :max="dismissSecs" height="4px"></b-progress>
      </b-alert>
    </div>
  </div>
</template>

<script>
import FormInput from './FormInput';
import axios from 'axios';
export default {
  data() {
    return {
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      genreData: {
        name: ''
      },
      token: this.$store.getters.token
    };
  },
  components: {
    FormInput
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    async subGenre() {
      await axios.post('/api/genres', this.genreData, {
        headers: {
          Authorization: ` Bearer ${this.token}`
        }
      });
      this.showAlert();
    }
  }
};
</script>

<style scoped>
.alert-modal {
  float: left;
  margin-right: 1rem;
  margin-top: 1rem;
  position: fixed;
  width: 25%;
  top: 0%;
}
</style>
