<template>
  <div class="form">
    <h2>Register</h2>
    <div class="form-group">
      <label for="email" >Email address</label>
      <input v-model="credential.email" class="form-control" placeholder="Email address" type="email" id="email" name="email">
    </div>
    <div class="form-group">
      <label for="firstname" >First Name</label>
      <input v-model="credential.firstname" class="form-control" placeholder="First name" type="firstName" id="firstName" name="firstName">
    </div>
    <div class="form-group">
      <label for="firstname" >Last Name</label>
      <input v-model="credential.lastname" class="form-control" placeholder="Last name" type="lastName" id="lastName" name="lastName">
    </div>
    <div class="form-group">
      <label for="password" >Password</label>
      <input v-model="credential.password" class="form-control" placeholder="Password" type="password" id="password" name="password">
    </div>
    <div class="form-group">
      <label for="password" >DateOfBirth</label>
      <input v-model="credential.dateOfBirth" class="form-control" placeholder="dateOfBirth" type="dateOfBirth" id="dateOfBirth" name="dateOfBirth">
    </div>
    <div class="form-group">
      <label for="password" >Role</label>
      <input v-model="credential.role" class="form-control" placeholder="Role" type="role" id="role" name="role">
    </div>
    <div class="form-group">
      <button v-on:click="register" class="bnt btn-primary">Register</button>
    </div>
  </div>
</template>
<script>

export default {
  data () {
    return {
      credential: {
        id: '',
        email: '',
        firstName: '',
        lastName: '',
        password: '',
        dateOfBirth: '',
        role: ''
      }
    }
  },

  methods: {
    register () {
      this.$http.post('http://localhost:5000/account/register', this.credential)
        .then(result => {
          this.$router.push({path: '/login'})
        })
    }
  }
}
/* eslint-disable */
</script>
