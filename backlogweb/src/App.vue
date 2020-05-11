<template>
  <div id="app">
    <Nav class="mb-6"></Nav>
    <div class="mx-auto px-4">
      <router-view/>
    </div>
  </div>
</template>
<script>

import Nav from '@/components/Nav'

export default {
  name: 'App',
  components: { Nav }
}

</script>

<style>
</style>
