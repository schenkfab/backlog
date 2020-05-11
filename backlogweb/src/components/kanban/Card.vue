<template>
    <li class="p-4 mb-3 flex justify-between items-center bg-white shadow rounded-lg cursor-move" style="min-width: 300px;">
        <div class="flex items-center">
            <img class="w-10 h-10 rounded-full" :src="user.avatar" :alt="user.name">
            <p class="ml-2 text-gray-700 font-semibold font-sans tracking-wide">{{user.name}}</p>
        </div>
        <div class="flex">
            <button aria-label="Go to Link"
                    class="p-1 focus:outline-none focus:shadow-outline text-purple-500 hover:text-purple-600"
                    @click="$emit('onExternalLink', user)">
                <ExternalLinkIcon/>
            </button>
        </div>
    </li>
</template>
<script>
import { ExternalLinkIcon } from 'vue-feather-icons'
export default {
  components: {
    ExternalLinkIcon
  },
  props: {
    user: {
      type: Object,
      default: () => ({})
    }
  }
}
</script>
