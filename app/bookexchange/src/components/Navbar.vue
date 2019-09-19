<template>
  <b-navbar type="dark" variant="dark">
    <b-navbar-brand :to="{ name: 'Home' }">Home</b-navbar-brand>
    <b-nav-item-dropdown text="Library" right>
        <b-dropdown-item :to="{ name: 'bookList' }">Your books</b-dropdown-item>
        <b-dropdown-item :to="{ name: 'addBook' }">Add book</b-dropdown-item>
        <b-dropdown-item href="#">Lents books</b-dropdown-item>
    </b-nav-item-dropdown>
    <b-nav-item-dropdown text="Users" right>
      <b-dropdown-item :to="{ name: 'Users' }">All users</b-dropdown-item>
        <b-dropdown-item href="#">Following</b-dropdown-item>
        <b-dropdown-item href="#">Followers</b-dropdown-item>
    </b-nav-item-dropdown>
      <b-navbar-nav>
      <b-nav-item :to="{ name: 'Division' }">Division</b-nav-item>
      <b-nav-item :to="{ name: 'Login' }">Login</b-nav-item>
      <b-nav-item :to="{ name: 'Register' }">Register</b-nav-item>
    </b-navbar-nav>
    <button v-on:click="logout" class="btn btn-outline-success my-2 my-sm-0">Wyloguj</button>
  </b-navbar>
</template>
<script>

export default {
  name: 'Navbar'
}

</script>
