using System;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class RemoveModel : PageModel
{
	private readonly IMediator _mediator;
	private readonly IRepo<AddressBookEntry> _repo;

	public RemoveModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	[BindProperty (SupportsGet = true)]
	public RemoveAddressRequest RemoveAddressRequest { get; set; }

	public void OnGet(Guid id)
	{
		// Use repo to get address book entry, set RemoveAddressRequest fields.
		var result = _repo.Find(new EntryByIdSpecification(id));
		if (result[0] != null) {
		RemoveAddressRequest.Line1 = result[0].Line1;
		RemoveAddressRequest.Line2 = result[0].Line2;
		RemoveAddressRequest.City = result[0].City;
		RemoveAddressRequest.State = result[0].State;
		RemoveAddressRequest.PostalCode = result[0].PostalCode;
		}
	}

	public ActionResult OnPost()
	{
		// Use mediator to send a "command" to update the address book entry, redirect to entry list.
		if (ModelState.IsValid)
		{
			_ = _mediator.Send(RemoveAddressRequest);
			return RedirectToPage("Index");
		}
		return Page();
	}
}