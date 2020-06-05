﻿using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}