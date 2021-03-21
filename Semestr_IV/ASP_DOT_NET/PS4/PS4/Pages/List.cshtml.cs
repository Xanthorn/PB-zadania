using System.Collections.Generic;
using PS4.Models;
namespace PS4
{
    public class ListModel : MyPageModel
    {
        public List<Product> productList;
        public void OnGet()
        {
            LoadDB();
            productList = productDB.List();
            SaveDB();
        }
    }
}