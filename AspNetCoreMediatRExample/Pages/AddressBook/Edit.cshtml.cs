using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        [BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public void OnGet(string id)
        {
            // Todo: Get address book entry, set UpdateAddressRequest fields
        }

        public void OnPost()
        {
            // Todo: "Persist" updated address book entry
        }
    }
}