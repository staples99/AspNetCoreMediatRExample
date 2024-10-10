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
	{	// use the unique id to get the entry in the repo
		var result = _repo.Find(new EntryByIdSpecification(request.Id));
		// assign the first entry in the list to variable entry, assuming there are no duplicate ids
		var entry = result[0];
		// update the entry
		entry.Update(request.Line1, request.Line2, request.City, request.State, 
			request.PostalCode);
		// update the repo
		_repo.Update(entry);
		// completed task
		await Task.FromResult(entry.Id);
	}
}