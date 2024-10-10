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
		// use the unique id to get the entry in the repo
		var result = _repo.Find(new EntryByIdSpecification(request.Id));
		// assign the first entry in the list to variable entry, assuming there are no duplicate ids
		var entry = result[0];
		// remove the entry from the repo
		_repo.Remove(entry);
		// completed task
		await Task.FromResult(entry.Id);
	}
}