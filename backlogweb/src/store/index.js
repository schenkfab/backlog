import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import _URLs from '../config/path'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    backlog: [],
    toDo: [],
    inProgress: [],
    done: [],
    rejected: [],
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
    },
    setBacklog (state, d) {
      state.backlog = d
    },
    setToDo (state, d) {
      state.toDo = d
    },
    setInProgress (state, d) {
      state.inProgress = d
    },
    setRejected (state, d) {
      state.rejected = d
    },
    setDone (state, d) {
      state.done = d
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

        const backlog = []
        const toDo = []
        const inProgress = []
        const done = []
        const rejected = []

        data[0].boardItems.forEach(o => {
          if (o.status === 1) {
            backlog.push(o)
          } else if (o.status === 2) {
            toDo.push(o)
          } else if (o.status === 3) {
            inProgress.push(o)
          } else if (o.status === 4) {
            done.push(o)
          } else if (o.status === 5) {
            rejected.push(o)
          }
        })

        commit('setBacklog', backlog)
        commit('setToDo', toDo)
        commit('setInProgress', inProgress)
        commit('setDone', done)
        commit('setRejected', rejected)

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
