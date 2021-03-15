<template>
  <div class="container">
    <div class="soon-movies ">
      <h4 class="mr-0 mb-3">
        <strong><i class="fa fa-film ml-1 "></i> به زودی ...</strong>
      </h4>
      <div class="container mt-1">
        <div class="card">
          <img src="http://localhost:5000/SeedData/tombraider.jpg" />
          <div class="card__head">TombRaider</div>
        </div>
        <div class="card">
          <img src="http://localhost:5000/SeedData/tombraider.jpg" />
          <div class="card__head">TombRaider</div>
        </div>
        <div class="card">
          <img src="http://localhost:5000/SeedData/tombraider.jpg" />
          <div class="card__head">TombRaider</div>
        </div>
        <div class="card">
          <img src="http://localhost:5000/SeedData/tombraider.jpg" />
          <div class="card__head">TombRaider</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
h4 {
  padding: 10px;
  padding-left: 25px;
  color: #ccc;
  margin: 0;
}
h4 strong {
  z-index: 2;
  background: #24282f;
  padding: 4px 8px;
}
h4 span {
  font-size: 0.7em;
  color: #aaa;
  margin-left: 10px;
}
h4:after {
  content: '';
  z-index: 1;
  bottom: 50%;
  margin-bottom: -2px;
  height: 2px;
  left: 0;
  right: 0;
  background: #373d47;
}
.container .mt-1 {
  box-shadow: 0px 6px 12px 0px #8888;
}
</style>
