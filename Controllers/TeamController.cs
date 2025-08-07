using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.MVC.Context;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.Controllers
{
	public class TeamController : Controller
	{
		private readonly SportsDbContext _context;
		private IMapper _mapper;

		public TeamController(SportsDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			List<Team> teams = _context.Teams.Where(t=>t.IsDeleted == false).ToList();
			List<TeamViewModel> model = _mapper.Map<List<TeamViewModel>>(teams);
			return View(model);
		}

        [HttpGet]
        public IActionResult Add()
        {
            TeamViewModel model = new TeamViewModel();

            List<Team> teams = _context.Teams.Where(b => b.IsDeleted == false && b.IsActive == true).ToList();

            List<TeamViewModel> teamsList = _mapper.Map<List<TeamViewModel>>(teams);

            ViewBag.TeamsList = teamsList;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TeamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Team teams = _mapper.Map<Team>(model);

            _context.Teams.Add(teams);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

		public IActionResult Edit(int id)
		{
			Team? team = _context.Teams.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

			if (team is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
				return RedirectToAction(nameof(Index));
			}

			TeamViewModel model = _mapper.Map<TeamViewModel>(team);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(TeamViewModel model)
		{
			int id = model.Id;

			if (!ModelState.IsValid)
				return View(model);

			var orginalTeam = _context.Teams.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

			if (orginalTeam is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
				return RedirectToAction(nameof(Index));
			}

			Team team = _mapper.Map<Team>(model);

			team.CreatedDate = orginalTeam.CreatedDate;
			team.UpdatedDate = DateTime.Now;

			_context.Teams.Update(team);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}



		[HttpGet]
		public IActionResult Remove(int id)
		{
			Team? team = _context.Teams.AsNoTracking().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

			if (team is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} kayıt bulunamadığı için kayıt silinemedi.";
				return RedirectToAction(nameof(Index));
			}

			team.IsDeleted = true;
			team.DeletedDate = DateTime.Now;

			_context.Teams.Update(team); // Bu id başka biri tarafından gözleniyor takip
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}
