using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.InterfacesRepository;

namespace WebAPI.Infra.Data.Repositories
{
    public class UnitOfWorkRepository : IGenericUnitofWorkRepository
    {
        public IAuditRepository Audits { get; }
        public ICepRepository Ceps { get; }
        public ICityRepository Cities { get; }
        public IRegionRepository Regions { get; }
        public IStatesRepository States { get; } 
        public IUserRepository Users { get; }

        public UnitOfWorkRepository(
            IAuditRepository Audits,
            ICepRepository Ceps,
            ICityRepository Cities,
            IRegionRepository Regions,
            IStatesRepository States,
            IUserRepository Users
            )
        {
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
