using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Services.Graphics;

public abstract class GraphicModel
{
    public readonly string Name;
    public readonly string Description;

    protected GraphicModel(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void BuildGraphic()
    {
        throw new NotImplementedException();
    }

    public virtual void SearchData()
    {
        throw new NotImplementedException();
    }
}

public class GraphicLineModel : GraphicModel
{
    public GraphicLineModel(string name, string description) : base(name, description)
    {
    }

    public override void BuildGraphic()
    {
        throw new NotImplementedException();
    }

    public override void SearchData()
    {
        throw new NotImplementedException();
    }
}

public class GraphicBarModel : GraphicModel
{
    public GraphicBarModel(string name, string description) : base(name, description)
    {
    }

    public override void BuildGraphic()
    {
        throw new NotImplementedException();
    }

    public override void SearchData()
    {
        throw new NotImplementedException();
    }
}