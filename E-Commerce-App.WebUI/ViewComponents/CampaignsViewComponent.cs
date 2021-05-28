using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Commerce_App.WebUI.ViewComponents
{
    //public class BestSellingProducts : ViewComponent
    //{
    //    // take falan filan yap 10 tane gelsin
    //    // resim pixellerini falan em yapmayi unutma
    //}
    //public class RecomemendedProducts : ViewComponent
    //{

    //}
    public class CampaignsViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IService<Campaign> _campaignService;
        public CampaignsViewComponent(IService<Campaign> campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var campaigns = _mapper.Map<IEnumerable<CampaignDto>>(_campaignService.Where(c => c.IsHome == true).Result);
            return View(campaigns);
        }
    }
}
