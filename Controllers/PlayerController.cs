using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Context;
using Sports.MVC.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Sports.MVC.Controllers
{
	public class PlayerController : Controller
	{
		private readonly SportsDbContext _context;
		private IMapper _mapper;

		public PlayerController(SportsDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			List<Player> players = _context.Players.Where(p => p.IsDeleted == false).Include(p=>p.Branch).ToList();
			List<PlayerViewModel> model = _mapper.Map<List<PlayerViewModel>>(players);
			return View(model);
			//.Include(b=>b.BranchTeam).ThenInclude(b=>b.Team).Include(b=>b.Players).Include(b=>b.Games)
		}

		[HttpGet]
		public IActionResult Add()
		{
			PlayerViewModel model = new PlayerViewModel();

			List<Branch> branches = _context.Branches.Where(p => p.IsDeleted == false && p.IsActive == true).ToList();

			List<BranchViewModel> branchList = _mapper.Map<List<BranchViewModel>>(branches);

			ViewBag.BranchList = branchList;

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(PlayerViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			Player player = _mapper.Map<Player>(model);
			
			_context.Players.Add(player);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			Player? player = _context.Players.Where(p => p.Id == id && p.IsDeleted == false).FirstOrDefault();

			if (player is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
				return RedirectToAction(nameof(Index));
			}

			PlayerViewModel model = _mapper.Map<PlayerViewModel>(player);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(PlayerViewModel model)
		{
			int id = model.Id;

			if (!ModelState.IsValid)
				return View(model);

			var orginalPlayer = _context.Players.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

			if (orginalPlayer is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
				return RedirectToAction(nameof(Index));
			}

			Player player = _mapper.Map<Player>(model);

			player.CreatedDate = orginalPlayer.CreatedDate;
			player.UpdatedDate = DateTime.Now;

			_context.Players.Update(player);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}



		[HttpGet]
		public IActionResult Remove(int id)
		{
			Player? player = _context.Players.AsNoTracking().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

			if (player is null)
			{
				TempData["RecordNotFounded"] = $"Id : {id} kayıt bulunamadığı için kayıt silinemedi.";
				return RedirectToAction(nameof(Index));
			}

			player.IsDeleted = true;
			player.DeletedDate = DateTime.Now;

			_context.Players.Update(player); // Bu id başka biri tarafından gözleniyor takip
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}

