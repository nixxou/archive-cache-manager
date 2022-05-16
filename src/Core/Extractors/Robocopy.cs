using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ArchiveCacheManager
{
    public class Robocopy : Extractor
    {
        private long? archiveSize;
        private string archiveSizePath;

        public Robocopy()
        {
            archiveSize = null;
            archiveSizePath = string.Empty;
        }

        public string GetArchivePathAlt(string archivePath)
        {
            if (!File.Exists(archivePath))
            {
                List<string> AlternativePath = new List<string>();
                AlternativePath.Add(@"C:\coffre\extract\NDS2");
                string potentialpath = "";
                foreach(string altp in AlternativePath)
                {
                    potentialpath = Path.Combine(altp, Path.GetFileName(archivePath));
                    if (File.Exists(potentialpath))
                    {
                        return potentialpath;
                    }
                }
            }
            return archivePath;
        }
        public override bool Extract(string archivePath, string cachePath, string[] includeList = null, string[] excludeList = null)
        {
            archivePath = GetArchivePathAlt(archivePath);

            char DriveArchive = Path.GetFullPath(archivePath).ToLower().Substring(0, 1)[0];
            char DriveCache = Path.GetFullPath(cachePath).ToLower().Substring(0, 1)[0];
            if(char.IsLetter(DriveCache) && DriveArchive == DriveCache)
            {
                DiskUtils.HardLink(Path.Combine(cachePath, Path.GetFileName(archivePath)), archivePath);
                if (File.Exists(Path.Combine(cachePath, Path.GetFileName(archivePath)))) return true;
            }


            // If the file is less than 50MB, the overhead of calling Robocopy isn't worth it. Instead just use File.Copy().
            if (GetSize(archivePath) > 52_428_800)
            {
                string args = string.Format("/c robocopy \"{0}\" \"{1}\" \"{2}\"", Path.GetDirectoryName(archivePath), cachePath, Path.GetFileName(archivePath));

                (string stdout, string stderr, int exitCode) = ProcessUtils.RunProcess("cmd.exe", args, true, ExtractionProgress, true);

                if (exitCode >= 8)
                {
                    Logger.Log(string.Format("Robocopy returned exit code {0} with error output:\r\n{1}", exitCode, stdout));
                    Environment.ExitCode = exitCode;
                }

                return exitCode < 8;
            }
            else
            {
                try
                {
                    File.Copy(archivePath, Path.Combine(cachePath, Path.GetFileName(archivePath)), true);
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Log($"File copy error: {e.ToString()}");
                    Console.Out.WriteLine(e.Message);
                    Environment.ExitCode = 1;
                }
            }

            return false;
        }

        public override long GetSize(string archivePath, string fileInArchive = null)
        {
            archivePath = GetArchivePathAlt(archivePath);
            if (!Equals(archivePath, archiveSizePath) || archiveSize == null)
            {
                archiveSizePath = archivePath;
                archiveSize = DiskUtils.GetFileSize(archivePath);
            }

            return (long)archiveSize;
        }

        public override string[] List(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            archivePath = GetArchivePathAlt(archivePath);
            return Path.GetFileName(archivePath).ToSingleArray();
        }

        override public (string[], long[]) ListWithSize(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            archivePath = GetArchivePathAlt(archivePath);

            string[] fileList = List(archivePath, includeList, excludeList, prefixWildcard);
            long[] fileSize = new long[fileList.Count()];
            for (int i = 0; i < fileList.Count(); i++) fileSize[i] = 0;
            return (fileList, fileSize);
        }

        public override string Name()
        {
            return "File Copy";
        }

        public override string GetExtractorPath()
        {
            return null;
        }
    }
}
