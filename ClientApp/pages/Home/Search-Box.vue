<template>
  <div id="cover" class="container">
    <form method="get" action="">
      <div class="tb">
        <div class="td">
          <input
            type="text"
            v-model="searchTitle"
            placeholder="جست و جو در بین فیلم ها "
            required
          />
        </div>
        <div class="td" id="s-cover" @click="subSearch">
          <button type="submit" class="mb-1">
            <div id="s-circle"></div>
            <span></span>
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
      this.$router.push(`${this.searchTitle}`);
    }
  }
};
</script>

<style scoped>
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
  background-color: #ff7575;
  border-radius: 10px;
  box-shadow: 0 10px 40px #ff7c7c, 0 0 0 20px #ffffffeb;
  transform: scaley(0.6);
  width: 54%;
  margin-left: 23.5%;
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
  color: #e16868;
}

#s-cover {
  width: 1px;
  padding-left: 35px;
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
