﻿using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsServices :EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsServices(AppDbContext context) : base(context) { }
        
    }
}
