namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("PT 01: Overlapping item")]
        public void PT_01_Overlapping_Item()
        {
            // Arrange
            Planning planning = new Planning();
            PlanningItem planningItem = new PlanningItem();

            // Act
            planning.AddItem(planningItem);

            // Assert
            planning.Items.Should().Contain(planningItem);
        }
    }
}
