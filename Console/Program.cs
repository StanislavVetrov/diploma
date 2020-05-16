﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Conference
{
    class Program
    {
        const int answerCount = 10;

        static void Main(string[] args)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            int countOfLayer = 0;
            int countOfInputs = 0;
            int countOfOuts = 0;
            double error = 0;
            int maxEpoch = 0;



            int[] counts = new int[1] { 30 };
            NeuronNet net = new NeuronNet(counts, 42/*countOfInputs*/, 10/*countOfOuts*/);

            double[][] inputs = new double[10][];
            double[][] answers = new double[10][];

            inputs[0] = new double[42]
        {
                0,1,1,1,1,0,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                0,1,1,1,1,0
        };
            answers[0] = new double[answerCount] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            inputs[1] = new double[42]
        {
                0,0,0,1,0,0,
                0,0,1,1,0,0,
                0,0,0,1,0,0,
                0,0,0,1,0,0,
                0,0,0,1,0,0,
                0,0,0,1,0,0,
                0,0,0,1,0,0
        };
            answers[1] = new double[answerCount] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };

            inputs[2] = new double[42]
        {
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,1,0,
                0,0,0,1,0,0,
                0,0,1,0,0,0,
                0,1,0,0,0,0,
                1,1,1,1,1,1
        };
            answers[2] = new double[answerCount] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };

            inputs[3] = new double[42]
        {
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,0,1,
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,1,0,0,0,1,
                1,1,1,1,1,1
        };
            answers[3] = new double[answerCount] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

            inputs[4] = new double[42]
        {
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,0,1,
                0,0,0,0,0,1
        };
            answers[4] = new double[answerCount] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };

            inputs[5] = new double[42]
        {
                1,1,1,1,1,1,
                1,0,0,0,0,0,
                1,0,0,0,0,0,
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,0,1,
                1,1,1,1,1,1
        };
            answers[5] = new double[answerCount] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };

            inputs[6] = new double[42]
        {
                0,0,0,1,0,0,
                0,0,1,0,0,0,
                0,1,0,0,0,0,
                1,1,1,1,1,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1
        };
            answers[6] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };


            inputs[7] = new double[42]
        {
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,1,0,
                0,0,0,1,0,0,
                0,0,1,0,0,0,
                0,1,0,0,0,0,
                1,0,0,0,0,0
        };
            answers[7] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };

            inputs[8] = new double[42]
        {
                1,1,1,1,1,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1
        };
            answers[8] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };

            inputs[9] = new double[42]
        {
                1,1,1,1,1,1,
                1,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1,
                0,0,0,0,1,0,
                0,0,0,1,0,0,
                0,0,1,0,0,0
        };
            answers[9] = new double[answerCount] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            DateTime timestart = DateTime.Now;
            net.Teach(inputs, answers, 10000000, 0.1, null);
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

            double[] example1 = new double[42]
        {
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                0,0,0,0,1,0,
                0,0,0,1,0,0,
                0,0,1,0,0,0,
                0,1,0,0,0,0,
                1,1,1,1,1,1
        };

            double[] example2 = new double[42]
        {
                0,0,0,1,1,1,
                0,0,1,0,0,1,
                0,1,0,0,0,1,
                1,1,1,1,1,1,
                0,0,0,0,0,1,
                1,0,0,0,0,1,
                1,1,1,1,1,1
        };


            char exam1 = NeuronNet.AnalyzeAnswer(net.Ask(example1));
            char exam2 = NeuronNet.AnalyzeAnswer(net.Ask(example2));
            //char exam3 = NeuronNet.AnalyzeAnswer(net.Ask(example3));

            Console.WriteLine("Символ 1 примера: " + exam1);
            Console.WriteLine("Символ 2 примера: " + exam2);
            //Console.WriteLine("Символ 3 примера: " + exam3);

            key = Console.ReadKey();
            //}
        }
    }
}
