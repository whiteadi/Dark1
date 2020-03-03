using Dark1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dark1.Data
{
    public class JokeManager
    {
        RestService restService;

        public JokeManager(RestService service)
        {
            restService = service;
        }

        public Task<TheJoke> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
