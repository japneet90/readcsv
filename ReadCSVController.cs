using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class ReadCSVController
    {
        public ReadCSVController()
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// upload and read csv file 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (file != null && file.FileName.EndsWith(".csv"))
            {
                try
                {
                    using (var sreader = new StreamReader(file.OpenReadStream()))
                    {
                        //headers can be fetched from following list, like headers[0], headers[1]
                        string[] headers = sreader.ReadLine().Split(',');
                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(',');
                            //here data can be read as rows[0], rows[1] etc
                        }                        
                    }
                    return RedirectToAction("Index", new { success = true });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { success = false });
                }
            }
            else {
                return RedirectToAction("Index", new { success = false });
            }
        }
    }
}
