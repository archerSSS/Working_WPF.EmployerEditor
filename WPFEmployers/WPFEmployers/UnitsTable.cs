//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFEmployers
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnitsTable
    {
        public string Название { get; set; }
        public Nullable<int> Руководитель { get; set; }
    
        public virtual EmployersTable EmployersTable { get; set; }
    }
}
