using System;
using System.Net;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Query;
using ProjectLibraryDAL.Models;


namespace ProjectLibraryDAL
{
    public class ProjectLibraryRepository
    {
        ProjectLibraryDBContext context;
        public ProjectLibraryRepository()
        {
            context = new ProjectLibraryDBContext();
        }

        public bool AddBook(String bookName, String author, int yearOfPublication, int totalQuantity)
        {
            bool status = false;
            BookList bookList = new BookList();
            bookList.BookName = bookName;
            bookList.Author = author;
            bookList.YearOfPublication = yearOfPublication;
            bookList.TotalQuantity = totalQuantity;
            bookList.AvailableQuantity = totalQuantity;
            try
            {
                context.BookList.Add(bookList);
                context.SaveChanges();
                status = true;
                return status;
            }
            catch
            {
                status = false;
                return status;
            }
        }
        public bool AddMember(String memberName, String phone, string address)
        {
            bool status = false;
            Members member = new Members();
            member.MemberName = memberName;
            member.Phone = phone;
            member.Address = address;
            member.MemberSince = DateTime.Today;
            try
            {
                context.Members.Add(member);
                context.SaveChanges();
                status = true;
                return status;
            }
            catch
            {
                status = false;
                return status;
            }
        }
        public bool AddLog(int? memberid, int? bookid)
        {
            bool status = false;
            LendingLog log = new LendingLog();
            log.MemberId = memberid;
            log.BookId = bookid;
            log.BorrowedOn = DateTime.Today;
            try
            {
                context.LendingLog.Add(log);
                context.SaveChanges();
                ProjectLibraryRepository repository = new ProjectLibraryRepository();
                bool result = repository.UpdateQuantityWhenLog(bookid);
                if (result)
                {
                    status = true;
                    return status;
                }
                else
                {
                    status = false;
                    return status;
                }

            }
            catch
            {
                status = false;
                return status;
            }
        }
        public bool UpdateQuantityWhenLog(int? bookId)
        {
            bool result = false;
            try
            {
                BookList bookList = context.BookList.Find(bookId);
                if (bookList != null)
                {
                    bookList.AvailableQuantity = bookList.AvailableQuantity - 1;
                    context.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch
            {
                result = false;
                return result;
            }
        }
    }
}