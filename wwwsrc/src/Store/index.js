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
    userKeeps: [],
    vaults: [],
    activeVault: {},
    userVaults: [],
    vaultKeeps: [],
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    addKeep(state, keep) {
      state.keeps = keep
    },
    // deleteKeep(state) {
    //   state.keeps = {}
    // },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    addVault(state, vault) {
      state.vaults = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults
    },
    setActiveVault(state, vault) {
      state.activeVault = vault
    },
    // deleteVault(state) {
    //   state.vaults = []
    // },
    setVaultKeeps(state, keeps) {
      state.vaultKeeps = keeps
    },
    // deleteVaultKeeps(state) {
    //   state.vaultKeeps = []
    // }
  },

  actions: {
    // AUTH

    login({ commit, dispatch }, loginCredentials) {
      auth.post('login', loginCredentials)
        .then(res => {
          console.log('Successfully logged in')
          console.log(res.data)
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
          dispatch("getVaults", res.data.id)
        })
    },

    register({ commit, dispatch }, userData) {
      auth.post('register', userData)
        .then(res => {
          console.log('Successfully registered')
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
          dispatch("getVaults", res.data.id)
        })
    },

    // register({ commit }, userData) {
    //   console.log(userData)
    //   auth.post('account/register', userData)
    //       .then(res => {
    //           commit('setUser', res.data)
    //           // router.push({ name: 'UserProfile' })
    //       })

    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Profile' })
          dispatch("getVaults", res.data.id)
        })
        .catch(res => {
          console.log(res.data)
        })
    },

    logout({ commit, dispatch }) {
      auth.delete('')
        .then(res => {
          console.log('You have successfully logged out')
          commit('deleteUser')
          router.push({ name: 'login' })
        })
    },

    // KEEPS
    addKeep({ commit, dispatch }, keep) {
      api.post('/keeps', keep)
        .then(res => {
          dispatch('getKeeps', res.data)
          // commit("setKeeps", res.data)
        })
    },

    getKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    getUserKeeps({ commit, dispatch }, user) {
      api.get("/keeps/user" + user.id)
        .then(res => {
          commit("setUserKeeps", res.data)
        })
    },

    viewKeep({ commit, dispatch, state }, keep) {
      api.get('/keeps/' + keep.id, keep)
        .then(res => {
          commit('setActivekeep', res.data)
        })
    },

    editKeep({ commit, dispatch }, keep) {
      api.put('/keeps/' + keep.id, keep)
        .then(res => {
          dispatch('getKeeps')
        })
    },

    deleteKeep({ commit, dispatch, state }, keep) {
      api.delete('/keeps/' + keep._id, keep)
        .then(res => {
          commit("deleteKeep", res.data)
          dispatch('getKeeps')
        })
    },

    // VAULTS
    addVault({ commit, dispatch }, vault) {
      api.post('/vaults', vault)
        .then(res => {
          // commit('setVaults', res.data)
          dispatch('getvaults', res.data)
        })
    },

    // getVaults({ commit, dispatch }) {
    //   api.get('/vaults')
    //     .then(res => {
    //       commit('setVaults', res.data)
    //     })
    // },
    getVaults({ commit, dispatch, state }, userid) {
      api.get('/vaults/author/' + userid)
        .then(res => {
          commit('setUserVaults', res.data)
        })
    },

    viewVault({ commit, dispatch, state }, vault) {
      api.get('/vaults/' + vault.id, vault)
        .then(res => {
          commit('setVaults', res.data)
        })
    },

    editVault({ commit, dispatch }, vault) {
      api.put('/vaults/' + vault.id, vault)
        .then(res => {
          dispatch('getVaults')
        })
    },

    deleteVault({ commit, dispatch, state }, vault) {
      api.delete('/vaults/' + vault._id, vault)
        .then(res => {
          commit("deleteVault", res.data)
          dispatch('getvaults')
        })
    },

    // VAULT KEEPS
    addVaultKeep({ dispatch, commit }, vaultkeep) {
      api.post('/vaultkeep', vaultkeep)
        .then(res => {
        })
    },

    setActiveVault({ commit, dispatch }, vault) {
      commit('setActive', vault)
    },

    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get('/vaultKeep/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },



  }
})