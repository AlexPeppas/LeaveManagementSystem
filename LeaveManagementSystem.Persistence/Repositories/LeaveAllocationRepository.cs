using LeaveManagementSystem.Application.Persistence.Contracts;
using LeaveManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation> , ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
