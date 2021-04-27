using BookShop.Core.DTOs;
using System.Collections.Generic;

namespace BookShop.Core.Interfaces
{
    public interface IBookRepository
    {
        List<DtoBook> GetBooks();
        int CreateBook(DtoBook data);
        int UpdateBook(DtoBook data);
        int DeleteBook(int data);        
    }
}
