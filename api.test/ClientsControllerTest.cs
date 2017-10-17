using Microsoft.VisualStudio.TestTools.UnitTesting;
using Absa.Assessment.Api.Client;
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
            ClientModel model = new ClientModel {
                Surname = "",
                FirstNames = " ",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "   ",
                DateOfBirth = new DateTime()
            };
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            controller.Post(model);

            repository.Verify(r => r.CreateClient(It.IsAny<ClientModel>()));
        }

        [TestMethod]
        public void GivenAnInvalidClientModel_WhenPosting_BadRequestIsReturned()
        {

        }

        [TestMethod]
        public void GivenAPersistedClientModel_WhenGettingById_TheClientModelIsReturned()
        {

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
