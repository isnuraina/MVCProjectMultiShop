using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopProject.Context;
using MultiShopProject.ViewModels.Home;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using Bigon.WebUI.Models.Entities;
using System.Globalization;
using Bigon.WebUI.AppCode.Extensions;
using Bigon.WebUI.AppCode.Services;
using System.Web;

namespace MultiShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context;
        private readonly IEmailService emailService;
        public HomeController(DataContext _context,IEmailService emailService)
        {
            context = _context;
            this.emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                CarouselItems = await context.CarouselItems.ToListAsync(),
                CardItems = await context.CardItems.ToListAsync(),
                Sponsors = await context.Sponsors.ToListAsync(),
                Categories = await context.Categories
                              .Include(m => m.Products)
                              .ToListAsync(),

                Products = await context.Products
                            .Include(m => m.Category)
                            .ToListAsync()
            };
            return View(homeVM);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (!email.IsEmail())
            {
                return Json(new
                {
                    error = true,
                    message = $"'{email}'email telebelerini odemir!"
                });
            }

            var subscriber = await context.Subscribers.FirstOrDefaultAsync(m => m.Email.Equals(email));

            if (subscriber != null && subscriber.Approved)
            {
                return Json(new
                {
                    error = true,
                    message = $"'{email}'bu e-poct adresine artiq abunelik tetbiq edilib!"
                });
            }
            else if (subscriber != null && !subscriber.Approved)
            {
                return Json(new
                {
                    error = false,
                    message = $"'{email}'bu e-poct adresini tesdiqlemesiniz!"
                });
            }
            subscriber = new Subscriber();
            subscriber.Email = email;
            subscriber.CreatedAt = DateTime.Now;
            await context.Subscribers.AddAsync(subscriber);
            await context.SaveChangesAsync();

            string token = $"#demo-{subscriber.Email}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";

            token = HttpUtility.UrlEncode(token);

            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";


            string message = $"Abuneliyinizi tesdiq etmek ucun <a href=\"{url}\">linklə</a> davam edin!";

            await emailService.SendMailAsync(subscriber.Email, "Bigon Service", message);

            return Json(new
            {
                error = false,
                message = $"Abuneliyinizi tesdiq etmek ucun '{email}'bu e-poct adresine daxil olub size gonderilen linke kecid edin!"
            });
        }
        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            string pattern = @"#demo-(?<email>[^-]*)-(?<date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})-bigon";
            Match match = Regex.Match(token, pattern);
            if (!match.Success)
            {
                return Content("token zedelidir!");
            }
            string email = match.Groups["email"].Value;
            string dateStr = match.Groups["date"].Value;

            if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss.fff", null, DateTimeStyles.None, out DateTime date))
            {
                return Content("token zedelidir");
            }
            var subscriber = await context.Subscribers.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.CreatedAt == date);
            if (subscriber == null)
            {
                return Content("token zedelidir");
            }
            if (!subscriber.Approved)
            {
                subscriber.Approved = true;
                subscriber.ApprovedAt = DateTime.Now;
            }
            await context.SaveChangesAsync();

            return Content($"Success: Email:{email}\n" +
                $"Date:{date}");
        }
    }
    }

