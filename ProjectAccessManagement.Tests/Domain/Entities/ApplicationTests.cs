using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;

namespace ProjectAccessManagement.Tests.Domain.Entities
{
    public class ApplicationTests
    {
        [Fact]
        public void Application_WhenCreated_ShouldNotBeNull()
        {
            var application = new App("Test Application", AppType.Web);

            Assert.NotNull(application);
        }

        [Fact]
        public void AddModule_WhenDoesNotExist_ShouldAddModule()
        {
            var application = new App("Test Application", AppType.Web);
            var moduleName = "Test Module";

            application.AddModule(moduleName);

            var module = application.Modules.FirstOrDefault(m => m.Name == moduleName);
            Assert.NotNull(module);
            Assert.Equal(moduleName, module.Name);
        }

        [Fact]
        public void AddModule_WhenAlreadyExists_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var moduleName = "Test Module";

            application.AddModule(moduleName);


            Assert.Throws<System.InvalidOperationException>(
                () => application.AddModule(moduleName));
        }

        [Fact]
        public void RemoveModule_WhenExists_ShouldRemoveModule()
        {
            var application = new App("Test Application", AppType.Web);
            var moduleName = "Test Module";
            application.AddModule(moduleName);
            application.RemoveModule(moduleName);
            var module = application.Modules.FirstOrDefault(m => m.Name == moduleName);
            Assert.Null(module);
        }

        [Fact]
        public void RemoveModule_WhenDoesNotExist_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var moduleName = "Test Module";
            Assert.Throws<System.InvalidOperationException>(
                () => application.RemoveModule(moduleName));
        }
    }
}
