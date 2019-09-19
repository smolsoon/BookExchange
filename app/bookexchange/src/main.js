import Vue from 'vue'
import App from './App'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import vueResource from 'vue-resource'
import vueCookies from 'vue-cookies'
import store from './store'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(vueResource)
Vue.use(vueCookies)

Vue.http.interceptors.push((request, next) => {
  if (localStorage.getItem('token')) {
    request.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
  }

  next(response => {
    if (response.status === 400 || response.status === 401 || response.status === 402) {
      router.push({path: '/login'})
    }
  })
})

// eslint-disable-next-line no-new
new Vue({
  el: '#app',
  store,
  router,
  components: { App },
  template: '<App/>'
})
