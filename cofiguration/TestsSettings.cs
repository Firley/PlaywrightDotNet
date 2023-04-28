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

    }
}
