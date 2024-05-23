using ECommerceBackEnd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Domain.Entities
{
    public class EntityFile : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }


        [NotMapped]
        public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
    }
}
