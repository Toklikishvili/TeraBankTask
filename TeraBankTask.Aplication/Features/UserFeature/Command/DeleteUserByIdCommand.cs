using MediatR;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Shared;

namespace TeraBankTask.Aplication.Features.UserFeature.Command;

public class DeleteUserByIdCommand : IRequest<Result<Unit>>
{
    public int UserId { get; set; }

    public DeleteUserByIdCommand(int userId)
    {
        UserId = userId;
    }
}

internal class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand , Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result<Unit>> Handle(DeleteUserByIdCommand request , CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return Result<Unit>.Failure($"User with UserID {request.UserId} not found ");

            user.IsDelete = true;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return Result<Unit>.Success("User deleted successfully");
        }
        catch (Exception ex)
        {
            return Result<Unit>.Failure(ex);
        }
    }
}
