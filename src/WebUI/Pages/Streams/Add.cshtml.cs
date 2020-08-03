using System.Threading.Tasks;
using ApiHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Library.Endpoints;
using WebUI.Library.Helpers;
using WebUI.Models;

namespace WebUI.Pages.Streams
{
    public class AddModel : PageModel
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IYouTubeHelper _youTubeHelper;
        private readonly IFacebookHelper _facebookHelper;
        [BindProperty]
        public Stream Stream { get; set; }

        public AddModel(IHttpHelper httpHelper, IYouTubeHelper youTubeHelper, IFacebookHelper facebookHelper)
        {
            _httpHelper = httpHelper;
            _youTubeHelper = youTubeHelper;
            _facebookHelper = facebookHelper;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Stream.IsActive = true;
                Stream.Link = Stream.Link.Contains("facebook") ? _facebookHelper.GetEmbedVideoLink(Stream.Link) : _youTubeHelper.GetEmbedVideoLink(Stream.Link);
                await _httpHelper.PostAsJsonAsync<CreatedRow, Stream>(BandCamsEndpoints.Stream, Stream);

                return Redirect("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}