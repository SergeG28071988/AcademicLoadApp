using LoadBL.Interfaces;

namespace LoadBL.Models
{
    public class DaoFactory
    {
        public static ILoadDao GetLoadDao()
        {
            return new LoadDao();
        }
    }
}
