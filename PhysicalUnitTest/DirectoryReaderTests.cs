using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Physical.UnitTest
{
    [TestClass]
    public sealed class DirectoryReaderTests
    {
        private DirectoryReader reader;

        private string testFolderPath;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reader = new DirectoryReader();

            this.testFolderPath = Path.Combine(Environment.CurrentDirectory, "TestFolder");
        }

        [TestMethod]
        public void GetFilesTest_傳入路徑ONE_PIECE_QStyle_預期得到目錄下所有檔案路徑()
        {
            var path = Path.Combine(this.testFolderPath, "ONE_PIECE", "QStyle");

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "01_魯夫.jpg"),
                    Path.Combine(path, "02_索隆.jpg"),
                    Path.Combine(path, "03_騙人布.jpg"),
                    Path.Combine(path, "04_娜美.jpg"),
                    Path.Combine(path, "05_香吉士.jpg"),
                    Path.Combine(path, "06_喬巴.jpg"),
                    Path.Combine(path, "07_羅賓.jpg"),
                };

            var actual = this.reader.GetFiles(path);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetFilesTest_傳入路徑SLAM_DUNK_QStyle_搜尋模式為湘北_預期得到目錄下所有符合搜尋模式的檔案路徑()
        {
            var path = Path.Combine(this.testFolderPath, "SLAM_DUNK", "QStyle");

            var searchPattern = @"*湘北*";

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "01_湘北_櫻木.png"),
                    Path.Combine(path, "02_湘北_赤木.png"),
                    Path.Combine(path, "03_湘北_流川.png"),
                    Path.Combine(path, "04_湘北_宮城.png"),
                    Path.Combine(path, "05_湘北_三井.png"),
                };

            var actual = this.reader.GetFiles(path, searchPattern);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetFilesTest_傳入路徑ONE_PIECE_搜尋模式為星_搜尋選項為包含所有子目錄_預期得到目錄下所有符合搜尋模式的檔案路徑()
        {
            var path = Path.Combine(this.testFolderPath, "ONE_PIECE");

            var searchPattern = @"*";

            var searchOption = SearchOption.AllDirectories;

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "QStyle", "01_魯夫.jpg"),
                    Path.Combine(path, "QStyle", "02_索隆.jpg"),
                    Path.Combine(path, "QStyle", "03_騙人布.jpg"),
                    Path.Combine(path, "QStyle", "04_娜美.jpg"),
                    Path.Combine(path, "QStyle", "05_香吉士.jpg"),
                    Path.Combine(path, "QStyle", "06_喬巴.jpg"),
                    Path.Combine(path, "QStyle", "07_羅賓.jpg"),
                    Path.Combine(path, "Wallpaper", "01.jpg"),
                    Path.Combine(path, "Wallpaper", "02.jpg"),
                    Path.Combine(path, "Wallpaper", "03.jpg"),
                    Path.Combine(path, "Wallpaper", "04.jpg"),
                };

            var actual = this.reader.GetFiles(path, searchPattern, searchOption);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetFilesTest_傳入路徑TestFolder_搜尋模式為png_搜尋選項為包含所有子目錄_預期得到目錄下所有符合搜尋模式的檔案路徑()
        {
            var path = this.testFolderPath;

            var searchPattern = @"*.png";

            var searchOption = SearchOption.AllDirectories;

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "01_湘北_櫻木.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "02_湘北_赤木.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "03_湘北_流川.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "04_湘北_宮城.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "05_湘北_三井.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "06_陵南_魚住.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "07_陵南_仙道.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "08_陵南_福田.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "09_翔陽_花形.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "10_翔陽_藤真.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "11_海南_清田.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "12_海南_牧.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "13_海南_神.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "14_豐玉_岸本.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "15_豐玉_南.png"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle", "16_山王_澤北.png"),
                };

            var actual = this.reader.GetFiles(path, searchPattern, searchOption);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetDirectoriesTest_傳入路徑ONE_PIECE_預期得到目錄下所有目錄路徑()
        {
            var path = Path.Combine(this.testFolderPath, "ONE_PIECE");

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "QStyle"),
                    Path.Combine(path, "Wallpaper"),
                };

            var actual = this.reader.GetDirectories(path);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetDirectoriesTest_傳入路徑ONE_PIECE_搜尋模式為QStyle_預期得到目錄下所有符合搜尋模式的目錄路徑()
        {
            var path = Path.Combine(this.testFolderPath, "ONE_PIECE");

            var searchPattern = @"QStyle";

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "QStyle"),
                };

            var actual = this.reader.GetDirectories(path, searchPattern);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetDirectoriesTest_傳入路徑TestFolder_搜尋模式為QStyle_搜尋選項為包含所有子目錄_預期得到目錄下最底層目錄符合搜尋模式的目錄路徑()
        {
            var path = this.testFolderPath;

            var searchPattern = @"*QStyle*";

            var searchOption = SearchOption.AllDirectories;

            var expected =
                new List<string>()
                {
                    Path.Combine(path, "ONE_PIECE", "QStyle"),
                    Path.Combine(path, "SLAM_DUNK", "QStyle"),
                };

            var actual = this.reader.GetDirectories(path, searchPattern, searchOption);

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}