import Vue from 'vue'
import Router from 'vue-router'
// import Login from '@/components/Login'
// import Register from '@/components/Register'
// @ts-ignore
import Home from '@/components/Home'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Home',
            component: Home
        },
        // {
        //     path: '/Login',
        //     name: 'Login',
        //     component: Login
        // },
        // {
        //     path: '/Register',
        //     name: 'Register',
        //     component: Register
        // },
    ]
})