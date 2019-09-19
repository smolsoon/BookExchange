<template>
  <div>
    <b-row>
      <b-col
        md="2"
        offset-md="10">
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Title</th>
                <th>Author</th>
                <th>PublishingHome</th>
                <th>Year</th>
                <th>Details</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="book in books"
                :key="book.id">
                <td>{{ book.title }}</td>
                <td>{{ book.author }}</td>
                <td>{{ book.publishingHouse }}</td>
                <td>{{ book.year }}</td>
                <td>
                  <b-button :to="{name:books-id, params: { id: books.id}}" variant="success" v-on:click="details">Details</b-button>
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

export default {
  name: 'BookList',
  data () {
    return {
      books: []
    }
  },
  created () {
    this.$http.get('http://localhost:5000/book', this.books)
      .then((response) => {
        this.books = response.data
      })
  },
  details () {
    this.$http.get('http://localhost:5000/book' + this.books.id, this.books)
      .then((response) => {
        this.books = response.data
        console.log(response)
      })
  }
}
</script>
