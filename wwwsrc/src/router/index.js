import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Profile from '@/components/Profile'
import Keep from '@/components/Keep'
import Vault from '@/components/Vault'

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