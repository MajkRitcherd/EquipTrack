using EquipTrack.Application.DTOs;
using EquipTrack.Application.Mappings;
using EquipTrack.Domain;

namespace EquipTrack.Application.Tests;

public class DeviceMappingTests
{
    [Fact]
    public void ToResponseDto_DeviceWithoutHardwareInfo_ShouldReturnDTO()
    {
        // Arrange
        var device = new Device()
        {
            Id = Guid.NewGuid(),
            ManufacturerName = "Acer",
            ModelName = "Nitro 5",
            SerialNumber = "1234",
        };

        // Act
        var dto = device.ToResponseDto();

        // Assert
        Assert.NotNull(dto);

        Assert.Null(dto.UserId);
        Assert.Null(dto.Cpu);
        Assert.Null(dto.IntegratedGpu);
        Assert.Null(dto.DedicatedGpu);
        Assert.Null(dto.RamStorageInGB);
        Assert.Null(dto.StorageInGB);

        Assert.Equal("Acer Nitro 5", dto.DisplayName);
        Assert.Equal("InStock", dto.State); // Default state
    }


    [Fact]
    public void ToResponseDto_DeviceWithHardwareInfo_ShouldReturnMappedHardware()
    {
        // Arrange
        var device = new Device()
        {
            Id = Guid.NewGuid(),
            ManufacturerName = "Acer",
            ModelName = "Nitro 5",
            SerialNumber = "AN51234",
            HardwareInfo = new DeviceHardwareInfo("Ryzen 7800 X3D", null, "RTX 4050", 32, 2000),
        };

        // Act
        var dto = device.ToResponseDto();

        // Assert
        Assert.NotNull(dto);

        Assert.Equal("Acer Nitro 5", dto.DisplayName);
        Assert.Equal("InStock", dto.State); // Default state

        Assert.Equal("Ryzen 7800 X3D", dto.Cpu);
        Assert.Null(dto.IntegratedGpu);
        Assert.Equal("RTX 4050", dto.DedicatedGpu);
        Assert.Equal(32, dto.RamStorageInGB);
        Assert.Equal(2000, dto.StorageInGB);
    }
}
