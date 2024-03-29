using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManager;

namespace BookManager
{
    public partial class Form1 : Form
    {
        private UICalls uiCalls;

        public Form1()
        {
            InitializeComponent();

            uiCalls = new UICalls(this);
        }

        private void bookManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiCalls.ShowBookManagerForm();
        }

        private void readerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiCalls.ShowReadersForm();
        }

        private void výToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
