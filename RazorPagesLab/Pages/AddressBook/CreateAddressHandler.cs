using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook
{
    public class CreateAddressHandler
        : IRequestHandler<CreateAddressRequest, Guid>
    {
        public async Task<Guid> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
        {
            var entry = AddressBookEntry.Create(request.Line1, request.Line2, request.City, request.State,
                request.PostalCode);
            AddressDb.Addresses.Add(entry);
            return await Task.FromResult(entry.Id);
        }
    }
}