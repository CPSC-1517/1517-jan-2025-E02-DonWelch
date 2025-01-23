using OOPsReview;
using FluentAssertions;

namespace TDDUnitTesting
{
    public class Person_Should
    {
        #region Constructors
        #region Valid tests
        //a Fact unit test excutes once
        //without the [Fact] annotation, the method is NOT considered a unit test
        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Default_Constructor()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            int expectedEmploymentPositionCount = 0; //the number of instances in the list

            //Act (this is the action that is under testing)
            //sut: subject under test
            Person sut = new Person();

            //Assert (check the results of the act against expected Values)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);

        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Greedy_Constructor_Without_Address_Employment()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            int expectedEmploymentPositionCount = 0; //the number of instances in the list

            //Act (this is the action that is under testing)
            //sut: subject under test
            Person sut = new Person("Don","Welch",null,null);

            //Assert (check the results of the act against expected Values)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);

        }
        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Greedy_Constructor_With_Address_Employment()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");

            //how to test a collection?
            //create individual instances of the item in the list
            //in this example those instances are objects
            //you must remember each object has a unique GUID
            //NOTE: you CANNOT reuse a single variable to hold the separate instances
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/10/04"), 6.5);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2020/04/04"));
            List<Employment> employments = new(); //int .Net core, one does not need to include
                                                  //  the datatype with declaration
                                                  //the system will recongize that the datatype
                                                  //    after new is the same as the variable datatype
            employments.Add(one);  //the index value of the first instance in the list is [0]
            employments.Add(two);
            int expectedEmploymentPositionCount = 2; //the number of instances in the list

            //Act (this is the action that is under testing)
            //sut: subject under test
            Person sut = new Person("Don", "Welch",
                new ResidentAddress(123, "Maple St.", "Edmonton", "AB", "T6Y7U8"), employments);

            //Assert (check the results of the act against expected Values)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            //before testing the actual contents of the collection, it is best
            //  to check the number of items in the collection
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
            //did the greedy constructor actually use the data I submitted
            //were the instances in the list loaded as expected, including the expected order
            //check the actual contents of the list
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(employments);
        }
        #endregion
        #region Invalid Valid tests
        //the second test anontation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determind by the number [InlineData()] anontations following the [Theory]
        //to setup the test header, you must include a parameter in a parameter list
        //  one for each value in the InlineData set of values
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Creating_Instance_Missing_FirstName(string testvalue)
        {
            //Arrange
            //for this test, no instance is expected to be created.
            //because the firstname is invalid, an exception is to be thrown
            //  thus, no instance to be created to be tested


            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(testvalue, "Welch", null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Creating_Instance_Missing_LastName(string testvalue)
        {
            //Arrange
            //for this test, no instance is expected to be created.
            //because the firstname is invalid, an exception is to be thrown
            //  thus, no instance to be created to be tested


            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person("Don", testvalue, null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #endregion
        #region Properties
        #region Successful Tests
        //directly change the firstname via property (character string exists)
        //directly change the Lastname via property (character string exists)
        //directly change the Address via property (with new address, without address (null))
        //does the full name return the name in the instance
        #endregion
        #region Exception Tests
        //throw ArgumentNullException if first name property is changed with missing data
        //throw ArgumentNullException if last name property is changed with missing data
        #endregion
        #endregion
        #region Methods
        #endregion

    }
}