using Microsoft.EntityFrameworkCore;

namespace WebAPI.InfraStructure.Data.Generic;

public abstract class GenericSeed
{
    public abstract void Execute(ModelBuilder context);
}