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
        private bool inLastPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);
            currentPage = 1;
            this.pageSize = pageSize;
        }

        public void FirstPage()
        {
            inLastPage = false;
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            if (page <= data.Count() / pageSize)
            {
                inLastPage = false;
                currentPage = page;
            }
            else
            {
                throw new System.InvalidOperationException("Invalid page number.");
            }
        }

        public void LastPage()
        {
            inLastPage = true;
            currentPage = data.Count() / pageSize;
        }

        public void NextPage()
        {
            if (currentPage <= pageSize)
            {
                currentPage++;
            } else
            {
                throw new System.InvalidOperationException();
            }
        }

        public void PrevPage()
        {
            if (currentPage > 1)
            {
                inLastPage = false;
                currentPage--;
            } else
            {
                throw new System.InvalidOperationException("Cannot go beyond first page.");
            }
        }

        public IEnumerable<string> GetVisibleItems()
        {
            if (inLastPage)
            {
                return data.Skip(data.Count() - pageSize).Take(pageSize);
            }
            else
            {
                return data.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
        }

        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            return pageSize;
        }
    }
}