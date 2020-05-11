<template>
<div class="w-full max-w-md text-center p-1">
  <div :class="this.class">
    <p class="mb-2 text-gray-700 font-semibold font-sans tracking-wide">{{ title }}</p>
    <draggable
      tag="ul"
      class="w-full max-w-md"
      ghost-class="moving-card"
      :list="users"
      :animation="200"
      group="all"
      style="min-height:400px"
      @change="onUpdate"
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
  computed: {
    class: function () {
      return `w-full max-w-md text-center p-2 bg-${this.color}-200 rounded-lg`
    }
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
    },
    color: {
      type: String,
      default: () => 'Blue'
    }
  },
  methods: {
    triggerEdit (user) {
      this.$emit('onEdit', user)
    },
    triggerDelete (user) {
      this.$emit('onDelete', user)
    },
    onUpdate (event, x) {
      if (event.added) {
        this.$emit('onUpdate', event, this.title)
      }
    }
  }
}
</script>

<style>
</style>
