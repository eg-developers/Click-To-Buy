﻿using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface ICountryManager : IBaseManager<Country>
    {
        public Country CheckName(string name);
    }
}
