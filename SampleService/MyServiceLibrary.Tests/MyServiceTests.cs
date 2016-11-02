using System;
using NUnit.Framework;
using MyServiceLibrary;
using System.Collections;

namespace MyServiceLibrary.Tests
{
    [TestFixture]
    public class MyServiceTests
    {
        private UserStorageService _service = new UserStorageService(UserIdDefaultGenerator.DefaultIdGenerator);

        [Test]
        public void Add_NullUser_ArgumentNullExceptionThrown()
        {
            Assert.Throws<ArgumentNullException>(() => _service.Add(null), "User is null");
        }


        //[Test]
        //public void Add_UserFirstNameIsNull_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = null,
        //        LastName = "Smith",
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's firstname is null");
        //}

        //[Test]
        //public void Add_UserFirstNameIsEmpty_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = "",
        //        LastName = "Smith",
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's firstname is empty");
        //}

        //[Test]
        //public void Add_UserLastNameIsNull_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = "Adam",
        //        LastName = null,
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's lastname is null");
        //}

        //[Test]
        //public void Add_UserLastNameIsEmpty_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = "Adam",
        //        LastName = "",
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's lastname is empty");
        //}

        //[Test]
        //public void Add_UserFirstAndLastNameIsNull_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = null,
        //        LastName = null,
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's first and lastname is null");
        //}

        //[Test]
        //public void Add_UserFirstAndLastNameIsEmpty_ExceptionThrown()
        //{
        //    var user = new User
        //    {
        //        FirstName = "",
        //        LastName = "",
        //        DateOfBirth = new DateTime(1990, 11, 5)
        //    };

        //    Assert.Throws<UserFirstOrLastNameIsNullOrEmptyException>(() => _service.Add(user), "User's first and lastname is empty");
        //}



        [Test, TestCaseSource(typeof(MyServiceTests), nameof(GetUsersForTestCases))]
        public void Add_InvalidPropertiesUser_UserCreateExceptionThrown(User user)
        {
            Assert.Throws<UserCreateException>(() => _service.Add(user), "User's first or last name is null or empty");
        }

        public static IEnumerable GetUsersForTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        FirstName = null,
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1990, 11, 5)
                    });

                yield return new TestCaseData(
                    new User
                    {
                        Id = 2,
                        LastName = "KKKk",
                        DateOfBirth = DateTime.Now
                    });

                yield return new TestCaseData(
                   new User
                   {
                       Id = 2,
                       LastName = "KKKk",
                       FirstName = "SSS0"
                   });
            }
        }
    }
}
