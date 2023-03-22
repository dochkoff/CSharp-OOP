using System;
using P02._Books_Before.Interfaces;

namespace P02._Books_Before
{
    public class PageTurner : IPageTurner
    {
        public string TurnPage(int page)
        {
            return $"Current page is {page}";
        }
    }
}

