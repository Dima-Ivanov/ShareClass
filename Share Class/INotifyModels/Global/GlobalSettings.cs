using BusinessLogicLayer.Models;
using BusinessLogicLayer.Interfaces;
using Share_Class.INotifyModels;

namespace Share_Class.Global
{
    public static class GlobalSettings
    {
        public static UserModel CurentUser { get; set; }
        public static IDbDataOperations dbDataOperations { get; set; }
        public static NotifyModels NotifyModels { get; set; }
    }
}
