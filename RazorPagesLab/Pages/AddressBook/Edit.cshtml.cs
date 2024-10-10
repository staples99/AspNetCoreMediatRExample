using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class EditModel : PageModel
{
	private readonly IMediator _mediator;
	private readonly IRepo<AddressBookEntry> _repo;

	public EditModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	[BindProperty (SupportsGet = true)]
	public UpdateAddressRequest UpdateAddressRequest { get; set; }

	public void OnGet(Guid id)
	{
		// use the unique id to get the address book entry in the repo
		var result = _repo.Find(new EntryByIdSpecification(id));
		// if an entry is found, set UpdateAddressRequest fields
		if (result[0] == null) 
		{
			NotFound();
		} else
		{ 
			UpdateAddressRequest.Line1 = result[0].Line1;
			UpdateAddressRequest.Line2 = result[0].Line2;
			UpdateAddressRequest.City = result[0].City;
			UpdateAddressRequest.State = result[0].State;
			UpdateAddressRequest.PostalCode = result[0].PostalCode;
		}
	}

	public ActionResult OnPost()
	{
		// Use mediator to send a "command" to update the address book entry, redirect to entry list.
		if (ModelState.IsValid)
		{
			_ = _mediator.Send(UpdateAddressRequest);
			return RedirectToPage("Index");
		}
		return Page();
	}
}