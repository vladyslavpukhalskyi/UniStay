using System.Collections.Generic;
using Domain.Listings;
using Domain.Users;

namespace Domain.Favorites
{
    public class Favorite
    {
        public FavoriteId Id { get; }
        public ListingId ListingId { get; }
        public Listing? Listing { get; }
        public List<User> Users { get; private set; } = new();
        
        private Favorite(FavoriteId id, ListingId listingId, Listing listing)
        {
            Id = id;
            ListingId = listingId;
            Listing = listing;
        }

        public static Favorite New(FavoriteId id, ListingId listingId, Listing listing)
            => new(id, listingId, listing);

        // Додавання користувача до улюбленого оголошення
        public void AddUser(User user)
        {
            if (!Users.Contains(user))
            {
                Users.Add(user);
            }
        }

        // Видалення користувача з улюбленого оголошення
        public void RemoveUser(User user)
        {
            if (Users.Contains(user))
            {
                Users.Remove(user);
            }
        }
    }
}