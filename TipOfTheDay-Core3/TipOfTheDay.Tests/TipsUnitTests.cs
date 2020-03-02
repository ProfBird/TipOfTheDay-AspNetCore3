using System;
using System.Collections.Generic;
using TipOfTheDay.Controllers;
using TipOfTheDay.Data.Repositories;
using TipOfTheDay.Models;
using Xunit;

namespace TipOfTheDay.Tests
{
    public class TipsTests
    {
        [Fact]
        public void CreateTipTest()
        {
            // Arrange
            var repo = new FakeTipsRepository();
            var tipsController = new TipsController(repo);
            var tip = new Tip {
                TipText = "Just testing",
                Member = new AppUser { FullName = "Joe User" }
            };

            // Act
            tipsController.Create(tip);

            // Assert
            Assert.Contains<Tip>(tip, repo.Tips);
           
        }

        /*
        [Fact]
        public void GetTipByUserNameTest()
        {
            // Arrange
            var repo = new FakeTipsRepository();
            var tipController = new TipsController(repo);

            // Act

            // Assert


        }
        */
    }
}
