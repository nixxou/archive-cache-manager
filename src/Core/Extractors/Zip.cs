﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchiveCacheManager
{
    /// <summary>
    /// Handles all calls to 7-Zip.
    /// </summary>
    public class Zip : Extractor
    {
        public override string Name()
        {
            return "7-Zip";
        }

        public override long GetSize(string archivePath, string fileInArchive = null)
        {
            // Run List command
            // Parse stdout for all "Size = " entries
            // Extract sizes and sum
            // Return -1 on error
            long size = 0;

            var (stdout, _, exitCode) = ListArchiveDetails(archivePath, fileInArchive.ToSingleArray(), null, false);

            if (exitCode == 0)
            {
                // TODO: Replace logic with regex?
                string[] stdoutArray = stdout.Split(new string[] { "------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                // Take substring at 25th char, after date/time/attr details and before file sizes
                string summary = stdoutArray[stdoutArray.Length - 1].Substring(25);
                size = Convert.ToInt64(summary.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            return size;
        }

        public override bool Extract(string archivePath, string cachePath, string[] includeList = null, string[] excludeList = null)
        {
            // x = extract
            // {0} = archive path
            // -o{1} = output path
            // -y = answer yes to any queries
            // -aoa = overwrite all existing files
            // -bsp1 = redirect progress to stdout
            string args = string.Format("x \"{0}\" \"-o{1}\" -y -aoa -bsp1 {2}", archivePath, cachePath, GetIncludeExcludeArgs(includeList, excludeList, false));

            (_, _, int exitCode) = Run7z(args, true);
            return exitCode == 0;
        }

        public override string[] List(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            // Run List command
            // Parse stdout for all "Path = " entries
            // Return -1 on error
            string[] fileList = Array.Empty<string>();

            var (stdout, _, exitCode) = ListArchiveDetails(archivePath, includeList, excludeList, prefixWildcard);

            /*
            stdout will be in the format below:
            --------
            c:\LaunchBox\ThirdParty\7-Zip>7z l "c:\Emulation\ROMs\Doom (USA).zip"

            7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21

            Scanning the drive for archives:
            1 file, 260733247 bytes (249 MiB)

            Listing archive: c:\Emulation\ROMs\Doom (USA).zip

            --
            Path = c:\Emulation\ROMs\Doom (USA).zip
            Type = zip
            Physical Size = 260733247
            Comment = TORRENTZIPPED-9F8E0391

               Date      Time    Attr         Size   Compressed  Name
            ------------------- ----- ------------ ------------  ------------------------
            1996-12-24 23:32:00 .....     84175728     69019477  Doom (USA) (Track 1).bin
            1996-12-24 23:32:00 .....     33737088     31332352  Doom (USA) (Track 2).bin
            1996-12-24 23:32:00 .....     20801088     19163186  Doom (USA) (Track 3).bin
            1996-12-24 23:32:00 .....     41992608     38498123  Doom (USA) (Track 4).bin
            1996-12-24 23:32:00 .....     36717072     34627868  Doom (USA) (Track 5).bin
            1996-12-24 23:32:00 .....     22936704     21946175  Doom (USA) (Track 6).bin
            1996-12-24 23:32:00 .....      9847824      8577248  Doom (USA) (Track 7).bin
            1996-12-24 23:32:00 .....     40560240     37567531  Doom (USA) (Track 8).bin
            1996-12-24 23:32:00 .....          814          147  Doom (USA).cue
            ------------------- ----- ------------ ------------  ------------------------
            1996-12-24 23:32:00          290769166    260732107  9 files

            c:\LaunchBox\ThirdParty\7-Zip>
            --------
            */

            if (exitCode == 0)
            {
                // Split on the "----" dividers (see above). There will then be three sections, the header info, the files, and the summary.
                string[] stdoutArray = stdout.Split(new string[] { "------------------- ----- ------------ ------------  ------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                if (stdoutArray.Length > 2)
                {
                    // Split the files on "\r\n", so we have an array with one element per filename + info
                    fileList = stdoutArray[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < fileList.Length; i++)
                    {
                        // Split the string at the 53rd char, after the date/time/attr/size/compressed info.
                        fileList[i] = fileList[i].Substring(53).Trim();
                    }
                }
            }
            else
            {
                Logger.Log(string.Format("Error listing archive {0}.", archivePath));
                Environment.ExitCode = exitCode;
            }

            return fileList;
        }

        public override (string[], long[]) ListWithSize(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            // Run List command
            // Parse stdout for all "Path = " entries
            // Return -1 on error
            string[] fileList = Array.Empty<string>();
            long[] sizeList = Array.Empty<long>();

            var (stdout, _, exitCode) = ListArchiveDetails(archivePath, includeList, excludeList, prefixWildcard);

            /*
            stdout will be in the format below:
            --------
            c:\LaunchBox\ThirdParty\7-Zip>7z l "c:\Emulation\ROMs\Doom (USA).zip"

            7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21

            Scanning the drive for archives:
            1 file, 260733247 bytes (249 MiB)

            Listing archive: c:\Emulation\ROMs\Doom (USA).zip

            --
            Path = c:\Emulation\ROMs\Doom (USA).zip
            Type = zip
            Physical Size = 260733247
            Comment = TORRENTZIPPED-9F8E0391

               Date      Time    Attr         Size   Compressed  Name
            ------------------- ----- ------------ ------------  ------------------------
            1996-12-24 23:32:00 .....     84175728     69019477  Doom (USA) (Track 1).bin
            1996-12-24 23:32:00 .....     33737088     31332352  Doom (USA) (Track 2).bin
            1996-12-24 23:32:00 .....     20801088     19163186  Doom (USA) (Track 3).bin
            1996-12-24 23:32:00 .....     41992608     38498123  Doom (USA) (Track 4).bin
            1996-12-24 23:32:00 .....     36717072     34627868  Doom (USA) (Track 5).bin
            1996-12-24 23:32:00 .....     22936704     21946175  Doom (USA) (Track 6).bin
            1996-12-24 23:32:00 .....      9847824      8577248  Doom (USA) (Track 7).bin
            1996-12-24 23:32:00 .....     40560240     37567531  Doom (USA) (Track 8).bin
            1996-12-24 23:32:00 .....          814          147  Doom (USA).cue
            ------------------- ----- ------------ ------------  ------------------------
            1996-12-24 23:32:00          290769166    260732107  9 files

            c:\LaunchBox\ThirdParty\7-Zip>
            --------
            */

            if (exitCode == 0)
            {
                // Split on the "----" dividers (see above). There will then be three sections, the header info, the files, and the summary.
                string[] stdoutArray = stdout.Split(new string[] { "------------------- ----- ------------ ------------  ------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                if (stdoutArray.Length > 2)
                {
                    // Split the files on "\r\n", so we have an array with one element per filename + info
                    fileList = stdoutArray[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    sizeList = new long[fileList.Length];
                    for (int i = 0; i < fileList.Length; i++)
                    {
                        // Split the string at the 53rd char, after the date/time/attr/size/compressed info.
                        //
                        string sizestr = fileList[i].Substring(25).Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                        long sizelong = 0;
                        bool is_numeric = long.TryParse(sizestr, out sizelong);
                        if (is_numeric) sizeList[i] = sizelong;
                        else sizeList[i] = 0;
                        fileList[i] = fileList[i].Substring(53).Trim();
                    }
                }
            }
            else
            {
                Logger.Log(string.Format("Error listing archive {0}.", archivePath));
            }

            return (fileList, sizeList);

        }

        public static string Get7zVersion()
        {
            var (stdout, _, _) = Run7z("");
            return stdout.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
        }

        public static bool SupportedType(string archivePath)
        {
            return PathUtils.HasExtension(archivePath, new string[] { ".zip", ".7z", ".rar", ".gz", ".gzip" });
        }

        /// <summary>
        /// Run the 7z list command on the specified archive.
        /// </summary>
        /// <param name="archivePath"></param>
        /// <returns>Tuple of (stdout, stderr, exitCode).</returns>
        private (string, string, int) ListArchiveDetails(string archivePath, string[] includeList = null, string[] excludeList = null, bool prefixWildcard = false)
        {
            // l = list
            // {0} = archive path
            string args = string.Format("l \"{0}\" {1}", archivePath, GetIncludeExcludeArgs(includeList, excludeList, prefixWildcard));

            return Run7z(args);
        }

        private string GetIncludeExcludeArgs(string[] includeList, string[] excludeList, bool prefixWildcard)
        {
            string includeExcludeArgs = string.Empty;
            // -i!"<wildcard>" = include files which match wildcard
            // -x!"<wildcard>" = exclude files which match wildcard
            // -r = recursive search for files
            if (includeList != null && includeList.Count() > 0)
            {
                foreach (var include in includeList)
                {
                    includeExcludeArgs = string.Format("{0} \"-i!{1}{2}\"", includeExcludeArgs, prefixWildcard ? "*" : "", include);
                }
            }

            if (excludeList != null && excludeList.Count() > 0)
            {
                foreach (var exclude in excludeList)
                {
                    includeExcludeArgs = string.Format("{0} \"-x!{1}{2}\"", includeExcludeArgs, prefixWildcard ? "*" : "", exclude);
                }
            }

            if (!string.IsNullOrEmpty(includeExcludeArgs))
            {
                includeExcludeArgs += " -r";
            }

            return includeExcludeArgs.Trim();
        }

        /// <summary>
        /// Run the desired 7z command.
        /// </summary>
        /// <param name="args"></param>
        public static void Call7z(string[] args)
        {
            string[] quotedArgs = args;
            string argString;

            // Wrap any args containing spaces with double-quotes.
            for (int i = 0; i < quotedArgs.Count(); i++)
            {
                if (quotedArgs[i].Contains(" ") && !quotedArgs[i].StartsWith("\"") && !quotedArgs[i].EndsWith("\""))
                {
                    quotedArgs[i] = string.Format("\"{0}\"", quotedArgs[i]);
                }
            }

            argString = String.Join(" ", quotedArgs);

            var (stdout, stderr, exitCode) = Run7z(argString);

            // Print the results to console and set the error code for LaunchBox to deal with
            Console.Write(stdout);
            Console.Write(stderr);
            Environment.ExitCode = exitCode;
        }

        /// <summary>
        /// Run 7z with the specified arguments. Results are returned by ref.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Tuple of (stdout, stderr, exitCode).</returns>
        public static (string, string, int) Run7z(string args, bool redirectOutput = false, bool redirectError = false)
        {
            (string stdout, string stderr, int exitCode) = ProcessUtils.RunProcess(PathUtils.GetLaunchBox7zPath(), args, redirectOutput, ExtractionProgress, redirectError);

            if (exitCode != 0)
            {
                Logger.Log(string.Format("7-Zip returned exit code {0} with error output:\r\n{1}", exitCode, stderr));
                Environment.ExitCode = exitCode;
            }

            return (stdout, stderr, exitCode);
        }

        public override string GetExtractorPath()
        {
            return PathUtils.GetLaunchBox7zPath();
        }
    }
}
