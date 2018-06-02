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

    [HttpGet]
    [AllowAnonymous]
    [Route("TryGetValue")]
    public IActionResult TryGetValue()
    {
      DateTime data;

      if (!_cache.TryGetValue("Data", out data))
      {
        data = DateTime.Now;

        int valor = 9999;
        int i = 0;
        while (i < valor)
          i++;

        var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromDays(1)); // Mantém no cache por este tempo, redefina o tempo se for acessado.

        _cache.Set("Data", data, cacheEntryOptions);
      }

      var ret = new
      {
        ValorCache = data,
        DataAtual = DateTime.Now
      };
      return Response(ret);
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("GetOrCreate")]
    public IActionResult GetOrCreate()
    {
      var cacheGet = _cache.GetOrCreate("Data", entry =>
      {
        double valor = 9999;
        double i = 0;
        while (i < valor)
          i++;

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

    [HttpGet]
    [AllowAnonymous]
    [Route("GetOrCreateAsync")]
    public Task<IActionResult> GetOrCreateAsync()
    {
      var cacheGet = _cache.GetOrCreateAsync("Data", entry =>
      {
        double valor = 9999;
        double i = 0;
        while (i < valor)
          i++;

        entry.SlidingExpiration = TimeSpan.FromDays(1);
        return Task.FromResult(Response(DateTime.Now));
      });

      var ret = new
      {
        ValorCache = cacheGet,
        DataAtual = DateTime.Now
      };

      return Task.FromResult(Response(ret));
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
