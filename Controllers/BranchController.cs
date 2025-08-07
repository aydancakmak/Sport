using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.MVC.Context;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.Controllers
{
    public class BranchController : Controller
    {
        private readonly SportsDbContext _context;
        private IMapper _mapper;

        public BranchController(SportsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Branch> branches = _context.Branches
                .Include(b => b.BranchTeam)
                    .ThenInclude(b => b.Team) 
                .Where(b=>b.IsDeleted == false).ToList();

            List<BranchViewModel> model = _mapper.Map<List<BranchViewModel>>(branches);
            return View(model);
		}

		[HttpGet]
        public IActionResult Add()
        {
            BranchViewModel model = new BranchViewModel();

            List<Branch> branches = _context.Branches.Where(b => b.IsDeleted == false ).ToList();

            List<BranchViewModel> branchList = _mapper.Map<List<BranchViewModel>>(branches);

            ViewBag.BranchList = branchList;

            return View(model);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(BranchViewModel model)
		{
            if (!ModelState.IsValid)
                return View(model);

            Branch branch = _mapper.Map<Branch>(model);

			_context.Branches.Add(branch);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

        public IActionResult Edit(int id)
        {
            Branch? branch = _context.Branches.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (branch is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            BranchViewModel model = _mapper.Map<BranchViewModel>(branch);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BranchViewModel model)
        {
            int id = model.Id;

            if (!ModelState.IsValid)
                return View(model);

            var orginalBranch = _context.Branches.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (orginalBranch is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            Branch branch = _mapper.Map<Branch>(model);

            branch.CreatedDate = orginalBranch.CreatedDate;
            branch.UpdatedDate = DateTime.Now;

            _context.Branches.Update(branch);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Remove(int id)
        {
            Branch? branch = _context.Branches.AsNoTracking().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (branch is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} kayıt bulunamadığı için kayıt silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            branch.IsDeleted = true;
            branch.DeletedDate = DateTime.Now;

            _context.Branches.Update(branch); // Bu id başka biri tarafından gözleniyor takip
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
