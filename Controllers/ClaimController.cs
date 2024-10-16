using Microsoft.AspNetCore.Mvc;
using ST10021160.PROG.POE.PT2.Models;
using System.Collections.Generic;

namespace ST10021160.PROG.POE.PT2.Controllers
{

    public class ClaimController : Controller
    {
        private static List<Claim> Claims = new List<Claim>();

        // Academic Manager's Dashboard
        public IActionResult AcademicManagerDashboard()
        {
            return View(Claims);
        }

        // Contract Lecturer Dashboard
        public IActionResult ContractLecturerDashboard()
        {
            return View(Claims);
        }

        // Submit Claim Form
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                Claims.Add(claim);
                return RedirectToAction("ContractLecturerDashboard");
            }
            return View(claim);
        }

        // Approve a claim
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = Claims.Find(c => c.ClaimId == id);
            if (claim != null) claim.Status = "Approved";
            return RedirectToAction("AcademicManagerDashboard");
        }

        // Reject a claim
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = Claims.Find(c => c.ClaimId == id);
            if (claim != null) claim.Status = "Rejected";
            return RedirectToAction("AcademicManagerDashboard");
        }

        // Upload Document for Contract Lecturers
        [HttpPost]
        public IActionResult UploadDocument(int id, IFormFile file)
        {
            var claim = Claims.Find(c => c.ClaimId == id);
            if (claim != null && file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                claim.AttachedFilePath = file.FileName;
            }
            return RedirectToAction("ContractLecturerDashboard");
        }
    }

}
