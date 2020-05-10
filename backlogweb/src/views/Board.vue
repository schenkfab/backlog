<template>
  <div class="w-full items-center justify-center">
    <add-board></add-board>
    <div>
      <boards-table @subscribe="subscribe" :boards="this.getboards" :subscribed="this.getSubscribed"></boards-table>
    </div>

  </div>
</template>

<script>
import AddBoard from '@/components/Board/AddBoard'
import BoardsTable from '@/components/Board/BoardsTable'
import { mapGetters, mapActions } from 'vuex'

export default {
  components: {
    AddBoard, BoardsTable
  },
  data: () => {
    return {}
  },
  computed: {
    ...mapGetters(['getFeeds', 'getSubscribed'])
  },
  methods: {
    ...mapActions(['getFeedsAsync', 'addSubscriptionAsync', 'getUserAsync'])
  },
  mounted: async function () {
    await this.getUserAsync()
    await this.getBoardsAsync()
  }
}
</script>
