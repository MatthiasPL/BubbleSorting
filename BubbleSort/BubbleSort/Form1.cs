using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BubbleSort;

namespace BubbleSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void BubbleSorting(int[] arr)
        {
            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;                        
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                AppendListBox(arr[i].ToString());
            }
        }

        public void CheckID(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(CheckID), new object[] { value });
                return;
            }
            lbOutput.SelectedIndex = 0;
        }

        public void ClearListBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ClearListBox), new object[] { value });
                return;
            }
            lbOutput.Items.Clear();
        }

        public void AppendListBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendListBox), new object[] { value });
                return;
            }
            lbOutput.Items.Add(value);
        }

        private void bSort_Click(object sender, EventArgs e)
        {
            String[] strarray = tbData.Text.Split(' ');
            int[] numbers = Array.ConvertAll(strarray, s => int.Parse(s));

            Thread.CurrentThread.Name = "Main";

            Task taskA = new Task(() => BubbleSorting(numbers));
            taskA.Start();
        }
    }
}
