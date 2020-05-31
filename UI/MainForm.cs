using Conference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            inputs[0] = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };
            answers[0] = new double[answerCount] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            inputs[1] = new double[100]
            {
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,1,0,0,0,0,
                0,0,0,1,0,1,0,0,0,0,
                0,0,1,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,1,0,0,0,0
            };
            answers[1] = new double[answerCount] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };

            inputs[2] = new double[100]
            {
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,1,0,
                0,0,0,0,0,0,0,1,0,0,
                0,0,0,0,0,0,1,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,0,0,0,0,0,
                0,0,0,1,0,0,0,0,0,0,
                0,0,1,0,0,0,0,0,0,0,
                0,1,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1
            };
            answers[2] = new double[answerCount] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };

            inputs[3] = new double[100]
            {
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,1
            };
            answers[3] = new double[answerCount] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

            inputs[4] = new double[100]
            {
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1
            };
            answers[4] = new double[answerCount] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };

            inputs[5] = new double[100]
            {
                1,1,1,1,1,1,1,1,1,1,
                1,0,0,0,0,0,0,0,0,0,
                1,0,0,0,0,0,0,0,0,0,
                1,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,0,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };
            answers[5] = new double[answerCount] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };

            inputs[6] = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,0,0,0,0,0,0,0,0,
                1,0,0,0,0,0,0,0,0,0,
                1,0,0,0,0,0,0,0,0,0,
                1,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };
            answers[6] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };


            inputs[7] = new double[100]
            {
                1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,1,0,
                0,0,0,0,0,0,0,1,0,0,
                0,0,0,0,0,0,1,0,0,0,
                0,0,0,0,0,1,0,0,0,0,
                0,0,0,0,1,0,0,0,0,0,
                0,0,0,1,0,0,0,0,0,0,
                0,0,1,0,0,0,0,0,0,0,
                0,1,0,0,0,0,0,0,0,0
            };
            answers[7] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };

            inputs[8] = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,1,1,1,1,1,1,1,1,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };
            answers[8] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };

            inputs[9] = new double[100]
            {
                0,1,1,1,1,1,1,1,1,0,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,
                0,1,1,1,1,1,1,1,1,0
            };
            answers[9] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            this.errorShow.Clear();
            DateTime timestart = DateTime.Now;
            net.Teach(inputs, answers, 100000, 0.1, (x, y) => 
                this.errorShow.AppendText(string.Format(@"Ошибка: {0}, эпоха: {1}{2}", x, y, Environment.NewLine)));
            
            DateTime timeFinish = DateTime.Now;
            TimeSpan span = timeFinish - timestart;

            Console.WriteLine("Время потраченной на обучение: " + span.ToString());

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
            //}
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
    }
}
