using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IApprovalService
    {
        void CreateApproval(int applicationId, int approverId, int level);
        void ApproveApplication(int approvalId, string comments);
        void RejectApplication(int approvalId, string comments);
        List<Approval> GetPendingApprovals(int approverId);
        List<Approval> GetApplicationApprovals(int applicationId);
        bool IsApplicationFullyApproved(int applicationId);
    }
}
