using System;
using LinqAdoNetDemo;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btFind.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Repo.getDataTableBooks(tbFind.Text);
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            if(tbFind.Text.Length!=0)
            {
                btFind.Enabled = true;
            }
            else
            {
                btFind.Enabled = false;
            }
        }
    }
}
