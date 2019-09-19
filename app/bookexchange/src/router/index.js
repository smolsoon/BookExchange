import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import NotFound from '@/components/NotFound'
import BookList from '@/components/book/booklist.component'
import Login from '@/components/Login'
import Register from '@/components/Register'
import AddBook from '@/components/AddBook'
import Users from '@/components/Users'
import Division from '@/components/Division'

Vue.use(Router)

export default new Router({
  routes: [
    { path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/book/list',
      name: 'bookList',
      component: BookList
    },
    {
      path: '/users',
      name: 'Users',
      component: Users
    },
    {
      path: '/division',
      name: 'Division',
      component: Division
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/register',
      name: 'Register',
      component: Register
    },
    {
      path: '/addbook',
      name: 'addBook',
      component: AddBook
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    }
  ]
})
