using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class ApprovalRepository : IApprovalRepo
    {
        private static List<Approval> approvals = new List<Approval>();

        public void AddApproval(Approval approval)
        {
            approvals.Add(approval);
        }

        public List<Approval> GetAllApprovals() => approvals;

        public Approval GetApprovalById(int id)
        {
            return approvals.FirstOrDefault(a => a.ApprovalID == id);
        }

        public List<Approval> GetApprovalsByApplication(int applicationId)
        {
            return approvals.Where(a => a.ApplicationID == applicationId).ToList();
        }

        public List<Approval> GetPendingApprovals(int approverId)
        {
            return approvals.Where(a => a.ApproverID == approverId && a.Status == false).ToList();
        }

        public void UpdateApproval(Approval approval)
        {
            var existingApproval = GetApprovalById(approval.ApprovalID);
            if (existingApproval != null)
            {
                existingApproval.Status = approval.Status;
                existingApproval.Comments = approval.Comments;
                existingApproval.Date = approval.Date;
            }
        }
    }
}
