using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiku.DTO.Request;
using Haiku.DTO.Response;
using Haiku.Data;

namespace Haiku.Services
{
    public class HaikusService : IHaikusService
    {
        private readonly UnitOfWork unitOfWork;
    }
}
