using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSystem.Helpers
{
    public class DirectoryHelper
    {
        /// <summary>
        /// Creates a random directory structure to the specified depth,
        /// where each folder has a random name of the specified length with the available chars.
        /// </summary>
        /// <param name="directoryDepth">Depth of folders to go to.</param>
        /// <param name="charsPerDirectoryName">Number of characters per directory name.</param>
        /// <param name="availableChars">Characters to randomize names from.</param>
        /// <returns></returns>
        public static string GetRandomDirectoryStructure(int directoryDepth, int charsPerDirectoryName, char[] availableChars =  null)
        {
            // Available characters for randomization
            if (availableChars == null)
            {
                availableChars = "0123456789ABCDEF".ToCharArray();
            }

            // Get random chars list
            int totalCharsNeeded = directoryDepth * charsPerDirectoryName;
            var randomChars = new List<char>();
            var random = new Random();
            while (randomChars.Count < totalCharsNeeded)
            {
                randomChars.Add(availableChars[random.Next(availableChars.Length -1)]);
            }

            // Split into nested directories as required
            var randomDirectoryStructure = new StringBuilder(totalCharsNeeded + directoryDepth);
            for (int index = 0; index < randomChars.Count; index++)
            {
                randomDirectoryStructure.Append(randomChars[index]);
                
                if (((index + 1) % charsPerDirectoryName) == 0)
                {
                    randomDirectoryStructure.Append(Path.DirectorySeparatorChar.ToString());
                }
            }
            return randomDirectoryStructure.ToString().Trim(Path.DirectorySeparatorChar);
        }
    }
}
