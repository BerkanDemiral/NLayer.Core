using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    /// <summary>
    /// Veritabanındaki Entity'lerde olacak değerlri tanımlıyor
    /// Bu classdaki değerlerden new ile bir nesne oluşturulmasını istemiyoruz. Bu nedenle abstract ile tanımladık
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
