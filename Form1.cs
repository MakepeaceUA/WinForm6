namespace WinFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AddTaskBTN_Click(object sender, EventArgs e)
        {
            TaskForm form = new TaskForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                TaskListBox.Items.Add($"{form.TaskName} | {form.TaskDate} | {form.TaskDescription}");
            }
        }
        private void EditTaskBTN_Click(object sender, EventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите задачу для редактирования.");
                return;
            }
            var select = TaskListBox.SelectedItem.ToString();
            var parts = select.Split('|');
            if (parts.Length != 3) return;

            TaskForm form = new TaskForm
            {
                TaskName = parts[0],
                TaskDate = parts[1],
                TaskDescription = parts[2]
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                TaskListBox.Items[TaskListBox.SelectedIndex] = $"{form.TaskName} | {form.TaskDate} | {form.TaskDescription}";
            }

        }
        private void DeleteTaskBTN_Click(object sender, EventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите задачу для удаления.");
                return;
            }

            TaskListBox.Items.Remove(TaskListBox.SelectedItem);
        }
        private void TaskListBox_SelectedIndexChanged(object sender, EventArgs e)
        { }

    }
}