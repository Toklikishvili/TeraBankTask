using AutoMapper;
using MediatR;
using TeraBankTask.Aplication.DTOs;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Shared;

namespace TeraBankTask.Aplication.Features.UserFeature.Command;

public class CreateUserCommand : IRequest<Result<int>>
{
    public CreateUserDTO CreateUserDTO { get; }

    public CreateUserCommand(CreateUserDTO createUserDTO)
    {
        CreateUserDTO = createUserDTO ?? throw new ArgumentNullException(nameof(createUserDTO));
    }
}

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand , Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<int>> Handle(CreateUserCommand request , CancellationToken cancellationToken)
    {
        try
        {
            var result = await _unitOfWork.UserRepository.Set(x => x.Email == request.CreateUserDTO.Email);

            if (!result.Any())
            {
                var user = _mapper.Map<User>(request.CreateUserDTO);
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return Result<int>.Success(user.Id);
            }
            return Result<int>.Warning($"Similar user email exists :  {request.CreateUserDTO.Email}");
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(ex);
        }
    }
}
