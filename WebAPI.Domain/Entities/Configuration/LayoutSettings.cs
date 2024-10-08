﻿using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class LayoutSettings : GenericEntity
{
    [DisplayName("ImageFileContentToUpload")]
    public string ImageFileContentToUpload { get; set; }

    [DisplayName("DocumentFileContentToUpload")]
    public string DocumentFileContentToUpload { get; set; }

    [DisplayName("MaxImageFileSize")]
    public double MaxImageFileSize { get; set; }

    [DisplayName("MaxDocumentFileSize")]
    public double MaxDocumentFileSize { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}
