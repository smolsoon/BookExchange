<template>
  <div>
    <b-row>
      <b-col
        md="2"
        offset-md="10">
        <a href="#">Users</a>
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Id</th>
                <th>Firstname</th>
                <th>Lastname</th>
                <th>Email</th>
                <th>DateOfBirth</th>
                <th>CreatedAt</th>
                <th>Details</th>
                <th>Subscribe</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="user in users" :key="user.id">
                <td>{{ user.id }}</td>
                <td>{{ user.firstname }}</td>
                <td>{{ user.lastname }}</td>
                <td>{{ user.email }}</td>
                <td>{{ user.dateOfBirth }}</td>
                <td>{{ user.createdAt }}</td>
                <td>
                  <b-button>Details</b-button>
                </td>
                <td>
                  <b-button v-bind:value="user.id" v-on:click="subscribe(user.id)">Subscribe</b-button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import axios from 'axios'

export default {
  name: 'Users',
  data () {
    return {
      users: []

    }
  },
  created () {
    this.$http.get('http://localhost:5000/account', this.users)
      .then((response) => {
        this.users = response.data
      })
  },
  methods: {
    subscribe () {
      axios.post('http://localhost:5000/following/4c538a7f-ffab-41d7-a54f-eede2c972a70/subscribe', this.users)
        .then(response => (this.chosenRoute = response.data))
        .then(result => {
          this.$router.push({path: '/'})
        })
    }
  }
}
</script>
