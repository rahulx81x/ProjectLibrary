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

//Landing Page for manager

        public ActionResult Index()
        {
            return View();
        }

//to fetch book list
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

//to get all logs 

        public ActionResult GetAllLogs()
        {
            List<ProjectLibraryDAL.Models.LendingLog> lstDAL = repository.GetAllLogs();
            List<ProjectLibraryMVCApp.Models.LendingLog> lstMVC = new List<ProjectLibraryMVCApp.Models.LendingLog>();
            try
            {
                foreach (var item in lstDAL)
                {
                    lstMVC.Add(_mapper.Map<Models.LendingLog>(item));
                }
                return View(lstMVC);
            }
            catch
            {
                return View("Error");
            }
        }

//to get all members

        public ActionResult GetAllMembers()
        {
            List<ProjectLibraryDAL.Models.Members> lstDAL = repository.GetAllMembers();
            List<ProjectLibraryMVCApp.Models.Members> lstMVC = new List<ProjectLibraryMVCApp.Models.Members>();
            try
            {
                foreach (var item in lstDAL)
                {
                    lstMVC.Add(_mapper.Map<Models.Members>(item));
                }
                return View(lstMVC);
            }
            catch
            {
                return View("Error");
            }
        }

//to add book to booklist
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

// to lend a book/add transaction log
        public ActionResult AddLog()
        {
            return View();
        }

        public ActionResult SaveAddLog(int memberId,int bookId)
        {
            bool result = repository.AddLog(memberId, bookId);
            if (result)
            {
                return RedirectToAction("GetAllLogs");
            }
            else
            {
                return View("Error");
            }

        }
// Returning book

         public ActionResult ReturnBook(Models.LendingLog logItem)
        {
            return View(logItem);
        }

        public ActionResult SaveReturnBook(int transactId)
        {
            bool result = repository.UpdateBookReturn(transactId);
            if (result)
            {
                return RedirectToAction("GetAllLogs");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
