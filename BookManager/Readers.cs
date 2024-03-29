using BookManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Readers : Form
    {
        private List<Reader> ReadersList = new List<Reader>();

        public Readers()
        {
            InitializeComponent();
        }

        private void clearInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void addReader(string Name, string Email, string TelNumber, string dateOfBirth)
        {
            Reader newReader = new Reader
            {
                Name = Name,
                Email = Email,
                TelNumber = TelNumber,
                dateOfBirth = dateOfBirth,
                ID = GenerateRandomID(),
            };

            ReadersList.Add(newReader);
        }

        private string GenerateRandomID()
        {
            // Generate ID
            Random random = new Random();
            int maxID = Settings.Default.maxID;
            int lowerBound = (int)Math.Pow(10, 5);
            int upperBound = maxID < 100000 ? 999999 : maxID;

            return random.Next(lowerBound, upperBound).ToString("D8");
        }


        private void DisplayReaderInfo(Reader reader)
        {
            MessageBox.Show($"ID: {reader.ID}\nName: {reader.Name}\nEmail: {reader.Email}\nTelNumber: {reader.TelNumber}\nDateOfBirth: {reader.dateOfBirth}",
                            "Reader Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void DisplayReaders()
        {
            // Clear any previous entries
            listBoxReaders.Items.Clear();

            // Display each book in the ListBox
            foreach (var Reader in ReadersList)
            {
                listBoxReaders.Items.Add($"({Reader.ID} {Reader.Name} {Reader.Email} ({Reader.TelNumber}) ({Reader.dateOfBirth})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get reader information from the user
            string name = textBox1.Text;
            string email = textBox2.Text;
            string telNumber = textBox3.Text;
            string dateOfBirth = dateTimePicker1.Text;
            string id = GenerateRandomID();

            addReader(name, email, telNumber, dateOfBirth);

            DisplayReaders();

            clearInputs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchID = textBox6.Text;
            string searchName = textBox7.Text;
            string searchEmail = textBox8.Text;
            string searchTelNumber = textBox4.Text;

            var foundItems = listBoxReaders.Items.Cast<string>().Where(item =>
                (string.IsNullOrEmpty(searchID) || item.Contains(searchID)) &&
                (string.IsNullOrEmpty(searchName) || item.Contains(searchName)) &&
                (string.IsNullOrEmpty(searchEmail) || item.Contains(searchEmail)) &&
                (string.IsNullOrEmpty(searchTelNumber) || item.Contains(searchTelNumber))
            ).ToList();

            if (foundItems.Any())
            {
                foreach (var foundItem in foundItems)
                {
                    MessageBox.Show(foundItem, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Reader not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listBoxReaders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
