<template>
  <div class="loader-background">
    <div class="loader"></div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.loader-background {
  position: absolute;
  top: 0;
  height: 100%;
  background-color: black;
  opacity: 0.5;
  width: 100%;
}

.loader {
  position: absolute;
  top: 40%;
  left: 50%;
  border: 16px solid #f3f3f3;
  border-radius: 50%;
  border-top: 16px solid #3498db;
  width: 120px;
  height: 120px;
  -webkit-animation: spin 2s linear infinite; /* Safari */
  animation: spin 2s linear infinite;
}

/* Safari */
@-webkit-keyframes spin {
  0% {
    -webkit-transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
  }
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
