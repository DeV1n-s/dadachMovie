<template>
  <div id="cover" class="container">
    <form method="get" action="">
      <div class="tb">
        <div class="td">
          <input
            class="search-form"
            type="text"
            v-model="searchTitle"
            placeholder="جست و جو در بین فیلم ها "
            required
          />
        </div>
        <div class="td" id="s-cover" @click.prevent="subSearch">
          <button type="submit" class="mb-1">
            <ul class="loading-frame">
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
              <div class="circle"></div>
            </ul>
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      searchTitle: ''
    };
  },
  methods: {
    subSearch() {
      this.$router.push(`MovieSearch/${this.searchTitle}`);
    }
  }
};
</script>

<style scoped>
body {
  background-color: #333;
}
.loading-frame {
  position: absolute;
  top: 25%;
  left: 55%;
}
.circle {
  position: absolute;
  height: 9px;
  width: 9px;
  border-radius: 15px;
  background-color: #3fc380;
  animation: animate linear 2s infinite;
}
.circle:nth-child(1) {
  animation-delay: 0.9s;
}
.circle:nth-child(2) {
  animation-delay: 1.1s;
  transform: translate(18px, 13px);
}
.circle:nth-child(3) {
  animation-delay: 1.3s;
  transform: translate(35px, 25px);
}
.circle:nth-child(4) {
  animation-delay: 1.1s;
  transform: translate(18px, 38px);
}
.circle:nth-child(5) {
  animation-delay: 0.9s;
  transform: translate(0px, 50px);
}
.circle:nth-child(6) {
  animation-delay: 0.9s;
  transform: translate(0, 25px);
}
.circle:nth-child(7) {
  animation-delay: 0.7s;
  transform: translate(-20px, 25px);
}
.circle:nth-child(8) {
  animation-delay: 0.5s;
  transform: translate(-40px, 25px);
}
.circle:nth-child(9) {
  animation-delay: 0.3s;
  transform: translate(-60px, 25px);
}
.circle:nth-child(10) {
  animation-delay: 0.1s;
  transform: translate(-80px, 25px);
}
@keyframes animate {
  0%,
  100% {
    background-color: #3fc380;
  }
  50% {
    background-color: #fff;
  }
}

input:focus {
  outline: none;
}
.tb {
  display: table;
  width: 100%;
}

.td {
  display: table-cell;
  vertical-align: middle;
}

input,
button {
  color: #fff;
  padding: 0;
  margin-bottom: 1.5rem;
  border: none;
  background-color: transparent;
}

#cover {
  background-color: #6c757d;
  border-radius: 10px;
  box-shadow: 0 10px 20px #6c757d, 0 0 0 10px #ffffffeb;
  transform: scaley(0.6);
  width: 55%;
  margin-left: 22.95%;
  height: 70px;
}

form {
  height: 70px;
}

input[type='text'] {
  width: 100%;
  height: 70px;
  font-size: 40px;
  line-height: 1;
}

input[type='text']::placeholder {
  color: #ccc;
}

#s-cover {
  width: 1px;
  padding-left: 55px;
  margin-bottom: 0.5rem !important;
}

button {
  position: relative;
  display: block;
  width: 84px;
  height: 90px;
  cursor: pointer;
  bottom: 1rem;
}

#s-circle {
  position: relative;
  top: -8px;
  left: 0;
  width: 43px;
  height: 43px;
  margin-top: 0;
  border-width: 15px;
  border: 15px solid #fff;
  background-color: transparent;
  border-radius: 50%;
  transition: 0.5s ease all;
}

button span {
  position: absolute;
  top: 68px;
  left: 43px;
  display: block;
  width: 45px;
  height: 15px;
  background-color: transparent;
  border-radius: 10px;
  transform: rotateZ(52deg);
  transition: 0.5s ease all;
}

button span:before,
button span:after {
  content: '';
  position: absolute;
  bottom: 0;
  right: 0;
  width: 45px;
  height: 15px;
  background-color: #fff;
  border-radius: 10px;
  transform: rotateZ(0);
  transition: 0.5s ease all;
}

#s-cover:hover #s-circle {
  top: -1px;
  width: 67px;
  height: 15px;
  border-width: 0;
  background-color: #fff;
  border-radius: 20px;
}

#s-cover:hover span {
  top: 50%;
  left: 56px;
  width: 25px;
  margin-top: -9px;
  transform: rotateZ(0);
}

#s-cover:hover button span:before {
  bottom: 11px;
  transform: rotateZ(52deg);
}

#s-cover:hover button span:after {
  bottom: -11px;
  transform: rotateZ(-52deg);
}
#s-cover:hover button span:before,
#s-cover:hover button span:after {
  right: -6px;
  width: 40px;
  background-color: #fff;
}

#ytd-url {
  display: block;
  position: fixed;
  right: 0;
  bottom: 0;
  padding: 10px 14px;
  margin: 20px;
  color: #fff;
  font-family: Nunito;
  font-size: 14px;
  text-decoration: none;
  background-color: #ff7575;
  border-radius: 4px;
  box-shadow: 0 10px 20px -5px rgba(255, 117, 117, 0.86);
  z-index: 125;
}
</style>
