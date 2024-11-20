using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class TaskForm : Form
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskDate { get; set; }
        public List<string> Files { get; private set; } = new List<string>();
        public TaskForm()
        {
            InitializeComponent();
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            TaskNameText.Text = TaskName;
            TaskDescText.Text = TaskDescription;
            TaskDateText.Text = TaskDate;

            FilesListBox.Items.Clear();

        }
        private void TaskNameText_TextChanged(object sender, EventArgs e)
        { }
        private void TaskDescText_TextChanged(object sender, EventArgs e)
        { }
        private void TaskDateText_TextChanged(object sender, EventArgs e)
        { }

        private void AcceptBTN_Click(object sender, EventArgs e)
        {
            TaskName = TaskNameText.Text;
            TaskDescription = TaskDescText.Text;
            TaskDate = TaskDateText.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddFileBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл для прикрепления";
            openFileDialog.Filter = "Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {

                    if (!Files.Contains(file))
                    {
                        FilesListBox.Items.Add(file);
                    }
                }
            }
        }

        private void DeleteFileBTN_Click(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите файл для удаления.");
                return;
            }

            FilesListBox.Items.Remove(FilesListBox.SelectedItem);
        }

        private void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        { }


    }
}
