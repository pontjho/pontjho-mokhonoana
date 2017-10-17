using Microsoft.VisualStudio.TestTools.UnitTesting;
using Absa.Assessment.Api.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using Moq;

namespace api.test
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void GivenAClientModel_WhenPosting_TheModelIsPersisted()
        {
            var model = new ClientModel {
                Surname = "Bloggs",
                FirstNames = "Joe Peter",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7202025074084",
                DateOfBirth = new DateTime(1972, 2, 2)
            };
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            controller.Post(model);

            repository.Verify(r => r.CreateClient(It.IsAny<ClientModel>()));
        }

        [TestMethod]
        public void GivenAnInvalidClientModel_WhenPosting_BadRequestIsReturned()
        {
            ClientModel model = new ClientModel {};
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);
            controller.ModelState.AddModelError("Surname", "Required");

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            repository.Verify(r => r.CreateClient(It.IsAny<ClientModel>()), Times.Never);
        }

        [TestMethod]
        public void GivenAPersistedClientModel_WhenGettingById_TheClientModelIsReturned()
        {
            var model = new ClientModel {
                Id = Guid.NewGuid(),
                Surname = "Bloggs",
                FirstNames = "Joe Peter",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7202025074084",
                DateOfBirth = new DateTime(1972, 2, 2)
            };
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            repository.Setup(r => r.GetClient(model.Id)).Returns(model);

            var result = controller.Get(model.Id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var typedResult = (OkObjectResult)result;
            Assert.AreEqual(typedResult.Value, model);
        }

        [TestMethod]
        public void GivenAClientModel_WhenGettingByInvalidId_NotFoundIsReturned()
        {

        }

        [TestMethod]
        public void GivenAPersistedClientModel_WhenUpdatingWithNewAttributes_ThePersistedModelIsUpdated()
        {

        }

        [TestMethod]
        public void GivenAListOfClientModels_WhenQuerying_TheClientModelsAreReturned()
        {

        }

        [TestMethod]
        public void GivenAPeristedClientModel_WhenDeleting_ThePersistedModelIsRemoved()
        {

        }

        [TestMethod]
        public void GivenAPeristedClientModel_WhenDeletingByInvalidId_NotFoundIsReturned()
        {
            
        }
    }
}
