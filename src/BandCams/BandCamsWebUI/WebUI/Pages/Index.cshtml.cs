using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebUI.Library.Endpoints;
using WebUI.Library.Helpers;
using WebUI.Models;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IYouTubeHelper _youTubeHelper;
        public List<Stream> Streams { get; private set; }
        public List<OnlineEvent> OnlineEvents { get; private set; }

        public IndexModel(IHttpHelper httpHelper, IYouTubeHelper youTubeHelper)
        {
            _httpHelper = httpHelper;
            _youTubeHelper = youTubeHelper;
        }

        public async Task OnGet()
        {
            var today = DateTime.Now;

            Streams = await _httpHelper.GetAsync<List<Stream>>(BandCamsEndpoints.GetStream(true));
            OnlineEvents = await _httpHelper.GetAsync<List<OnlineEvent>> (BandCamsEndpoints.GetOnlineEvent(today, today.AddDays(7)));
        }

        public async Task<PartialViewResult> OnGetShowModal(int streamId)
        {
            var stream = await _httpHelper.GetAsync<Stream>(BandCamsEndpoints.GetStream(streamId));

            return new PartialViewResult
            {
                ViewName = "_StreamVideoPartial",
                ViewData = new ViewDataDictionary<Stream>(ViewData, stream)
            };
        }

        public string GetVideoImageLink(string link)
        {
            return link.Contains("youtube") ? _youTubeHelper.GetThumbnailLink(link) : "img/fb_stream_img.jpg";
        }
    }
}
