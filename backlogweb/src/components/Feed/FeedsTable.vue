<template>
  <table class="table-auto w-full" v-if="this.feeds">
      <thead>
        <tr>
          <th class="px-4 py-2">Name</th>
          <th class="px-4 py-2">Url</th>
          <th class="px-4 py-2">Last Crawl</th>
          <th class="px-4 py-2">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="feed in this.feeds" :key="feed.id">
          <td class="border px-4 py-2 text-center">{{ feed.name }}</td>
          <td class="border px-4 py-2">{{ feed.url }}</td>
          <td class="border px-4 py-2">{{ feed.lastCrawl }}</td>
          <td class="border px-4 py-2">
            <button class="bg-white hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow" @click="subscribe(feed.id)">
              Subscribe
            </button>
          </td>
        </tr>
      </tbody>
    </table>
</template>

<script>
export default {
  props: {
    feeds: {
      type: Array,
      default: () => ([])
    }
  },
  methods: {
    subscribe: function (id) {
      this.$emit('subscribe', id)
    }
  }
}
</script>

<style>

</style>
