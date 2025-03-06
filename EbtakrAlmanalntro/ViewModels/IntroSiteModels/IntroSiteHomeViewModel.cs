using EbtakrAlmanalntro.Data.TableDb;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using System.Collections.Generic;

namespace EbtakrAlmanalntro.Models.IntroDLLModels
{
    public class IntroDLLHomeViewModel
    {
        public IntroDLLHomeViewModel()
        {
            Adventages = new List<AdventagesViewModel>();
            customerOpinions = new List<CustomerOpinionViewModel>();
            Slider = new List<string>();
        }
        public List<string> Slider { get; set; }
        public IntroSettingViewModel IntroSetting { get; set; }
        public List<AdventagesViewModel> Adventages { get; set; }
        public List<CustomerOpinionViewModel> customerOpinions { get; set; }
        public List<SocialMedia> SocailMedia { get; set; }
        public string conditions { get; set; }
        public string policy { get; set; }

        public List<OurClient> Partners { get; set; }
    }
}
