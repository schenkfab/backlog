<template>
  <div class="text-center">
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-4">
        <column :entities="backlog" @onEdit="onEdit" @onDelete="onDelete" @onUpdate="update" title="Backlog" color="gray"  />
        <column :users="users2" @onEdit="onEdit" @onDelete="onDelete" @onUpdate="update" title="To Do" color="purple" />
        <column :users="users" @onEdit="onEdit" @onDelete="onDelete" @onUpdate="update" title="In Progress" color="blue" />
        <div>
          <column :users="users" @onEdit="onEdit" @onDelete="onDelete" @onUpdate="update" title="Done" color="green" />
          <column :users="users" @onEdit="onEdit" @onDelete="onDelete" @onUpdate="update" title="Rejected" color="red" />
        </div>
    </div>
  </div>
</template>
<script>
import Column from '@/components/kanban/Column'
import { mapActions } from 'vuex'

export default {
  name: 'Home',
  components: {
    Column
  },
  data () {
    return {
      users2: [],
      users: [
        {
          id: 1,
          name: 'Adrian Schubert',
          avatar:
            'https://pickaface.net/gallery/avatar/unr_sample_161118_2054_ynlrg.png'
        },
        {
          id: 2,
          name: 'Violet Gates',
          avatar: 'https://pickaface.net/gallery/avatar/freud51c8b3f65e7dc.png'
        },
        {
          id: 3,
          name: 'Steve Jobs',
          avatar: 'https://pickaface.net/gallery/avatar/Opi51c74d0125fd4.png'
        },
        {
          id: 4,
          name: 'Yassine Smith',
          avatar:
            'https://pickaface.net/gallery/avatar/unr_yassine_191124_2012_3gngr.png'
        },
        {
          id: 5,
          name: 'Senior Saez',
          avatar:
            'https://pickaface.net/gallery/avatar/elmedinilla541c03412955c.png'
        }
      ]
    }
  },
  methods: {
    onEdit (user) {
      alert(`Editing ${user.name}`)
    },
    onDelete (user) {
      alert(`Deleting ${user.name}`)
    },
    update (event, board) {
      console.log(`Element with id ${event.added.element.id} was added to board ${board}`)
    },
    ...mapActions(['getUserAsync'])
  },
  computed: {
    backlog: {
      get () {
        return this.$store.state.backlog
      },
      set (val) {
        this.$store.commit('setBacklog', val)
      }
    }
  },
  mounted: async function () {
    await this.getUserAsync()
  }
}
</script>
