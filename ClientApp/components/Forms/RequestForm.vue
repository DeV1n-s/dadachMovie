<template>
  <div
    class="modal fade"
    id="exampleModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">ثبت درخواست جدید</h5>
        </div>
        <div class="modal-body">
          <form>
            <div class="form-group">
              <label for="exampleFormControlInput1"></label>
              <div class="form-group">
                <form-input
                  label="موضوع درخواست"
                  :required="true"
                  id="name"
                  v-model="requestData.subject"
                />
              </div>
              <div class="form-group">
                <label for="exampleFormControlTextarea2">شرح درخواست</label>
                <textarea
                  class="form-control rounded-0"
                  id="exampleFormControlTextarea2"
                  rows="6"
                  v-model="requestData.message"
                ></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">
            بازگشت
          </button>
          <button type="button" class="btn btn-success" @click="PostRequest">
            ثبت
          </button>
        </div>
        <p class="text-danger mr-3" v-if="!isFormValid">
          خطا ! لطفا تمامی موارد حواسته شده را تکمیل کنید
        </p>
      </div>
    </div>
    <div class="alert-modal">
      <b-alert
        :show="dismissCountDown"
        variant="success"
        @dismissed="dismissCountDown = 0"
        @dismiss-count-down="countDownChanged"
      >
        <p>درخواست با موفقیت ثبت شد</p>
        <p>{{ dismissCountDown }}</p>
        <b-progress :max="dismissSecs" height="4px"></b-progress>
      </b-alert>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import FormInput from './FormInput.vue';
export default {
  data() {
    return {
      isFormValid: true,
      requestData: {
        subject: '',
        message: ''
      },
      dismissSecs: 3,
      dismissCountDown: 0,
      showDismissibleAlert: false
    };
  },
  methods: {
    valChecker() {
      if (this.requestData.subject === '') {
        this.isFormValid = false;
      }
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs;
    },
    async PostRequest() {
      this.isFormValid = true;
      await this.valChecker();
      if (this.isFormValid) {
        try {
          await axios.post('/api/requests/NewRequest', this.requestData, {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          });

          this.showAlert();
        } catch (error) {
          console.log(error);
          this.isFormValid = false;
        }
      }
    }
  },
  props: ['token'],
  components: { FormInput }
};
</script>

<style scoped>
.alert-modal {
  width: 25% !important;
}
</style>
