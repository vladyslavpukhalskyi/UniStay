using Domain.Users;
using Domain.Amenities;
using System;
using System.Collections.Generic;
using Domain.Reviews;
using Domain.ListingImages;  // Import the ListingImages namespace

namespace Domain.Listings
{
    public class Listing
    {
        public ListingId Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }
        public float Price { get; private set; }
        public ListingEnums.ListingType Type { get; private set; }
        public UserId UserId { get; private set; }
        
        public User? User { get; }
        public List<ListingEnums.CommunalService> CommunalServices { get; private set; } = new();
        public ListingEnums.OwnershipType Owners { get; private set; }
        public ListingEnums.NeighbourType Neighbours { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public List<Amenity> Amenities { get; private set; } = new();
        public List<Review> Reviews { get; private set; } = new();
        
        // Add a collection of ListingImages to the Listing class
        public List<ListingImage> ListingImages { get; private set; } = new();

        private Listing(ListingId id, string title, string description, string address, float price, ListingEnums.ListingType type,
                        UserId userId, List<ListingEnums.CommunalService> communalServices, ListingEnums.OwnershipType owners, ListingEnums.NeighbourType neighbours,
                        DateTime publicationDate, List<Amenity> amenities, List<Review> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Address = address;
            Price = price;
            Type = type;
            UserId = userId;
            CommunalServices = communalServices;
            Owners = owners;
            Neighbours = neighbours;
            PublicationDate = publicationDate;
            Amenities = amenities;
            Reviews = reviews;
        }

        public static Listing New(ListingId id, string title, string description, string address, float price, ListingEnums.ListingType type,
                                  UserId userId, List<ListingEnums.CommunalService> communalServices, ListingEnums.OwnershipType owners, ListingEnums.NeighbourType neighbours,
                                  DateTime publicationDate, List<Amenity> amenities, List<Review> reviews)
            => new(id, title, description, address, price, type, userId, communalServices, owners, neighbours, publicationDate, amenities, reviews);

        public void UpdateDetails(string title, string description, string address, float price, ListingEnums.ListingType type,
                                  List<ListingEnums.CommunalService> communalServices, ListingEnums.OwnershipType owners, ListingEnums.NeighbourType neighbours)
        {
            Title = title;
            Description = description;
            Address = address;
            Price = price;
            Type = type;
            CommunalServices = communalServices;
            Owners = owners;
            Neighbours = neighbours;
        }

        public void AddAmenity(Amenity amenity)
        {
            if (!Amenities.Contains(amenity))
            {
                Amenities.Add(amenity);
            }
        }

        public void RemoveAmenity(Amenity amenity)
        {
            if (Amenities.Contains(amenity))
            {
                Amenities.Remove(amenity);
            }
        }

        // Method to add a review to the listing
        public void AddReview(Review review)
        {
            if (!Reviews.Contains(review))
            {
                Reviews.Add(review);
            }
        }

        // Method to remove a review from the listing
        public void RemoveReview(Review review)
        {
            if (Reviews.Contains(review))
            {
                Reviews.Remove(review);
            }
        }

        // Method to add an image to the listing
        public void AddListingImage(ListingImage listingImage)
        {
            if (!ListingImages.Contains(listingImage))
            {
                ListingImages.Add(listingImage);
            }
        }

        // Method to remove an image from the listing
        public void RemoveListingImage(ListingImage listingImage)
        {
            if (ListingImages.Contains(listingImage))
            {
                ListingImages.Remove(listingImage);
            }
        }
    }
}
