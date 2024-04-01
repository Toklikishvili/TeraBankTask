using AutoMapper;
using MediatR;
using TeraBankTask.Aplication.DTOs;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Shared;

namespace TeraBankTask.Aplication.Features.TransactionFeature.Command;

public class CreateTransactionCommand : IRequest<Result<int>>
{
    public CreateTransactionDTO CreateTransactionDTO { get; }

    public CreateTransactionCommand(CreateTransactionDTO createTransactionDTO)
    {
        CreateTransactionDTO = createTransactionDTO ?? throw new ArgumentNullException(nameof(createTransactionDTO));
    }
}

internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand , Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<int>> Handle(CreateTransactionCommand request , CancellationToken cancellationToken)
    {
        try
        {
            var resultSender = await _unitOfWork.UserRepository.GetByIdAsync(request.CreateTransactionDTO.SenderUserId);

            var resultReceiver = await _unitOfWork.UserRepository.GetByIdAsync(request.CreateTransactionDTO.ReceiverUserId);

            if (resultSender == null || resultSender.IsDeleted==true)
                return Result<int>.Warning($"User with SenderUserId {request.CreateTransactionDTO.SenderUserId} not found");
            else if (resultReceiver == null || resultReceiver.IsDeleted == true)
                return Result<int>.Warning($"User with ReceiverUserId {request.CreateTransactionDTO.ReceiverUserId} not found");

            var transaction = _mapper.Map<Transaction>(request.CreateTransactionDTO);
            transaction.CreateDate= DateTime.Now;

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(transaction.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(ex);
        }
    }
}
