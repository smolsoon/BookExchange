<template>
  <div class="form">
    <h2>Add book</h2>
    <div class="form-group">
      <label for="email" >Title</label>
      <input v-model="credential.title" class="form-control" placeholder="Title" type="title" id="title" name="title">
    </div>
    <div class="form-group">
      <label for="author" >Author</label>
      <input v-model="credential.author" class="form-control" placeholder="Author" type="author" id="author" name="author">
    </div>
    <div class="form-group">
      <label for="publishingHouse" >Publishing House</label>
      <input v-model="credential.publishingHouse" class="form-control" placeholder="Publishing House" type="publishingHouse" id="publishingHouse" name="publishingHouse">
    </div>
    <div class="form-group">
      <label for="year" >Year</label>
      <input v-model="credential.year" class="form-control" placeholder="Year" type="year" id="year" name="year">
    </div>
    <div class="form-group">
      <button v-on:click="addBook" class="bnt btn-primary">Add book</button>
    </div>
  </div>
</template>
<script>

export default {
  data () {
    return {
      credential: {
        title: '',
        author: '',
        publishingHouse: '',
        year: ''
      }
    }
  },

  methods: {
    addBook () {
      this.$http.post('http://localhost:5000/book/addbook', this.credential)
        .then(result => {
          this.$router.push({path: '/book/list'})
        })
    }
  }
}
/* eslint-disable */
</script>
