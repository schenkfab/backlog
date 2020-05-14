<template>
  <div id="app">
    <Nav class="mb-6"></Nav>
    <div class="se-pre-con" v-if="getLoading"></div>
    <div class="mx-auto px-4">
      <router-view/>
    </div>
  </div>
</template>
<script>
import { mapGetters } from 'vuex'
import Nav from '@/components/Nav'

export default {
  name: 'App',
  components: { Nav },
  computed: {
    ...mapGetters(['getLoading'])
  }
}

</script>

<style>
.se-pre-con {
  position: fixed;
  left: 0px;
  top: 0px;
  width: 100%;
  height: 100%;
  z-index: 9999;
  background: url(https://smallenvelop.com/wp-content/uploads/2014/08/Preloader_11.gif) center no-repeat #fff;
}
</style>
