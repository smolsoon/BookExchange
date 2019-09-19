import Axios from 'axios'

const RESOURCE_NAME = '/account'

export default {
  getAll () {
    return Axios.get(RESOURCE_NAME)
  },
  get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
  },
  login (user, password) {
    return Axios.post(RESOURCE_NAME, user, password)
  },
  register (id, data) {
    return Axios.post(RESOURCE_NAME, data)
  }
}
