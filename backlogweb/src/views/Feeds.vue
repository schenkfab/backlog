<template>
  <div class="w-full items-center justify-center">
    <add-feed></add-feed>
    <div>
      <feeds-table @subscribe="subscribe" :feeds="this.getFeeds" :subscribed="this.getSubscribed"></feeds-table>
    </div>

  </div>
</template>

<script>
import AddFeed from '@/components/Feed/AddFeed'
import FeedsTable from '@/components/Feed/FeedsTable'
import { mapGetters, mapActions } from 'vuex'

export default {
  components: {
    AddFeed, FeedsTable
  },
  data: () => {
    return {}
  },
  computed: {
    ...mapGetters(['getFeeds', 'getSubscribed'])
  },
  methods: {
    ...mapActions(['getFeedsAsync', 'addSubscriptionAsync', 'getUserAsync']),
    subscribe: async function (id) {
      await this.addSubscriptionAsync(id)
    }
  },
  mounted: async function () {
    await this.getUserAsync()
    await this.getFeedsAsync()
  }
}
</script>
