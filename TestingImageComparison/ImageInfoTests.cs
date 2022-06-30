using NUnit.Framework;
using SimpleImageComparisonClassLibrary;
using System;
using System.Diagnostics;
using System.IO;

namespace TestingImageComparison
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindSimilarImages()
        {
            //arrange
            var testImageDirectory = Path.Combine( Directory.GetCurrentDirectory(), "TestImages");
            var whiteImagePath = Path.Combine(testImageDirectory, "White.png");

            //act
            var similarToWhite =  DuplicateImageFinder.FindSimilarImages(whiteImagePath, testImageDirectory, true, 0, 20);
            var halfOfImageDifferent = DuplicateImageFinder.FindSimilarImages(whiteImagePath, testImageDirectory, true, .50f, 0);

            //assert
            Assert.AreEqual(1, similarToWhite.Count);
            Assert.AreEqual(1, halfOfImageDifferent.Count);
        }

        [Test]

        public void TestStreamConstructor()
        {
	        //arrange
	        var testImageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestImages");
	        var whiteImagePath = Path.Combine(testImageDirectory, "White.png");
            using var whiteImageStream1 = new FileStream(whiteImagePath, FileMode.Open, FileAccess.Read);
            using var whiteImageStream2 = new FileStream(whiteImagePath, FileMode.Open, FileAccess.Read);

            //act
            var imageInfo = new ImageInfo(whiteImageStream2);
	        
            //assert
            Assert.AreEqual(16, imageInfo.GrayValues.GetLength(0));
            Assert.AreEqual(16, imageInfo.GrayValues.GetLength(1));
        }
    }
}