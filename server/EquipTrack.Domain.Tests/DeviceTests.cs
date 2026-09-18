namespace EquipTrack.Domain.Tests
{
    public class DeviceTests
    {
        [Fact]
        public void AssignToUser_WhenDeviceIsInStock_ShouldAssignUserAndChangeState()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Lenovo",
                ModelName = "ThinkPad",
                SerialNumber = "12345"
                // Default state = InStock, UserId = null
            };
            int newUserId = 42;

            // Act
            device.AssignToUser(newUserId);

            // Assert
            Assert.Equal(DeviceState.Assigned, device.State);
            Assert.Equal(newUserId, device.UserId);
        }

        [Fact]
        public void AssignToUser_WhenDeviceIsNotInStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Lenovo",
                ModelName = "ThinkPad",
                SerialNumber = "12345",
            };
            int userId = 42;

            device.AssignToUser(userId);

            // Act + Assert
            // - Device is already assigned and cannot be re-assigned without being returned to stock
            int newUserId = 43;
            Assert.Throws<InvalidOperationException>(() =>
            {
                device.AssignToUser(newUserId);
            });
        }

        [Fact]
        public void ReturnToStock_WhenDeviceIsAssigned_ShouldReturnToStockAndUnassignUser()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Acer",
                ModelName = "Nitro 5",
                SerialNumber = "ABCDEF"
            };
            int userId = 42;

            // Act
            device.AssignToUser(userId);
            device.ReturnToStock();

            // Assert
            Assert.Null(device.UserId);
            Assert.Equal(DeviceState.InStock, device.State);
        }

        [Fact]
        public void ReturnToStock_WhenDeviceIsInStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Acer",
                ModelName = "Nitro 5",
                SerialNumber = "ABCDEF"
            };

            // Act + Assert
            // - Created device is in stock and cannot be returned to stock
            Assert.Throws<InvalidOperationException>(device.ReturnToStock);
        }

        [Fact]
        public void SendToRepair_WhenDeviceIsAssigned_ShouldUnassignUserAndChangeState()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Acer",
                ModelName = "Nitro 5",
                SerialNumber = "ABCDEF"
            };
            int userId = 42;

            // Act
            device.AssignToUser(userId);
            device.SendToRepair();

            // Assert
            Assert.Null(device.UserId);
            Assert.Equal(DeviceState.InRepair, device.State);
        }

        [Fact]
        public void SendToRepair_WhenDeviceIsInRepair_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Acer",
                ModelName = "Nitro 5",
                SerialNumber = "ABCDEF"
            };

            device.SendToRepair();

            // Act + Assert
            Assert.Throws<InvalidOperationException>(device.SendToRepair);
        }
    }
}