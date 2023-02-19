﻿using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class Tipo_TamanhoRepository : BaseRepository<Tipo_Tamanho>, ITipo_TamanhoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Tipo_TamanhoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
