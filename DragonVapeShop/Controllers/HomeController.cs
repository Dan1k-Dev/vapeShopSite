using DragonVapeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using VapeShop.ClassesDb;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace DragonVapeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DatabaseContext _context; // Инициализация контекста БД
        IWebHostEnvironment _environment; // инициализация интерфейса дял вывода фото на веб-страницу

        public HomeController(ILogger<HomeController> logger, DatabaseContext context, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            _environment = environment;
        }
    }
}