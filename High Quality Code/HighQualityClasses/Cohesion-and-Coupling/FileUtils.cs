namespace CohesionAndCoupling
{
    public class FileUtils
    {
        /// <summary>
        ///     Get file extension of some file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Extension from file if there is.</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        ///     Get only file name without extension
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>Filename without extension</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
