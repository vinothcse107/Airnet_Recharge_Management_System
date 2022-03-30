using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airnet_Backend.Model;

namespace Airnet_Backend.Services
{
      public interface ITokenService
      {
            public string CreateToken(User user);
      }
}