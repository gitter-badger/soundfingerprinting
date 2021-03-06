﻿namespace SoundFingerprinting.Tests.Unit.Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    using SoundFingerprinting.Tests.Integration;
    using SoundFingerprinting.Utils;

    [TestFixture]
    public class TestRunnerUtilsTest : IntegrationWithSampleFilesTest
    {
        private readonly TestRunnerUtils testRunnerUtils = new TestRunnerUtils();

        [Test]
        public void ShouldCaptureAllAudioFilesFromFolder()
        {
            string path = Path.GetFullPath(".");

            var files = testRunnerUtils.ListFiles(path, new List<string> { "*.mp3" });

            var filenames = files.Select(Path.GetFileNameWithoutExtension).ToList();
            var unique = new HashSet<string>(filenames);
            Assert.AreEqual(1, unique.Count);
            Assert.IsTrue(unique.Contains(Path.GetFileNameWithoutExtension(PathToMp3)));
        }

        [Test]
        public void ShouldParseInts()
        {
            const string Ints = "1|2|3|4|5";

            var result = testRunnerUtils.ParseInts(Ints, '|');

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [Test]
        public void ShouldFailParsingInts()
        {
            const string Ints = "1|2|3|4|%";

            Assert.Throws<FormatException>(() => testRunnerUtils.ParseInts(Ints, '|'));
        }
    }
}
