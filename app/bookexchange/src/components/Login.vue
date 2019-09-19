<template>
  <div class="form">
    <h2>Log in</h2>
    <div class="form-group">
      <label for="email" >Email address</label>
      <input v-model="credential.email" class="form-control" placeholder="Email address" type="email" id="email" name="email">
    </div>
    <div class="form-group">
      <label for="password" >Password</label>
      <input v-model="credential.password" class="form-control" placeholder="Password" type="password" id="password" name="password">
    </div>
    <div class="form-group">
      <button v-on:click="login" class="bnt btn-primary">Login</button>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      credential: {
        email: '',
        password: ''
      }
    }
  },

  methods: {
    login () {
      this.$store.dispatch('login', this.credential)
    }
  }
}

/* eslint-disable */
</script>
