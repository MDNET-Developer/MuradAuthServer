using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuradAuthServer.Core.Repositories;
using MuradAuthServer.Core.Service;
using MuradAuthServer.Core.UnitOfWork;
using SharedLiblary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<TDto>> AddAsync(TDto dto)
        {
            var convertEntity = _mapper.Map<TEntity>(dto);
            await _genericRepository.AddAsync(convertEntity);
            await _unitOfWork.SaveCommitAsync();
            var convertDto = _mapper.Map<TDto>(convertEntity);
            return Response<TDto>.Succsess(convertDto, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var defaultEntity = await _genericRepository.GetAllAsync();
            var convertDto = _mapper.Map<IEnumerable<TDto>>(defaultEntity);
            return Response<IEnumerable<TDto>>.Succsess(convertDto, 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var defaultEntity = await _genericRepository.GetByIdAsync(id);
            if (defaultEntity == null)
            {
                return Response<TDto>.Fail($" Id={id} olan verilən tapılmadı", 404, true);
            }
            else
            {
                var convertDto = _mapper.Map<TDto>(defaultEntity);
                return Response<TDto>.Succsess(convertDto, 200);
            }

        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var getEntityId = await _genericRepository.GetByIdAsync(id);
            if (getEntityId == null)
            {
                return Response<NoDataDto>.Fail(errorMessage: $"Id={id} olan verilən tapılmadı", statusCode: 404, isShow: true);
            }
            else
            {
                 _genericRepository.Remove(getEntityId);
                await _unitOfWork.SaveCommitAsync();
                return Response<NoDataDto>.Succsess(statusCode:204);
                //204 - no content demekdir, hec bir data olmayacaq demekdri
            }
        }

        public async Task<Response<NoDataDto>> Update(TDto dto,int id)
        {
            var getEntityId = await _genericRepository.GetByIdAsync(id);
            if (getEntityId == null)
            {
                return Response<NoDataDto>.Fail(errorMessage: $"Id={id} olan verilən tapılmadı", statusCode: 404, isShow: true);
            }
            else
            {
                var convertEntity = _mapper.Map<TEntity>(dto);
                _genericRepository.Update(convertEntity);
                await _unitOfWork.SaveCommitAsync();
                return Response<NoDataDto>.Succsess(204);//204 - no content demekdir, hec bir data olmayacaq demekdri
                //Meslehet gorulur ki, update edendens sonra geriye data dondermeyek.Ele bir basa emeliyyat icra olunsun. NoData geriye donderek
            }
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);
            var command = await list.ToListAsync();
            var convertDto = _mapper.Map<IEnumerable<TDto>>(command);
            return Response<IEnumerable<TDto>>.Succsess(convertDto, 200);
        }
    }
}
