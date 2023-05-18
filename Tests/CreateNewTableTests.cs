using Microsoft.Playwright;
using Newtonsoft.Json;
using PlaywrightTests.ApiRequests;
using PlaywrightTests.ApiRequests.Models;
using PlaywrightTests.PageObjects;
using PlaywrightTests.PageObjects.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests;

public class CreateNewTableTests : BaseTest
{
    public string TableName { get; set; } = "Table1";
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
        await createTileForm.SelectNonStandardColor(1);

        var request = new MemberRequest(Settings, Playwright.APIRequest);
        var getBoardsReponse = await request.GetMemberBoardsAsync();
        var boards = JsonConvert.DeserializeObject<List<Board>>(await getBoardsReponse.TextAsync()) ?? new List<Board>();
        Assert.That(boards.Where(b => b.Name == TableName).Count(), Is.EqualTo(1));
   }

    [TearDown]
}
