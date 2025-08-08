using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.User.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
