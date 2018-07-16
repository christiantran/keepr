import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from "../router"

var production = !window.location.host.includes('localhost');
var baseUrl = production ? '' : '//localhost:5000/';


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
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    deleteUser(state) {
      state.user = {}
    },

  },

  actions: {

    login({ commit, dispatch }, loginCredentials) {
      auth.post('login', loginCredentials)
        .then(res => {
          console.log("Successfully logged in!")
          console.log(res.data)
          commit('setUser', res.data)
          router.push({ name: 'Home' })
        })
        .catch(err => {
          console.log(err)
        })
    },

    logout({ commit, dispatch }) {
      auth.delete('')
        .then(res => {
          console.log("Successfully logged out!")
          commit('deleteUser')
          router.push({ name: 'Login' })
        })
        .catch(err => {
          console.log(err)
        })
    },

    register({ commit, dispatch }, userData) {
      auth.post('register', userData)
        .then(res => {
          console.log("Registration Successful")
          router.push({ name: 'Login' })
        })
        .catch(err => {
          console.log(err)
        })
    },

    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Home' })
        })

    },




  }
})
