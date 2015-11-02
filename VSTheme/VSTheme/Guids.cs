// Guids.cs
// MUST match guids.h
using System;

namespace Company.VSTheme
{
    static class GuidList
    {
        public const string guidVSThemePkgString = "e32d74e6-bb0e-44be-9978-9b2bfb192847";
        public const string guidVSThemeCmdSetString = "03cdb5c2-ede1-4c92-b958-002e9cc052fb";

        public static readonly Guid guidVSThemeCmdSet = new Guid(guidVSThemeCmdSetString);
    };
}