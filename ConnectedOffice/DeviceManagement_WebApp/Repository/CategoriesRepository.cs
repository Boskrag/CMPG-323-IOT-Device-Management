using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();



        // GET: Categories
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        // GET: Categories/Details/5
        public async Task<Category> GetById(Guid? id)
        {

            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);

            return (category);
        }
    }

    
}
