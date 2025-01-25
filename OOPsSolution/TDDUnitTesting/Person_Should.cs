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
        //the second test annotation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determind by the number [InlineData()] annotations following the [Theory]
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
        [Fact]
        public void Directly_Change_First_Name_Via_Property()
        {
            //Arrange
            string expectedFirstName = "Shirley";
            //since we are trying to use the property of an instance.
            //  one needs to have an instance in the first place.
            Person sut = new Person("Pat", "Ujest", null, null);

            //Act
            //if your code needs to sanitize the string then on your Act, you could
            //  include some leading and trailing blanks
            sut.FirstName = "   Shirley   ";

            //Assert
            sut.FirstName.Should().Be(expectedFirstName);
        }
        //directly change the Lastname via property (character string exists)
        [Fact]
        public void Directly_Change_Last_Name_Via_Property()
        {
            //Arrange
            string expectedLastName = "Ujest";
            //since we are trying to use the property of an instance.
            //  one needs to have an instance in the first place.
            Person sut = new Person("Shirley", "Downe", null, null);

            //Act
            sut.LastName = "    Ujest    ";

            //Assert
            sut.LastName.Should().Be(expectedLastName);
        }
        //directly change the Address via property (with new address, without address (null))
        //One could assume that there are 2 test values and thus think that a Theory is the annotation
        //HOWEVER: The InlineData has restriction on the type of value you can use as the test value
        //      Unfortunately, declaring an instance of an class is NOT a value type of test value
        //      Therefore, these test had to be done in 2 separate Fact tests
        [Fact]
        public void Directly_Change_Address_To_New_Address_Via_Property()
        {
            //Arrange
            Person sut = new Person("Lowan", "Behold",
                    new ResidentAddress(132, "Ash Lane", "Edmonton", "AB", "T6Y7U8"), null);
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");

            //Act
            //sut.Address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            sut.Address = expectedAddress;

           //Assert
           sut.Address.Should().Be(expectedAddress);
        }

        [Fact]
        public void Directly_Change_Address_To_Null_Via_Property()
        {
            //Arrange
            Person sut = new Person("Lowan", "Behold",
                    new ResidentAddress(132, "Ash Lane", "Edmonton", "AB", "T6Y7U8"), null);
           

            //Act
            sut.Address = null;

            //Assert
            sut.Address.Should().BeNull();
        }
        //does the full name return the name in the instance
        [Fact]
        public void Retreive_Full_Name()
        {
            //Arrange
            string expectedFullName = "Ujest, Shirley";
            //since we are trying to use the property of an instance.
            //  one needs to have an instance in the first place.
            Person sut = new Person("Shirley", "Ujest", null, null);

            //Act
            //you could retreive the full name into a local string and use
            //  the local string in the Assert
            //you could move the creation of the instance from Arrange to Act
            //  to have something in Act
            //you might not need an Act
            //string fullname = sut.FullName();

            //Assert
            //fullname.Should().Be(expectedFullName);
            sut.FullName.Should().Be(expectedFullName);  //an have no Act code
        }
        #endregion
        #region Exception Tests
        //throw ArgumentNullException if first name property is changed with missing data
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Directly_Changing_FirstName_With_Missing_Data(string testvalue)
        {
            //Arrange
            Person sut = new Person("Don", "Welch", null, null);


            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => sut.FirstName = testvalue;

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        //throw ArgumentNullException if last name property is changed with missing data
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Directly_Changing_LastName_With_Missing_Data(string testvalue)
        {
            //Arrange
            Person sut = new Person("Don", "Welch", null, null);

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () =>sut.LastName = testvalue;

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #endregion
        #region Methods
        #region Successful Tests
        //can add a new employment instance to collection
        [Fact]
        public void Add_New_Employment_To_Collection()
        {
            //Arrange
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                               DateTime.Parse("2013/10/04"), 6.5);
            TimeSpan days = DateTime.Today - DateTime.Parse("2020/04/04");
            double years = Math.Round(days.Days / 365.2, 1);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2020/04/04"), years);
            List<Employment> employments = new(); 
            employments.Add(one);  
            employments.Add(two);
            Person sut = new Person("Don", "Welch", null, employments);

            //build expect new employment
            Employment three = new Employment("SUP I", SupervisoryLevel.Supervisor,
                               DateTime.Today);

            //reuse the current collection and add the new expected employment
            //employments.Add(three);

            //another way of setting up the expected employment collect is to
            //  create a second list and add all employments to the second list
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);
            expectedEmployments.Add(three);

            int expectedEmploymentPositionCount = 3;

            //Act
            sut.AddEmployment(three);

            //Assert
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionCount);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmployments);

        }
        //can change the full name of the person
        [Fact]
        public void Change_FullName_At_Once()
        {
            //Arrange
            Person sut = new Person("Don", "Welch", null, null);
            string expectedFullName = "Kase, Charity";
            //Act
            sut.ChangeFullName("Charity", "Kase");

            //Assert
            sut.FullName.Should().Be(expectedFullName);
        }
        #endregion
        #region Exception Tests
        //adding a new employment : missing data
        //adding a new employment : data already present
        //change a person fullname : missing data
        #endregion
        #endregion

    }
}