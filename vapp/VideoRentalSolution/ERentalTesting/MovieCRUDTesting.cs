using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    public class MovieCRUDTesting
    {
        IMovieRepository repository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestMovie") // In-memory database for testing
                                .Options;
            MovieContext context = new MovieContext(dbOptions);
            repository = new MovieRepository(context);
        }

        [Test]
        public void AddMovieTest()
        {
            // Arrange
            Movie movieToAdd = new Movie
            {
                GenreName = "Action",
                MovieName = "Test Movie",
                DiscNumber = 1,
                Image = "test_image.jpg",
                MovieDescription = "This is a test movie",
                MovieDuration = 120,
                MovieRating = 4.5,
                MovieRentalCost = 5
            };

            // Act
            string result = repository.AddMovie(movieToAdd);

            // Assert
            Assert.AreEqual("Movie inserted successfully", result);
        }

        [Test]
        public void GetMovieByIdTest()
        {
            // Arrange
            Movie movieToAdd = new Movie
            {
                GenreName = "Drama",
                MovieName = "Test Drama Movie",
                DiscNumber = 2,
                Image = "drama_image.jpg",
                MovieDescription = "This is a test drama movie",
                MovieDuration = 150,
                MovieRating = 4.0,
                MovieRentalCost = 6
            };

            // Add the movie to the repository
            string addResult = repository.AddMovie(movieToAdd);
            Assert.AreEqual("Movie inserted successfully", addResult);

            // Act
            Movie retrievedMovie = repository.GetMovieById(1);

            // Assert
            Assert.IsNotNull(retrievedMovie);
            Assert.AreEqual("Test Drama Movie", retrievedMovie.MovieName);
        }

        [Test]
        public void UpdateMovieTest()
        {
            // Arrange
            Movie movieToAdd = new Movie
            {
                GenreName = "Comedy",
                MovieName = "Test Comedy Movie",
                DiscNumber = 3,
                Image = "comedy_image.jpg",
                MovieDescription = "This is a test comedy movie",
                MovieDuration = 100,
                MovieRating = 3.8,
                MovieRentalCost = 4
            };

            // Add the movie to the repository
            string addResult = repository.AddMovie(movieToAdd);
            Assert.AreEqual("Movie inserted successfully", addResult);

            // Modify the movie details
            Movie updatedMovie = new Movie
            {
                MovieRating = 4.2,
                MovieRentalCost = 5
            };

            // Act
            string updateResult = repository.UpdateMovie(updatedMovie);

            // Assert
            Assert.AreEqual("Movie details updated successfully", updateResult);
        }

        [Test]
        public void DeleteMovieTest()
        {
            // Arrange
            Movie movieToAdd = new Movie
            {
                GenreName = "Horror",
                MovieName = "Test Horror Movie",
                DiscNumber = 4,
                Image = "horror_image.jpg",
                MovieDescription = "This is a test horror movie",
                MovieDuration = 90,
                MovieRating = 4.8,
                MovieRentalCost = 7
            };

            // Add the movie to the repository
            string addResult = repository.AddMovie(movieToAdd);
            Assert.AreEqual("Movie inserted successfully", addResult);

            // Act
            string deleteResult = repository.DeleteMovie(1);

            // Assert
            Assert.AreEqual("movie removed from database", deleteResult);
        }
    }
}
