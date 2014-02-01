using System;
using System.Collections.Generic;

namespace Neuro.Domain
{
    /// <summary>
    /// Образ которым обучаем распознавать нейрон класс образа
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// Образ представленный в виде целочисленного вектора
        /// </summary>
        public IList<Int32> Data { get; set; }

        /// <summary>
        /// Номер Класса к которому принадлежит образ
        /// </summary>
        public Int32 Class { get; set; }
    }
}
