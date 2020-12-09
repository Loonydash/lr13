using System;
using System.Windows.Forms;

namespace WindowsForms12
{
    public partial class Form3 : Form
    {
        int worker;
        public Form3()
        {
            InitializeComponent();
        }

        public bool ShowDialogForm(Menu parrent)
        {

            if (ShowDialog(parrent) == DialogResult.OK)
            {
                worker = Convert.ToInt32(textBox1.Text);
                Program.Dismiss(worker);

                return true;
            }
            else return false;

        }
    }
}