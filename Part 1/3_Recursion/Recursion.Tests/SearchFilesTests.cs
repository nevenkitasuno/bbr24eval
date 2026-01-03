using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recursion.Tests
{
    public class SearchFilesTests
    {
        private string GetTestDir()
        {
            DirectoryInfo workdir = new DirectoryInfo(Directory.GetCurrentDirectory());
            return workdir.Parent.Parent.Parent + "/Ex8TestDir";
        }
        [Fact]
        public void FindAll_aka_EmptySearchQuery_Tests()
        {
            List<string> result;
            string directory = GetTestDir();

            result = RecursionFunctions.SearchFilesRecursively(directory, "");
            Assert.Contains("cat.txt", result);
            Assert.Contains("rat.png", result);
            Assert.Contains("bat.pdf", result);
            Assert.Contains("dog.dmg", result);
        }

        [Fact]
        public void PresentSearchQuery_Tests()
        {
            List<string> result;
            string directory;

            directory = GetTestDir();
            result = RecursionFunctions.SearchFilesRecursively(directory, "at.p");
            Assert.DoesNotContain("cat.txt", result);
            Assert.Contains("rat.png", result);
            Assert.Contains("bat.pdf", result);
            Assert.DoesNotContain("dog.dmg", result);
        }

        [Fact]
        public void EmptyDirTest()
        {
            List<string> result;
            string directory = GetTestDir() + "/Ex8TestSubDir1";
            Directory.CreateDirectory(directory); // Creates empty dir if not already exist

            result = RecursionFunctions.SearchFilesRecursively(directory, "at.p");
            Assert.Empty(result);

            result = RecursionFunctions.SearchFilesRecursively(directory, "");
            Assert.Empty(result);
        }

        [Fact]
        public void WrongDirTest()
        {
            List<string> result;
            string directory;

            directory = GetTestDir() + "/Algorithmmmmmmm";
            result = RecursionFunctions.SearchFilesRecursively(directory, "at.p");
            Assert.Empty(result);

            result = RecursionFunctions.SearchFilesRecursively(directory, "");
            Assert.Empty(result);
        }
    }
}