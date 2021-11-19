using LoadBL.Entities;
using System.Collections.Generic;

namespace LoadBL.Interfaces
{
    /// <summary>
    ///  Описание действий с объектом нагрузка в базе
    /// </summary>    
    public interface ILoadDao
    {
        /// <summary>
        /// Получить данные о нагрузке по id   
        /// </summary>
        /// <param name="id">id нагрузки</param>
        /// <returns></returns>
        Load Get(int id);

        /// <summary>
        ///  Получить данные о всех нагрузках в базе
        /// </summary>
        /// <returns>список всех нагрузок</returns>
        IList<Load> GetAll();

        /// <summary>
        ///  Добавить нагрузку в базу
        /// </summary>
        /// <param name="load"></param>
        void Add(Load load);

        /// <summary>
        ///  Обновление данных о нагрузке
        /// </summary>
        /// <param name="load">обновленная нагрузка</param>
        void Update(Load load);

        /// <summary>
        ///  Удалить данные о нагрузке
        /// </summary>
        /// <param name="id">id удаляемой нагрузки</param>
        void Delete(int id);
    }
}
