<template>
  <div>
    <add-feed></add-feed>
  </div>
</template>

<script>
import AddFeed from '@/components/Feed/AddFeed'
export default {
  components: {
    AddFeed
  },
  data: () => {
    return {
      feeds: []
    }
  }
}
</script>
