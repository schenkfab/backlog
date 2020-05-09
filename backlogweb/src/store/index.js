import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import _URLs from '../config/path'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    feeds: [],
    user: {
      token: ''
    }
  },
  getters: {
    getFeeds: state => {
      return state.feeds
    }
  },
  mutations: {
  },
  actions: {
    addFeedAsync: async ({ dispatch, commit, state }, feed) => {
      const options = {
        headers: { Authorization: `Bearer ${state.user.token}` }
      }

      await axios.post(_URLs.POST_FEED(), feed, options)

      dispatch('getFeedsAsync')
    }
  }
})
