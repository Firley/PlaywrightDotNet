using Microsoft.Playwright;
using PlaywrightTests.ApiRequests;
using PlaywrightTests.ApiRequests.Models;
using PlaywrightTests.PageObjects;
using PlaywrightTests.PageObjects.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    internal class CreateNewTableTests : BaseTest
    {
        public string TableName { get; set; } = "Table2";
        [Test]
        public async Task CreateNewTable()
        {
            await Page.GotoAsync(Settings.Link);
            DashBoardPage dashBoard = new DashBoardPage(Page);
            dashBoard.OpenCreateNewTableFormAsync().Wait();
            CreateBoardSubPage createTileForm = new CreateBoardSubPage(Page);
            await Expect(createTileForm.BoardSubpageTitleHeading).ToHaveTextAsync("Utwórz Tablicę");
            await Expect(createTileForm.BoardSubpageTitleHeading).ToBeVisibleAsync();
            await Expect(createTileForm.BackgroundImagePreview).ToBeVisibleAsync();
            await Expect(createTileForm.BackgroundPickerLabel).ToHaveTextAsync("Tło");
            await Expect(createTileForm.BackgroundPickerLabel).ToBeVisibleAsync();
            await Expect(createTileForm.DefaultBackgroundImages).ToHaveCountAsync(4);
            await Expect(createTileForm.BackgroundColorList).ToHaveCountAsync(6);
            await Expect(createTileForm.TitleInputLabel).ToBeVisibleAsync();
            await Expect(createTileForm.TitleInput).ToBeFocusedAsync();

            await Expect(createTileForm.CreateBoardSubmitButton).ToBeDisabledAsync();
            await createTileForm.InsertTitle(TableName);
            await Expect(createTileForm.CreateBoardSubmitButton).ToBeEnabledAsync();
            await createTileForm.ClickSubmitButton();

            var request = new MemberRequest(Settings);
            GetMemberBoardsResponse getMemberBoardsResponse = await request.GetMemberBoardsAsync();
            Assert.That(getMemberBoardsResponse.Boards?.Select(b => b.Name == TableName).Count() == 1);
            var board = getMemberBoardsResponse.Boards?.SingleOrDefault(b=> b.Name == TableName);
       }
    }
}
