using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    internal class UICalls
    {
        private Form1 form1;

        public UICalls(Form1 form1)
        {
            this.form1 = form1;
        }

        public void ShowBookManagerForm()
        {
            BookManager bookManagerForm = new BookManager();
            bookManagerForm.Show();
        }

        public void ShowReadersForm()
        {
            Readers ReadersForm= new Readers();
            ReadersForm.Show();
        }
    }
}
