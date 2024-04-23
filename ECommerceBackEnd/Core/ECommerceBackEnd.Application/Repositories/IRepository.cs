using ECommerceBackEnd.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity //where T class - yazdiqimiz zaman interfaceimize gelen
                                                         //generic Type larin class oldugu bildirilir
                                                         // : BaseEntity Vermeyimiz ise yanliz BaseEntity
                                                         // Classindan miras alan class lari goturmesi ucun verilir
                                                         //Burada yazilan bu kod setir IRepositroyni impliment eden
                                                         //butun class larda bildirilmelidir

    {
        //IRepository Butun repositeriylerde olan seyleri saxlamaq ucun yaradilir(evrensel)
        DbSet<T> Table { get; } //dB daki butun Tableleri getirmek ucun istifade edilir
    }
}
