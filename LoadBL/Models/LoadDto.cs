using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBL.Models
{
    /// <summary>
    ///  Класс - нагрузка
    /// </summary>
    public class LoadDto
    {
        /// <summary>
        ///  id нагрузки 
        /// </summary>
        public int Id { get; set; }
       
        /// <summary>
        ///  Преподаватель
        /// </summary>
        public string Teacher { get; set; }
       
        /// <summary>
        ///  Предмет
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        ///  Группа
        /// </summary>
        public string Group { get; set; }
      
        /// <summary>
        ///  Количество часов по плану
        /// </summary>
        public int HousPlan { get; set; }
       
        /// <summary>
        ///  Количество часов фактически
        /// </summary>
        public int? HousActuality { get; set; }
       
        /// <summary>
        ///  Тип занятия
        /// </summary>
        public string Type { get; set; }
    }
}
