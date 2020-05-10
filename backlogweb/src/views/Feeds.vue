<template>
  <div class="w-full items-center justify-center">
    <add-feed></add-feed>
    <div>
      <feeds-table @subscribe="subscribe" :feeds="this.getFeeds"></feeds-table>
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
    ...mapGetters(['getFeeds'])
  },
  methods: {
    ...mapActions(['getFeedsAsync']),
    subscribe: function (id) {
      console.log(id)
    }
  },
  mounted: function () {
    this.getFeedsAsync()
  }
}
</script>
