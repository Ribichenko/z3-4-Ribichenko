//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace z3_4_Ribichenko.AppDataFile
{
    using System;
    using System.Collections.Generic;
    
    public partial class material
    {
        public int id { get; set; }
        public int number_material { get; set; }
        public string name { get; set; }
        public int id_unit { get; set; }
        public int ostatok { get; set; }
        public int id_garage { get; set; }
    
        public virtual garage garage { get; set; }
        public virtual units units { get; set; }
    }
}
