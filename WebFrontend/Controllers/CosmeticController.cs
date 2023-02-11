using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebFrontend.Models;
using WebFrontend.services;

namespace WebFrontend.Controllers
{
    public class CosmeticController : Controller
    {
        private readonly ICosmetic _cosmeticService;

        public CosmeticController(ICosmetic cosmeticService)
        {
            _cosmeticService = cosmeticService;
        }

        public async Task<IActionResult> Products()
        {
            //ViewBag.title = "Asmae";

            List<CosmeticDto> list = new List<CosmeticDto>();
            var res = await _cosmeticService.GetAllCosmeticsAsync<ResponseDto>();
            if (res != null)
            {
                list = JsonConvert.DeserializeObject<List<CosmeticDto>>(Convert.ToString(res.result));
            }

            return View(list);
        }
        
        public async Task<IActionResult> AddProduct()
        {
            //ViewBag.Error = new List<string>();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(CosmeticDto model)
        {

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //ViewBag.Error = errors;
            Guid uuid = new Guid();
            model.id = uuid.ToString();

            if (ModelState.IsValid)
            {
                var res = await _cosmeticService.CreateCosmetic<ResponseDto>(model);
                if (res != null & res.success)
                {
                    return RedirectToAction(nameof(Products));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDetails(string id)
        {
            CosmeticDto product = new CosmeticDto();
            var res = await _cosmeticService.GetCosmeticById<ResponseDto>(id);
            if (res != null)
            {
                product = JsonConvert.DeserializeObject<CosmeticDto>(Convert.ToString(res.result));
            }

            return View(product);
        }
    }
}
