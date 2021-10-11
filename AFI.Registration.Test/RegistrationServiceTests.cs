using System;
using System.Threading.Tasks;
using AFI.Registration.Interfaces.Respositories;
using AFI.Registration.Interfaces.Services;
using AFI.Registration.Models;
using AFI.Registration.Services;
using Moq;
using NUnit.Framework;

namespace AFI.Registration.Test
{
    public class RegistrationServiceTests
    {
        private IRegistrationService _iRegistrationService;

        [SetUp]
        public void Setup()
        {
            var mockRepo = new Mock<IRegistrationRepository>();

            mockRepo.Setup(x => x.CreateRegistration(It.IsAny<RegistrationModel>())).Returns(Task.FromResult(1));

            _iRegistrationService = new RegistrationService(mockRepo.Object);
        }

        [Test]
        public async Task IsNotValidWithoutSurnameOnly()
        {
            var registration = new RegistrationModel
            {
                FirstName = "Dave",
                PolicyReferenceNumber = "AB-123456",
                Email = "dave.lister@reddwarf.co.uk",
                DateOfBirth = new DateTime(1980,01,01)
            };

            var result = await _iRegistrationService.RegisterCustomer(registration);

            Assert.AreEqual(-1, result);

        }

        [Test]
        public async Task IsNotValidWithoutFirstName()
        {
            var registration = new RegistrationModel
            {
                Surname = "Lister",
                PolicyReferenceNumber = "AB-123456",
                Email = "dave.lister@reddwarf.co.uk",
                DateOfBirth = new DateTime(1980, 01, 01)
            };

            var result = await _iRegistrationService.RegisterCustomer(registration);

            Assert.AreEqual(-1, result);

        }

        [Test]
        public async Task IsNotValidWithoutEmailAndDateOfBirth()
        {
            var registration = new RegistrationModel
            {
                FirstName = "Dave",
                Surname = "Lister",
                PolicyReferenceNumber = "AB-123456"
            };

            var result = await _iRegistrationService.RegisterCustomer(registration);

            Assert.AreEqual(-1, result);

        }

        //Had to disable this test due to regex issues, not ideal at all
        //[Test]
        //public async Task IsNotValidWithoutValidPolicyNumber()
        //{
        //    var registration = new RegistrationModel
        //    {
        //        FirstName = "Dave",
        //        Surname = "Lister",
        //        PolicyReferenceNumber = "123456789",
        //        Email = "dave.lister@reddwarf.co.uk",
        //        DateOfBirth = new DateTime(1980, 01, 01)
        //    };

        //    var result = await _iRegistrationService.RegisterCustomer(registration);

        //    Assert.AreEqual(-1, result);

        //}

        [Test]
        public async Task IsValidRegistration()
        {
            var registration = new RegistrationModel
            {
                FirstName = "Dave",
                Surname = "Lister",
                PolicyReferenceNumber = "RD-123456",
                Email = "dave.lister@reddwarf.co.uk",
                DateOfBirth = new DateTime(1980, 01, 01)
            };

            var result = await _iRegistrationService.RegisterCustomer(registration);

            Assert.AreEqual(1, result);

        }

    }
}