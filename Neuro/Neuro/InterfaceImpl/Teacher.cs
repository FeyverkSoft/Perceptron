using System;
using System.Collections.Generic;
using Neuro.Domain;
using Neuro.Interface;

namespace Neuro.InterfaceImpl
{

    /// <summary>
    ///Учитель
    ///учит перцептрон распознаванию цифр
    /// </summary>
    public class Teacher : ITeacher
    {
        /// <summary>
        /// Персептрон
        /// </summary>
        private readonly IPerceptron _perceptron;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="perceptron">Персептрон</param>
        public Teacher(IPerceptron perceptron)
        {
            _perceptron = perceptron;
        }


        /// <summary>
        ///  Обучение перцептрона
        /// </summary>
        /// <param name="images">Образы для обучения</param>
        /// <param name="n">количество циклов обучения</param>
        public void Teach(ICollection<ImageData> images, Int32 n)
        {
            // инициализация начальных весов
            _perceptron.InitWeights(10);
            // получение пиксельных массивов каждого изображения
            // и обучение n раз каждой выборке
            while (n-- > 0)
            {
                foreach (var item in images)
                {
                    var y = GetOutVector(Convert.ToInt32(item.Class));
                    _perceptron.Teach(item.Data, y);
                }
            }
        }

        /// <summary>
        ///Генерация правильного выходного вектора
        /// </summary>
        /// <param name="n">цифра, в соответствии с которой 
        ///  нужно построить вектор, другими словами:
        ///  на каком месте должна быть 1, остальные 0</param>
        /// <returns>вектор для входа перцептрона</returns>
        private Int32[] GetOutVector(Int32 n)
        {
            var y = new Int32[_perceptron.GetNeuronCount];
            if (_perceptron.GetNeuronCount > n)
                y[n] = 1;
            return y;
        }
    }
}
