using Microsoft.VisualStudio.TestTools.UnitTesting;
using Absa.Assessment.Api.Client;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;
using Moq;

namespace api.test
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public async Task GivenAClientModel_WhenPosting_TheModelIsPersisted()
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

            await controller.Post(model);

            repository.Verify(r => r.CreateClient(It.IsAny<ClientModel>()));
        }

        [TestMethod]
        public async Task GivenAnInvalidClientModel_WhenPosting_BadRequestIsReturned()
        {
            ClientModel model = new ClientModel {};
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);
            controller.ModelState.AddModelError("Surname", "Required");

            var result = await controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            repository.Verify(r => r.CreateClient(It.IsAny<ClientModel>()), Times.Never);
        }

        [TestMethod]
        public async Task GivenAPersistedClientModel_WhenGettingById_TheClientModelIsReturned()
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

            repository.Setup(r => r.GetClient(model.Id)).Returns(Task.FromResult(model));

            var result = await controller.Get(model.Id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var typedResult = (OkObjectResult)result;
            Assert.AreEqual(typedResult.Value, model);
        }

        [TestMethod]
        public async Task GivenAClientModel_WhenGettingByInvalidId_NotFoundIsReturned()
        {
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            repository.Setup(r => r.GetClient(It.IsAny<Guid>())).Returns(Task.FromResult((ClientModel)null));

            var result = await controller.Get(Guid.NewGuid());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GivenAPersistedClientModel_WhenUpdatingWithNewAttributes_ThePersistedModelIsUpdated()
        {
            var originalModel = new ClientModel {
                Id = Guid.NewGuid(),
                Surname = "Bloggs",
                FirstNames = "Joe Peter",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7202025074084",
                DateOfBirth = new DateTime(1972, 2, 2)
            };
            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            var result = await controller.Put(originalModel.Id, new ClientModel {
                Id = Guid.NewGuid(),
                Surname = "Bloggs1",
                FirstNames = "Joe Peters",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7302025074084",
                DateOfBirth = new DateTime(1973, 2, 2)
            });

            Assert.IsInstanceOfType(result, typeof(OkResult));
            repository.Verify(r => r.UpdateClient(originalModel.Id, It.IsAny<ClientModel>()), Times.Once);
        }

        [TestMethod]
        public async Task GivenAListOfClientModels_WhenQuerying_TheClientModelsAreReturned()
        {
            var model1 = new ClientModel {
                Id = Guid.NewGuid(),
                Surname = "Bloggs",
                FirstNames = "Joe Peter",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7202025074084",
                DateOfBirth = new DateTime(1972, 2, 2)
            };
            var model2 = new ClientModel {
                Id = Guid.NewGuid(),
                Surname = "Bloggs1",
                FirstNames = "Joe Peter1",
                IdentityType = ClientIdentityType.Passport,
                IdentityNumber = "7302025074084",
                DateOfBirth = new DateTime(1973, 2, 2)
            };

            var repository = new Mock<ClientRepository>();
            var controller = new ClientsController(repository.Object);

            repository.Setup(r => r.QueryClients()).Returns(Task.FromResult((IEnumerable<ClientModel>)new ClientModel[] { model1, model2 } ));

            var result = await controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var typedResult = (OkObjectResult)result;
            var modelList = typedResult.Value as IEnumerable<ClientModel>;
            Assert.AreEqual(2, modelList.Count());
            Assert.AreEqual(model1.Id, modelList.ToArray()[0].Id);
        }
    }
}
