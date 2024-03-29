using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookManager
{
    public partial class BookManager : Form
    {
        private List<Book> books = new List<Book>();

        public BookManager()
        {
            InitializeComponent();
        }

        private void clearInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void AddBook(string title, string author, int year)
        {
            Book newBook = new Book
            {
                Title = title,
                Author = author,
                Year = year
            };

            books.Add(newBook);
        }

        private void DisplayBooks()
        {

            listBoxBooks.Items.Clear();
            foreach (var book in books)
            {
                listBoxBooks.Items.Add($"{book.Title} by {book.Author} ({book.Year})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            string yearText = textBox3.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(yearText))
            {
                MessageBox.Show("Please enter values for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(yearText, out int year))
            {
                MessageBox.Show("Invalid year. Please enter a valid integer for the year.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddBook(title, author, year);

            DisplayBooks();

            clearInputs();
        }

    }
}