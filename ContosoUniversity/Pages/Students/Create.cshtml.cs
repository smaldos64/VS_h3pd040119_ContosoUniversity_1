﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public CreateModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Student.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "Student",   // Prefix for form value. Der skal stå Student her. Ellers kommer der ingen data med !!!
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}