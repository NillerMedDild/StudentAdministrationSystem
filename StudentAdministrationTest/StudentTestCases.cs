using StudentAdministrationWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudentAdministrationTest
{
    public class StudentTestCases : DatabaseFixture
    {

        public StudentTestCases() : base("StudentContext")
        {
        }

        [Fact]
        public void RetrieveStudentsTest()
        {
            using (var appContext = ContextFactory.BuildContext())
            {
                // Setup
                var foo = new Student() { Name = "John Snow", Address = "Winterfell Avenue 39b" };
                var bar = new Student() { Name = "Grey Worm", Address = "Tent Park 13122" };
                appContext.Students.Add(foo);
                appContext.Students.Add(bar);
                appContext.SaveChanges();

                // Act
                var data = appContext.Students;

                // Assert
                Assert.Contains(data, e => e.Id == foo.Id);
                Assert.Contains(data, e => e.Id == bar.Id);

                // Cleanup
                appContext.Students.Remove(foo);
                appContext.Students.Remove(bar);
                appContext.SaveChanges();
            }
        }
        
    }
}
