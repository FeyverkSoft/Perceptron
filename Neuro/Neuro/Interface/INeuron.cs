using System;
using System.Collections.Generic;

namespace Neuro.Interface
{
    internal interface INeuron
    {
        /// <summary>
        /// Передаточная функция
        /// </summary>
        /// <param name="x"> входной вектор</param>
        /// <returns>выходное значение нейрона</returns>
        Int32 Transfer(IList<Int32> x);

        /// <summary>      
        /// Инициализация начальных весов синапсов
        ///  небольшими случайными значениями от 0 до n
        /// </summary>
        /// <param name="n"> от 0 до n</param>
        void InitWeights(Int32 n);

        /// <summary> 
        /// Модификация весов синапсов для обучения
        /// </summary>
        /// <param name="v"> - скорость обучения</param>
        /// <param name="d"> - разница между выходом нейрона и нужным выходом</param>
        /// <param name="x"> - входной вектор</param>
        void ChangeWeights(Int32 v, Int32 d, IList<Int32> x);
    }
}
