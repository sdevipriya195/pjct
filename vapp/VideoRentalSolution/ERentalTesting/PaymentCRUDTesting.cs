using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;
using System;

namespace ERentalTesting
{
    public class PaymentCRUDTesting
    {
        PaymentRepository paymentRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestPayment") // In-memory database for testing
                                .Options;

            MovieContext context = new MovieContext(dbOptions);
            paymentRepository = new PaymentRepository(context);
        }

        [Test]
        public void AddPaymentTest()
        {
            // Arrange
            Payment paymentToAdd = new Payment
            {
                CardNumber = "1234567890123456",
                ExpiryDate = "12/25",
                CVV = "123",
                PaymentAmount = 20.99f,
                PaymentDate = DateTime.Now,
                RentalId = 1
                // Add other necessary properties
            };

            // Act
            string result = paymentRepository.AddPayment(paymentToAdd);

            // Assert
            Assert.AreEqual("Payment done successfully", result);
        }

        [Test]
        public void GetAllPaymentsTest()
        {
            // Act
            var result = paymentRepository.GetAllPayments();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(System.Collections.Generic.List<Payment>), result);
        }
    }
}
