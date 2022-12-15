using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

        public List<BookList> GetAllBooks()
        {
            try
            {
                var books = context.BookList.ToList();
                return books;
            }
            catch
            {
                return null;
            }
        }

        public List<LendingLog> GetAllLogs()
        {
            try
            {
                var logs = context.LendingLog.ToList();
                return logs;
            }
            catch
            {
                return null;
            }
        }

        public BookList GetBookListById(int? bookId)
         {
            try
            {
                BookList bookList = context.BookList.Find(bookId);
                return bookList;
            }
            catch
            {
                Console.WriteLine("Some Error Occured");
                return null;
            }
         }
        public Members GetMemberById(int? memberId)
        {
            try
            {
               Members member = context.Members.Find(memberId);
                return member;
            }
            catch
            {
                Console.WriteLine("Some Error Occured");
                return null;
            }
        }
        public LendingLog GetLogById(int? transactId)
        {
            try
            {
                LendingLog log = context.LendingLog.Find(transactId);
                return log;
            }
            catch
            {
                Console.WriteLine("Some Error Occured");
                return null;
            }
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
                Console.WriteLine("Some Error Occured");
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
                Console.WriteLine("Some Error Occured");
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
                status=true;
                ProjectLibraryRepository repository = new ProjectLibraryRepository();
                bool result = repository.UpdateQuantityWhenLog(bookid);
                if (result)
                {

                    status = true;
                    return status;
                }
                else
                {
                    Console.WriteLine("Some Error Occured else block addlog");
                    status = false;
                    return status;
                }

            }
            catch
            {
                Console.WriteLine("Some Error Occured catch block addlog");
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
                    Console.WriteLine("Some Error Occured else block updatequantwhenlog");
                    result = false;
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Some Error Occured catch updatequantwhenlog");
                result = false;
                return result;
            }
        }

        public bool UpdateQuantity(int? bookId, int updatedValue)
        {
            bool result = false;
            try
            {
                BookList bookList = context.BookList.Find(bookId);
                if (bookList != null)
                {
                    bookList.AvailableQuantity = updatedValue;
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
                Console.WriteLine("Some Error Occured");
                result = false;
                return result;
            }
        }

        public bool UpdateBookReturn(int? transactId)
        {
            bool result = false;
            try
            {
                LendingLog log = context.LendingLog.Find(transactId); ;
                if (log != null)
                {
                    log.ReturnedOn = DateTime.Today;
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
                Console.WriteLine("Some Error Occured");
                result = false;
                return result;
            }
        }

        public bool RemoveMember(int? memberId)
        {
            bool result = false;
            try
            {
                Members member = context.Members.Find(memberId);
                if (member != null)
                {
                    context.Members.Remove(member);
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
                Console.WriteLine("Some Error Occured");
                result = false;
                return result;
            }

        }
        public bool RemoveBook(int? bookId)
        {
            bool result = false;
            try
            {
                BookList bookList = context.BookList.Find(bookId);
                if (bookList != null)
                {
                    context.BookList.Remove(bookList);
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
                Console.WriteLine("Some Error Occured");
                result = false;
                return result;
            }

        }
    }
}