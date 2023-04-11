using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    /// <summary>
    /// Product ve ProductFeature arasında 1e1 bir ilişki olacak ve zaten Product Base'den miras aldı
    /// Bu nedenle direkt olarak Product'dan miras aldırmamamız en doğrusu olacaktır. 
    /// </summary>
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
