<template>
    <li class="p-2 mb-3 bg-white shadow rounded-lg cursor-move" style="min-width: 300px;">
        <div class="flex justify-between items-center">
          <div class="flex items-center">
            <img class="w-10 h-10 rounded-full" v-if="data.picture" :src="data.picture" :alt="data.name">
            <img class="w-10 h-10 rounded-full" v-if="!data.picture" src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Generic_Feed-icon.svg/1024px-Generic_Feed-icon.svg.png" :alt="data.name">
            <p class="ml-2 text-gray-700 font-sans tracking-wide text-sm">{{data.name}}</p>
          </div>
          <div class="flex">
            <button aria-label="Go to Link"
                    class="p-1 focus:outline-none focus:shadow-outline text-purple-500 hover:text-purple-600"
                    @click="$emit('onExternalLink', data)">
                <ExternalLinkIcon/>
            </button>
          </div>
        </div>
        <p class="text-gray-400 font-sans text-xs">{{(new Date(data.date)).toLocaleDateString()}}</p>
    </li>
</template>
<script>
import { ExternalLinkIcon } from 'vue-feather-icons'
export default {
  components: {
    ExternalLinkIcon
  },
  props: {
    data: {
      type: Object,
      default: () => ({})
    }
  }
}
</script>
