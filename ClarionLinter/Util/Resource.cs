using System.IO;
using System.Reflection;

namespace Util
{

    /// <summary>
    /// Provides helper functions for working with assembly resources.
    /// </summary>
    class Resource
    {

        /// <summary>
        /// Gets the contents of an embedded resource as a string.
        /// </summary>
        /// <param name="resource">The relative path to the resource from the project root.</param>
        /// <returns>The contents of the embedded resource.</returns>
        public static string GetEmbeddedResource(string resource)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            resource = resource.Replace(" ", "_").Replace("\\", ".").Replace("/", ".");
            resource = assembly.GetName().Name + "." + resource;
            using (Stream stream = assembly.GetManifestResourceStream(resource))
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

    }

}
