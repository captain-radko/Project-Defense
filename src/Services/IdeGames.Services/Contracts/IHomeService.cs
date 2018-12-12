using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Services.Models.Models.Home;

namespace IdeGames.Services.Contracts
{
    public interface IHomeService
    {
        IndexViewModel GetNews();
    }
}
