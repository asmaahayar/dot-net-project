using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/cosmetics/")]
    public class CosmeticController : ControllerBase
    {
            private CosmeticRepository _cosmeticRepository;
            private ResponseDto _response;


            public CosmeticController(CosmeticRepository specialistRepository)
            {
                _cosmeticRepository = specialistRepository;
                _response = new ResponseDto();
            }
            [HttpGet]
            [Route("list")]
            public async Task<ResponseDto> GetSpecialistsList()
            {
                IEnumerable<CosmeticDto> res = await _cosmeticRepository.GetCosmetics();
                _response.success = true;
                _response.result = res;
                return _response;
            }

            [HttpGet]
            [Route("list/brand/{brand}")]
            public async Task<object> GetByBrand([FromRoute] string brand)
            {
                IEnumerable<CosmeticDto> res = await _cosmeticRepository.SearchCosmeticsByBrand(brand);
                return res;
            }

        [HttpGet]
        [Route("list/name/{name}")]
        public async Task<object> GetByName([FromRoute] string name)
        {
            IEnumerable<CosmeticDto> res = await _cosmeticRepository.SearchCosmeticsByName(name);
            return res;
        }

        [HttpPost]
            [Route("create")]
            public async Task<ResponseDto> Add(CosmeticDto requestDto)
            {

                CosmeticDto res = await _cosmeticRepository.CreateCosmetic(requestDto);
                _response.result = res;
                _response.success = true;
                return _response;


            }

            [HttpGet]
            [Route("{id}")]
            public async Task<ResponseDto> getSpecialistById([FromRoute] string id)
            {

                CosmeticDto res = await _cosmeticRepository.GetCosmeticById(id);
                _response.success = true;
                _response.result = res;
                return _response;

            }

            [HttpDelete]
            [Route("{id}")]
            public async Task<ResponseDto> deleteById([FromRoute] string id)
            {

                return await _cosmeticRepository.DeleteCosmetic(id); ;

            }

            [HttpPut]
            [Route("{id}")]
            public async Task<ResponseDto> update(CosmeticDto requestDto, [FromRoute] string id)
            {

                CosmeticDto res = await _cosmeticRepository.UpdateCosmetic(requestDto, id);
                if (res == null)
                {
                    _response.result = null;
                    _response.success = false;
                    _response.DisplayMessage = "recorrd Not Found";
                }
                else
                {
                    _response.result = res;
                    _response.success = true;
                }

                return _response;

            }


        }
}
