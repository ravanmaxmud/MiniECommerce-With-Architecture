using ECommerceBackEnd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //IQueryble Sorgu uzerinde isleyeceyimiz ucun yazilir.  
        IQueryable<T> GetAll(bool tracking = true); 
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method , bool tracking = true); // Buradaki Exspression Lambda exspression
                                                                                       // yaza bilek deye yazilir(Serti yoxlayir)
                                                                                       // Tracking - DbContextden cekilen butun datalar tracking
                                                                                       // mexanizimi vasitesi ile takib edilir (izlenilir , deyisiklikleri gorur)
                                                                                       // Bunu burda yazmaqimizn sebebi bezi yerlerde bize tracking mexaniziminin
                                                                                       // ehtiyyac olmamisidir meselen : butun productlari listlemek
                                                                                       // burada trackingmexanizimi bize lazim deyil 
                                                                                       // adeten tracking post emeliyyatlarinda lazim olur bize bunu
                                                                                       // burda yazmaqimizin sebebi de trackingi manuel olaraq idare etmeyimiz ucundur
       Task<T> GetSingleAsync(Expression<Func<T,bool>>method, bool tracking = true);
        Task<T> GetByIdAsync(string id , bool tracking = true);
    }
}
