using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class CampaignDto : BaseDto
    {
        public int Id { get; set; }

        [Display(Name = "Kampanya Adı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Name { get; set; }

        [Display(Name = "Kampanya Resmi")]
        public string ImagePath { get; set; }

        [Display(Name = "Kampanya Resim Etiket Adı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string ImageAltTag { get; set; }

        [Display(Name = "Ana Sayfada Görünsün mü ?")]
        public bool IsHome { get; set; }
    }
}
