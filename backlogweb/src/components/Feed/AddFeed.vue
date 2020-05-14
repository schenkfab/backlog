<template>
  <form>
  <div class="md:flex md:items-center mb-6">
    <div class="md:w-1/4">
      <label class="block text-gray-500 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name">
        Feed URL:
      </label>
    </div>
    <div class="md:w-2/4 pr-4">
      <input class="bg-gray-200 appearance-none border-2 border-gray-200 rounded w-full py-2 px-4 text-gray-700 leading-tight focus:outline-none focus:bg-white focus:border-purple-500" type="text" v-model="url">
    </div>
    <div class="md:w-1/4 md:items-center">
      <div class="md:w-1/3"></div>
      <div class="md:w-2/3">
        <button class="shadow bg-purple-500 hover:bg-purple-400 focus:shadow-outline focus:outline-none text-white font-bold py-2 px-4 rounded" type="button" @click="getFeed">
        Get Feed
        </button>
      </div>
    </div>
  </div>
  <div class="md:flex md:items-center mb-6">
    <div class="md:w-1/4">
      <label class="block text-gray-500 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name">
        Feed Title:
      </label>
    </div>
    <div class="md:w-2/4 pr-4">
      <input class="bg-gray-200 appearance-none border-2 border-gray-200 rounded w-full py-2 px-4 text-gray-700 leading-tight focus:outline-none focus:bg-white focus:border-purple-500" type="text" v-model="title">
    </div>
    <div class="md:w-1/4 md:items-center">
      <div class="md:w-1/3"></div>
      <div class="md:w-2/3">
        <button class="shadow bg-purple-500 hover:bg-purple-400 focus:shadow-outline focus:outline-none text-white font-bold py-2 px-4 rounded" type="button" @click="addFeed">
        Add Feed
        </button>
      </div>
    </div>
  </div>
  <div v-if="created">
    <div class="bg-blue-100 border-t border-b border-blue-500 text-blue-700 px-4 py-3 pb-2" role="alert" v-if="this.title">
      <p class="text-sm">{{ `Feed ${this.title} has been added.` }}</p>
    </div>
  </div>
</form>
</template>

<script>
import { mapActions } from 'vuex'
import Parser from 'rss-parser'

export default {
  data: () => {
    return {
      url: 'https://cloudblogs.microsoft.com/sqlserver/feed/',
      created: false,
      title: null
    }
  },
  methods: {
    ...mapActions(['addFeedAsync']),
    async addFeed () {
      await this.addFeedAsync({ name: this.title, url: this.url })
      this.created = true
    },
    async getFeed () {
      const parser = new Parser()
      const o = await parser.parseURL(`https://cors-anywhere.herokuapp.com/${this.url}`)
      this.title = o.title
    }
  }
}
</script>

<style>

</style>
