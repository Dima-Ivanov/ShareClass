using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer;
using Ninject.Modules;
using DataAccessLayer.Interfaces;
using DataAccessLayer;

namespace Share_Class.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDBRepository>().To<DataRepository>();
            Bind<IDbDataOperations>().To<DbDataOperations>();
        }
    }
}
