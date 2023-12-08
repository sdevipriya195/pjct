using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    public class RentalCRUDTesting
    {
        RentalRepository rentalRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestRental") // In-memory database for testing
                                .Options;

            MovieContext context = new MovieContext(dbOptions);
            rentalRepository = new RentalRepository(context);
        }

        [Test]
        public void AddRentalTest()
        {
            // Arrange
            Rental rentalToAdd = new Rental
            {
                RentalDate = "2023-12-08",
                RentalCost = 10.99f,
                MovieId = 1
                // Add other necessary properties
            };

            // Act
            string result = rentalRepository.AddRental(rentalToAdd);

            // Assert
            Assert.AreEqual("Rental inserted successfully", result);
        }

        [Test]
        public void UpdateRentalTest()
        {
            // Arrange
            Rental rentalToUpdate = new Rental
            {
                RentalId = 1,
                RentalCost = 15.99f
                // Update other necessary properties
            };

            // Act
            string result = rentalRepository.UpdateRental(rentalToUpdate);

            // Assert
            Assert.AreEqual("Rental details updated successfully", result);
        }

        [Test]
        public void DeleteRentalTest()
        {
            // Arrange
            int rentalIdToDelete = 1;

            // Act
            string result = rentalRepository.DeleteRental(rentalIdToDelete);

            // Assert
            Assert.AreEqual("Rental removed from database", result);
        }

        [Test]
        public void GetRentalByIdTest()
        {
            // Arrange
            int rentalIdToGet = 1;

            // Act
            Rental result = rentalRepository.GetRentalById(rentalIdToGet);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(rentalIdToGet, result.RentalId);
        }
    }
}
