<template>
  <div class="text-center">
    <div class="bg-gray-200 flex justify-center p-2">
        <column :users="backlog" @onEdit="onEdit" @onDelete="onDelete" />
        <column :users="users2" @onEdit="onEdit" @onDelete="onDelete" />
    </div>
  </div>
</template>

<script>
import Column from '@/components/kanban/Column'

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
    }
  },
  computed: {
    backlog: {
      get() {
        return this.$store.state.backlog
      },
      set(val) {
        this.$store.commit('setBacklog', val)
      }
    }
  }
}
</script>
