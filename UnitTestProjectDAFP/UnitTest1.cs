using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.ContentModel;
using DAF_Project;

namespace UnitTestProjectDAFP
{
    [TestClass]
    public class GoodsAllocationTests
    {
        [TestMethod]
        public void AllocateGoods_ValidQuantity_Success()
        {
            // Arrange
            var disasterId = 1;
            var goodsId = 1;
            var quantityAvailable = 10;
            var quantityToAllocate = 5;

            // Mock dependencies
            var mockRepo = new Mock<IGoodsRepository>();
            mockRepo.Setup(r => r.GetAvailableQuantity(disasterId, goodsId)).Returns(quantityAvailable);

            // Instantiate service with mocks
            var allocationService = new GoodsAllocationService(mockRepo.Object);

            // Act
            var allocationResult = allocationService.AllocateGoods(disasterId, goodsId, quantityToAllocate);

            // Assert
            Assert.True(allocationResult.IsSuccess);
            Assert.Equal(quantityToAllocate, allocationResult.QuantityAllocated);
        }

        [TestMethod]
        public void AllocateGoods_ExceedsAvailableQuantity_Failure()
        {
            // Arrange
            var disasterId = 1;
            var goodsId = 1;
            var quantityAvailable = 10;
            var quantityToAllocate = 15;

            // Mock dependencies
            var mockRepo = new Mock<IGoodsRepository>();
            mockRepo.Setup(r => r.GetAvailableQuantity(disasterId, goodsId)).Returns(quantityAvailable);

            // Instantiate service with mocks
            var allocationService = new GoodsAllocationService(mockRepo.Object);

            // Act
            var allocationResult = allocationService.AllocateGoods(disasterId, goodsId, quantityToAllocate);

            // Assert
            Assert.False(allocationResult.IsSuccess);
            Assert.Equal("Quantity requested exceeds available goods.", allocationResult.ErrorMessage);
        }

        [TestMethod]
        public void AllocateGoods_InvalidIds_Failure()
        {
            // Arrange
            var disasterId = 0;
            var goodsId = 0;
            var quantityToAllocate = 5;

            // Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GoodsAllocationService().AllocateGoods(disasterId, goodsId, quantityToAllocate));
        }
    }
}