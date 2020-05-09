<template>
  <form class="w-full">
  <div class="md:flex md:items-center mb-6">
    <div class="md:w-1/4">
      <label class="block text-gray-500 font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-full-name">
        Feed URL:
      </label>
    </div>
    <div class="md:w-2/4 pr-4">
      <input class="bg-gray-200 appearance-none border-2 border-gray-200 rounded w-full py-2 px-4 text-gray-700 leading-tight focus:outline-none focus:bg-white focus:border-purple-500" type="text" :value="url">
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
</form>
</template>

<script>
export default {
  data: () => {
    return {
      url: 'https://cloudblogs.microsoft.com/sqlserver/feed/'
    }
  },
  methods: {
    addFeed: () => {
      console.log('hello!')
    }
  }
}
</script>

<style>

</style>
