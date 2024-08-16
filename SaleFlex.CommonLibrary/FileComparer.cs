using System;
using System.Collections;
using System.IO;

namespace SaleFlex.CommonLibrary
{
    public enum enumFileCompareBy
    {
        Name,           // a-z
        LastWriteTime,  // Newest to oldest
        CreationTime,   // Newest to oldest
        LastAccessTime, // Newest to oldest
        FileSize        // smallest first
    }

    public class FileComparer : IComparer
    {


        // default comparison
        enumFileCompareBy m_enumCompareBy = enumFileCompareBy.LastWriteTime;

        public FileComparer()
        {
        }

        public FileComparer(enumFileCompareBy prm_enumCompareBy)
        {
            m_enumCompareBy = prm_enumCompareBy;
        }

        int IComparer.Compare(object prm_objFirstFile, object prm_objSecondFile)
        {
            int iOutput = 0;

            FileInfo xFirstFileInfo = (FileInfo)prm_objFirstFile;
            FileInfo xSecondFileInfo = (FileInfo)prm_objSecondFile;

            switch (m_enumCompareBy)
            {
                case enumFileCompareBy.LastWriteTime:
                    iOutput = DateTime.Compare(xSecondFileInfo.LastWriteTime, xFirstFileInfo.LastWriteTime);
                    break;
                case enumFileCompareBy.CreationTime:
                    iOutput = DateTime.Compare(xSecondFileInfo.CreationTime, xFirstFileInfo.CreationTime);
                    break;
                case enumFileCompareBy.LastAccessTime:
                    iOutput = DateTime.Compare(xSecondFileInfo.LastAccessTime, xFirstFileInfo.LastAccessTime);
                    break;
                case enumFileCompareBy.FileSize:
                    iOutput = Convert.ToInt32(xFirstFileInfo.Length - xSecondFileInfo.Length);
                    break;
                case enumFileCompareBy.Name:
                default:
                    iOutput = (new CaseInsensitiveComparer()).Compare(xFirstFileInfo.Name, xSecondFileInfo.Name);
                    break;
            }

            return iOutput;
        }
    }
}
