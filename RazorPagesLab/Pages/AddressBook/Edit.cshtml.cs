using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook
{
    public class EditModel : PageModel
	{
		[BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public void OnGet(Guid id)
        {
            // Todo: Get address book entry, set UpdateAddressRequest fields.
		}

        public void OnPost()
        {
			// Todo: "Persist" updated address book entry
        }
    }
}