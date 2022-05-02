using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.TourIO;
using TourPlanner.DAL.Mock;

namespace TourPlanner.Test.BL
{
    public class TestTourExporter
    {

        [Test]
        public void TestExport_CreatesFile()
        {
            var exporter = new TourExporter(new UnitOfWorkMock());
            exporter.Export("TestExport.json");
            Assert.IsTrue(File.Exists("TestExport.json"));
        }
    }
}
