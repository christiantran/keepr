import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from '@/components/Home'
// @ts-ignore
import Profile from '@components/Profile'
// @ts-ignore
import Keep from '@components/Keep'
// @ts-ignore
import Vault from '@components/Vault'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Home',
            component: Home
        },
        {
            path: '/Profile',
            name: 'Profile',
            component: Profile
        },
        {
            path: '/Keep',
            name: 'Keep',
            component: Keep
        },
        {
            path: '/Vault',
            name: 'Vault',
            component: Vault
        },
    ]
})