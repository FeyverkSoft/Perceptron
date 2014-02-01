using System;
using System.Collections.Generic;
using System.Linq;
using Neuro.Interface;

namespace Neuro.InterfaceImpl
{

    /// <summary>
    /// Однослойный n-нейронный перцептрон
    /// </summary>
    [Serializable]
    public class Perceptron : IPerceptron
    {
        readonly IList<INeuron> _neurons; // слой нейронов
        readonly Int32 _neuronCount;
        readonly Int32 _m;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="neuronCount"> число нейронов</param>
        /// <param name="m">число входов каждого нейрона скрытого слоя</param>
        public Perceptron(Int32 neuronCount, Int32 m)
        {
            _neuronCount = neuronCount;
            _m = m;
            _neurons = new Neuron[neuronCount];
            for (var j = 0; j < _neurons.Count; j++)
            {
                _neurons[j] = new Neuron(m);
            }
        }

        /// <summary>
        /// Распознавание образа
        /// </summary>
        /// <param name="x">входной вектор</param>
        /// <returns> выходной образ</returns>
        public Int32[] Recognize(IList<Int32> x)
        {
            var y = new Int32[_neurons.Count];

            for (var j = 0; j < _neurons.Count; j++)
            {
                y[j] = _neurons[j].Transfer(x);
            }
            return y;
        }

        /// <summary>
        /// Инициализация начальных весов 
        /// малым случайным значением
        /// </summary>
        /// <param name="max">Максимальное значение начальных весов</param>
        public void InitWeights(Int32 max)
        {
            foreach (var neuron in _neurons)
            {
                neuron.InitWeights(max);
            }
        }

        /// <summary>
        /// Обучение перцептрона
        /// </summary>
        /// <param name="x">входной вектор</param>
        /// <param name="y">правильный выходной вектор</param>
        public void Teach(IList<Int32> x, IList<Int32> y)
        {
            const Int32 v = 1; // скорость обучения
            var t = Recognize(x);
            while (!VectorEqual(t, y))
            {
                // подстройка весов каждого нейрона
                for (var j = 0; j < _neurons.Count; j++)
                {
                    var d = y[j] - t[j];
                    _neurons[j].ChangeWeights(v, d, x);
                }
                t = Recognize(x);
            }
        }

        /// <summary>
        /// Сравнивание двух векторов
        /// </summary>
        /// <param name="a">первый вектор</param>
        /// <param name="b">второй вектор</param>
        /// <returns>boolean</returns>
        private Boolean VectorEqual(IList<Int32> a, IList<Int32> b)
        {
            if (a.Count != b.Count) return false;
            return !a.Where((t, i) => t != b[i]).Any();
        }

        /// <summary>
        ///  число нейронов
        /// </summary>
        public Int32 GetNeuronCount
        {
            get { return _neuronCount; }
        }

        /// <summary>
        /// число входов каждого нейрона скрытого слоя
        /// </summary>
        public Int32 GetM
        {
            get { return _m; }
        }
    }
}
