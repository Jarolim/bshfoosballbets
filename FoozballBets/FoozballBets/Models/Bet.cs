//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoozballBets.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bet
    {
        public int BetId { get; set; }
        public int BetValue { get; set; }
        public string BetForecast { get; set; }
        public int MatchId { get; set; }
        public int ProfileId { get; set; }
        public Nullable<System.DateTime> BetDate { get; set; }
    
        public virtual Match Match { get; set; }
        public virtual ProfilesBSH ProfilesBSH { get; set; }
    }
}