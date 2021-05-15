using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        public ShopController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
