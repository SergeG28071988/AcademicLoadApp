using System.Collections.Generic;
using LoadBL.Models;

namespace LoadBL.Interfaces
{
    /// <summary>
    /// Декларация действий по работе с нагрузкой
    /// </summary>
    public interface ILoadProcess
    {
        /// <summary>
        ///  Возвращает список нагрузок
        /// </summary>
        /// <returns>список нагрузок</returns>
        IList<LoadDto> GetList();

        /// <summary>
        ///  Возвращает нагрузку по id 
        /// </summary>
        /// <param name="id">id нагрузки</param>
        /// <returns>Нагрузка</returns>
        LoadDto Get(int id);

        /// <summary>
        ///  Добавляет нагрузку
        /// </summary>
        /// <param name="load"></param>
        void Add(LoadDto load);

        /// <summary>
        ///  Обновляет данные о нагрузке
        /// </summary>
        /// <param name="load">Данные о нагрузке, которые надо сохранить</param>
        void Update(LoadDto load);

        /// <summary>
        /// Удаляет данные о нагрузке
        /// </summary>
        /// <param name="id">id нагрузки, которые надо удалить</param>
        void Delete(int id);


    }
}
