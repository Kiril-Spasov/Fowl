using System;
using System.IO;
using System.Windows.Forms;

namespace Fowl
{
    public partial class FormFawlGame : Form
    {
        public FormFawlGame()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\fowl.txt";
            StreamReader streamReader = new StreamReader(path);

            int lineCount = Convert.ToInt32(streamReader.ReadLine());

            for (int i = 1; i <= lineCount; i++)
            {
                line = streamReader.ReadLine();
                TxtResult.Text += "#" + i + " - " + CheckResult(line) + Environment.NewLine;
            }     
        }

        private string CheckResult(string input)
        {

            string result = "";

            int a, b;
            int c = 0;

            string[] dist = input.Split(' ');
            int[] distances = new int[dist.Length];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Convert.ToInt32(dist[i]);
            }

            //We sort them, because numbers are in any order.
            //First number in the array is the biggest(the hipotenuse).
            Sort(distances);

            c = distances[0];
            a = distances[1];
            b = distances[2];

            //We check if c*c = a*a + b*b.
            return result = CheckFormula(a, b, c) ? "YES" : "NO"; 
        }

        private void Sort(int[] distances)
        {
            int temp = 0;
            bool swap = false;

            do
            {
                swap = false;

                for (int i = 0; i < distances.Length - 1; i++)
                {
                    if (distances[i] < distances[i + 1])
                    {
                        temp = distances[i];
                        distances[i] = distances[i + 1];
                        distances[i + 1] = temp;
                        swap = true;
                    }
                }
            }
            while (swap == true);
        }

        private bool CheckFormula(int a, int b, int c)
        {
            if (Math.Pow(c, 2) == Math.Pow(a, 2) + Math.Pow(b, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
