using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yimi.PublishManage.Web.Models;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Framework.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.IO;
using Yimi.PublishManage.Web.Model;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishManage.Core.Domain;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Yimi.PublishManage.Framework.Mvc.Filters;

namespace Yimi.PublishManage.Web.Controllers
{
    public class HomeController : BasePublicController
    {
        private readonly ILogger _logger;
        private readonly IQuoteService _quoteService;
        //public HomeController(ILogger logger)
        //{
        //    _logger = logger;
        //}

       public HomeController()
        {
            _logger = EngineContext.Current.Resolve<ILogger>();
            _quoteService = EngineContext.Current.Resolve<IQuoteService>();
        }


        public IActionResult Index()
        {
            //SendMail(new Quote { PartNo = "21312312", Phone="21312312", Company ="213213123", Commnet = "213123", Email ="123123213", Leadtime ="213213213", Quantity = "123123123", Name = "123123123", Type = "213123123123" });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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


        public void GetProjectType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //编制、审计
            list.Add(new SelectListItem { Text = "--- Please Choose Type of Quote ---", Value = "0" });
            list.Add(new SelectListItem { Text = "PCB Quote", Value = "PCB Quote" });
            list.Add(new SelectListItem { Text = "Assembly Quote(Components and PCB consigned)", Value = "Assembly Quote(Components and PCB consigned)" });
            list.Add(new SelectListItem { Text = "Assembly Quote(Components and PCB consigned)", Value = "Assembly Quote(Components and PCB consigned)" });
            list.Add(new SelectListItem { Text = "Full Turnkey (PCB, Components and Assembly)", Value = "Full Turnkey (PCB, Components and Assembly)" });
            ViewBag.ProjectList = list;
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult leadtime()
        {
            return View();
        }

        public IActionResult Product2()
        {
            return View();
        }

        public IActionResult Capability()
        {
            return View();
        }


        public IActionResult UploadQuote()
        {
            GetProjectType();
            return View();
        }

        [HttpPost]
        public IActionResult UploadQuote(QuoteModel model)
        {
            GetProjectType();

            if(string.IsNullOrEmpty(model.Company))
            {
                ModelState.AddModelError("", "Company can not be empty.");
            }

            if(string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("", "Name can not be empty.");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "Email can not be empty.");
            }

            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("", "Phone can not be empty.");
            }

            if(Request.Form.Files == null || Request.Form.Files.Count == 0)
            {
                ModelState.AddModelError("", "Please upload file.");
            }

            var code = TempData["code"].ToString();
            if (string.IsNullOrEmpty(model.Code) || model.Code.ToLower()!=code.ToLower())
            {
                ModelState.AddModelError("", "Captcha error.");
            }

            IFormFile file = null;
            string ext = string.Empty;
            if(Request.Form.Files.Count>0)
            {
                file = Request.Form.Files[0];
                if (file.Length > 1024 * 1024 * 10)
                {
                    ModelState.AddModelError("", "Upload file is too large.");
                }
                ext = Path.GetExtension(file.FileName);

                if (string.IsNullOrEmpty(ext))
                {
                    ModelState.AddModelError("", "Upload file must be zip ,pdf, rar ,arj .");
                }

                ext = ext.ToLower();
                //zip, tgz, rar, arj, pdf
                string[] extarray = new string[] { ".zip", ".pdf", ".rar", ".arj" };
                if (!extarray.ToList().Contains(ext))
                {
                    ModelState.AddModelError("", "Upload file must be zip ,pdf, rar ,arj.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please upload file");
            }
           
            if (!ModelState.IsValid)
            {
                return View();
            }

            
            string fileid = Guid.NewGuid().ToString();
            var filepath = Directory.GetCurrentDirectory() + "\\upload\\" + fileid + ext;

            if (file.Length > 0)
            {
                using (var inputStream = new FileStream(filepath, FileMode.Create))
                {
                    // read file to stream
                    file.CopyTo(inputStream);
      
                }
            }

            Quote domainmodel = new Quote
            {
                Commnet = model.Commnet,
                Company = model.Company,
                Deleted = false,
                Email = model.Email,
                Leadtime = model.Leadtime,
                Name = model.Name,
                PartNo = model.PartNo,
                Phone = model.Phone,
                Quantity = model.Quantity,
                Type = model.Type == "0" ? string.Empty : model.Type,
                Uploadfile = fileid + ext
            };

            _quoteService.AddQuote(domainmodel);
            SendMail(domainmodel, filepath);

            return RedirectToAction("Success");
        }

        private void SendMail(Quote quote,string filepath)
        {
            SmtpClient client = new SmtpClient("smtp.163.com",25);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("15062334059@163.com", "Tuesday002");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("15062334059@163.com");
            mailMessage.To.Add("sales@starklink-xdz.com");
            mailMessage.Body = quote.ToString();
            mailMessage.Subject = $"New Quote from Company:{quote.Company},Phone:{quote.Phone},Parto:{quote.PartNo}";

            if (System.IO.File.Exists(filepath))
            {
                Attachment attachment = new Attachment(filepath);
                mailMessage.Attachments.Add(attachment);
            }

            client.Send(mailMessage);

        }

        [YimiAuthorize]
        public IActionResult ListQuote(int? pageindex , int? pagesize)
        {

            
            var pageIndex = pageindex ?? 0;
            var pageSize = pagesize ?? 10;
            var result = _quoteService.GetQuotes(pageIndex, pageSize);

            string url = $"/home/ListQuote";
            ViewBag.PageInfo = new Yimi.PublishManage.Framework.UI.Paging.PageModel { PageCount = result.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 0, Url = url }; 
            return View(result);
        }

        private static string RndNum(int VcodeNum)
        {
            //验证码可以显示的字符集合  
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p" +
                ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q" +
                ",R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组   
            string code = "";//产生的随机数  
            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数  

            Random rand = new Random();
            //采用一个简单的算法以保证生成随机数的不同  
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类  
                }
                int t = rand.Next(61);//获取随机数  
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);//如果获取的随机数重复，则递归调用  
                }
                temp = t;//把本次产生的随机数记录起来  
                code += VcArray[t];//随机数的位数加一  
            }
            return code;
        }


        public static MemoryStream Create(out string code, int numbers = 4)
        {
            code = RndNum(numbers);
            //Bitmap img = null;
            //Graphics g = null;
            MemoryStream ms = null;
            Random random = new Random();
            //验证码颜色集合  
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            //验证码字体集合
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };


            using (var img = new Bitmap((int)code.Length * 18, 32))
            {
                using (var g = Graphics.FromImage(img))
                {
                    g.Clear(Color.White);//背景设为白色

                    //在随机位置画背景点  
                    for (int i = 0; i < 100; i++)
                    {
                        int x = random.Next(img.Width);
                        int y = random.Next(img.Height);
                        g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
                    }
                    //验证码绘制在g中  
                    for (int i = 0; i < code.Length; i++)
                    {
                        int cindex = random.Next(7);//随机颜色索引值  
                        int findex = random.Next(5);//随机字体索引值  
                        Font f = new Font(fonts[findex], 15, FontStyle.Bold);//字体  
                        Brush b = new SolidBrush(c[cindex]);//颜色  
                        int ii = 4;
                        if ((i + 1) % 2 == 0)//控制验证码不在同一高度  
                        {
                            ii = 2;
                        }
                        g.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), ii);//绘制一个验证字符  
                    }
                    ms = new MemoryStream();//生成内存流对象  
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);//将此图像以Png图像文件的格式保存到流中  
                }
            }

            return ms;
        }

       
        public void GetVerifyCode()
        {
            Response.ContentType = "image/jpeg";
            using (var stream = Create(out string code))
            {
                var buffer = stream.ToArray();

                // 将验证码的token放入cookie
                //Response.Cookies.Append(VERFIY_CODE_TOKEN_COOKIE_NAME, await SecurityServices.GetVerifyCodeToken(code));
                TempData["code"] = code;
                 Response.Body.Write(buffer, 0, buffer.Length);
            }
        }


        public IActionResult Success()
        {
            return View();
        }
    }
}
