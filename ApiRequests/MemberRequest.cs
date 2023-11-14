﻿using Microsoft.Playwright;
using System.Text.Json;
using PlaywrightTests.ApiRequests.Models;
using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlaywrightTests.ApiRequests
{
    public class MemberRequest : ApiRequest
    {
        protected override string Route => "members";

        public MemberRequest(TestsSettings settings, IAPIRequest request) : base(settings, request) {}

        public async Task<IAPIResponse> GetMemberBoardsAsync()
        {
            await CreateApiRequestContextAsync();
            return await RequestContext.GetAsync($"{Route}/" + Settings.UserId + "/boards" + $"?key={Settings.ApiKey}" + "&token=" + Settings.Token);   
        }
    }
}
