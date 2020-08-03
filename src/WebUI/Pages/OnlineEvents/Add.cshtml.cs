using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Library.Endpoints;
using WebUI.Library.Helpers;
using WebUI.Library.Validators.Files;
using WebUI.Models;

namespace WebUI.Pages.OnlineEvents
{
    public class AddModel : PageModel
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IFileHelper _fileHelper;
        private readonly IFileValidator _fileValidator;

        [BindProperty]
        public OnlineEvent OnlineEvent { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Pole Grafika jest wymagane.")]
        [Display(Name = "Grafika")]
        public IFormFile OnlineEventImage { get; set; }

        public AddModel(IHttpHelper httpHelper, IFileHelper fileHelper, IFileValidator fileValidator)
        {
            _httpHelper = httpHelper;
            _fileHelper = fileHelper;
            _fileValidator = fileValidator;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var byteFile = await _fileHelper.ConvertToByteArrayAsync(OnlineEventImage);

                if (_fileValidator.ValidateSize(OnlineEventImage.Length) &&
                    _fileValidator.ValidateExtension(OnlineEventImage.FileName) &&
                    _fileValidator.ValidateSignature(OnlineEventImage.FileName, byteFile))
                {
                    OnlineEvent.ImageContent = byteFile;
                    await _httpHelper.PostAsJsonAsync<CreatedRow, OnlineEvent>(BandCamsEndpoints.OnlineEvent, OnlineEvent);

                    return Redirect("/Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(OnlineEventImage), $"Plik nie może być większy niż {_fileValidator.GetMaxFileSizeInMb}. Dopuszczalne rozszerzenia to {_fileValidator.GetPermittedExtensions}");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}