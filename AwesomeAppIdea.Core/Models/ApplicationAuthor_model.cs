using AwesomeAppIdea.Core.Contracts;

namespace AwesomeAppIdea.Core.Models
{
    public class ApplicationAuthor_Model : IApplicationAuthor
    {
        public ApplicationAuthor_Model(string name, string email)
        {
            Name = name;
            EmailAddress = email;
        }

        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }
}