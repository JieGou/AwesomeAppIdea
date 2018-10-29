using AwesomeAppIdea.Core.Enums;
using System.Diagnostics;

namespace AwesomeAppIdea.Core.Contracts
{
    public interface IClientInformation
    {
        int AppId { get; }
        string AppPath { get; }
        Process CurrentProcess { get; }
        Products Product { get; }
        Years Year { get; }
    }
}