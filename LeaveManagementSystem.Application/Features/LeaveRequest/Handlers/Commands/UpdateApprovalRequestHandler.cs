using AutoMapper;
using LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Commands;
using LeaveManagementSystem.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateApprovalRequestHandler : IRequestHandler <UpdateApprovalRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateApprovalRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateApprovalRequest request, CancellationToken cancellationToken)
        {
            var UpdateApprovalEntity = await _leaveRequestRepository.GetAsync(request.Payload.Id);
            var itemToUpdate = _mapper.Map(request.Payload, UpdateApprovalEntity);

            await _leaveRequestRepository.UpdateAsync(itemToUpdate);
            return Unit.Value;

        }
    }
}
