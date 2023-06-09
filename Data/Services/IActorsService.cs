﻿using OnlineShop.Models;
using System.Threading.Tasks;

namespace OnlineShop.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        void Add(Actor actor);
        Task<Actor> Update(int id, Actor newActor);
        void Delete(Actor actor);
    }
}
