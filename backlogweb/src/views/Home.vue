<template>
  <div class="text-center">
    <div class="bg-gray-200 flex justify-center p-2">
      <div class="w-full max-w-md text-center p-2">
        <p class="mb-2 text-gray-700-font-semibold font-sans tracking-wide">List 1</p>
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
            @on-edit="onEdit"
            @on-delete="onDelete"
          ></card>
        </draggable>
      </div>
      <div class="w-full max-w-md text-center p-2">
        <p class="mb-2 text-gray-700-font-semibold font-sans tracking-wide">List 2</p>
        <draggable
          tag="ul"
          class="w-full max-w-md"
          ghost-class="moving-card"
          :list="users2"
          :animation="200"
          style="min-height:400px"
          group="all"
        >
          <card
            v-for="user in users2"
            :user="user"
            :key="user.id"
            @on-edit="onEdit"
            @on-delete="onDelete"
          ></card>
        </draggable>
      </div>
    </div>
  </div>
</template>

<script>
import Card from '@/components/kanban/Card'
import Draggable from 'vuedraggable'

export default {
  name: 'Home',
  components: {
    Card,
    Draggable
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
  }
}
</script>
