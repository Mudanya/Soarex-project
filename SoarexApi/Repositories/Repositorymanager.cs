using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repositorymanager : IRepositorymanager
    {
        private readonly RepositoryContext _context;
        private IAboutUsRepository aboutUsRepository;
        private IContactRepository contactRepository;
        private ICustomerFeedbackRepository customerFeedbackRepository;
        private IEnquiryRepository enquiryRepository;
        private IPrivacyPolicyRepository privacyPolicyRepository;
        private IServicesRepository servicesRepository;
        private ISettingsRepository settingsRepository;
        private ITermsRepository termsRepository;
        private IKeyAreasRepository KeyAreasRepository;
        public Repositorymanager(RepositoryContext context)
        {
            _context = context;
        }
        public IAboutUsRepository AboutUs
        {
            get
            {
                if(aboutUsRepository == null)
                {
                    aboutUsRepository = new AboutUsRepository(_context);
                }
                return aboutUsRepository;
            }
        }

        public IContactRepository Contact
        {
            get
            {
                if(contactRepository == null)
                {
                    contactRepository = new ContactRepository(_context);
                }
                return contactRepository;
            }
        }

        public ICustomerFeedbackRepository CustomerFeedback
        {
            get
            {
                if(customerFeedbackRepository == null)
                {
                    customerFeedbackRepository = new CustomerFeedbackRepository(_context);
                }
                return customerFeedbackRepository;
            }
        }

        public IEnquiryRepository Enquiry
        {
            get
            {
                if(enquiryRepository == null)
                {
                    enquiryRepository = new EnquiryRepository(_context);
                }
                return enquiryRepository;
            }
        }

        public IPrivacyPolicyRepository PrivacyPolicy
        {
            get
            {
                if(privacyPolicyRepository == null)
                {
                    privacyPolicyRepository = new PrivacyPolicyRepository(_context);
                }
                return privacyPolicyRepository;
            }
        }

        public IServicesRepository Services
        {
            get
            {
                if(servicesRepository == null)
                {
                    servicesRepository = new ServicesRepository(_context);
                }
                return servicesRepository;
            }
        }

        public ISettingsRepository Settings
        {
            get
            {
                if(settingsRepository == null)
                {
                    settingsRepository = new SettingsRepository(_context);
                }
                return settingsRepository;
            }
        }

        public ITermsRepository Terms
        {
            get
            {
                if(termsRepository == null)
                {
                    termsRepository = new TermsRepository(_context);
                }
                return termsRepository;
            }
        }

        public IKeyAreasRepository KeyAreas
        {
            get
            {
                if(KeyAreasRepository== null)
                {
                    KeyAreasRepository = new KeyAreasRepository(_context);
                }
                return KeyAreasRepository;
            }
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
