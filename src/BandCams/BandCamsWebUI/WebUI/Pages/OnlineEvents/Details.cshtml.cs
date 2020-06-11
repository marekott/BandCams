using System;
using System.Threading.Tasks;
using ApiHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Library.Endpoints;
using WebUI.Models;

namespace WebUI.Pages.OnlineEvents
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpHelper _httpHelper;
        public OnlineEvent OnlineEvent { get; private set; }

        public DetailsModel(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                OnlineEvent = await _httpHelper.GetAsync<OnlineEvent>(BandCamsEndpoints.GetOnlineEvent(id));
                return Page();
            }
            catch (Exception)//TODO porządna obsługa - słabe rozwiązanie bo każdy wyjątek kalsyfikujemy jakby api zwróciło 404
            {
                return NotFound();
            }
        }
    }
}