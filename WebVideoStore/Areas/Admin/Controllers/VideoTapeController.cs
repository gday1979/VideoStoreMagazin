namespace WebVideoStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;

    [Area("Admin")]
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
           List<VideoTape> objVideoTapeList = _unitOfWork.VideoTape.GetAll().ToList();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
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
                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    videoTapeViewModels.VideoTape.ImageUrl = @"\images\videotape\" + fileName;
                }
                _unitOfWork.VideoTape.Add(videoTapeViewModels.VideoTape);
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
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            VideoTape videoTapeFromDb = _unitOfWork.VideoTape.Get(u => u.Id == id);
            if (videoTapeFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.VideoTape.Remove(videoTapeFromDb);
            _unitOfWork.Save();
            TempData["success"] = "VideoTape deleted successfully";
            return RedirectToAction("Index");
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
    }
}
