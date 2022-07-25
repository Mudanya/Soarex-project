using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositorymanager
    {
        IAboutUsRepository AboutUs { get; }
        IContactRepository Contact { get; }
        ICustomerFeedbackRepository CustomerFeedback { get; }
        IEnquiryRepository Enquiry { get; }
        IPrivacyPolicyRepository PrivacyPolicy { get; }
        IServicesRepository Services { get; }
        ISettingsRepository Settings { get; }
        ITermsRepository Terms { get; }
        Task SaveAsync();
    }
}
