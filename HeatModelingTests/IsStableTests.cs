namespace Lab1UnitTests
{
    public class IsStableTests
    {
        #region Тесты

        [Fact]
        public void IsStable_PassCorrectParameters_GetTrue_Test()
        {
            // Arrange:
            double h = 0.01;
            double tau = 0.01;
            double alfa = 0.03;

            // Act:
            bool actual = (tau * alfa * alfa) / (h * h) < 0.125;

            // Assert:
            Assert.True(actual);
        }

        [Theory]
        [InlineData(0.01, 0.01, 0.036)]
        [InlineData(0.01, 0.1, 0.03)]
        [InlineData(0.001, 0.01, 0.036)]
        [InlineData(0.0001, 0.01, 0.036)]
        public void IsStable_PassIncorrectParameters_GetFalse_Test(double h, double tau, double alfa)
        {
            // Arrange:

            // Act:
            bool actual = (tau * alfa * alfa) / (h * h) < 0.125;

            // Assert:
            Assert.False(actual);
        }

        #endregion
    }
}
