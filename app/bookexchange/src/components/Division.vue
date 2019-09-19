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
                <th>UserId</th>
                <th>BookId</th>
                <th>Title</th>
                <th>Approved</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="division in divisions"
                :key="division.id">
                <td>{{ division.UserId }}</td>
                <td>{{ division.BookId }}</td>
                <td>{{ division.TitleT }}</td>
                <td>
                  <b-button v-on:click="approved">Approved</b-button>
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
  name: 'Division',
  data () {
    return {
      division: []
    }
  },
  created () {
    this.$http.get('http://localhost:5000/division', this.books)
      .then((response) => {
        this.division = response.data
      })
  },
  approved () {
    this.$http.get('http://localhost:5000/book/yourslibrary' + this.books.id, this.books)
      .then((response) => {
        this.division = response.data
        console.log(response)
      })
  }
}
</script>
