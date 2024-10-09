using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class RemoveAddressHandler
	: IRequestHandler<RemoveAddressRequest>
{
	private readonly IRepo<AddressBookEntry> _repo;

	public RemoveAddressHandler(IRepo<AddressBookEntry> repo)
	{
		_repo = repo;
	}

	public async Task Handle(RemoveAddressRequest request, CancellationToken cancellationToken)
	{
		var result = _repo.Find(new EntryByIdSpecification(request.Id));
		var entry = result[0];
		_repo.Remove(entry);
		await Task.FromResult(entry.Id);
	}
}