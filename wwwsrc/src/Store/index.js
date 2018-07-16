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
      state.keeps = []
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    addVault(state, vault) {
      state.vaults = []
    },
    setVaults(state, payload) {
      state.vaults = payload
    },
  },

  actions: {
    // AUTH
    login({ commit }, loginCredentials) {
      auth.post('login', loginCredentials)
        .then(res => {
          console.log('Successfully logged in')
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
        })
    },

    register({ commit, dispatch }, userData) {
      auth.post('register', userData)
      .then(res => {
        console.log('Successfully registered')
        commit('setUser', res.data)
        router.push({ name: 'login' })
      })
    },
    
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
      .then(res => {
        commit('setUser', res.data)
        router.push({ name: 'Home' })
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
    addKeep({ dispatch, commit }, keep) {
      api.post('/keeps', keep)
        .then(res => {
          dispatch('getKeeps')
        })
    },

    getKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    // VAULTS
    addVault({ dispatch, commit }, vault) {
      api.post('/vault', vault)
        .then(res => {
          dispatch('getvaults')
        })
    },

    getVaults({ commit, dispatch }) {
      api.get('/vaults')
        .then(res => {
          commit('setvaults', res.data)
        })
    },






  }
})
