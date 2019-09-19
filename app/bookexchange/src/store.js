import Vue from 'vue'
import Vuex from 'vuex'
import router from './router'

Vue.use(Vuex)

const types = {
  LOGIN: 'LOGIN',
  LOGOUT: 'LOGOUT'
}

const state = {
  logger: localStorage.getItem('token')
}

const getters = {
  isLogged: state => state.logged
}

const actions = {
  login ({commit}, credential) {
    Vue.http.post('http://localhost:5000/account/login', credential)
      .then((response) => response.json())
      .then((result) => {
        localStorage.setItem('token', result.token)
        commit(types.LOGIN)
        router.push({path: '/book/list'})
      })
  },
  subscribe () {
    Vue.http.post('http://localhost:5000/following/4c538a7f-ffab-41d7-a54f-eede2c972a70/subscribe')
      .then((response) => response.json())
      .then((result) => {
        localStorage.getItem('token', result.token)
        router.push({path: '/book/list'})
      })
  }
}

const mutations = {
  [types.LOGIN] (state) {
    state.logged = 1
  },

  [types.LOGOUT] (state) {
    state.logged = 0
  }
}

export default new Vuex.Store({
  state,
  getters,
  actions,
  mutations
})
