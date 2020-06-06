using Conference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        const int answerCount = 10;
        public static NeuronNet net;
        public static char exam1;
        public static char exam2;
        public static char exam3;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            int countOfLayer = 0;
            int countOfInputs = 0;
            int countOfOuts = 0;
            double error = 0;
            int maxEpoch = 0;

            int[] counts = new int[1] { 30 };
            net = new NeuronNet(counts, 100/*countOfInputs*/, 10/*countOfOuts*/);

            double[][] inputs = new double[10][];
            double[][] answers = new double[10][];

            string pathToInputs = inputsBox.Text;

            string[] readText = File.ReadAllLines(pathToInputs);

            for (int i = 0; i < 10; i++)
            {
                var a = readText[i].ToCharArray().Select(c => Char.ToString(c)).ToArray();
                double[] doubles = Array.ConvertAll(a, new Converter<string, double>(Double.Parse));
                inputs[i] = doubles;
            }

            string pathToAnswers = answersBox.Text;

            readText = File.ReadAllLines(pathToAnswers);

            for (int i = 0; i < 10; i++)
            {
                var a = readText[i].Split(',').Select(c => c.Trim()).ToArray();
                double[] doubles = Array.ConvertAll(a, new Converter<string, double>(Double.Parse));
                answers[i] = doubles;
            }

            this.errorShow.Clear();
            DateTime timestart = DateTime.Now;
            net.Teach(inputs, answers, 100000, 0.1, (x, y) => 
                this.errorShow.AppendText(string.Format(@"Ошибка: {0}, эпоха: {1}{2}", x, y, Environment.NewLine)));
            
            DateTime timeFinish = DateTime.Now;
            TimeSpan span = timeFinish - timestart;

            Console.WriteLine("Время, потраченное на обучение: " + span.ToString());

            char c0 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[0]));
            char c1 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[1]));
            char c2 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[2]));
            char c3 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[3]));
            char c4 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[4]));
            char c5 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[5]));
            char c6 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[6]));
            char c7 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[7]));
            char c8 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[8]));
            char c9 = NeuronNet.AnalyzeAnswer(net.Ask(inputs[9]));

            double[] example1 = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,1,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,1,0,1,
                1,1,1,0,1,1,0,1,1,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,1,0,0,0,0,0,1,
                1,1,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,0
            };

            double[] example2 = new double[100]
            {
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,0,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };

            double[] example3 = new double[100]
            {
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,1,0,0,0,0,
                0,0,0,1,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0
            };

            exam1 = NeuronNet.AnalyzeAnswer(net.Ask(example1));
            exam2 = NeuronNet.AnalyzeAnswer(net.Ask(example2));
            exam3 = NeuronNet.AnalyzeAnswer(net.Ask(example3));

            MessageBox.Show("Обучилась");
            
        }

        double[] example1 = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,1,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,1,0,1,
                1,1,1,0,1,1,0,1,1,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,1,0,0,0,0,0,1,
                1,1,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,0
            };

        double[] example2 = new double[100]
        {
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,0,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
        };

        double[] example3 = new double[100]
        {
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,1,0,0,0,0,
                0,0,0,1,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0
        };

        private void Display(string parError, string parAge) => errorShow.Text += parError;

        private void ex1_Click(object sender, EventArgs e)
        {
          textBox3.Text = exam1.ToString();
        }

        private void ex2_Click(object sender, EventArgs e)
        {
            textBox3.Text = exam2.ToString();
        }

         private void ex3_Click(object sender, EventArgs e)
        {
            textBox3.Text = exam3.ToString();
        }

        private void SubmitInputs_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            inputsBox.Text = filename;
        }

        private void SubmitAnswers_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            string filename = openFileDialog2.FileName;
            answersBox.Text = filename;
        }
    }
}
