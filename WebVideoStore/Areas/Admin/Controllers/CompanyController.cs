namespace WebVideoStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;
    using WebVideoStoreUtility;

    [Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
           List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            if (id == null)
            {
                //this for create
                return View(new Company());
            }
            else
            {
                Company companyObj= _unitOfWork.Company.Get(u=>u.Id==id);
                return View(companyObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
               
                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);

                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {

                

                return View(CompanyObj);
            }
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            
            return Json(new { success=true,message= "Delete Succeful" });
        }
        #endregion
    }
}

