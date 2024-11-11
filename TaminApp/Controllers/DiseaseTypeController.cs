using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaminApp.Core;
using TaminApp.Entity;
using TaminApp.ViewModels.Degree;
using TaminApp.ViewModels.DiseaseType;

namespace TaminApp.Controllers
{
    public class DiseaseTypeController : Controller
    {
        #region Initialize
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiseaseTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion 
        #region Index
        public async Task<IActionResult> Index()
        {
            var disease = await _unitOfWork.Repository<DiseaseType >()
                .GetAllAsync(w => !w.IsDelete);

            var viewModel = _mapper.Map<List<DiseaseTypeListViewModel >>(disease );
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
        public async Task<IActionResult> Create(DiseaseTypeCreateViewModel  model)
        {
            if (ModelState.IsValid)
            {
                var existdisease = await _unitOfWork.Repository<DiseaseType>()
                    .GetAllAsync(w => w.DiseaseName == model.DiseaseName && !w.IsDelete);

                if (existdisease.Any())
                {
                    ModelState.AddModelError("DegreeName", "این نام از قبل وجود دارد.");
                    return View(model);
                }

                var _disease = _mapper.Map<DiseaseType >(model);
                _disease.RegisterDate = DateTime.Now;
               _disease.IsActive = true;

                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    await _unitOfWork.Repository<DiseaseType>().AddAsync(_disease);
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
            var disease = await _unitOfWork.Repository<DiseaseType >().GetByIdAsync(id);
            if (disease == null || disease.IsDelete)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<DiseaseTypeEditViewModel>(disease );
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DiseaseTypeEditViewModel  model)
        {
            if (id != model.ID || !ModelState.IsValid)
            {
                return View(model);
            }

            var disease = await _unitOfWork.Repository<DiseaseType >().GetByIdAsync(id);
            if (disease  == null || disease.IsDelete)
            {
                return NotFound();
            }

            var exsitdisease = await _unitOfWork.Repository<DiseaseType >()
                .GetAllAsync(w => w.DiseaseName  == model.DiseaseName  && w.ID != id && !w.IsDelete);

            if (exsitdisease.Any())
            {
                ModelState.AddModelError("DiseaseName", "این نام از قبل وجود دارد.");
                return View(model);
            }

            var _disease = _mapper.Map(model, disease );
            _disease .UpdatedDate = DateTime.Now;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<DiseaseType >().Update(_disease );
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
            var disease = await _unitOfWork.Repository<DiseaseType >().GetByIdAsync(id);
            if (disease  == null || disease.IsDelete)
            {
                return NotFound();
            }

           disease.IsDelete = true;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.Repository<DiseaseType>().Update(disease);
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
