using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infra.Generic;

public abstract class GenericSeed
{
    public abstract void Execute(ModelBuilder context);
}