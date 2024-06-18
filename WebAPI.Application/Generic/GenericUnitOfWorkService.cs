using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Generic
{
    public class GenericUnitOfWorkService : IGenericUnitofWorkService
    {
        public IAccountService Accounts { get; }
        public IAuditService Audits { get; }
        public ICepService Ceps { get; }
        public ICityService Cities { get; }
        public IRegionService Regions { get; }
        public IStatesService States { get; }
        public IUserService Users { get; }

        public GenericUnitOfWorkService(
            IAccountService Accounts,
            IAuditService Audits,
            ICepService Ceps,
            ICityService Cities,
            IRegionService Regions,
            IStatesService States,
            IUserService Users
            )
        {
            this.Accounts = Accounts ?? throw new ArgumentNullException(nameof(Accounts));
            this.Audits = Audits ?? throw new ArgumentNullException(nameof(Audits));
            this.Ceps = Ceps ?? throw new ArgumentNullException(nameof(Ceps));
            this.Cities = Cities ?? throw new ArgumentNullException(nameof(Cities));
            this.Regions = Regions ?? throw new ArgumentNullException(nameof(Regions));
            this.States = States ?? throw new ArgumentNullException(nameof(States));
            this.Users = Users ?? throw new ArgumentNullException(nameof(Users));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}