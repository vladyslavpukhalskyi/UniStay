using Domain.Amenities;
using Optional;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IAmenitiesRepository
    {
        Task<Amenity> Add(Amenity amenity, CancellationToken cancellationToken);
        Task<Amenity> Update(Amenity amenity, CancellationToken cancellationToken);
        Task<Amenity> Delete(Amenity amenity, CancellationToken cancellationToken);
        Task<Option<Amenity>> GetById(AmenityId id, CancellationToken cancellationToken);
        Task<Option<Amenity>> GetByTitle(string title, CancellationToken cancellationToken);
    }
}