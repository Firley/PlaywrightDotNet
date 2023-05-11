using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.cofiguration
{
    public class TestsSettings
    {
        public string Link { get; set; } = null!;
        public string Browser { get; set; } = null!;
        public bool Headless { get; set; } = false;
        public string ApiKey { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string ApiUrl { get; set; } = null!;
        public string ApiSecret { get; set; }

    }
}
