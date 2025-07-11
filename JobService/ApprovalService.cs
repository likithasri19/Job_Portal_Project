using JobRepository.Model;
using JobRepository.Repository;
using JobService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService
{
    public class ApprovalService : IApprovalService
    {
        private readonly IApprovalRepo _approvalRepo;

        public ApprovalService(IApprovalRepo approvalRepo)
        {
            _approvalRepo = approvalRepo;
        }

        public void CreateApproval(int applicationId, int approverId, int level)
        {
            var approval = new Approval
            {
                ApplicationID = applicationId,
                ApproverID = approverId,
                ApprovalLevel = level,
                Status = false,
                Date = DateTime.Now
            };
            _approvalRepo.AddApproval(approval);
        }

        public void ApproveApplication(int approvalId, string comments)
        {
            var approval = _approvalRepo.GetApprovalById(approvalId);
            if (approval != null)
            {
                approval.Status = true;
                approval.Comments = comments;
                approval.Date = DateTime.Now;
                _approvalRepo.UpdateApproval(approval);
            }
        }

        public void RejectApplication(int approvalId, string comments)
        {
            var approval = _approvalRepo.GetApprovalById(approvalId);
            if (approval != null)
            {
                approval.Status = false;
                approval.Comments = comments;
                approval.Date = DateTime.Now;
                _approvalRepo.UpdateApproval(approval);
            }
        }

        public List<Approval> GetPendingApprovals(int approverId)
        {
            return _approvalRepo.GetPendingApprovals(approverId);
        }

        public List<Approval> GetApplicationApprovals(int applicationId)
        {
            return _approvalRepo.GetApprovalsByApplication(applicationId);
        }

        public bool IsApplicationFullyApproved(int applicationId)
        {
            var approvals = _approvalRepo.GetApprovalsByApplication(applicationId);
            return approvals.All(a => a.Status);
        }
    }
}
