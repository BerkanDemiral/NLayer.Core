using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        /// <summary>
        /// Bir kategoride birden fazla product olabilir bu nedenle ICollection arayüzü içerisinde bu tanımı yapıyoruz.
        /// Navigation Property --> Farklı class ve entitylere referans verilen propertyler 
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
