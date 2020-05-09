<template>
  <div>Hi there!</div>
</template>

<script>

import Parser from 'rss-parser'

export default {
  name: 'Home',

  data () {
    return {
      users2: [],
      users: []
    }
  },
  methods: {
  },
  created: async function () {
    const parser = new Parser()
    const o = await parser.parseURL('https://cors-anywhere.herokuapp.com/https://www.brentozar.com/blog/feed/')
    console.log(o)
  }
}
</script>
