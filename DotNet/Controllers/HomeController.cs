﻿using DotNet.Models;
using DotNet.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace DotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BulkCategory()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]

        public async Task<IActionResult> BulkCategory(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Variable to track if any duplicate categories were found
                bool duplicateFound = false;

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            bool isHeaderSkipped = false;

                            while (reader.Read())
                            {
                                if (!isHeaderSkipped)
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }
                                string categoryName = reader.GetValue(1).ToString();

                                if (!_context.Categories.Any(c => c.CategoryName == categoryName))
                                {
                                    Category category = new Category();
                                    category.CategoryName = categoryName;

                                    _context.Add(category);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    // If a duplicate category is found, set the flag and exit the loop
                                    duplicateFound = true;
                                    break;
                                }
                            }

                            // If a duplicate category is found, break out of the loop
                            if (duplicateFound)
                            {
                                break;
                            }

                        } while (reader.NextResult());
                    }
                }

                // Set ViewBag.Message based on whether duplicates were found
                if (duplicateFound)
                {
                    ViewBag.Message = "Duplicate";
                }
                else
                {
                    ViewBag.Message = "Success";
                }
            }
            else
            {
                ViewBag.Message = "Empty";
            }

            return View();
        }
        [Authorize(Roles = "Admin,General")]
        public IActionResult BulkItem()
        {
            return View();
        }
        [Authorize(Roles = "Admin,General")]
        [HttpPost]

        public async Task<IActionResult> BulkItem(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Variable to track if any duplicate items were found
                bool duplicateFound = false;

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {

                            bool isHeaderSkipped = false;

                            while (reader.Read())
                            {
                                if (!isHeaderSkipped)
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }

                                string itemName = reader.GetValue(1).ToString();
                                int itemUnit = Convert.ToInt32(reader.GetValue(2).ToString());
                                int itemQuantity = Convert.ToInt32(reader.GetValue(3).ToString());
                                string itemImageFileName = reader.GetValue(4).ToString();
                                DateTime itemCreatedAt = Convert.ToDateTime(reader.GetValue(5).ToString());
                                int itemCategoryId = Convert.ToInt32(reader.GetValue(6).ToString());

                                if (!_context.Items.Any(c => c.ImageFileNames == itemImageFileName))
                                {
                                    Item item = new Item();

                                    item.Name = itemName;
                                    item.Unit = itemUnit;
                                    item.Quantity = itemQuantity;
                                    item.ImageFileNames = itemImageFileName;
                                    item.CreatedAt = itemCreatedAt;
                                    item.CategoryId = itemCategoryId;

                                    _context.Add(item);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    // If a duplicate item is found, set the flag and exit the loop
                                    duplicateFound = true;
                                    break;
                                }
                            }

                            // If a duplicate item is found, break out of the loop
                            if (duplicateFound)
                            {
                                break;
                            }

                        } while (reader.NextResult());
                    }
                }

                // Set ViewBag.Message based on whether duplicates were found
                if (duplicateFound)
                {
                    ViewBag.Message = "Duplicate";
                }
                else
                {
                    ViewBag.Message = "Success";
                }
            }
            else
            {
                ViewBag.Message = "Empty";
            }

            return View();
        }

    }
}
