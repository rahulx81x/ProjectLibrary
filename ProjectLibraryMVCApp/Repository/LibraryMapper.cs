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
            CreateMap<LendingLog, Models.LendingLog>();
            CreateMap<Models.LendingLog, LendingLog>();
            CreateMap<Members, Models.Members>();
            CreateMap<Models.Members, Members>();
        }
    }
    
}
