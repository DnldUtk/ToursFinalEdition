//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPHotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelComment
    {
        public string ID_comment { get; set; }
        public int ID_hotel { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
    
        public virtual Hotel Hotel { get; set; }
    }
}
