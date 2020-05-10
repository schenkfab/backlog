<template>
  <nav class="flex items-center justify-between flex-wrap bg-purple-500 p-4">
    <div class="flex items-center flex-shrink-0 text-white mr-6">
     <alc /><span class="font-semibold text-xl tracking-tight pl-4"> News Backlog</span>
    </div>
    <div class="w-full block flex-grow lg:flex lg:items-center lg:w-auto">
      <div class="text-sm lg:flex-grow">
        <router-link class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/">Home</router-link>
        <router-link class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/about">About</router-link>
        <router-link class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/rss">rss</router-link>
        <router-link class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/feeds">Feeds</router-link>
      </div>
      <div>
        <router-link v-if="!this.getUser.initialized" class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/login">Login</router-link>
        <router-link v-if="this.getUser.initialized" class="block mt-4 lg:inline-block lg:mt-0 text-white text-lg hover:text-white mr-4" to="/">{{ this.getUser.name }}</router-link>
      </div>
    </div>
  </nav>
</template>

<script>
import { ArrowLeftCircleIcon } from 'vue-feather-icons'
import { mapGetters } from 'vuex'

export default {
  name: 'Nav',
  components: { alc: ArrowLeftCircleIcon },
  computed: {
    ...mapGetters(['getUser'])
  },
  mounted: function () {
    console.log(this.getUser)
  }
}
</script>
