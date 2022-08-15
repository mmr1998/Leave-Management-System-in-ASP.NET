using AutoMapper;
using LeaveManagement.Application.Contracts.Persisence;
using LeaveManagement.Application.Profiles;
using LeaveManagement.Application.UnitTests.Mock;
using LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.DTOs.LeaveType;
using Shouldly;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _createLeaveTypeCommandHandler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _createLeaveTypeCommandHandler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Unit Test 1"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            var result = await _createLeaveTypeCommandHandler.Handle(new CreateLeaveTypeCommand() { leaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetLeaveTypeWithDetails();

            result.ShouldBeOfType<int>();

            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
            _leaveTypeDto.DefaultDays = -1;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
                ( async () =>
                    await _createLeaveTypeCommandHandler.Handle(new CreateLeaveTypeCommand() { leaveTypeDto = _leaveTypeDto}, CancellationToken.None)
                );

            var leaveTypes = await _mockRepo.Object.GetLeaveTypeWithDetails();

            leaveTypes.Count.ShouldBe(2);
            ex.ShouldNotBeNull();
        }
    }
}
