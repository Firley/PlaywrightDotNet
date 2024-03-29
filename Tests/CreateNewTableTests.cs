﻿using Newtonsoft.Json;
using PlaywrightTests.ApiRequests;
using PlaywrightTests.ApiRequests.Models;
using PlaywrightTests.PageObjects;
using PlaywrightTests.PageObjects.Dashboard;

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
        await createTileForm.SelectNonStandardColor(1);
        await Expect(createTileForm.CreateBoardSubmitButton).ToBeDisabledAsync();
        await createTileForm.InsertTitle(TableName);
        await Expect(createTileForm.CreateBoardSubmitButton).ToBeEnabledAsync();
        await createTileForm.ClickSubmitButton();

        var request = new MemberRequest(Settings, Playwright.APIRequest);
        var getBoardsReponse = await request.GetMemberBoardsAsync();
        var boards = JsonConvert.DeserializeObject<List<Board>>(await getBoardsReponse.TextAsync()) ?? new List<Board>();
        Assert.That(boards.Where(b => b.Name == TableName).Count(), Is.EqualTo(1));
    }

    [TearDown]
    public async Task DeleteNewTable()
    {
        var request = new MemberRequest(Settings, Playwright.APIRequest);
        var getBoardsReponse = await request.GetMemberBoardsAsync();
        var boards = JsonConvert.DeserializeObject<List<Board>>(await getBoardsReponse.TextAsync())?.Where(b => b.Name == TableName) ?? new List<Board>(); 
        var boardRequest = new BoardRequest(Settings, Playwright.APIRequest);

        foreach (var board in boards)
        {
            await boardRequest.DeleteBoardRequestAsync(board.Id);
        }
    }
}
