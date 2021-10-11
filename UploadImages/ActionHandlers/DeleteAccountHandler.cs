using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.Repository;

namespace UploadImages.ActionHandlers
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, bool>
    {
        private IAccountWriter _writer;

        public DeleteAccountHandler(IAccountWriter writer)
        {
            _writer = writer;
        }
        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            return await _writer.Delete(request.Id);
        }
    }
}
