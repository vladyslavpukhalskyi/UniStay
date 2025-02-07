using Domain.ListingImages;
using Optional;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Listings;

namespace Application.Common.Interfaces.Queries
{
    public interface IListingImagesQueries
    {
        Task<IReadOnlyList<ListingImage>> GetAll(CancellationToken cancellationToken);

        Task<Option<ListingImage>> GetById(ListingImageId id, CancellationToken cancellationToken);

        Task<IReadOnlyList<ListingImage>> GetByListingId(ListingId listingId, CancellationToken cancellationToken);
    }
}