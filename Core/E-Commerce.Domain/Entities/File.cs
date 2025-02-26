using E_Commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    //BASE FILE
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        // updatedTime prop not going to use
        [NotMapped]
        public override DateTime UpdatedTime { get => base.UpdatedTime; set => base.UpdatedTime = value; }
    }
}
