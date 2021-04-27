using BookShop.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Core.Interfaces
{
    public interface IWriterRepository
    {
        IEnumerable<DtoWriter> GetWriter();
        DtoWriter GetWriter(int Id);
        int CreateWriter(DtoWriter Data);
        int UpdateWriter(DtoWriter Data);
        int DeleteWriter(int Id);
    }
}
