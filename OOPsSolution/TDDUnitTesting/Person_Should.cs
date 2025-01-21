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
            int expectedEmploymentPositionCount = 0;

            //Act (this is the action that is under testing)
            //sut: subject under tesgt
            Person sut = new Person();

            //Assert (check the results of the act against expected Values)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);

        }
        #endregion
        #region Invalid Valid tests
        #endregion
        #endregion
        #region Properties
        #endregion
        #region Methods
        #endregion
        
    }
}