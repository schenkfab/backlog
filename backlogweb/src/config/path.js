module.exports = {
  POST_FEED () {
    return 'https://localhost:44312/api/feeds'
  },
  GET_FEED () {
    return 'https://localhost:44312/api/feeds'
  },
  POST_Subscription () {
    return 'https://localhost:44312/api/subscriptions'
  },
  GET_User () {
    return 'https://localhost:44312/api/users'
  },
  POST_NON_DUB_USER () {
    return 'https://localhost:44312/api/users'
  },
  PATCH_ITEM (itemId, statusId) {
    return `https://localhost:44312/api/users/${itemId}/${statusId}`
  }
}
