//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCar
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceList
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Deposit { get; set; }
        public int CarId { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
