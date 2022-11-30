using executiveData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace executiveWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public ProjectController(
            AppDbContext context,
            IConfiguration configuration
            )
        {
            this.context = context;
            this.configuration = configuration;
        }


        public async Task<IActionResult> ProjectIndex()
        {

            var model = await context.Projects.ToListAsync();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            //await Dropdowns();

            return View(new Project { Enabled=true});
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(Project model)
        {

            return View();
        }

    }
}
