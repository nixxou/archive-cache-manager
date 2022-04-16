﻿using System;
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
        public Robocopy()
        {

        }

        public override bool Extract(string archivePath, string cachePath, string[] includeList = null, string[] excludeList = null)
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

        public override long GetSize(string archivePath, string fileInArchive = null)
        {
            return new FileInfo(archivePath).Length;
        }

        public override string[] List(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            return Path.GetFileName(archivePath).ToSingleArray();
        }

        override public (string[], long[]) ListWithSize(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            string[] fileList = List(archivePath, includeList, excludeList, prefixWildcard);
            long[] fileSize = new long[fileList.Count()];
            for (int i = 0; i < fileList.Count(); i++) fileSize[i] = 0;
            return (fileList, fileSize);
        }

        public override string Name()
        {
            return "File Copy";
        }
    }
}
