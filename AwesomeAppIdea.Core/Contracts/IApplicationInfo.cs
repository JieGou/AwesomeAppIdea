namespace AwesomeAppIdea.Core.Contracts
{
    public interface IApplicationInfo
    {
        IApplicationAuthor Author { get; }

        string Product { get; set; }

        string Description { get; set; }

        string Copyright { get; }

        string Version { get; set; }
    }
}