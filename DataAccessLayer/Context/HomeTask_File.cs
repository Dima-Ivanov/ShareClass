//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class HomeTask_File
    {
        public int ID { get; set; }
        public string File_Name { get; set; }
        public int HomeTask_ID { get; set; }
    
        public virtual HomeTask HomeTask { get; set; }
    }
}
