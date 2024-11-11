using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaminApp.Core;
using TaminApp.Entity;
using TaminApp.ViewModels.Bank;
using TaminApp.ViewModels.people;

namespace TaminApp.Controllers
{
    public class PeopleController : Controller
    {
        #region Initialize
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion 
        #region Index
        public async Task<IActionResult> Index()
        {
            var peopel = await _unitOfWork.Repository<people>()
                .GetAllAsync(w => !w.IsDelete);

            var viewModel = _mapper.Map<List<PeopleListViewModel>>(peopel);
            return View(viewModel);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PeopleCreateViewModel  model)
        {
            if (ModelState.IsValid)
            {
                var existpeople = await _unitOfWork.Repository<people >()
                    .GetAllAsync(w => w.NationalCode  == model.NationalCode  && !w.IsDelete);

                if (existpeople.Any())
                {
                    ModelState.AddModelError("NationalCode", "این کدملی از قبل وجود دارد.");
                    return View(model);
                }

                var _people = _mapper.Map<people>(model);
                _people.RegisterDate = DateTime.Now;
                _people.IsActive = true;

                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    await _unitOfWork.Repository<people >().AddAsync(_people);
                    await _unitOfWork.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "خطایی در ذخیره‌سازی داده‌ها رخ داد.");
                    return View(model);
                }
            }
            return View(model);
        }
        #endregion
        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            var bank = await _unitOfWork.Repository<Bank>().GetByIdAsync(id);
            if (bank == null || bank.IsDelete)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<BankEditViewModel>(bank);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BankEditViewModel model)
        {
            if (id != model.ID || !ModelState.IsValid)
            {
                return View(model);
            }

            var bank = await _unitOfWork.Repository<Bank>().GetByIdAsync(id);
            if (bank == null || bank.IsDelete)
            {
                return NotFound();
            }

            var exsitBank = await _unitOfWork.Repository<Bank>()
                .GetAllAsync(w => w.BankName == model.BankName && w.ID != id && !w.IsDelete);

            if (exsitBank.Any())
            {
                ModelState.AddModelError("BankName", "این نام از قبل وجود دارد.");
                return View(model);
            }

            var _bank = _mapper.Map(model, bank);
            _bank.UpdatedDate = DateTime.Now;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<Bank>().Update(_bank);
                await _unitOfWork.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در بروزرسانی داده‌ها رخ داد.");
                return View(model);
            }
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var bank = await _unitOfWork.Repository<Bank>().GetByIdAsync(id);
            if (bank == null || bank.IsDelete)
            {
                return NotFound();
            }

            bank.IsDelete = true;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<Bank>().Update(bank);
                await _unitOfWork.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در حذف داده‌ها رخ داد.");
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion
    }
}
