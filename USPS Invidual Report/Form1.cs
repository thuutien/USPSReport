using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USPS_Invidual_Report
{
    public partial class Form1 : Form
    {
        string fileDirectory;
        string folder;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            string directory = txt_directory.Text;
            if(directory != "")
            {
                folder = directory;
                string[] fileArray = Tools.getFiles(directory);
                string excelFileDirectory = Tools.createExcelFile(directory);
                fileDirectory = excelFileDirectory;
                Tools.extractData(excelFileDirectory, fileArray);
            } else
            {
                MessageBox.Show("Please enter directory to the report folder");
            }
               

        }
        
        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            try {
                System.Diagnostics.Process.Start(fileDirectory);
            }
            catch {
                MessageBox.Show("Cannot open file");
            }

            try
            {
                System.Diagnostics.Process.Start(folder);
            }
            catch
            {
                MessageBox.Show("Cannot open folder");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_version_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/thuutien");
        }
    }
}
