﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using zadanie03.Models;
using zadanie03.Data;

namespace zadanie03.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NumContext _context;

        [BindProperty(SupportsGet = true)]
        public Num Number { get; set; }

        public IndexModel(ILogger<IndexModel> logger, NumContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {   
                Number.When = DateTime.Now;
                Number.Result = "Result: ";

                if (Number.Value % 3 == 0)
                {
                    Number.Result += "Fizz";
                }
                if (Number.Value % 5 == 0)
                {
                    Number.Result += "Buzz";
                }
                if(Number.Result == "Result: ")
                {
                    Number.Result = "Your number: " + Number.Value.ToString() + " does not meet the FizzBuzz conditions.";
                }

                _context.Number.Add(Number);

                _context.SaveChanges();
                var SessionFizzBuzz = HttpContext.Session.GetString("SessionFizzBuzz");


                List<Num> ListOfSearches;

                if (SessionFizzBuzz == null) 
                { 
                    ListOfSearches = new List<Num>(); 
                }
                else
                {
                    ListOfSearches = JsonConvert.DeserializeObject<List<Num>>(SessionFizzBuzz);
                }

                ListOfSearches.Add(Number);

                HttpContext.Session.SetString("SessionFizzBuzz", JsonConvert.SerializeObject(ListOfSearches));

                
            }
            return Page();

        }

    }
}
