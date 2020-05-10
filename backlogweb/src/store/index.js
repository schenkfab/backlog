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
    getFeeds: state => state.feeds,
    getUser: state => state.user
  },
  mutations: {
    setUser (state, user) {
      state.user = user
      state.user.initialized = true
    },
    setFeeds (state, feeds) {
      state.feeds = feeds
    }
  },
  actions: {
    getFeedsAsync: async ({ commit }) => {
      try {
        const { data } = await axios.get(_URLs.GET_FEED())
        commit('setFeeds', data)
      } catch (err) {
        console.log(err)
      }
    },
    addFeedAsync: async ({ dispatch, state }, feed) => {
      const options = {
        headers: { Authorization: `Bearer ${state.user.token}` }
      }
      try {
        await axios.post(_URLs.POST_FEED(), feed, options)
      } catch (err) {
        console.log(err)
      }

      dispatch('getFeedsAsync')
    }
  }
})
