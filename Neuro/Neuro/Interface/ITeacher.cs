using System;
using System.Collections.Generic;
using Neuro.Domain;

namespace Neuro.Interface
{
    public interface ITeacher
    {
        /// <summary>
        ///  Обучение перцептрона
        /// </summary>
        /// <param name="images">Образы для обучения</param>
        /// <param name="n">количество циклов обучения</param>
        void Teach(ICollection<ImageData> images, Int32 n);
    }
}
