using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TipOfTheDay.Controllers;
using TipOfTheDay.Data.Repositories;
using TipOfTheDay.Models;
using Xunit;

namespace TipOfTheDay.Tests
{
    public class TipsTests
    {
        FakeTipsRepository repo;
        TipsController controller;
        Tip tip;
        AppUser member;

        // Common setup for all tests
       public TipsTests()
        {
            repo = new FakeTipsRepository();
            controller = new TipsController(repo);
            member = new AppUser { FullName = "Joe User" };
            tip = new Tip
            {
                TipText = "Just testing",
                Member = member
            };

        }

        [Fact]
        public void CreateTipTest()
        {
            // Arrange
            // Done in the constructor

            // Act
            controller.Create(tip);

            // Assert
            Assert.Contains<Tip>(tip, repo.Tips);
        }

        [Fact]
        public void GetAllTipsTest()
        {
            // Arrange
            // In addition to setup done in the constructor
            repo.AddTip(tip);

            tip = new Tip
            {
                TipText = "Second tip",
                Member = member
            };
            repo.AddTip(tip);

            tip = new Tip
            {
                TipText = "Third tip",
                Member = member
            };
            repo.AddTip(tip);

            // Act
            var result = (ViewResult)controller.Index().Result;
            var tips = (List<Tip>)result.Model;

            // Assert
            Assert.Equal(3, tips.Count);
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
