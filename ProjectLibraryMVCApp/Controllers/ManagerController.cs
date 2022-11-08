using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProjectLibraryDAL;
using ProjectLibraryDAL.Models;
using System.Collections.Generic;

namespace ProjectLibraryMVCApp.Controllers
{
    public class ManagerController : Controller
    {
        private ProjectLibraryDBContext _context;
        private readonly IMapper _mapper;
        ProjectLibraryRepository repository;
        public ManagerController(ProjectLibraryDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            repository = new ProjectLibraryRepository();
        }
        public ActionResult GetAllBooks()
        {
            List<ProjectLibraryDAL.Models.BookList> lstDAL = repository.GetAllBooks();
            List <ProjectLibraryMVCApp.Models.BookList> lstMVC = new List<ProjectLibraryMVCApp.Models.BookList>();
            try
            {
                foreach (var item in lstDAL)
                {
                    lstMVC.Add(_mapper.Map<Models.BookList>(item));
                }
                return View(lstMVC);
            }
            catch
            {
                return View("Error");
            }
        }
    
        public ActionResult AddBook()
        {
            return View();
        }

        public ActionResult SaveAddBook(Models.BookList book)
        {
           bool result = repository.AddBook(book.BookName,book.Author,book.YearOfPublication,book.TotalQuantity);
            if (result)
            {
                return RedirectToAction("GetAllBooks");
            }
            else
            {
                return View("Error");
            }
        }
    }
}