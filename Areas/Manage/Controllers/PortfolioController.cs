using Microsoft.AspNetCore.Mvc;
using WebApplication15.DAL;
using WebApplication15.Models;

namespace WebApplication15.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Portfolio.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            if(!ModelState.IsValid) return View();
            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid() + portfolio.formFile.FileName;
            using(FileStream fileStream=new FileStream(path + filename, FileMode.Create))
            {
                portfolio.formFile.CopyTo(fileStream);
            }
            portfolio.ImgUrl = filename;
            _context.Portfolio.Add(portfolio);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var Portfolio= _context.Portfolio.FirstOrDefault(x=>x.Id==id);
            if(Portfolio==null)
            {
                return NotFound();
            }
            return View(Portfolio);
        }
        [HttpPost]
        public IActionResult Update(Portfolio portfolio) 
        {
            if (ModelState.IsValid && portfolio.ImgUrl != null) 
            { 
                return View();
            }
            var oldPortfolio= _context.Portfolio.FirstOrDefault(x=>x.Id == portfolio.Id);
            if (oldPortfolio!=null) 
            {
                string path = _environment.WebRootPath + @"\Upload\";
                FileInfo fileInfo = new FileInfo(path+oldPortfolio.ImgUrl);
                if(fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                string filename = Guid.NewGuid() + portfolio.formFile.FileName;
                using (FileStream fileStream = new FileStream(path + filename, FileMode.Create))
                {
                    portfolio.formFile.CopyTo(fileStream);
                }
                oldPortfolio.ImgUrl= filename;
            }
            oldPortfolio.Name=portfolio.Name;
            oldPortfolio.Description=portfolio.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var Portfolio = _context.Portfolio.FirstOrDefault(x => x.Id == id);
            _context.Portfolio.Remove(Portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
