using AwesomeAppIdea.Core.Contracts;
using System.Reflection;

namespace AwesomeAppIdea.Core.Models
{
    public class ApplicationInfo_Model : IApplicationInfo
    {
        public ApplicationInfo_Model(Assembly loadingassembly, IApplicationAuthor author)
        {
            if (loadingassembly == null)
            {
                throw new System.ArgumentNullException(nameof(loadingassembly));
            }

            Product = ((AssemblyProductAttribute)loadingassembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;

            Description = ((AssemblyDescriptionAttribute)loadingassembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;

            Copyright = ((AssemblyCopyrightAttribute)loadingassembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;

            Version = loadingassembly.GetName().Version.ToString();

            Author = author;
        }

        public string Product { get; set; }

        public string Description { get; set; }

        public string Copyright { get; }

        public string Version { get; set; }

        public IApplicationAuthor Author { get; }
    }
}