namespace WebVideoStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;
    using WebVideoStoreUtility;

    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class VideoTapeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VideoTapeController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment  )
        {

            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
           List<VideoTape> objVideoTapeList = _unitOfWork.VideoTape.GetAll(includeProperties:"Category").ToList();
           
            return View(objVideoTapeList);
        }
        public IActionResult Upsert(int? id)
        {
            VideoTapeViewModels videoTapeViewModels = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                VideoTape = new VideoTape()
            };
            if (id == null || id == 0)
            {
                //create
                return View(videoTapeViewModels);
            }
            else
            {
                //update
                videoTapeViewModels.VideoTape = _unitOfWork.VideoTape.Get(u => u.Id == id);
                return View(videoTapeViewModels);
            }
        }
            
        [HttpPost]
        public IActionResult Upsert(VideoTapeViewModels videoTapeViewModels,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                if(file !=null)
                {
                    string fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(webRootPath, @"images\videotape");
                    if (!string.IsNullOrEmpty(videoTapeViewModels.VideoTape.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(webRootPath, videoTapeViewModels.VideoTape.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    videoTapeViewModels.VideoTape.ImageUrl = @"\images\videotape\" + fileName;
                }
                if (videoTapeViewModels.VideoTape.Id == 0)
                {
                    _unitOfWork.VideoTape.Add(videoTapeViewModels.VideoTape);

                }
                else
                {
                    _unitOfWork.VideoTape.Update(videoTapeViewModels.VideoTape);
                }
                _unitOfWork.Save();
                TempData["success"] = "VideoTape created successfully";
            return RedirectToAction("Index");
            }
            else
            {

                videoTapeViewModels.CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                
            return View(videoTapeViewModels);
            }
        }
        
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            VideoTape? obj = _unitOfWork.VideoTape.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.VideoTape.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "VideoTape deleted successfully";
            return RedirectToAction("Index");

        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<VideoTape> objVideoTapeList = _unitOfWork.VideoTape.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objVideoTapeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var videotapeToBeDeleted = _unitOfWork.VideoTape.Get(u => u.Id == id);
            if(videotapeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath =
                Path.Combine(_webHostEnvironment.WebRootPath,
                videotapeToBeDeleted.ImageUrl .TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.VideoTape.Remove(videotapeToBeDeleted);
            _unitOfWork.Save();
            List<VideoTape> objVideoTapeList = _unitOfWork.VideoTape.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objVideoTapeList });
        }
        #endregion
    }
}
