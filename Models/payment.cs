namespace MoMoney
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payments")]
    public partial class payment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(Order = 1)]
        public int uid { get; set; }

        [Column(Order = 2)]
        public int category { get; set; }

        [Column(Order = 3)]
        public DateTime time { get; set; }


        [Column(Order = 4, TypeName = "money")]
        public decimal amount { get; set; }

        [StringLength(144)]
        public string note { get; set; }

        public virtual category category1 { get; set; }

        public virtual login login { get; set; }
    }
}
