using LeaveManagementSystem.Application.Persistence.Contracts;
using LeaveManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
