using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Repository;

namespace UploadImages.ActionHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ApplicationAccount>
    {
        private IAccountWriter _writer;

        public CreateAccountHandler(IAccountWriter writer)
        {
            _writer = writer;
        }
        public Task<ApplicationAccount> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return _writer.Create(new ApplicationAccount
            {
                name = request.Name
            });
        }
    }
}
