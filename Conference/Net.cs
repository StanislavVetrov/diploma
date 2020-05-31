using System;
using System.Collections.Generic;
using System.Text;

namespace Conference
{
	/// <summary>
	/// Делегат для отображения ошибки.
	/// </summary>
	/// <param name="parError">Текущая ошибка.</param>
	/// <param name="parAge">Текущая эпоха.</param>
	public delegate void ShowError(string parError, string parAge);

	public class NeuronNet
	{
		private double ALPHA = 0.01;

        /// <summary>
        /// Коэффициент влияния вычислимых поправок
        /// </summary>
        private double _Nu = 0.2;

		/// <summary>
		/// Массив весов [l][i][j],
		/// где l - слой, i - нейрон слоя l-1, от которого идет вес,
		///  j - нейрон слоя l, к которому идет.
		/// </summary>
		private double[][][] _W;

		/// <summary>
		/// Моменты изменений весов.
		/// </summary>
		private double[][][] _WMoments;

		/// <summary>
		/// Количество входов сети.
		/// </summary>
		private int _InputsCount;

		/// <summary>
		/// Количество выходов сети
		/// </summary>
		private int _OutputsCount;

		/// <summary>
		/// Массив ответов каждого слоя.
		/// </summary>
		private double[][] _Outs;

		/// <summary>
		/// Массив поправок для алгоритма обратного распространения ошибки.
		/// </summary>
		private double[][] _Deltas;

		/// <summary>
		/// Кол-во слоев вместе с выходным.
		/// </summary>
		private int _LayersCount = 1;

		/// <summary>
		/// Колличестов нейронов на каждом слое, кроме выходного.
		/// </summary>
		private int[] _LayerNumberNeurons;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="parLayerCount">Количество скрытых слоев.</param>
		/// <param name="parInputCount">Количество входов.</param>
		/// <param name="parOutputCount">Количество выходов.</param>
		public NeuronNet(int[] parLayerNumberNeurons, int parInputCount, int parOutputCount)
		{
			_InputsCount = parInputCount;
			//_NeuronesOnLayer = (int)(parInputCount /2 );
			_OutputsCount = parOutputCount;

			_LayersCount = parLayerNumberNeurons.Length;
			_LayerNumberNeurons = parLayerNumberNeurons;

			_W = new double[_LayersCount + 1][][];
			_WMoments = new double[_LayersCount + 1][][];
			_Deltas = new double[_LayersCount + 1][];
			
			_Outs = new double[_LayersCount + 1][];
			_Outs[_LayersCount] = new double[_OutputsCount];
			_Deltas[_LayersCount] = new double[_OutputsCount];

			for (int i = 0; i < _LayersCount; i++)
			{
				_Outs[i] = new double[_LayerNumberNeurons[i]];
				_Deltas[i] = new double[_LayerNumberNeurons[i]];
			}

			InitializeW();

			InitializeOutput();
		}

		/// <summary>
		/// Инициализация выходного слоя.
		/// </summary>
		private void InitializeOutput()
		{
			Random r = new Random();
			_W[_LayersCount] = new double[_OutputsCount][];
			_WMoments[_LayersCount] = new double[_OutputsCount][];
			for (int i = 0; i < _OutputsCount; i++)
			{
				int length = (_LayersCount != 0) ? _LayerNumberNeurons[_LayersCount - 1] : _InputsCount;

				_W[_LayersCount][i] = new double[length];
				_WMoments[_LayersCount][i] = new double[length];

				for (int j = 0; j < length; j++)
				{
					_W[_LayersCount][i][j] = r.NextDouble();
					_WMoments[_LayersCount][i][j] = 0;
				}
			}
		}

		/// <summary>
		/// Изменения буфера для коррекции весов.
		/// </summary>
		/// <param name="parLayer">Номер слоя.</param>
		/// <param name="parI"></param>
		/// <param name="parInput">Передается исключительно для верхнего слоя.</param>
		private void WmCorrect(int parLayer, int parI, double[] parInput)
		{
			// коррекция для первого и остальных слоев различаются
			int s = _WMoments[parLayer][parI].Length;

			// внутренние слои
			if (parLayer > 0)
			{
				for (int j = 0; j < s; j++)
				{
					_WMoments[parLayer][parI][j] = _Nu * _Deltas[parLayer][parI] * _Outs[parLayer - 1][j];
						// ALPHA * _WMoments[parLayer][parI][j] + (1 - ALPHA) * _Nu * _Deltas[parLayer][parI] * _Outs[parLayer - 1][j];//!!!
				}
			}
			else
			{
				for (int j = 0; j < s; j++)
				{
					_WMoments[parLayer][parI][j] = _Nu * _Deltas[parLayer][parI] * parInput[j];
						//ALPHA * _WMoments[parLayer][parI][j] + 
						//(1 - ALPHA) * _Nu * _Deltas[parLayer][parI] * parInput[j];//!!
				}
			}
		}
        ShowError _errorSize;

        public void errorRegister (ShowError errorSize)
        {
            _errorSize = errorSize;
        }

		/// <summary>
		/// Обучение сети на примере.
		/// </summary>
		/// <param name="parInputps">Массив примеров.</param>
		/// <param name="parAnswers">Массив ответов</param>
		/// <param name="parMaxAge">Максимальное количество эр обучения.</param>
		/// <param name="parErrorLevel">Макимальная величина суммарной ошибки выходного сигнала.</param>
		public void Teach(double[][] parInputps, double[][] parAnswers, int parMaxAge, double parErrorLevel, ShowError parDispaly)
		{
			int examplesNumber = parAnswers.Length;
			List<double> lists = new List<double>();
			double totalError = 0;

			for (int age = 0; age < parMaxAge; age++)
			{
				if (parDispaly != null)
					parDispaly(totalError.ToString(), age.ToString());
				else
                {   if(_errorSize != null)
                        _errorSize(totalError.ToString(), age.ToString());
                }
					//Console.WriteLine(totalError.ToString());
				
				totalError = 0;
				
				for (int ex = 0; ex < examplesNumber; ex++)
				{
					double[] input = parInputps[ex];
					double[] answer = parAnswers[ex];

					double[] outs = Ask(input);

					double d = 0;// невязка работы сети

					for (int i = 0; i < _OutputsCount; i++)
						d += (outs[i] - answer[i]) * (outs[i] - answer[i]);

					totalError += d / 2;

					//если невязка слишком большая, то запускаем backProp
					if (totalError > parErrorLevel)
					{
						//корректировка весов выходного слоя.
						int olayer = _LayersCount;

						for (int i = 0; i < _OutputsCount; i++)
						{
							double o = _Outs[olayer][i];
							_Deltas[olayer][i] =o * (1 - o) * (answer[i] - o);
							WmCorrect(olayer, i, input);
						}

						//корректировка весов скрытых слоев.
						for (int l = _LayersCount - 1; l >= 0; l--)
						{
							for (int i = 0; i < _LayerNumberNeurons[l]; i++)
							{
								double o = _Outs[l][i];
								int linksNumber = _W[l+1].Length;

								_Deltas[l][i] = 0;
								for (int k = 0; k < linksNumber; k++)
								{
									_Deltas[l][i] += _Deltas[l + 1][k] 
										* _W[l + 1][k][i];
								}
								_Deltas[l][i] *= o;//* (1 - o);
								WmCorrect(l, i, input);
							}
						}

						//корректируем веса.
						for (int l = 0; l <= _LayersCount; l++)
						{
							int s1 = _WMoments[l].Length;

							for (int i = 0; i < s1; i++)
							{
								int s2 = _WMoments[l][i].Length;
								for (int j = 0; j < s2; j++)
								{
									_W[l][i][j] += _WMoments[l][i][j];
								}
							}
						}
					}

				}

                if (totalError <= parErrorLevel)
                {
                    //parDispaly(totalError.ToString(), age.ToString());

                    return;
                }

                lists.Add(totalError);
			}
		}

		/// <summary>
		/// Ответ сети на вектор на заданный вектор.
		/// </summary>
		/// <param name="parInput">Входной вектор.</param>
		/// <returns>Выходной вектор.</returns>
		public double[] Ask(double[] parInput)
		{
			int inputCount = parInput.Length;
			int outLayer = _LayersCount;
			//int neuronsOnLayer = _NeuronesOnLayer;
			
			//Ответ входного слоя.
			for (int i = 0; i < _LayerNumberNeurons[0]; i++)
			{
				double sum = 0;
				for (int j = 0; j < inputCount; j++)
				{
					sum += _W[0][i][j] * parInput[j];
				}
				_Outs[0][i] = Activate(sum);
			}

			//получаем ответы основных слоёв.
			for (int l = 1; l < _LayersCount; l++)
			{
				for (int i = 0; i < _LayerNumberNeurons[l]; i++)
				{
					double sum = 0;

					for (int j = 0; j < _LayerNumberNeurons[l - 1]; j++)
					{
						sum += _W[l][i][j] * _Outs[l - 1][j];//изменил
					}

					_Outs[l][i] = Activate(sum);
				}
			}

			// получаем ответы выходного слоя
			if (outLayer > 0)
			{
				for (int i = 0; i < _OutputsCount; i++)
				{
					double sum = 0;
					for (int j = 0; j < _LayerNumberNeurons[_LayersCount - 1]; j++)
					{
						sum += _W[outLayer][i][j] * _Outs[outLayer - 1][j];
					}
					_Outs[outLayer][i] = Activate(sum);
				}
			}

			return _Outs[outLayer];
		}

		/// <summary>
		/// Инициализация весов.
		/// </summary>
		private void InitializeW()
		{
			Random r = new Random();
			if (_W != null)
			{
				if (_LayersCount > 0)
				{
					for (int l = 0; l < _LayersCount; l++)
					{
						_W[l] = new double[_LayerNumberNeurons[l]][];
						_WMoments[l] = new double[_LayerNumberNeurons[l]][];

						int length = (l == 0) ? _InputsCount : _LayerNumberNeurons[l - 1];
						for (int i = 0; i < _LayerNumberNeurons[l]; i++)
						{
							_W[l][i] = new double[length];
							_WMoments[l][i] = new double[length];

							for (int j = 0; j < length; j++)
							{
								_W[l][i][j] = r.NextDouble();
								_WMoments[l][i][j] = 0;
							}
						}
					}
				}
			}
		}

		private double Activate(double value)
		{
			double res = 1 / (1 + Math.Exp(-value));

			return res;
		}

		/// <summary>
		/// Проанализировать ответ нейронной сети.
		/// </summary>
		/// <param name="parOutput">Выход сети.</param>
		/// <returns>Ответ сети.</returns>
		public static char AnalyzeAnswer(double[] parOutput)
		{
			int max = 0;
			double maxValue = 0;

			for (int i = 0; i < parOutput.Length; i++)
			{
				if (maxValue < parOutput[i])
				{
					max = i;
					maxValue = parOutput[i];
				}
			}

			switch (max)
			{
				case 0: return '0';
				case 1: return '1';
				case 2: return '2';
				case 3: return '3';
				case 4: return '4';
				case 5: return '5';
				case 6: return '6';
				case 7: return '7';
				case 8: return '8';
				case 9: return '9';
				default: return '!';
			}
		}

	}
}
