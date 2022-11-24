using Shop.Common.DTOs.Deposit;

namespace Shop.Bll.Interfaces;

public interface IDepositService
{
    Task CreateDepositAsync(CreateDepositDto deposit, string username);
}