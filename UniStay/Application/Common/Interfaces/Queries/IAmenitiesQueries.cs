using Domain.Amenities;
using Optional;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Queries
{
    public interface IAmenitiesQueries
    {
        Task<IReadOnlyList<Amenity>> GetAll(CancellationToken cancellationToken);

        Task<Option<Amenity>> GetById(AmenityId id, CancellationToken cancellationToken);

        Task<Option<Amenity>> GetByTitle(string title, CancellationToken cancellationToken);
    }
}