using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipOfTheDay.Controllers;
using TipOfTheDay.Data.Repositories;
using TipOfTheDay.Models;
using Xunit;

namespace TipOfTheDay.Tests
{
    public class TipsTests
    {
        FakeTipsRepository repo;
        TipController controller;
        Tip tip;
        AppUser member;

        const String JOE_USER = "Joe User";
        const String JANE_USER = "Jane User";

        // Constructor with common setup for all tests
       public TipsTests()
        {
            repo = new FakeTipsRepository();
            controller = new TipController(null);
            member = new AppUser { FullName = JOE_USER };
            tip = new Tip
            {
                TipText = "Just testing",
                Member = member
            };

        }

        // Helper for test setup--it adds three tips to the repo
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


        /************ Tip Tests ***********/
        /*
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
        */
        /*
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
        */
        /*
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
        */
        /*************** Comment tests *************/
       /*
        [Fact]
        private async Task AddCommentToTipAsync()
        {
            // Arrange
            await repo.AddTipAsync(tip);
            Comment comment = new Comment
            {
                CommentText = "This is a comment",
                Member = new AppUser { FullName = JANE_USER }
            };

            // Act
            await controller.CreateComment(comment, tip.TipID);

            // Assert
            Assert.True(repo.Comments.Contains(comment) &&
                        tip.Comments.Contains(comment));

        }
        */
    }
}
