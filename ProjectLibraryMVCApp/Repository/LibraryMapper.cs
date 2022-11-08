using AutoMapper;
using ProjectLibraryDAL.Models;
using System.Runtime;

namespace ProjectLibraryMVCApp.Repository
{
    public class LibraryMapper : Profile
    {
        public LibraryMapper()
        {
            CreateMap<BookList, Models.BookList>();
            CreateMap<Models.BookList, BookList>();
        }
    }
    
}
