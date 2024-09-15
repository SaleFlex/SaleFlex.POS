using System;
using System.Collections;
using System.IO;

namespace SaleFlex.CommonLibrary
{
    // Enum defining the different ways to compare files
    public enum enumFileCompareBy
    {
        Name,           // Compare by file name, alphabetically (A-Z)
        LastWriteTime,  // Compare by last modified time, newest to oldest
        CreationTime,   // Compare by creation time, newest to oldest
        LastAccessTime, // Compare by last access time, newest to oldest
        FileSize        // Compare by file size, smallest to largest
    }

    // FileComparer class implements IComparer interface to compare two files based on various file properties.
    public class FileComparer : IComparer
    {
        // The default file comparison method is by last write time (newest to oldest).
        enumFileCompareBy m_enumCompareBy = enumFileCompareBy.LastWriteTime;

        // Default constructor, uses LastWriteTime as default comparison method.
        public FileComparer()
        {
        }

        // Constructor allowing custom comparison method (Name, LastWriteTime, etc.).
        public FileComparer(enumFileCompareBy prm_enumCompareBy)
        {
            m_enumCompareBy = prm_enumCompareBy; // Set the comparison type
        }

        // The Compare method, as required by the IComparer interface. 
        // This method compares two objects, expected to be of type FileInfo.
        int IComparer.Compare(object prm_objFirstFile, object prm_objSecondFile)
        {
            int iOutput = 0;

            // Cast the input objects to FileInfo
            FileInfo xFirstFileInfo = (FileInfo)prm_objFirstFile;
            FileInfo xSecondFileInfo = (FileInfo)prm_objSecondFile;

            // Switch on the selected comparison method, as determined by the enumFileCompareBy value.
            switch (m_enumCompareBy)
            {
                case enumFileCompareBy.LastWriteTime:
                    // Compare files by LastWriteTime (most recent first)
                    iOutput = DateTime.Compare(xSecondFileInfo.LastWriteTime, xFirstFileInfo.LastWriteTime);
                    break;

                case enumFileCompareBy.CreationTime:
                    // Compare files by CreationTime (most recent first)
                    iOutput = DateTime.Compare(xSecondFileInfo.CreationTime, xFirstFileInfo.CreationTime);
                    break;

                case enumFileCompareBy.LastAccessTime:
                    // Compare files by LastAccessTime (most recent first)
                    iOutput = DateTime.Compare(xSecondFileInfo.LastAccessTime, xFirstFileInfo.LastAccessTime);
                    break;

                case enumFileCompareBy.FileSize:
                    // Compare files by FileSize (smallest first)
                    iOutput = Convert.ToInt32(xFirstFileInfo.Length - xSecondFileInfo.Length);
                    break;

                case enumFileCompareBy.Name:
                default:
                    // Compare files by Name (alphabetically), case insensitive.
                    iOutput = (new CaseInsensitiveComparer()).Compare(xFirstFileInfo.Name, xSecondFileInfo.Name);
                    break;
            }

            // Return the result of the comparison.
            return iOutput;
        }
    }
}
