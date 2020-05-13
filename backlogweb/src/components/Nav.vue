<template>
  <nav class="flex items-center justify-between flex-wrap p-4 border-b">
    <div class="flex items-center flex-shrink-0 mr-6">
     <rss /><span class="font-semibold text-xl tracking-tight pl-4"> News Backlog</span>
    </div>
    <div class="w-full block flex-grow lg:flex lg:items-center lg:w-auto">
      <div class="text-sm lg:flex-grow">
        <router-link class="block mt-4 lg:inline-block lg:mt-0 hover:text-gray-400 mr-4" to="/">Home</router-link>
        <router-link class="block mt-4 lg:inline-block lg:mt-0 hover:text-gray-400 mr-4" to="/feeds">Feeds</router-link>
      </div>
      <div>
        <router-link v-if="!this.getUser.initialized" class="block mt-4 lg:inline-block lg:mt-0 text-sm hover:text-gray-400 mr-4" to="/login">Login</router-link>
        <router-link v-if="this.getUser.initialized" class="block mt-4 lg:inline-block lg:mt-0 text-sm hover:text-gray-400 mr-4" to="/">{{ this.getUser.name }}</router-link>
      </div>
    </div>
  </nav>
</template>

<script>
import { RssIcon } from 'vue-feather-icons'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'Nav',
  components: { rss: RssIcon },
  methods: {
    ...mapActions(['getUserAsync'])
  },
  computed: {
    ...mapGetters(['getUser'])
  }
}
</script>
