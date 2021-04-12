using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
    public class PageInfo
    {
        public int TotalItem { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int GetTotalPage() => (int)Math.Ceiling((decimal)TotalItem / ItemsPerPage);

    }
}
