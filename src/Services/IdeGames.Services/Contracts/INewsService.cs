using IdeGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Services.Models.Models.News;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Services.Contracts
{
    public interface INewsService
    {
        NewsDetailsViewModel GetNewsById(int id);
    }
}