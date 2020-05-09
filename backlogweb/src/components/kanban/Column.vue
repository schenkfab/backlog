<template>
  <div class="w-full max-w-md text-center p-2">
    <p class="mb-2 text-gray-700-font-semibold font-sans tracking-wide">{{ title }}</p>
    <draggable
      tag="ul"
      class="w-full max-w-md"
      ghost-class="moving-card"
      :list="users"
      :animation="200"
      group="all"
      style="min-height:400px"
    >
      <card
        v-for="user in users"
        :user="user"
        :key="user.id"
        @on-edit="triggerEdit"
        @on-delete="triggerDelete"
      ></card>
    </draggable>
  </div>
</template>

<script>
import Card from '@/components/kanban/Card'
import Draggable from 'vuedraggable'
export default {
  components: {
    Card,
    Draggable
  },
  props: {
    users: {
      type: Array,
      default: () => []
    },
    group: {
      type: String,
      default: () => 'all'
    },
    title: {
      type: String,
      default: () => 'Column'
    },
    onDelete: {
      type: Function
    },
    onEdit: {
      type: Function
    }
  },
  methods: {
    triggerEdit (user) {
      this.$emit('onEdit', user)
    },
    triggerDelete (user) {
      this.$emit('onDelete', user)
    }
  }
}
</script>

<style>
</style>
