//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaNetwork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gender
    {
        public Gender()
        {
            this.People = new HashSet<Person>();
        }
    
        public int GenderId { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<Person> People { get; set; }
    }
}
