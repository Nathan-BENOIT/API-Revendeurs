using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using APIRevendeurs;
using APIRevendeurs.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreApp.Tests
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var controller = new ProduitsController();

            var result = controller.GetAsync() as Task<List<Produits>>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var controller = new ProduitsController();

            var result = controller.Get(4) as Task<Produits>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProduitsController();

            var result = controller.Get(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}