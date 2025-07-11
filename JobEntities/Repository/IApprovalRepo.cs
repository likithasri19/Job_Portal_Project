using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IApprovalRepo
    {
        void AddApproval(Approval approval);
        List<Approval> GetAllApprovals();
        Approval GetApprovalById(int id);
        List<Approval> GetApprovalsByApplication(int applicationId);
        List<Approval> GetPendingApprovals(int approverId);
        void UpdateApproval(Approval approval);
    }
}
