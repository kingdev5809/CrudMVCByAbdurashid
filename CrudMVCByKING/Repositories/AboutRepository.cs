﻿using AutoMapper;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class AboutRepository : RepositoryService<About,AboutDto, UsersDbContext>
    {
        public AboutRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
