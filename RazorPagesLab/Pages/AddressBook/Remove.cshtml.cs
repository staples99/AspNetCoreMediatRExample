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
		// use the unique id to get the address book entry from repo
		var result = _repo.Find(new EntryByIdSpecification(id));
		// if an entry is found, set RemoveAddressRequest fields
		if (result[0] == null)
		{
			NotFound();
		} else 
		{
			RemoveAddressRequest.Line1 = result[0].Line1;
			RemoveAddressRequest.Line2 = result[0].Line2;
			RemoveAddressRequest.City = result[0].City;
			RemoveAddressRequest.State = result[0].State;
			RemoveAddressRequest.PostalCode = result[0].PostalCode;
		}
	}

	public ActionResult OnPost()
	{
		// Use mediator to send a "command" to remove the address book entry, redirect to entry list.
		if (ModelState.IsValid)
		{
			_ = _mediator.Send(RemoveAddressRequest);
			return RedirectToPage("Index");
		}
		return Page();
	}
}