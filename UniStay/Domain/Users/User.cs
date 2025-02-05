using System;
using System.Collections.Generic;
using Domain.Favorites;
using Domain.Reviews;
using Domain.Messages;

namespace Domain.Users
{
    public class User
    {
        public UserId Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserEnums.UserRole Role { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ProfileImage { get; private set; }
        public DateTime RegistrationDate { get; }

        // Навігаційна властивість для зв'язку багато-до-багатьох
        public List<Favorite> Favorites { get; private set; } = new();

        // Навігаційна властивість для зв'язку один-до-багатьох (один користувач має багато відгуків)
        public List<Review> Reviews { get; private set; } = new();

        // Навігаційна властивість для зв'язку один-до-багатьох (один користувач може надсилати багато повідомлень)
        public List<Message> SentMessages { get; private set; } = new();

        // Навігаційна властивість для зв'язку один-до-багатьох (один користувач може отримувати багато повідомлень)
        public List<Message> ReceivedMessages { get; private set; } = new();

        public string FullName => $"{FirstName} {LastName}";

        private User(UserId id, string firstName, string lastName, string email, string password, UserEnums.UserRole role,
            string phoneNumber, string profileImage, DateTime registrationDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            PhoneNumber = phoneNumber;
            ProfileImage = profileImage;
            RegistrationDate = registrationDate;
        }

        public static User New(UserId id, string firstName, string lastName, string email, string password,
            UserEnums.UserRole role, string phoneNumber, string profileImage)
            => new(id, firstName, lastName, email, password, role, phoneNumber, profileImage, DateTime.UtcNow);

        public void UpdateDetails(string firstName, string lastName, string phoneNumber, string profileImage)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            ProfileImage = profileImage;
        }

        // Додавання улюбленого оголошення
        public void AddFavorite(Favorite favorite)
        {
            if (!Favorites.Contains(favorite))
            {
                Favorites.Add(favorite);
            }
        }

        // Видалення улюбленого оголошення
        public void RemoveFavorite(Favorite favorite)
        {
            if (Favorites.Contains(favorite))
            {
                Favorites.Remove(favorite);
            }
        }

        // Додавання відгуку
        public void AddReview(Review review)
        {
            if (!Reviews.Contains(review))
            {
                Reviews.Add(review);
            }
        }

        // Видалення відгуку
        public void RemoveReview(Review review)
        {
            if (Reviews.Contains(review))
            {
                Reviews.Remove(review);
            }
        }

        // Додавання повідомлення, яке користувач надіслав
        public void AddSentMessage(Message message)
        {
            if (!SentMessages.Contains(message))
            {
                SentMessages.Add(message);
            }
        }

        // Додавання повідомлення, яке користувач отримав
        public void AddReceivedMessage(Message message)
        {
            if (!ReceivedMessages.Contains(message))
            {
                ReceivedMessages.Add(message);
            }
        }

        // Видалення повідомлення, яке користувач надіслав
        public void RemoveSentMessage(Message message)
        {
            if (SentMessages.Contains(message))
            {
                SentMessages.Remove(message);
            }
        }

        // Видалення повідомлення, яке користувач отримав
        public void RemoveReceivedMessage(Message message)
        {
            if (ReceivedMessages.Contains(message))
            {
                ReceivedMessages.Remove(message);
            }
        }
    }
}
