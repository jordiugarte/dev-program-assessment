using System.Collections.Generic;
using System.Linq;
using System;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);
            currentPage = 1;
            this.pageSize = pageSize;
        }

        public void FirstPage()
        {
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            if (page <= data.Count() / pageSize)
            {
                currentPage = page;
            }
            else
            {
                string message = "Invalid page number.";
                throw new System.InvalidOperationException(message);
                Console.Write(message);
            }
        }

        public void LastPage()
        {
            currentPage = data.Count() / pageSize;
            if (data.Count() % pageSize > 0)
            {
                currentPage++;
            }
        }

        public void NextPage()
        {
            if (currentPage <= pageSize)
            {
                currentPage++;

            } else
            {
                string message = "Cannot go further last page.";
                throw new System.InvalidOperationException(message);
                Console.Write(message);
            }
        }

        public void PrevPage()
        {
            if (currentPage > 1)
            {
                currentPage--;
            } else
            {
                string message = "Cannot go beyond first page.";
                throw new System.InvalidOperationException(message);
                Console.Write(message);
            }
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            return pageSize;
        }

        public void PrintCurrentElements()
        {
            for(int i=0; i < GetVisibleItems().ToList().Count; i++)
            {
                Console.WriteLine(GetVisibleItems().ToList()[i]);
            }
        }
    }
}