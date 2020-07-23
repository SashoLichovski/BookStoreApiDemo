using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        UserApplication GetByApiKey(string apiKey);
    }
}
