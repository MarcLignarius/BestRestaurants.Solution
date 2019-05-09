using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BestRestaurants.Models;

namespace BestRestaurants.Tests
{
  [TestClass]
  public class CuisineTests
  {
    [TestMethod]
    public void CuisineConstructor_CreatesInstanceOfCuisine_Cuisine()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Assert
      Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
    }
  }
}
