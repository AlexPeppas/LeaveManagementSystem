using LeaveManagementSystem.Application.Persistence.Contracts;
using LeaveManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest> , ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
