using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
     public interface ICategoryService 
    {
        List<Category> GetCategories();
        
        void CreateProduct(Product product);
    }

   
}