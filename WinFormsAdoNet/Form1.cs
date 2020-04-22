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

        private void buttonLazyLoad_Click(object sender, EventArgs e)
        {  
            try
            {
                long start = DateTime.Now.Ticks;
                //some actions are performed here 
                dataGridView1.DataSource = Repo.getDataTableBooksLoading(1);
                long end = DateTime.Now.Ticks;
                long tick = end - start; //number of ticks
                long milliseconds = tick / TimeSpan.TicksPerMillisecond; //number of milliseconds
                labelTime.Text = milliseconds.ToString();
            }
            catch (Exception ex)
            {
                //handling exceptions
            }
        }

        private void buttonEagerLoad_Click(object sender, EventArgs e)
        {
            try
            {
                long start = DateTime.Now.Ticks;
                //some actions are performed here 
                dataGridView1.DataSource = Repo.getDataTableBooksLoading(5);
                long end = DateTime.Now.Ticks;
                long tick = end - start; //number of ticks
                long milliseconds = tick / TimeSpan.TicksPerMillisecond; //number of milliseconds
                labelTime.Text = milliseconds.ToString();
            }
            catch (Exception ex)
            {
                //handling exceptions
            }
        }
    }
}
