using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Tests.Domain.Entities
{
    public class CredentialTests
    {
        [Fact]
        public void CreateCredential_WhenExistingApplication_ShouldCreateCredential()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);

            Assert.NotNull(credential);
            Assert.Equal(credential.Application, application);
            Assert.Equal(CredentialType.LoginPassword, credential.CredentialType);
        }

        [Fact]
        public void CreateCredential_WhenNullApplication_ShouldThrowException()
        {
            App application = null;

            Assert.Throws<System.ArgumentNullException>(
                () => new Credential("Test Credential", application, CredentialType.LoginPassword));
        }

        [Fact]
        public void AddModule_WhenModuleFromSameApplication_SouldAddModule()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var module = new Module("Test Module", application);

            credential.AddModule(module);

            Assert.Contains(module, credential.Modules);
        }

        [Fact]
        public void AddModule_WhenModuleFromDifferentApplication_ShouldThrowException()
        {
            var application1 = new App("Test Application 1", AppType.Web);
            var application2 = new App("Test Application 2", AppType.Web);

            var credential = new Credential("Test Credential", application1, CredentialType.LoginPassword);
            var module = new Module("Test Module", application2);

            Assert.Throws<System.InvalidOperationException>(
                () => credential.AddModule(module));
        }

        [Fact]
        public void AddModule_WhenModuleBelongsToCredential_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var module = new Module("Test Module", application);

            credential.AddModule(module);

            Assert.Throws<System.InvalidOperationException>(
                () => credential.AddModule(module));
        }

        [Fact]
        public void AddModule_WhenModuleNameBelongsToCredential_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var moduleName = "Test Module";
            var module = new Module(moduleName, application);

            credential.AddModule(module);

            Assert.Throws<System.InvalidOperationException>(
                () => credential.AddModule(moduleName));
        }

        [Fact]
        public void AddModule_WhenModuleNameNotInCredential_ShouldAddModule()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var moduleName = "Test Module";

            credential.AddModule(moduleName);

            var modulo = credential.Modules.FirstOrDefault(m => m.Name == moduleName);
            Assert.NotNull(modulo);
            Assert.Equal(moduleName, modulo.Name);
        }

        [Fact]
        public void UpdateExpireDate_WhenNewDate_ShouldUpdateExpireDate()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var newDate = DateTime.Now.AddDays(1);

            credential.UpdateExpireDate(newDate);

            Assert.Equal(newDate, credential.ExpiryDate);
        }

        [Fact]
        public void RemoveModule_WhenModuleExistsInCredential_ShouldRemoveModule()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var module = new Module("Test Module", application);

            credential.AddModule(module);
            credential.RemoveModule(module);

            Assert.DoesNotContain(module, credential.Modules);
        }

        [Fact]
        public void RemoveModule_WhenModuleExistsButNotInCredential_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var module1 = new Module("Test Module 1", application);
            var module2 = new Module("Test Module 2", application);

            credential.AddModule(module1);

            Assert.Throws<System.InvalidOperationException>(
                () => credential.RemoveModule(module2));
        }

        [Fact]
        public void RemoveModule_WhenModuleNameNotInCredential_ShouldThrowException()
        {
            var application = new App("Test Application", AppType.Web);
            var credential = new Credential("Test Credential", application, CredentialType.LoginPassword);
            var module = new Module("Test Module", application);

            credential.AddModule(module);

            Assert.Throws<System.InvalidOperationException>(
                () => credential.RemoveModule("Nome inexistente"));
        }
    }
}
