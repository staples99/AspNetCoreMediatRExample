using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class UpdateAddressHandler
	: IRequestHandler<UpdateAddressRequest>
{
	private readonly IRepo<AddressBookEntry> _repo;

	public UpdateAddressHandler(IRepo<AddressBookEntry> repo)
	{
		_repo = repo;
	}

	public async Task Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
	{	var result = _repo.Find(new EntryByIdSpecification(request.Id));
		var entry = result[0];
		entry.Update(request.Line1, request.Line2, request.City, request.State, 
			request.PostalCode);
		_repo.Update(entry);
		await Task.FromResult(entry.Id);
	}
}