<template>
  <div class="text-center">
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-4" v-if="this.getUser.initialized">
        <column :entities="backlog" @onUpdate="update" title="Backlog" color="gray" @onExternalLink="triggerExternalLink" />
        <column :entities="toDo" @onUpdate="update" title="To Do" color="purple" @onExternalLink="triggerExternalLink"/>
        <column :entities="inProgress" @onUpdate="update" title="In Progress" color="blue" @onExternalLink="triggerExternalLink"/>
        <div>
          <column :entities="done" @onUpdate="update" title="Done" color="green" @onExternalLink="triggerExternalLink"/>
          <column :entities="rejected" @onUpdate="update" title="Rejected" color="red" @onExternalLink="triggerExternalLink"/>
        </div>
    </div>
  </div>
</template>
<script>
import Column from '@/components/kanban/Column'
import { mapActions, mapMutations, mapGetters } from 'vuex'

export default {
  name: 'Home',
  components: {
    Column
  },
  data () {
    return {
      highlighted: {},
      hasHighlight: false
    }
  },
  methods: {
    triggerExternalLink (entity) {
      var win = window.open(entity.link, '_blank')
      win.focus()
    },
    update (event, board) {
      let status = 0
      if (board === 'Backlog') {
        status = 0
      } else if (board === 'To Do') {
        status = 1
      } else if (board === 'In Progress') {
        status = 2
      } else if (board === 'Done') {
        status = 3
      } else if (board === 'Rejected') {
        status = 4
      }

      const el = event.added.element
      el.status = status

      this.setStatusAsync({ itemId: el.id, statusId: el.status })
    },
    ...mapActions(['getUserAsync', 'setStatusAsync']),
    ...mapMutations(['setToDo', 'setLoading'])
  },
  computed: {
    ...mapGetters(['getUser']),
    backlog: {
      get () {
        return this.$store.state.backlog
      },
      set (val) {
        this.$store.commit('setBacklog', val)
      }
    },
    toDo: {
      get () {
        return this.$store.state.toDo
      },
      set (val) {
        console.log(val)
        this.setToDo(val)
      }
    },
    inProgress: {
      get () {
        return this.$store.state.inProgress
      },
      set (val) {
        this.$store.commit('setInProgress', val)
      }
    },
    done: {
      get () {
        return this.$store.state.done
      },
      set (val) {
        this.$store.commit('setDone', val)
      }
    },
    rejected: {
      get () {
        return this.$store.state.rejected
      },
      set (val) {
        this.$store.commit('setRejected', val)
      }
    }

  },
  mounted: async function () {
    this.setLoading(true)
    await this.getUserAsync()
    this.setLoading(false)
  }
}
</script>
