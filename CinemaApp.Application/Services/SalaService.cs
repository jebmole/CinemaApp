using AutoMapper;
using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Requests;
using CinemaApp.Application.Responses;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Interfaces;
using System.Collections.Generic;

namespace CinemaApp.Application.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _repository;
        private readonly IMapper _mapper;

        public SalaService(ISalaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void DeleteSala(int idSala)
        {
            _repository.DeleteSala(idSala);
        }

        public SalaResponse GetSalaById(int idSala)
        {
            var sala = _repository.GetSalaById(idSala);
            var salaResponse = _mapper.Map<SalaResponse>(sala);
            return salaResponse;
        }

        public IEnumerable<SalaResponse> GetSalas()
        {
            var salas = _repository.GetSalas();
            var salasResponse = _mapper.Map<IEnumerable<SalaResponse>>(salas);
            return salasResponse;
        }

        public void InsertSala(CreateSalaRequest request)
        {
            var sala = _mapper.Map<Sala>(request);
            _repository.InsertSala(sala);
        }

        public void UpdateSala(UpdateSalaRequest request)
        {
            var sala = _mapper.Map<Sala>(request);
            _repository.UpdateSala(sala);
        }
    }
}
