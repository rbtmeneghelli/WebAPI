﻿using WebAPI.Application.Services.Graphics;

namespace WebAPI.Application.Interfaces;

public interface IBaseGraphicService<TGraphic> : IDisposable where TGraphic : class
{
    void BuildGraphic(TGraphic graphic);
    void CalculateGraphic(TGraphic graphic);
}


public interface IGraphicLineService : IBaseGraphicService<GraphicLineModel> 
{
}

public interface IGraphicBarService : IBaseGraphicService<GraphicBarModel>
{
}