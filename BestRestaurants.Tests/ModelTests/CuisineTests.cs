using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BestRestaurants.Models;

namespace BestRestaurants.Tests
{
  [TestClass]
  public class CuisineTests: IDisposable
  {
    public void Dispose()
    {
      Cuisine.ClearAll();
    }

    public void CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
    }

    [TestMethod]
    public void CuisineConstructor_CreatesInstanceOfCuisine_Cuisine()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Assert
      Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
    }

    [TestMethod]
    public void Name_ReturnName_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Act
      string result = newCuisine.Name;

      //Assert
      Assert.AreEqual(result, "thai");
    }

    [TestMethod]
    public void Description_ReturnDescription_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Act
      string result = newCuisine.Description;

      //Assert
      Assert.AreEqual(result, "spicy SE Asian");
    }

    [TestMethod]
    public void Name_SetName_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");
      string newName = "barbecue";

      //Act
      string result = newCuisine.Name = newName;

      //Assert
      Assert.AreEqual(result, "barbecue");
    }

    [TestMethod]
    public void Description_SetDescription_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");
      string newDescription = "Southern eatin'";
      //Act
      string result = newCuisine.Description = newDescription;

      //Assert
      Assert.AreEqual(result, "Southern eatin'");
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_CuisineList()
    {
      //Arrange
      List<Cuisine> newList = new List<Cuisine> { };

      //Act
      List<Cuisine> result = Cuisine.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAndDescriptionsAreTheSame_Cuisine()
    {
      // Arrange, Act
      Cuisine firstCuisine = new Cuisine("thai", "spicy SE Asian");
      Cuisine secondCuisine = new Cuisine("thai", "spicy SE Asian");

      // Assert
      Assert.AreEqual(firstCuisine, secondCuisine);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CuisineList()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("thai", "spicy SE Asian");

      //Act
      testCuisine.Save();
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


  }



}
