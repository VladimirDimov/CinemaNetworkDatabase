//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonEntitiesData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Towns
    {
        public Towns()
        {
            this.Cinemas = new HashSet<Cinemas>();
        }
    
        public int TownId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Cinemas> Cinemas { get; set; }
    }
}
