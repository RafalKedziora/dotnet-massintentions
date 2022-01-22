import Vue from 'vue'
import VueRouter from 'vue-router'
import IntentionList from "@/views/IntentionList"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect: '/list'
  },
  {
    path: '/list',
    name: 'IntentionList',
    component: IntentionList
  },
  {
    path: '/mass/add',
    name: 'IntentionAdd',
    component: () => import('../views/IntentionAdd')
  },
  {
    path: '/mass/:id',
    name: 'IntentionEdit',
    component: () => import('../views/IntentionEdit')
  },
  {
    path: '/category/add',
    name: 'CategoryAdd',
    component: () => import('../views/CategoryAdd')
  },
  {
    path: '/404',
    name: 'ErrorPage',
    component: () => import('../views/ErrorPage')
  },
  {
    path: '*',
    redirect: '/404'
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
