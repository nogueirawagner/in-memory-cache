using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Controllers
{
  

  [Produces("application/json")]
  [Route("api/cache")]
  public class CacheController : Controller
  {
    protected IMemoryCache _cache;

    public CacheController(IMemoryCache cache)
    {
      _cache = cache;
    }

    // GET: api/Cache
    [HttpGet]
    [AllowAnonymous]
    [Route("GetOrCreate")]
    public IActionResult GetOrCreate()
    {
      var cacheGet = _cache.GetOrCreate("Data", entry =>
      {
        double valor = 99999;
        double i = 0;
        while (i < valor)
        {
          i++;
        }

        entry.SlidingExpiration = TimeSpan.FromDays(1);

        return Response(DateTime.Now);
      });

      var ret = new
      {
        ValorCache = cacheGet,
        DataAtual = DateTime.Now
      };

      return Response(ret);
    }

    protected new IActionResult Response(object result = null)
    {
      return Ok(new
      {
        success = true,
        data = result
      });
    }
  }
}
