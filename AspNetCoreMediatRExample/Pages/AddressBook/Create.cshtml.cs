using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator) => _mediator = mediator;

        [BindProperty] public CreateAddressRequest CreateAddressRequest { get; set; }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _ = await _mediator.Send(CreateAddressRequest);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}