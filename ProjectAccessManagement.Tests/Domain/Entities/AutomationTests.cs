using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;

namespace ProjectAccessManagement.Tests.Domain.Entities
{
    public class AutomationTests
    {
        [Fact]
        public void AddModule_WhenModuleIsNotAlreadyAdded_ShouldAddModule()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var module = new Module("Test Module", new App("Test Application", AppType.Web));

            automation.AddModule(module);

            Assert.Contains(module, automation.Modules);
        }

        [Fact]
        public void AddModule_WhenModuleIsAlreadyAdded_ShouldThrowException()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var module = new Module("Test Module", new App("Test Application", AppType.Web));

            automation.AddModule(module);

            Assert.Throws<System.InvalidOperationException>(
                () => automation.AddModule(module));
        }

        [Fact]
        public void RemoveModule_WhenModuleIsAdded_ShouldRemoveModule()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var module = new Module("Test Module", new App("Test Application", AppType.Web));

            automation.AddModule(module);
            automation.RemoveModule(module);

            Assert.DoesNotContain(module, automation.Modules);
        }

        [Fact]
        public void RemoveModule_WhenModuleIsNotAdded_ShouldThrowException()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var module = new Module("Test Module", new App("Test Application", AppType.Web));

            Assert.Throws<System.InvalidOperationException>(
                () => automation.RemoveModule(module));
        }

        [Fact]
        public void AddCredential_WhenCredentialIsNotAlreadyAdded_ShouldAddCredential()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var credential = new Credential("Test Credential", new App("Test Application", AppType.Web), CredentialType.LoginPassword);

            automation.AddCredential(credential);

            Assert.Contains(credential, automation.Credentials);
        }

        [Fact]
        public void AddCredential_WhenCredentialIsAlreadyAdded_ShouldThrowException()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var credential = new Credential("Test Credential", new App("Test Application", AppType.Web), CredentialType.LoginPassword);

            automation.AddCredential(credential);

            Assert.Throws<System.InvalidOperationException>(
                () => automation.AddCredential(credential));
        }

        [Fact]
        public void RemoveCredential_WhenCredentialIsAdded_ShouldRemoveCredential()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var credential = new Credential("Test Credential", new App("Test Application", AppType.Web), CredentialType.LoginPassword);

            automation.AddCredential(credential);
            automation.RemoveCredential(credential);

            Assert.DoesNotContain(credential, automation.Credentials);
        }
        [Fact]
        public void RemoveCredential_WhenCredentialIsNotAdded_ShouldThrowException()
        {
            var businessArea = new BusinessArea("Test Business Area");
            var automation = new Automation("Test Automation", businessArea, 1);
            var credential = new Credential("Test Credential", new App("Test Application", AppType.Web), CredentialType.LoginPassword);

            Assert.Throws<System.InvalidOperationException>(
                () => automation.RemoveCredential(credential));
        }
    }
}
