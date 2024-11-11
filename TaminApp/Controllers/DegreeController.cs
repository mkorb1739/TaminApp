using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaminApp.Core;
using TaminApp.Entity;
using TaminApp.ViewModels.Bank;
using TaminApp.ViewModels.Degree;

namespace TaminApp.Controllers
{
    public class DegreeController : Controller
    {
        #region Initialize
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DegreeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion 
        #region Index
        public async Task<IActionResult> Index()
        {
            var degree = await _unitOfWork.Repository<Degree >()
                .GetAllAsync(w => !w.IsDelete);

            var viewModel = _mapper.Map<List<DegreeListViewModel >>(degree );
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
        public async Task<IActionResult> Create(DegreeCreateViewModel  model)
        {
            if (ModelState.IsValid)
            {
                var existDegree = await _unitOfWork.Repository<Degree >()
                    .GetAllAsync(w => w.DegreeName == model.DegreeName  && !w.IsDelete);

                if (existDegree.Any())
                {
                    ModelState.AddModelError("DegreeName", "این نام از قبل وجود دارد.");
                    return View(model);
                }

                var _degree = _mapper.Map<Degree >(model);
                _degree.RegisterDate = DateTime.Now;
                _degree.IsActive = true;

                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    await _unitOfWork.Repository<Degree>().AddAsync(_degree );
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
            var degree = await _unitOfWork.Repository<Degree>().GetByIdAsync(id);
            if (degree  == null || degree .IsDelete)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<DegreeEditViewModel >(degree );
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DegreeEditViewModel  model)
        {
            if (id != model.ID || !ModelState.IsValid)
            {
                return View(model);
            }

            var degree = await _unitOfWork.Repository<Degree >().GetByIdAsync(id);
            if (degree  == null || degree.IsDelete)
            {
                return NotFound();
            }

            var exsitDegree = await _unitOfWork.Repository<Degree>()
                .GetAllAsync(w => w.DegreeName  == model.DegreeName  && w.ID != id && !w.IsDelete);

            if (exsitDegree.Any())
            {
                ModelState.AddModelError("DegreeName", "این نام از قبل وجود دارد.");
                return View(model);
            }

            var _degree = _mapper.Map(model,degree  );
            _degree.UpdatedDate = DateTime.Now;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<Degree>().Update(_degree);
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
            var degree = await _unitOfWork.Repository<Degree>().GetByIdAsync(id);
            if (degree  == null || degree.IsDelete)
            {
                return NotFound();
            }

           degree.IsDelete = true;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<Degree>().Update(degree);
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
