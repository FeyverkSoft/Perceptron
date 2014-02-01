using System;
using System.Collections.Generic;
using System.Linq;
using Neuro.Interface;

namespace Neuro.InterfaceImpl
{
    [Serializable]
    internal class Neuron : INeuron
    {
        private readonly IList<Int32> _w; // веса синапсов    
        private const Int32 S = 50; // порог

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="m">число входов</param>
        internal Neuron(Int32 m)
        {
            _w = new Int32[m];
        }

        /// <summary>
        /// Передаточная функция
        /// </summary>
        /// <param name="x"> входной вектор</param>
        /// <returns>выходное значение нейрона</returns>
        public Int32 Transfer(IList<Int32> x)
        {
            return Activator(Adder(x));
        }

        /// <summary>      
        /// Инициализация начальных весов синапсов
        ///  небольшими случайными значениями от 0 до n
        /// </summary>
        /// <param name="n"> от 0 до n</param>
        public void InitWeights(Int32 n)
        {
            var rand = new Random();
            for (var i = 0; i < _w.Count; i++)
            {
                _w[i] = rand.Next(n);
            }
        }

        /// <summary> 
        /// Модификация весов синапсов для обучения
        /// </summary>
        /// <param name="v"> - скорость обучения</param>
        /// <param name="d"> - разница между выходом нейрона и нужным выходом</param>
        /// <param name="x"> - входной вектор</param>
        public void ChangeWeights(Int32 v, Int32 d, IList<Int32> x)
        {
            for (var i = 0; i < _w.Count; i++)
            {
                _w[i] += v * d * x[i];
            }
        }

        /// <summary> 
        /// Сумматор
        /// </summary> 
        /// <param name="x">входной вектор</param> 
        /// <returns> не взвешенная сумма nec (биас не используется)</returns>>
        private int Adder(IEnumerable<Int32> x)
        {
            return x.Select((t, i) => t*_w[i]).Sum();
        }

        /// <summary>
        /// Нелинейный преобразователь или функция активации,
        /// в данном случае - жесткая пороговая функция,
        /// имеющая область значений {0;1}
        /// </summary>
        /// <param name="nec">выход сумматора</param>
        /// <returns></returns>

        private Int32 Activator(Int32 nec)
        {
            return nec >= S ? 1 : 0;
        }
    }
}