using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        const String JOE_USER = "Joe User";
        const String JANE_USER = "Jane User";

        // Common setup for all tests
       public TipsTests()
        {
            repo = new FakeTipsRepository();
            controller = new TipsController(repo);
            member = new AppUser { FullName = JOE_USER };
            tip = new Tip
            {
                TipText = "Just testing",
                Member = member
            };

        }

        [Fact]
        public async Task CreateTipTestAsync()
        {
            // Arrange
            // Done in the constructor

            // Act
            await controller.Create(tip);

            // Assert
            Assert.Contains<Tip>(tip, repo.Tips);
        }

        [Fact]
        public async Task GetAllTipsTestAsync()
        {
            // Arrange
            // In addition to setup done in the constructor
            await AddTipsToRepoAsync();
            
            // Act
            var result =  await controller.Index();
            var viewResult = (ViewResult)result;
            var tips = (List<Tip>)viewResult.Model;   // Get the list of tips out fo the VeiwResult object.

            // Assert
            Assert.Equal(3, tips.Count);
        }

        
        [Fact]
        public async Task FindByNameTestAsync()
        {
            // Arrange
            await AddTipsToRepoAsync();

            // Act
            var result = (ViewResult)await controller.Find(JOE_USER);
            var tips = (List<Tip>)result.Model;   // Get the list of tips out fo the VeiwResult object.

            // Assert
            Assert.Equal(2, tips.Count);
        }

        private async Task AddTipsToRepoAsync()
        {
            await repo.AddTipAsync(tip);  // first tip created in constructor
            tip = new Tip
            {
                TipText = "Second tip",
                Member = member
            };
            await repo.AddTipAsync(tip);

            tip = new Tip
            {
                TipText = "Third tip",
                Member = new AppUser { FullName = JANE_USER }
            };
            await repo.AddTipAsync(tip);
        }
        
    }
}
