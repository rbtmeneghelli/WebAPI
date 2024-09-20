using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class LogSettings : GenericEntity
{
    public bool SaveLogTurnOnSystem { get; set; }
    public bool SaveLogTurnOffSystem { get; set; }
    public bool SaveLogCreateData { get; set; }
    public bool SaveLogResearchData { get; set; }
    public bool SaveLogUpdateData { get; set; }
    public bool SaveLogDeleteData { get; set; }
}
