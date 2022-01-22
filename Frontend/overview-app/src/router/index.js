import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from "@/views/Login"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('../views/Register')
  },
  {
    path: '/list',
    name: 'IntentionList',
    component: () => import('../views/IntentionList')
  },
  {
    path: '/desktop',
    name: 'Desktop',
    component: () => import('../views/Desktop')
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

const originalPush = VueRouter.prototype.push;

VueRouter.prototype.push = function push(location) {
  return originalPush.call(this, location).catch(() => {});
};

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
