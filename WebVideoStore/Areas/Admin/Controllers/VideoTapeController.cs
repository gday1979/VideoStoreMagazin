namespace WebVideoStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;
    using WebVideoStore.Models.Models;

    [Area("Admin")]
    public class VideoTapeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VideoTapeController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
           List<VideoTape> objVideoTapeList = _unitOfWork.VideoTape.GetAll().ToList();
            return View(objVideoTapeList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VideoTape obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VideoTape.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "VideoTape created successfully";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
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
            return View(videoTapeFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VideoTape obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VideoTape.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "VideoTape updated successfully";
            }
            return RedirectToAction("Index");
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
