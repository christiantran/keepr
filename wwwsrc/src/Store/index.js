import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from "../router"

var production = !window.location.host.includes('localhost');
var baseUrl = production ? '//keepr2h.herokuapp.com' : '//localhost:5000/';


var api = axios.create({
  baseURL: baseUrl + 'api/',
  timeout: 3000,
  withCredentials: true
})
var auth = axios.create({
  baseURL: baseUrl + 'account/',
  timeout: 3000,
  withCredentials: true
})

vue.use(vuex)

export default new vuex.Store({
  state: {
    user: {},
    keeps: {},
    vaults: []
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    addKeep(state, keep) {
      state.keeps = keep
    },
    deleteKeep(state) {
      state.keeps = {}
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    addVault(state, vault) {
      state.vaults = vault
    },
    setVaults(state, payload) {
      state.vaults = payload
    },
    deleteVault(state) {
      state.vaults = []
    }
  },

  actions: {
    // AUTH

    login({ commit }, loginCredentials) {
      auth.post('login', loginCredentials)
        .then(res => {
          console.log('Successfully logged in')
          console.log(res.data)
          commit('setUser', res.data.data)
          router.push({ name: 'Profile' })
        })
    },

    register({ commit }, userData) {
      auth.post('register', userData)
        .then(res => {
          console.log('Successfully registered')
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
        })
    },

    authenticate({ commit}) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
        })
        .catch(res => {
          console.log(res.data)
        })
    },

    //   logout({ commit, dispatch }) {
    //     auth.delete('')
    //         .then(res => {
    //             console.log('You have successfully logged out')
    //             commit('deleteUser')
    //             router.push({ name: 'login' })
    //         })
    // },

    // KEEPS
    addKeep({ commit, dispatch }, keep) {
      api.post('api/keeps', keep)
        .then(res => {
          // dispatch('getKeeps')
          commit("setKeeps", res.data)
        })
    },

    getKeeps({ commit, dispatch }) {
      api.get('api/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    // VAULTS
    addVault({ commit, dispatch }, vault) {
      api.post('api/vaults/', vault)
        .then(res => {
          commit('setVaults', res.data)
        })
    },

    getVaults({ commit, dispatch }) {
      api.get('api/vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },






  }
})
