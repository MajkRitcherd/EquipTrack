using EquipTrack.Application.DTOs;
using FluentValidation;

namespace EquipTrack.Application.Validators
{
    /// <summary>
    /// Defines the validation rules for incoming <see cref="CreateDeviceRequest"/> payloads.
    /// </summary>
    /// <remarks>
    /// Enforces mandatory fields, maximum string lengths to match database constraings,
    /// and ensures that numerical hardware specifications are valid (greater than zero) if provided.
    /// </remarks>
    public class CreateDeviceRequestValidator : AbstractValidator<CreateDeviceRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDeviceRequestValidator"/> class
        /// and configures the validation rules.
        /// </summary>
        public CreateDeviceRequestValidator()
        {
            RuleFor(device => device.ManufacturerName)
                .NotEmpty().WithMessage("Manufacturer name is mandatory")
                .MaximumLength(50).WithMessage("Manufacturer name can have maximum of 50 characters");

            RuleFor(device => device.ModelName)
                .NotEmpty().WithMessage("Model name is mandatory")
                .MaximumLength(50).WithMessage("Model name can have maximum of 50 characters");

            RuleFor(device => device.SerialNumber)
                .NotEmpty().WithMessage("Serial number is mandatory")
                .MaximumLength(100).WithMessage("Serial number can have maximum of 100 characters");

            RuleFor(device => device.Cpu)
                .MaximumLength(50).WithMessage("CPU name can have maximum of 50 characters");

            RuleFor(device => device.IntegratedGpu)
                .MaximumLength(50).WithMessage("Integrated GPU name can have maximum of 50 characters");

            RuleFor(device => device.DedicatedGpu)
                .MaximumLength(50).WithMessage("Dedicated GPU name can have maximum of 50 characters");

            RuleFor(device => device.RamStorageInGB)
                .GreaterThan(0).WithMessage("RAM storage should be at least 1 GB");

            RuleFor(device => device.StorageInGB)
                .GreaterThan(0).WithMessage("Total storage should be at least 1 GB");

            RuleFor(device => device.Cpu)
                .NotEmpty().WithMessage("CPU must be provided if any hardware info is entered")
                .When(HasAnyHardwareInfo);

            RuleFor(device => device.RamStorageInGB)
                .NotNull().WithMessage("RAM must be provided if any hardware info is entered")
                .GreaterThan(0).WithMessage("RAM storage should be at least 1 GB")
                .When(HasAnyHardwareInfo);

            RuleFor(device => device.StorageInGB)
                .NotNull().WithMessage("Total storage must be provided if any hardware info is entered")
                .GreaterThan(0).WithMessage("Total storage should be at least 1 GB")
                .When(HasAnyHardwareInfo);
        }

        /// <summary>
        /// Determines whether or not the create request has hardware information such as CPU or RAM storage or Total Storage.
        /// </summary>
        /// <param name="request">Data-Transfer Object (DTO) used to create device.</param>
        /// <returns>True, if hardware info is specified (either CPU or RAM storage or Total storage), otherwise false.</returns>
        private bool HasAnyHardwareInfo(CreateDeviceRequest request)
        {
            return !string.IsNullOrEmpty(request.Cpu)
                || request.RamStorageInGB.HasValue
                || request.StorageInGB.HasValue;
        }
    }
}