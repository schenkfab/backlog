import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import _URLs from '../config/path'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    feeds: [],
    token: {
      token: ''
    },
    user: {
    },
    subscribed: []
  },
  getters: {
    getFeeds: state => state.feeds,
    getUser: state => state.user,
    getSubscribed: state => state.subscribed
  },
  mutations: {
    setUser (state, user) {
      state.user = user
      state.user.initialized = true
    },
    setToken (state, token) {
      state.token = token
      state.token.initialized = true
    },
    setFeeds (state, feeds) {
      state.feeds = feeds
    },
    setSubscribed (state, subscribed) {
      state.subscribed = subscribed
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
        headers: { Authorization: `Bearer ${state.token.token}` }
      }
      try {
        await axios.post(_URLs.POST_FEED(), feed, options)
      } catch (err) {
        console.log(err)
      }

      dispatch('getFeedsAsync')
    },
    getUserAsync: async ({ commit, state }) => {
      try {
        const options = {
          headers: { Authorization: `Bearer ${state.token.token}` }
        }
        const { data } = await axios.get(_URLs.GET_User(), options)
        commit('setUser', data[0])

        // get all subscribed feed Ids:
        var subscribed = []
        data[0].subscriptions.forEach(o => {
          subscribed.push(o.feed.id)
        })

        commit('setSubscribed', subscribed)
      } catch (err) {
        console.log(err)
      }
    },
    addSubscriptionAsync: async ({ dispatch, state }, feedId) => {
      const options = {
        headers: { Authorization: `Bearer ${state.token.token}` }
      }

      const sub = {
        userId: state.user.id,
        feedId: feedId
      }

      try {
        await axios.post(_URLs.POST_Subscription(), sub, options)
      } catch (err) {
        console.log(err)
      }

      dispatch('getUserAsync')
    }
  }
})
