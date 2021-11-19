using LoadBL.Interfaces;

namespace LoadBL.Models
{
    /// <summary>
    /// Фабрика классов бизнес-логики
    /// </summary>
    public class ProcessFactory
    {
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="ILoadProcess"/>>  
        /// </summary>
        /// <returns></returns>
        public static ILoadProcess GetLoadProcess()
        {
            return new LoadProcessDb();
        }
    }
}
