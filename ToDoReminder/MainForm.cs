using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ToDoReminder
{
    public partial class MainForm : Form
    {
        TaskManager taskManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        public void InitializeGUI()
        {
            this.Text = "ToDo Reminder by Basir";
            comboBox.DataSource = Enum.GetValues(typeof(PriorityType));
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            dateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            menuStrip = new MenuStrip();
            taskManager = new TaskManager();
        }

        /*
         * This method runs when add Add button is clicked
         * Get the user input and add a new Task to the Task Manager and update GUI lastly
         */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbToDo.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Todo description", "No Todo description!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string strTodo = tbToDo.Text;
                string priority = comboBox.SelectedItem.ToString();

                Task task = new Task(dateTimePicker.Value, strTodo, (PriorityType)Enum.Parse(typeof(PriorityType), priority));

                taskManager.AddNewTask(task);

                updateGUI();
                tbToDo.Clear();
            }
        }

        /*
         * This method runs when save in file button in menu is clicked.
         * First open the existing file and add the tasks sent to TaskManager to the file
         */
        private void saveInFileMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openedFile = new OpenFileDialog();

            if (openedFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openedFile.FileName;

                List<string> lines = File.ReadAllLines(filePath).ToList();

                string[] taskList = taskManager.GetInfoStringsList();
                for (int i = 0; i < taskList.Length; i++)
                {
                    lines.Add(taskList[i]);
                }
                File.WriteAllLines(filePath, lines);
            }
            lbTodo.Items.Clear();
            MessageBox.Show("The tasks was added to the file");
        }

        /*
         *  Run thie method when save as button in menu is clicked.
         * First create the file with input name and then add the tasks sent to TaskManager to the file. 
         */
        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedFile = new SaveFileDialog();
            savedFile.Filter = "Text File|*.txt";
            if (savedFile.ShowDialog() == DialogResult.OK)
            {

                string filePath = savedFile.FileName;

                List<string> lines = new List<string>();
                //lines = File.ReadAllLines(filePath).ToList();

                string[] taskList = taskManager.GetInfoStringsList();
                for (int i = 0; i < taskList.Length; i++)
                {
                    lines.Add(taskList[i]);
                }
                File.WriteAllLines(filePath, lines);
            }

            lbTodo.Items.Clear();
            MessageBox.Show("The tasks was saved in the file");
        }

        /*
         * Run this method when open button is clicked in menu.
         * Open the file path chosen by user, read all the lines and write to listbox 
         */
        private void openMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openedFile = new OpenFileDialog();

            if (openedFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openedFile.FileName;

                List<string> lines = File.ReadAllLines(filePath).ToList();

                lbTodo.Items.Clear();

                foreach (String line in lines)
                {
                    lbTodo.Items.Add(line);
                }
                btnDelete.Enabled = false;
                btnChange.Enabled = false;
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit the program", "Think twice", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            } 
        }

        /*
         * This method update the GUI (mainly listbox) when called.  
         */
        private void updateGUI()
        {
            lbTodo.Items.Clear();
            string[] taskList = taskManager.GetInfoStringsList();
            for (int i = 0; i < taskList.Length; i++)
            {
                lbTodo.Items.Add(taskList[i]);
            }
            btnDelete.Enabled = true;
            btnChange.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbTodo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Item first!");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this task", "Delete task", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    taskManager.removeThisTask(lbTodo.SelectedIndex);
                    updateGUI();
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lbTodo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Item first!");
            }
            else
            {
                Task thisTask = taskManager.getList().ElementAt(lbTodo.SelectedIndex);

                string priority = comboBox.SelectedItem.ToString();

                Task newTask = new Task(dateTimePicker.Value, tbToDo.Text, (PriorityType)Enum.Parse(typeof(PriorityType), priority));

                taskManager.editThisTask(thisTask, newTask);
                updateGUI();
                tbToDo.Clear();
            }
        }
    }
}
