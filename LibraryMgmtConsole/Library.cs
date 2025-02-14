using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgmtConsole
{
    internal class Library
    {
        #region -- Dictionary --
        Dictionary<int, Book> book = new Dictionary<int, Book> {
            { 1, new Book(1, "Lewis Carrol","Alice in Wonderland" ) },
            { 2, new Book(2, "G.B.Shaw","Arms and the Man" ) },
            { 3, new Book(3, "Coleridge","Ancient Mariner" ) }
        };
        #endregion

        #region -- add book --
        public bool Addbook(int id, string title, string author)
        {
            return book.TryAdd(id, new Book(id, author,title));
        }
        #endregion

        #region -- add rating --
        public bool AddRating(int bookid, double rate)
        {
            if(book.ContainsKey(bookid))
            {
                book[bookid].Rating.Add(rate);
                return true;
            }
            return false;
        }
        #endregion

        #region -- get average rating --
        public double GetAverageRating(int bookKey)
        {
            if (book[bookKey].Rating.Count > 0) { 
                return book[bookKey].Rating.Average();
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region -- get books --
        public void GetBooks(bool status)
        {
            if(book.Count > 0)
            {
                book.Where(book => book.Value.IsAvailable == status).ToList().ForEach(x => Console.WriteLine($"ID\t:{x.Key}\nTitle\t:{x.Value.Title}\nAuthor\t:{x.Value.Author}\nRating\t:{GetAverageRating(x.Key)}\n"));
            }
            else
            {
                Console.WriteLine("Library is Empty!");
            }

        }
        #endregion

        #region -- borrow Books -- 
        public bool BorrowBook(int bookid)
        {
            if (book.ContainsKey(bookid)) {
                book[bookid].IsAvailable = false;
                return true;
            }
            return false;
        }
        #endregion

        #region -- Return Books -- 
        public bool ReturnBook(int bookid)
        {
            if (book.ContainsKey(bookid))
            {
                book[bookid].IsAvailable = true;
                return true;
            }
            return false;
        }
        #endregion

        #region -- remove book --
        public bool RemoveBook(int bookid)
        {
            if (book.ContainsKey(bookid))
            {
                return book.Remove(bookid);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region -- find book --
        public void SearchBook(string value)
        {
            var result = book.Where(x => x.Value.Title.Contains(value) || x.Value.BookId == int.Parse(value)).ToList();
            if (result.Count > 0) {
                result.ForEach(x => Console.WriteLine($"\nID\t:{x.Key}\nTitle\t:{x.Value.Title}\nAuthor\t:{x.Value.Author}\nRating\t:{GetAverageRating(x.Key)}\n"));
            }
            else
            {
                Console.WriteLine("Book Not Found!");
            }
        }
        #endregion

    }
}
